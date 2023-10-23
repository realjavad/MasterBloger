using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using _01_Feactures.Domain;

namespace _01_Feactures.Infrastructure
{
    public interface IRepository<in TKey, T> where T : DomainBase<TKey>
    {
        void Create(T entity);
        List<T> GetAll();
        T Get(TKey id);
        bool Exists(Expression<Func<T,bool>> exception);
    }
}