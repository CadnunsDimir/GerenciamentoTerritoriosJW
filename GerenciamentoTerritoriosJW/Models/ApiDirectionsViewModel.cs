using GerenciamentoTerritoriosJW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoTerritoriosJW.Models
{
    public class ApiDirectionsViewModel
    {
        public class Cards
        {
            public Cards(List<int> cards)
            {
                this.CardsNumbers = cards;
            }
            public List<int> CardsNumbers { get; private set; }
        }

        public class DirectionListItem
        {
            public int DirectionId { get; set; }
            public string StreetName { get; set; }
            public string HouseNumber { get; set; }
            public static List<DirectionListItem> List (List<Direction> directions)
            {
                return directions
                    .Select(x => 
                        new DirectionListItem {
                            DirectionId = x.DirectionId,
                            StreetName = x.StreetName,
                            HouseNumber = x.HouseNumber
                        })
                    .ToList();

            }
        }

        public class DirectionCard
        {
            public List<DirectionListItem> directions { get; private set; }
            public string message { get; private set; }
            public int CardNumber { get; private set; }

            public DirectionCard(List<Direction> directions, string message)
            {
                this.directions = DirectionListItem.List(directions);
                this.message = message;
                this.CardNumber = this.directions.Count > 0 ? directions.FirstOrDefault().CardNumber : 0;
            }
        }
    }
}
