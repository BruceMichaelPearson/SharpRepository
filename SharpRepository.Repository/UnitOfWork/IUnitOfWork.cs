using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRepository.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        void AddRepository<T>() where T : class, new();
        void Add<T>(T entity) where T : class, new();
    }
}
