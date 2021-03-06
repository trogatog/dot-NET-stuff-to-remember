﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Glimpse.API.Web.Extensions;

namespace Glimpse.API.Web.Data
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private DbSet<T> DbSet { get; set; }

        public EntityFrameworkRepository(DbContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable(); ;
        }

        public IQueryable<T> GetAll(params string[] includes)
        {
            return DbSet.IncludeAll(includes);
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void SubmitChanges()
        {
            _context.SaveChanges();
        }
    }
}