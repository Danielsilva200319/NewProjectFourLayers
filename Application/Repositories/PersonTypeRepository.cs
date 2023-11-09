using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class PersonTypeRepository : GenericRepository<PersonType>, IPersonType
    {
        private readonly CampuxContext _context;

        public PersonTypeRepository(CampuxContext context) : base(context)
        {
            _context = context;
        }
    }
}