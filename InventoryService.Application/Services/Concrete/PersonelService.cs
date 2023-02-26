using AutoMapper;
using InventoryService.Application.Dtos.PersonelDtos;
using InventoryService.Application.Services.Abstract;
using InventoryService.Domain.Entities;
using InventoryService.Infrastructure.ContextDb;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Application.Services.Concrete
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
        public async Task<PersonelResponseDto> CreatePersonel(PersonelCreateDto personelDto)
        {
            var personel = _mapper.Map<Personel>(personelDto);
            var createdEntity = await _context.AddAsync(personel);
            await _context.SaveChangesAsync();
            var personelResponse = _mapper.Map<PersonelResponseDto>(createdEntity.Entity);
            return personelResponse;
        }
        public async Task<List<Guid>> UpdatePersonel(List<PersonelUpdateDto> personelDto)
        {
            var result = new List<Guid>();

            foreach (var item in personelDto)
            {
                var existingPersonel = await _context.Personels.FindAsync(item.Id);
                _mapper.Map(item, existingPersonel);
                result.Add(item.Id);
            }
            await _context.SaveChangesAsync();
            return result;
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
        public async Task<PersonelResponseDto> PersonelGetById(Guid id)
        {
            var existingId = await _context.Personels.FirstOrDefaultAsync(x => x.IsDeleted.Equals(false) && x.Id.Equals(id));
            var result = _mapper.Map<PersonelResponseDto>(existingId);
            return result;
        }
        public async Task<GetPersonelListDto> GetPersonelList(bool IsDeleted, int page = 1, int pageSize = 10)
        {
            var existingPersonel = _context.Personels.Where(x => x.IsDeleted.Equals(IsDeleted))
              .Skip((page - 1) * pageSize)
              .Take(pageSize);
            var totalRecords = await existingPersonel.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            var data = _mapper.Map<List<PersonelResponseDto>>(await existingPersonel.ToListAsync());

            return new GetPersonelListDto
            {
                Data = data,
                totalPages = totalPages,
                totalRecords = totalRecords
            };
        }
    }
}
