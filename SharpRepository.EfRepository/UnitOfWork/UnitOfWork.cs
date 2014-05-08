using SharpRepository.Repository;
using SharpRepository.Repository.UnitOfWork;
using SharpRepository.EfRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SharpRepository.EfRepository.UnitOfWork 
{
    public class UnitOfWork : UnitOfWorkBase
    {
        private DbContext BaseContext;
        private UnitOfWork()
        {
        }
        public UnitOfWork(DbContext context)
        {
            BaseContext = context;
        }

        public override void AddRepository<TEntity>()
        {
           RepositoryDictionary.Add(typeof(TEntity), new EfRepository<TEntity>(BaseContext));
        }
    }
}
