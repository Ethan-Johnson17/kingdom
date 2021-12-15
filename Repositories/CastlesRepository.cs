using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using kingdom.Models;

namespace kingdom.Repositories
{
  public class CastlesRepository
  {
    private readonly IDbConnection _db;
    public CastlesRepository(IDbConnection db)
    {
      _db = db;
    }
    internal List<Castle> GetAll()
    {
      string sql = @"
      SELECT
        castle.*,
        account.*
      FROM castles castle
      JOIN accounts account ON castle.creatorId = account.id;
      ";
      return _db.Query<Castle, Account, Castle>(sql, (castle, account) =>
      {
        castle.Creator = account;
        return castle;
      }, splitOn: "id").ToList();
    }

    internal Castle Create(Castle newCastle)
    {
      string sql = @$"
      INSERT INTO castles
      (location, armaments, population, creatorId)
      VALUES
      (@location, @armaments, @population, @creatorId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newCastle);
      newCastle.Id = id;
      return newCastle;
    }
  }
}