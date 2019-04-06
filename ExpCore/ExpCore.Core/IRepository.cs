using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpCore.Core
{
    public interface IRepository<T> where T: IEntity
    {
        IQueryable<T> GetAll();

        T FindById(string id);

        void Add(T entity);

        bool Exists(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
