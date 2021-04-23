using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PictureShare.Repository
{
    public interface IRepository<T> where T :class
    {
        T Get(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null
            );

        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null
            );

        void Add(T entity);

        void Remove(int id);

        void Remove(T entity);


    }
}
