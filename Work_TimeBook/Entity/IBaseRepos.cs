﻿using System;
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
        IQueryable<T> Where(Expression<Func<T,bool>> whereFuncExpression);

        IQueryable<T> ToOrderList<TKey>(Expression<Func<T,TKey>> whereFuncExpression);
        IEnumerable<T> ToList();
            
            T FirstOrDefault(Expression<Func<T, bool>> whereFuncExpression);
        T FindById(int? id);
       
        void Dispose();
        EntityState GetEntityState(T t);
        void Attach(T entity);
       // EFDbContext GetContext();
        bool SetModified(T entity);

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

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> whereFuncExpression)
        {
           return  _Context.Set<T>().Where(whereFuncExpression);
        }

        public IQueryable<T> ToOrderList<TKey>(Expression<Func<T, TKey>> whereFuncExpression)
        {
            return GetSet().OrderBy(whereFuncExpression);
        }

        

        public IEnumerable<T> ToList()
        {
            return GetSet().ToList();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> whereFuncExpression)
        {
            return GetSet().FirstOrDefault(whereFuncExpression);
        }

        public T FindById(int? id)
        {
            return GetSet().Find(id);
        }

        protected DbSet<T> GetSet()
        {
            return _Context.Set<T>();
        }

        protected EFDbContext GetContext()
        {
            return _Context;
        }

        public void Dispose()
        {
            GetContext().Dispose();
        }

        public EntityState GetEntityState(T t)
        {
            return _Context.Entry(t).State;
        }

        public void Attach(T entity)
        {
            GetSet().Attach(entity);
        }

        public bool SetModified(T entity)
        {
            GetContext().Entry(entity).State=EntityState.Modified;
            return true;
        }


        public  virtual int SaveChanges()
        {
            
            return _Context.SaveChanges();
        }

        //EFDbContext IBaseRepos<T>.GetContext()
        //{
        //    return _Context;
        //}
    }
}