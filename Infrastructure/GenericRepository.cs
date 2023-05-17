using Entities.Models.Common;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private ApplicationDbContext _db;
        private readonly DbSet<T> entities;
        public GenericRepository(ApplicationDbContext  db)
        {
            _db = db;
            entities = _db.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public T GetById(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Create(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException();
            }
            entities.Add(entity);
            _db.SaveChanges();    
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            entities.Remove(entity);
            _db.SaveChanges();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _db.SaveChanges();
        }
    }
}
