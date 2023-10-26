namespace NorthwindService.Application.Services.Concrete.Paging
{
    internal class Paginate<TSource, TResult> : IPaginate<TResult>
    {
        public int PageNumber { get; }
        public int Size { get; }
        public int Count { get; }
        public int Pages { get; }
        public int From { get; }
        public IList<TResult> Items { get; }
        public bool HasPrevious => PageNumber - From > 0;
        public bool HasNext => PageNumber - From + 1 < Pages;

        public Paginate(IEnumerable<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter, int pageNumber, int size, int from)
        {
            TSource[] source2 = source as TSource[] ?? source.ToArray();
            if (from > pageNumber)
            {
                throw new ArgumentException($"From: {from} > Index: {pageNumber}, must From <= Index");
            }

            IQueryable<TSource> queryable = source as IQueryable<TSource>;
            if (queryable != null)
            {
                PageNumber = pageNumber;
                Size = size;
                From = from;
                Count = queryable.Count();
                Pages = (int)Math.Ceiling(Count / (double)Size);
                TSource[] arg = queryable.Skip((PageNumber - From) * Size).Take(Size).ToArray();
                Items = new List<TResult>(converter(arg));
            }
            else
            {
                PageNumber = pageNumber;
                Size = size;
                From = from;
                Count = source2.Count();
                Pages = (int)Math.Ceiling(Count / (double)Size);
                TSource[] arg2 = source2.Skip((PageNumber - From) * Size).Take(Size).ToArray();
                Items = new List<TResult>(converter(arg2));
            }
        }

        public Paginate(IPaginate<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
        {
            PageNumber = source.PageNumber;
            Size = source.Size;
            From = source.From;
            Count = source.Count;
            Pages = source.Pages;
            Items = new List<TResult>(converter(source.Items));
        }
    }
}
