﻿namespace PeopleRegister.Domain.Interfaces;

public interface IOperationsBase<TEntity> where TEntity : class
{
    void Add(TEntity obj);
    void Update(TEntity obj);
    void Remove(TEntity obj);
    IEnumerable<TEntity> GetAll();
    TEntity GetById(int id);
}
