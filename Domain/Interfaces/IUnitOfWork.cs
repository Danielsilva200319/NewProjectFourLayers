using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICity Cities { get; }
        ICostumer Costumers { get; }
        ICountry Countries { get; }
        IPersonType PersonTypes { get; }
        IState States { get; }
        Task<int> SaveAsync();
    }
}