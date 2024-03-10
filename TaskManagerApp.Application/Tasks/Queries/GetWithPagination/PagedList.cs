using System.Collections;

namespace TaskManagerApp.Application.Tasks.Queries.GetWithPagination
{
    public class PagedList<T> : IReadOnlyList<T>
    {
        private readonly IList<T> _pagedItems;
        public PagedList(IEnumerable<T> pagedItems, int count, int pageNumber, int pageSize)
        {
            _pagedItems = pagedItems as IList<T> ?? new List<T>(pagedItems);

            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public int PageNumber { get; }
        public int TotalPages { get; }
        public int Count => _pagedItems.Count;

        public T this[int index] => _pagedItems[index];
        public IEnumerator<T> GetEnumerator() => _pagedItems.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _pagedItems.GetEnumerator();
    }
}