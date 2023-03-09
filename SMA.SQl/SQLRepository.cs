﻿using SMA.Core.Contracts;
using SMA.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA.SQl
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        AppDbContext context;
        internal DbSet<T> dbSet;

        public SQLRepository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public IQueryable<T> Collection()
        {
            return dbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(string Id)
        {
            var t = Find(Id);
            if (context.Entry(t).State == EntityState.Detached)
                dbSet.Attach(t);

            dbSet.Remove(t);
        }

        public T Find(string Id)
        {
            return dbSet.Find(Id);
        }


        public void Insert(T t)
        {
            dbSet.Add(t);
        }

        public void Update(T t)
        {
            dbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }
    }
    
}
