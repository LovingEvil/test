using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Web.Models
{
    public class PaginatedList<T>
    {
        public PaginatedList()
        {

        }
        public PaginatedList(int pageIndex, int totalPages)
        {
            this.PageIndex = pageIndex;
            this.TotalPages = totalPages;

        }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.Items = new List<T>();
            this.Items.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}