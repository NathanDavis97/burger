using System;
using System.Collections.Generic;
using burger.db;
using burger.Models;
using burger.Repositories;

namespace  burger.Services
{
    public class DrinkService
    {
      private readonly DrinkRepository _repo;

    public DrinkService(DrinkRepository repo)
    {
      _repo = repo;
    }
        public IEnumerable<Drink> Get()
    {
      return _repo.GetAll();
    }
    internal Drink GetById(int id)
    {
      Drink drink = _repo.GetById(id);
      if (drink == null)
      {
        throw new Exception("invalid Id");
      } return drink;
    }
    internal Drink Create(Drink newDrink)
    {

      return _repo.Create(newDrink);
    }
    internal Drink Edit(Drink updated)
    {
      Drink original = GetById(updated.Id);

      original.Name = updated.Name != null ? updated.Name : original.Name;
            original.Description = updated.Description != null ? updated.Description : original.Description;
      original.Price = updated.Price > 0 ? updated.Price : original.Price;

      return _repo.Edit(original);
;
    }
    internal Drink Delete(int id)
    {

      Drink drink = GetById(id);
      _repo.Delete(drink);
      return drink;
    }

    }
}