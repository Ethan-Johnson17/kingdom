using System;
using System.Collections.Generic;
using kingdom.Models;
using kingdom.Repositories;

namespace kingdom.Services
{
  public class CastlesService
  {
    private readonly CastlesRepository _repo;
    public CastlesService(CastlesRepository repo)
    {
      _repo = repo;
    }
    internal List<Castle> Get()
    {
      return _repo.GetAll();
    }

    internal Castle Create(Castle newCastle)
    {
      _repo.Create(newCastle);
      return newCastle;
    }
  }
}