using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VehicleWebApp.Service.Repositories.Common
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
