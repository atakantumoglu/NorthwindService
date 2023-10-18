namespace NorthwindService.Application.Services.Concrete.Paging
{
    public static class PaginateExtensions
    {
        public static IPaginate<T> ToPaginate<T>(this IEnumerable<T> source, int pageNumber, int size, int from = 0)
        {
            return new Paginate<T>(source, pageNumber, size, from);
        }
    }
}
