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
            var entity = DataSet.FirstOrDefault(item => item.DirectionId == direction.DirectionId);

            // Validate entity is not null
            if (entity != null)
            {
                entity.CardNumber = direction.CardNumber;
                entity.City = direction.City;
                entity.HouseNumber = direction.HouseNumber;
                entity.Neighborhood = direction.Neighborhood;
                entity.PostalCode = direction.PostalCode;
                entity.State = direction.State;
                entity.StreetName = direction.StreetName;

                DataSet.Update(entity);
                Db.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            return DataSet.Any(x => x.DirectionId == id);
        }
    }
}
