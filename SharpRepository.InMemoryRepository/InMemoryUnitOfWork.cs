using SharpRepository.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRepository.InMemoryRepository.UnitOfWork
{
    public class UnitOfWork : UnitOfWorkBase
    {
        public UnitOfWork()
        {
        }
        public override void AddRepository<TEntity>()
        {
            RepositoryDictionary.Add(typeof(TEntity), new InMemoryRepository<TEntity>());
        }
    }
}
