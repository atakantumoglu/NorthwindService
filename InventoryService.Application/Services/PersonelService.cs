using AutoMapper;
using InventoryService.Application.Dtos.PersonelDtos;
using InventoryService.Domain.Entities;
using InventoryService.Infrastructure.ContextDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Application.Services
{
    public class PersonelService : IPersonelService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PersonelService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult> GetList(bool IsDeleted, int page = 1, int pageSize = 10)
        {

            var existingPersonel = _context.Personels.Where(x => x.IsDeleted.Equals(IsDeleted))
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var totalRecords = await existingPersonel.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            var data = _mapper.Map<List<PersonelResponseDto>>(await existingPersonel.ToListAsync());

            return new { data, totalRecords, totalPages };
        }

        public async Task<PersonelResponseDto> CreatePersonel(PersonelCreateDto personelDto)
        {
            var personel = _mapper.Map<Personel>(personelDto);

            var createdEntity = await _context.AddAsync(personel);

            await _context.SaveChangesAsync();

            var personelResponse = _mapper.Map<PersonelResponseDto>(createdEntity.Entity);

            return personelResponse;
        }

        public async Task<Personel> DeletePersonel(PersonelDeleteDto personelDto)
        {
            var existingPersonel = await _context.Personels.FindAsync(personelDto.Id);

            if (existingPersonel == null)
            {
                throw new Exception("Personel bulunamadı!");
            }

            existingPersonel.IsDeleted = true;

            await _context.SaveChangesAsync();

            return existingPersonel;
        }
    }
}
