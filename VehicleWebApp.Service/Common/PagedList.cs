using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleWebApp.Service.Common
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public bool HasNextPage
        {
            get { return (CurrentPage < TotalPages); }
        }

        public bool HasPreviousPage
        {
            get { return (CurrentPage > 1); }
        }


        public PagedList(List<T> items, int currentPage, int objectsPerPage, int totalObjects)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(totalObjects / (double)objectsPerPage);

            AddRange(items);
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int currentPage, int objectsPerPage)
        {
            var items = await source.Skip((currentPage - 1) * objectsPerPage)
                                    .Take(objectsPerPage)
                                    .ToListAsync();

            int totalObjects = source.Count();

            return new PagedList<T>(items, currentPage, objectsPerPage, totalObjects);
        }
    }
}
