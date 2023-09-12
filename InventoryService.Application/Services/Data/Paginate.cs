namespace NorthwindService.Application.Services.Data
{
    public class Paginate<T> : IPaginate<T>
    {
        public Paginate(IEnumerable<T> sources, int pageNumber, int size, int from)
        {

        }
        public Paginate(IEnumerable<T> source, Func<IEnumerable<T>, IEnumerable<T>> converter, int pageNumber, int size, int from = 0)
        {

        }
        public int From { get; set; }

        public int PageNumber { get; set; }

        public int Size { get; set; }

        public int Count { get; set; }

        public int Pages { get; set; }

        public IList<T> Items { get; set; }

        public bool HasPrevious { get; set; }

        public bool HasNext { get; set; }
    }
}
