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
        public void Add(Queue entity)
        {
            using(var ctx = new CompeerContext())
            {
                ctx.Add(entity);
                ctx.SaveChanges();
            }
        }

        public void Delete(Queue entity)
        {
            using(var ctx = new CompeerContext())
            {
                ctx.Remove(entity);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<Queue> Get()
        {
            using(var ctx = new CompeerContext())
            {
                return ctx.Queues;
            }
        }

        public IEnumerable<Queue> Get(Expression<Func<Queue, bool>> predicate)
        {
            using(var ctx = new CompeerContext())
            {
                return ctx.Queues.Where(predicate);
            }
        }

        public void Update(Queue entity)
        {
            using(var ctx = new CompeerContext())
            {
                ctx.Update(entity);
                ctx.SaveChanges();
            }
        }
    }
}