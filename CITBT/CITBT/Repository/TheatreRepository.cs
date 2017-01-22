using CITBT.Models;
using CITBT.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CITBT.Repository
{
    public class TheatreRepository : IDisposable
    {
        private ApplicationDbContext con;

        public TheatreRepository()
        {
            this.con = new ApplicationDbContext();
        }

        public Theater InsertOrUpdate(Theater entity)
        {
            this.con.Entry<Theater>(entity).State = entity.Id == Guid.Empty ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;

            return entity;
        }

        public void Remove(Theater entity)
        {
            this.con.Theatres.Remove(entity);
        }

        public IEnumerable<Theater> InsertOrUpdateAll(IEnumerable<Theater> entities)
        {
            IList<Theater> _entities = new List<Theater>();
            foreach (var entity in entities)
            {
                _entities.Add(this.InsertOrUpdate(entity));
            }
            return _entities;
        }

        public void RemoveAll(IEnumerable<Theater> entities)
        {
            this.con.Theatres.RemoveRange(entities);
        }

        public IEnumerable<Theater> GetAll
        {
            get
            {
                return this.con.Theatres.ToList();
            }
        }

        public Theater GetById(Guid id)
        {
            return this.con.Theatres.Where(t => t.Id == id).FirstOrDefault();
        }


        public void Dispose()
        {
            this.con.SaveChanges();
            this.con.Dispose();
            this.Dispose();
        }
    }
}