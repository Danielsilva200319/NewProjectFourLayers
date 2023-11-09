using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class StateRepository : GenericRepository<State>, IState
    {
        private readonly CampuxContext _context;

        public StateRepository(CampuxContext context) : base(context)
        {
            _context = context;
        }
    }
}