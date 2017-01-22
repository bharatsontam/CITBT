using CITBT.Models;
using CITBT.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace CITBT.Repository
{
    public class Repository<T> : IDisposable where T : Entity
    {
        private ApplicationDbContext con;

        public Repository()
        {
            this.con = new ApplicationDbContext();
        }

        public T InsertOrUpdate(T entity)
        {
            try
            {
                this.con.Entry<T>(entity).State = (entity.Id == Guid.Empty) ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;
                this.con.SaveChanges();
                return entity;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return entity;
            }
        }

        public void Remove(T entity)
        {
            this.con.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            this.con.SaveChanges();
        }

        public IEnumerable<T> InsertOrUpdateAll(IEnumerable<T> entities)
        {
            IList<T> _entities = new List<T>();
            foreach (var entity in entities)
            {
                _entities.Add(this.InsertOrUpdate(entity));
            }
            return _entities;
        }

        public void RemoveAll(IEnumerable<T> entities)
        {
            entities.ToList().ForEach(x => this.Remove(x));
        }

        public IEnumerable<T> GetAll
        {
            get
            {
                return this.con.Set<T>().ToList();
            }
        }

        public T GetById(Guid id)
        {
            return this.con.Set<T>().Where(t => t.Id == id).FirstOrDefault();
        }


        public void Dispose()
        {
        }
    }
}