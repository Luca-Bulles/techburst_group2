using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IHandler<T> where T: class
    {
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        T GetById(int id);


    }
}
