﻿using HadesGeneric.Data.Helper;
using InventoryService.Application.Services.Data.Abstract;
using InventoryService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Application.Services.Data.Concrete
{
    public class DeleteRepository<T> : IDeleteRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeleteRepository(DbContext context, IHttpContextAccessor httpContextAccessor)
        {
            DbContext dbContext = context ?? throw new ArgumentException("context");
            _dbSet = dbContext.Set<T>();
            _httpContextAccessor = httpContextAccessor;
        }

        public void SoftDelete(T entity)
        {
            entity.CreationTime = entity.CreationTime;
            entity.CreatorId = entity.CreatorId;
            entity.LastModificationTime = entity.LastModificationTime;
            entity.LastModifierId = entity.LastModifierId;
            entity.DeleterId = _httpContextAccessor.HttpContext!.User.Id();
            entity.DeletionTime = DateTime.Now;
            entity.IsDeleted = true;
            _dbSet.Update(entity);
        }
    }
}