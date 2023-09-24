namespace NorthwindService.Application.Dtos.CustomerDtos
{
    public sealed record CustomerGetListDto
    {
        public List<CustomerGetByIdDto> Customers { get; set; }
    }
}
