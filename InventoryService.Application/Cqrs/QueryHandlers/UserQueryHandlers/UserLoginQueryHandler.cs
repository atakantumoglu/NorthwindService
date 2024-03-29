﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NorthwindService.Application.Cqrs.Queries.UserQueries;
using NorthwindService.Application.ResponseObjects;
using NorthwindService.Application.Services.Abstract.UnitOfWork;
using NorthwindService.Domain.Entities;
using NorthwindService.Infrastructure.Data.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace NorthwindService.Application.Cqrs.QueryHandlers.UserQueryHandlers
{
    public class UserLoginQueryHandler(IUnitOfWork<ApplicationDbContext> unitOfWork, IDistributedCache distributedCache) : IRequestHandler<UserLoginQuery, ApiResponse>
    {
        public async Task<ApiResponse> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await ValidateUser(request.Email, request.Password);

            var claims = new Claim[]
            {
                 new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new(JwtRegisteredClaimNames.Aud,"NorthwindService Audience"),
                 new(JwtRegisteredClaimNames.Iss,"NorthwindService")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretkeysecretkeysecretkeysecretkey"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.Now.AddDays(300);

            var token = new JwtSecurityToken(claims: claims, expires: expireDate, signingCredentials: credentials, notBefore: DateTime.Now);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new ApiResponse()
            {
                Data = jwt,
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK
            };
        }

        public async Task<User> ValidateUser(string email, string password)
        {
            var userFromDb = await GetUserFromDatabase(email);

            // Kullanıcının giriş yaparken verdiği şifreyi, veritabanından alınan salt değeri ile hash'le.
            var hashedPassword = HashWithSalt(password, userFromDb.Salt);

            // Elde edilen hash'lenmiş değeri, veritabanındaki hash'lenmiş değerle karşılaştır.
            if (hashedPassword != userFromDb.Password)
            {
                throw new Exception("Email or password incorrect");
            }
            return userFromDb;
        }

        public async Task<User> GetUserFromDatabase(string email)
        {
            string? cachedUser = await distributedCache.GetStringAsync(email);

            User? user;

            if (string.IsNullOrEmpty(cachedUser))
            {
                user = await unitOfWork.GetReadOnlyRepositoryAsync<User>().SingleOrDefaultAsync(u => u.Email.Equals(email));
                
                if (user == null)
                {
                    throw new Exception("User cannot found");
                }

                await distributedCache.SetStringAsync(email, JsonConvert.SerializeObject(user));

                return user;
            }

            user = JsonConvert.DeserializeObject<User>(cachedUser);

            return new User
            {
                Id = user!.Id,
                Email = user.Email,
                Password = user.Password,
                Salt = user.Salt
            };

        }
        
        public string HashWithSalt(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] combinedBytes = new byte[saltBytes.Length + passwordBytes.Length];
            Buffer.BlockCopy(saltBytes, 0, combinedBytes, 0, saltBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, combinedBytes, saltBytes.Length, passwordBytes.Length);

            byte[] hashedBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashedBytes = sha256.ComputeHash(combinedBytes);
            }

            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hashedBytes)
            {
                stringBuilder.Append(b.ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
