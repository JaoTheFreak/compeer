using System.Collections.Generic;
using Compeer.Core.Interfaces;
using Compeer.Core.Entities;
using Compeer.Core.Data;
using System;
using System.Linq.Expressions;
using System.Linq;

namespace Compeer.Core.Services
{
    public class QueueService : IService<Queue>
    {
        private readonly CompeerContext _db;

        public QueueService(CompeerContext db)
        {
            _db = db;
        }

        public void Add(Queue entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Queue entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public IEnumerable<Queue> Get()
        {
            return _db.Queues;
        }

        public IEnumerable<Queue> Get(Expression<Func<Queue, bool>> predicate)
        {
            return _db.Queues.Where(predicate);
        }

        public void Update(Queue entity)
        {
            _db.Update(entity);
            _db.SaveChanges();
        }
    }
}