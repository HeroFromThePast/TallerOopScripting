using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerOopScripting.Clases;

namespace TallerOopScripting.Clases
{
    public class Deck
    {
        private List<Card> cards;

        private int totalPoints;

        public Deck(int totalPoints)
        {
            cards = new List<Card>();
            TotalPoints = totalPoints;
        }
        
        public Deck()
        {
            cards = new List<Card>();
            totalPoints = 0;
        }

        public int TotalPoints { get => totalPoints; set => totalPoints = value; }
        public List<Card> Cards { get => cards; set => cards = value; }


        public int AddCard(Card newCard)
        {
            int result = 0;

            if(totalPoints > 0 && totalPoints >= newCard.CostPoints)
            {
                cards.Add(newCard);
                totalPoints -= newCard.CostPoints;
                result = totalPoints;
                return result;
            }
            else
            {
                result = totalPoints;
            }

            return result;
            
        }
    }
}
