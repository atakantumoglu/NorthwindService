using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Application.Services.Data.Concrete.Paging
{
    public partial class Paginate<T> : IPaginate<T>
    {
        public int From { get; set; }

        public int PageNumber { get; set; }

        public int Size { get; set; }

        public int Count { get; set; }

        public int Pages { get; set; }

        public IList<T> Items { get; set; }

        public bool HasPrevious => PageNumber - From > 0;

        public bool HasNext => PageNumber - From + 1 < Pages;

        internal Paginate(IEnumerable<T> source, int pageNumber, int size, int from)
        {
            T[] source2 = (source as T[]) ?? source.ToArray();
            if (from > pageNumber)
            {
                throw new ArgumentException($"indexFrom: {from} > pageIndex: {pageNumber}, must indexFrom <= pageIndex");
            }

            IQueryable<T> queryable = source as IQueryable<T>;
            if (queryable != null)
            {
                PageNumber = pageNumber;
                Size = size;
                From = from;
                Count = queryable.Count();
                Pages = (int)Math.Ceiling((double)Count / (double)Size);
                Items = queryable.Skip((PageNumber - From) * Size).Take(Size).ToList();
            }
            else
            {
                PageNumber = pageNumber;
                Size = size;
                From = from;
                Count = source2.Count();
                Pages = (int)Math.Ceiling((double)Count / (double)Size);
                Items = source2.Skip((PageNumber - From) * Size).Take(Size).ToList();
            }
        }

        internal Paginate()
        {
            Items = new T[0];
        }
    }


}
