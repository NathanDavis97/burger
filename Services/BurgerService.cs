using System;
using System.Collections.Generic;
using burger.db;
using burger.Models;
using burger.Repositories;

namespace  burger.Services
{
    public class BurgerService
    {
      private readonly BurgerRepository _repo;

    public BurgerService(BurgerRepository repo)
    {
      _repo = repo;
    }
        public IEnumerable<Burger> Get()
    {
      return _repo.GetAll();
    }
    internal Burger GetById(int id)
    {
      Burger burger = _repo.GetById(id);
      if (burger == null)
      {
        throw new Exception("invalid Id");
      } return burger;
    }
    internal Burger Create(Burger newBurger)
    {

      return _repo.Create(newBurger);
    }
    internal Burger Edit(Burger updated)
    {
      Burger original = GetById(updated.Id);

      original.Name = updated.Name != null ? updated.Name : original.Name;
            original.Description = updated.Description != null ? updated.Description : original.Description;
      original.Price = updated.Price > 0 ? updated.Price : original.Price;

      return _repo.Edit(original);
;
    }
    internal Burger Delete(int id)
    {

      Burger burger = GetById(id);
      _repo.Delete(burger);
      return burger;
    }

    }
}