using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Application.Services.Data.Concrete.Paging
{
    public static class QueryablePaginateExtensions
    {
        public static async Task<IPaginate<T>> ToPaginateAsync<T>(this IQueryable<T> source, int pageNumber, int size, int from = 0, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (from > pageNumber)
            {
                throw new ArgumentException($"From: {from} > PageNumber: {pageNumber}, must From <= Index");
            }

            int count = await source.CountAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
            List<T> items = await source.Skip((pageNumber - from) * size).Take(size).ToListAsync(cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);
            return new Paginate<T>
            {
                PageNumber = pageNumber,
                Size = size,
                From = from,
                Count = count,
                Items = items,
                Pages = (int)Math.Ceiling((double)count / (double)size)
            };
        }
    }
}
