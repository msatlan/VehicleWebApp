using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleWebApp.Service.Common
{
    public class PagedList<T> : List<T> 
    {
        public PagedList(List<T> items, int currentPage, int objectsPerPage)
        {
            AddRange(items);
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int currentPage, int objectsPerPage)
        {
            var items = await source.Skip((currentPage - 1) * objectsPerPage)
                                    .Take(objectsPerPage)
                                    .ToListAsync();

            return new PagedList<T>(items, currentPage, objectsPerPage);
        }
    }
}
