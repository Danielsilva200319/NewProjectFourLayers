using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class CostumerRepository : GenericRepository<Costumer>, ICostumer
    {
        private readonly CampuxContext _context;

        public CostumerRepository(CampuxContext context) : base(context)
        {
            _context = context;
        }
    }
}