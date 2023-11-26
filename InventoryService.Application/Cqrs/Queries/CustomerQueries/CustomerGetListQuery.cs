using MediatR;
using NorthwindService.Application.ResponseObjects;

namespace NorthwindService.Application.Cqrs.Queries.CustomerQueries
{
    public record CustomerGetListQuery(int PageNumber, int Size, bool IsDeleted) : IRequest<ApiResponse>
    {
        public int PageNumber { get; set; } = PageNumber;
        public int Size { get; set; } = Size;
        public bool IsDeleted { get; set; } = IsDeleted;
    }
}
