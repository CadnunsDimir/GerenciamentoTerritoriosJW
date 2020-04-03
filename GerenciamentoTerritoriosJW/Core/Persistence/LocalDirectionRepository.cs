using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoTerritoriosJW.Core.Models;
using GerenciamentoTerritoriosJW.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTerritoriosJW.Core.Persistence
{
    public class LocalDirectionRepository : IDirectionRepository
    {
        public DbSet<Direction> DataSet { get; }
        public MvcTerritoriosContext Db { get; }

        public LocalDirectionRepository(MvcTerritoriosContext context)
        {
            this.DataSet = context.Directions;
            this.Db = context;
        }

        public List<int> CardList()
        {
            return this.DataSet.GroupBy(x => x.CardNumber).Select(x => x.Key).ToList();
        }

        public void Insert(Direction direction)
        {
            this.DataSet.Add(direction);
            this.Db.SaveChanges();
        }

        public List<Direction> ListCard(int cardNumber)
        {
            return this.DataSet.Where(x => x.CardNumber == cardNumber).ToList();
        }

        public void Update(Direction direction)
        {
            this.DataSet.Update(direction);
            this.Db.SaveChanges();
        }
    }
}
