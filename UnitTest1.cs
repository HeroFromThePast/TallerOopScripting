using NUnit.Framework;
using TallerOopScripting.Clases;

namespace TallerOopScripting
{
    public class Tests
    {
        [Test]
        public void AddCardToDeckTest()
        {
            Deck deck1test1 = new Deck(5);
            Card card1test1 = new Character("test1char", 3, Erarity.Rare, 3, 1, EAffinity.Knight);

            Deck deck2test1 = new Deck(3);
            Card card2test1 = new Character("test1char2", 3, Erarity.Rare, 3, 1, EAffinity.Knight);

            Deck deck3test1 = new Deck(3);
            Card card3test1 = new Character("test1char3", 5, Erarity.Rare, 3, 1, EAffinity.Knight);

            Assert.AreEqual(2, deck1test1.AddCard(card1test1));//añade con exito y resta los puntos del deck
            Assert.AreEqual(0, deck2test1.AddCard(card2test1));//añade con exito y resta los puntos del deck
            Assert.AreEqual(3, deck3test1.AddCard(card3test1));//no logra añadir la carta porque el deck no tiene puntos suficientes, se devuelve el valor de los puntos del deck
        }
        
        [Test]
        public void DestroyEquipmentTest()
        {
            Equip test2Equip1 = new Equip();
            Equip test2Equip2 = new Equip();
            Equip test2Equip3 = new Equip();

            SupportSkill testSupportSkill1 = new SupportSkill("supSkill1", 1, Erarity.Common, EEffectType.DestroyEquip, 0);

            Character dummyCharactertest2 = new Character("test2char1", 5, Erarity.Rare, 3, 1, EAffinity.Knight);
            dummyCharactertest2.Equipment.Add(test2Equip1);
            dummyCharactertest2.Equipment.Add(test2Equip2);
            dummyCharactertest2.Equipment.Add(test2Equip3);


            Assert.AreEqual(2, testSupportSkill1.UseSkill(dummyCharactertest2).Equipment.Count);
            //remueve una de los objetos de la lista de equipamento y prueba que efectivamente hay un elemento menos 
        }

        [Test]
        public void TestCharAttack()
        {
            Character dummyCharacter1test3 = new Character("test3char1", 5, Erarity.Rare, 3, 5, EAffinity.Knight);
            Character dummyCharacter2test3 = new Character("test3char2", 5, Erarity.Rare, 3, 3, EAffinity.Knight);

            Assert.AreEqual(2, dummyCharacter2test3.Attack(dummyCharacter1test3).Rp);
            Assert.AreEqual(0, dummyCharacter1test3.Attack(dummyCharacter2test3).Rp);
        }


        [Test]
        public void TestCharAffinity()
        {
            Character dummyknight1 = new Character("test3char1", 5, Erarity.Rare, 2, 6, EAffinity.Knight);
            Character dummymage1 = new Character("test3char2", 5, Erarity.Rare, 2, 6, EAffinity.Mage);

            Character dummymage2 = new Character("test3char1", 5, Erarity.Rare, 2, 6, EAffinity.Mage);
            Character dummyundead1 = new Character("test3char2", 5, Erarity.Rare, 2, 6, EAffinity.Undead);

            

            Assert.AreEqual(3, dummyknight1.Attack(dummymage1).Rp);

            Assert.AreEqual(3, dummymage2.Attack(dummyundead1).Rp);

            Assert.AreEqual(5, dummymage1.Attack(dummyknight1).Rp);

            Assert.AreEqual(5, dummyundead1.Attack(dummymage2).Rp);

        }

        [Test]
        public void TestEquipTargetAtributte()
        {
            
        }

       [Test]
        public void TestEquipAffinity()
        {

        }

        [Test]
        public void Test
    }
}