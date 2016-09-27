using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using Entity.Model;

namespace Entity
{
    public interface IBaseRepos<T> where T :class 
    {
        void AddorUpdate(T entity);
        int SaveChanges();
        void Delete(T entity);
        IEnumerable<T> Where(Expression<Func<T,bool>> whereFuncExpression);
        DbSet<T> GetSet();
        EFDbContext GetContext();
       
    }

    
            
    public class BaseRepos<T> : IBaseRepos<T> where T : class
    {
        protected EFDbContext _Context;
        
        public BaseRepos(EFDbContext context)
        {
            _Context = context;
        }

        public virtual void AddorUpdate(T entity)
        {
            
            _Context.Set<T>().AddOrUpdate(entity);
        }

        public virtual void Delete(T entity)
        {
            _Context.Set<T>().Remove(entity);
        }

        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> whereFuncExpression)
        {
           return  _Context.Set<T>().Where(whereFuncExpression);
        }

        public DbSet<T> GetSet()
        {
            return _Context.Set<T>();
        }

        public EFDbContext GetContext()
        {
            return _Context;
        }

       

        public  virtual int SaveChanges()
        {
            return _Context.SaveChanges();
        }
    }
}