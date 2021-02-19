using System;
using System.Collections.Generic;
using burger.db;
using burger.Models;
using burger.Repositories;

namespace  burger.Services
{
    public class SideService
    {
      private readonly SideRepository _repo;

    public SideService(SideRepository repo)
    {
      _repo = repo;
    }
        public IEnumerable<Side> Get()
    {
      return _repo.GetAll();
    }
    internal Side GetById(int id)
    {
      Side side = _repo.GetById(id);
      if (side == null)
      {
        throw new Exception("invalid Id");
      } return side;
    }
    internal Side Create(Side newSide)
    {

      return _repo.Create(newSide);
    }
    internal Side Edit(Side updated)
    {
      Side original = GetById(updated.Id);

      original.Name = updated.Name != null ? updated.Name : original.Name;
            original.Description = updated.Description != null ? updated.Description : original.Description;
      original.Price = updated.Price > 0 ? updated.Price : original.Price;

      return _repo.Edit(original);
;
    }
    internal Side Delete(int id)
    {

      Side side = GetById(id);
      _repo.Delete(side);
      return side;
    }

    }
}