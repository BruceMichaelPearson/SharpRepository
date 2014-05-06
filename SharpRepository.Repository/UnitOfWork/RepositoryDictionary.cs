using SharpRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRepository.Repository.UnitOfWork
{
    public class RepositoryDictionary : Dictionary<Type, object>
    {
        public void Add<T>(IRepository<T> repo) where T : class
        {
            base.Add(typeof(T), repo);
        }
    }
}
