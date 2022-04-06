using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerOopScripting.Clases
{
    public abstract class Card
    {
        protected string name;

        protected int costPoints;

        protected Erarity rarity;

        public Card(string name, int costPoints, Erarity rarity)
        {
            Name = name;
            CostPoints = costPoints;
            Rarity = rarity;
        }

        public Card()
        {
            Name = "Default";
            CostPoints=1;
            Rarity = Erarity.Common;
        }

        public string Name { get => name; set => name = value; }
        public int CostPoints { get => costPoints; set => costPoints = value; }
        public Erarity Rarity { get => rarity; set => rarity = value; }
    }
}
