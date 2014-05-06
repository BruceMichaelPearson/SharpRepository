using SharpRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRepository.Repository.UnitOfWork
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        protected RepositoryDictionary RepositoryDictionary = new RepositoryDictionary();
        public abstract void AddRepository<T>() where T : class, new();

        public void Add<T>(T entity) where T : class
        {
            object repo;
            if (!RepositoryDictionary.TryGetValue(typeof(T), out repo))
            {
                throw new InvalidOperationException("No repository of type " + typeof(T).ToString() + " found.");
            }
            ((IRepository<T>)repo).Add(entity);
        }
    }
}
