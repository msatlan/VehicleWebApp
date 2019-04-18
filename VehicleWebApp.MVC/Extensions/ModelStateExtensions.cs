using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleWebApp.MVC.Extensions
{
    public static class Bla
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            var errorMessage = dictionary.SelectMany(m => m.Value.Errors)
                                             .Select(m => m.ErrorMessage)
                                             .ToList();

            return errorMessage;
        }
    }
}
