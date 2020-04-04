using GerenciamentoTerritoriosJW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoTerritoriosJW.Core.Services
{
    public interface IDirectionRepository
    {
        List<int> CardList();
        List<Direction> ListCard(int cardNumber);
        void Insert(Direction direction);
        void Update(Direction direction);
        bool Exists(int id);
    }
}
