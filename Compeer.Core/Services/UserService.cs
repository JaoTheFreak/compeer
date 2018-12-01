using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Compeer.Core.Data;
using Compeer.Core.Entities;
using Compeer.Core.Interfaces;

namespace Compeer.Core.Services
{
    public class UserService : IService<User>
    {
        private readonly CompeerContext _db;

        public UserService(CompeerContext db)
        {
            _db = db;
        }

        public void Add(User entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
        }

        public async Task AddAsync(User entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public void Delete(User entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public IEnumerable<User> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Get(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}