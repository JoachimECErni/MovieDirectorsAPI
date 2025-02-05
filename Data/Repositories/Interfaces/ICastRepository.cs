﻿using System.Linq.Expressions;
using MovieDirectorsAPI.Data.Contracts;
using MovieDirectorsAPI.Data.Entity;

namespace MovieDirectorsAPI.Data.Repositories.Interfaces
{
    public interface ICastRepository<T>
    {
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
