using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CampuxContext _context;
        private CityRepository _cities;
        private CostumerRepository _costumers;
        private CountryRepository _countries;
        private PersonTypeRepository _personTypes;
        private StateRepository _states;
        private IRefreshToken _refreshTokens;
        private IRol _rols;
        private IUser _users;

        public UnitOfWork(CampuxContext context)
        {
            _context = context;
        }

        public ICity Cities
        {
            get
            {
                if (_cities == null)
                {
                    _cities = new CityRepository(_context);
                }
                return _cities;
            }
        }

        public ICostumer Costumers
        {
            get
            {
                if (_costumers == null)
                {
                    _costumers = new CostumerRepository(_context);
                }
                return _costumers;
            }
        }

        public ICountry Countries
        {
            get
            {
                if (_countries == null)
                {
                    _countries = new CountryRepository(_context);
                }
                return _countries;
            }
        }

        public IPersonType PersonTypes
        {
            get
            {
                if (_personTypes == null)
                {
                    _personTypes = new PersonTypeRepository(_context);
                }
                return _personTypes;
            }
        }

        public IState States
        {
            get
            {
                if (_states == null)
                {
                    _states = new StateRepository(_context);
                }
                return _states;
            }
        }
        public IRefreshToken RefreshTokens
        {
            get
            {
                if (_refreshTokens == null)
                {
                    _refreshTokens = new RefreshTokenRepository(_context); 
                }
                return _refreshTokens;
            }
        }

        public IRol Rols
        {
            get
            {
                if (_rols == null)
                {
                    _rols = new RolRepository(_context); 
                }
                return _rols;
            }
        }

        public IUser Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context); 
                }
                return _users;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}