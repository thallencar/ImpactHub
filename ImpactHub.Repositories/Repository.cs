﻿using ImpactHub.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ImpactHub.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ImpactHubDbContext _context;

        private readonly DbSet<T> _dbSet;

        public Repository(ImpactHubDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _context.Add(entity);

            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);

            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int? id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
