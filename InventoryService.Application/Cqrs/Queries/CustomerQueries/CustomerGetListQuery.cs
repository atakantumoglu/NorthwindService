using MediatR;
using NorthwindService.Application.ResponseObjects;

namespace NorthwindService.Application.Cqrs.Queries.CustomerQueries
{
    public record CustomerGetListQuery : IRequest<ApiResponse>
    {
        public CustomerGetListQuery(int pageNumber, int size, bool isDeleted)
        {
            PageNumber = pageNumber;
            Size = size;
            IsDeleted = isDeleted;
        }

        public int PageNumber { get; set; }
        public int Size { get; set; }
        public bool IsDeleted { get; set; }
    }
}
