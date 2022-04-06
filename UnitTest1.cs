using NUnit.Framework;
using TallerOopScripting.Clases;

namespace TallerOopScripting
{
    public class Tests
    {
        [Test]
        public void AddCardToDeckTest() //Se prueba que una carta se añada a un deck dependiendo si el deck si tiene los puntos para la carta y se prueba que al añadirse se le reste el valor de las cartas
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
        public void DestroyEquipmentTest() //Se prueba que la skill que remueve equipamento efectivamente lo haga 
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
        public void TestCharAttack()//Se prueba que un personaje pueda atacar a otro y se reduzcan sus rp
        {
            Character dummyCharacter1test3 = new Character("test3char1", 5, Erarity.Rare, 3, 5, EAffinity.Knight);
            Character dummyCharacter2test3 = new Character("test3char2", 5, Erarity.Rare, 3, 3, EAffinity.Knight);

            Assert.AreEqual(2, dummyCharacter2test3.Attack(dummyCharacter1test3).Rp);
            Assert.AreEqual(0, dummyCharacter1test3.Attack(dummyCharacter2test3).Rp);
        }


        [Test]
        public void TestCharAffinity() //se prueba que se aumente o se reduzcan los Ap del atacante segun su afinidad
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
        public void TestDestroyedCharacter()//Se prueba que un personaje no pueda hacer nada si sus Rp estan en 0, fue lo que se me ocurrió para decir que esta "destruido"
        {
            Character dummyCharacter1test4 = new Character("test3char1", 5, Erarity.Rare, 3, 0, EAffinity.Knight);
            Character dummyCharacter2test4 = new Character("test3char1", 5, Erarity.Rare, 3, 0, EAffinity.Knight);
            Character dummyCharacter3test4 = new Character("test3char1", 5, Erarity.Rare, 3, 0, EAffinity.Knight);

            Character Idummyknight = new Character("test3char1", 5, Erarity.Rare, 2, 6, EAffinity.Knight);
            Equip Itest4equip = new Equip("sajdnjf", 1, Erarity.Common, ETargetAtributte.AP, EEquipAffinity.Knight, 1);

            Assert.AreEqual(6, dummyCharacter1test4.Attack(Idummyknight).Rp);

            Assert.AreEqual(3, dummyCharacter2test4.EquipItem(Itest4equip).Ap);





        }

        [Test]
        public void TestEquipTargetAtributte() //se prueba que el atributo que un equipamento se supone que va afectar, efectivamente sea afectado
        {
            Equip test5equip1 = new Equip("sajdnjf", 1, Erarity.Common, ETargetAtributte.AP, EEquipAffinity.Knight, 1);
            Equip test5equip2 = new Equip("sajdnjf", 1, Erarity.Common, ETargetAtributte.RP, EEquipAffinity.Knight, 1);
            Equip test5equip3 = new Equip("sajdnjf", 1, Erarity.Common, ETargetAtributte.ALL, EEquipAffinity.Knight, 1);
            Equip test5equip4 = new Equip("sajdnjf", 1, Erarity.Common, ETargetAtributte.ALL, EEquipAffinity.Knight, 1);

            Character dummyCharacter1test5 = new Character("test2char1", 5, Erarity.Rare, 3, 1, EAffinity.Knight);
            Character dummyCharacter2test5 = new Character("test2char1", 5, Erarity.Rare, 3, 1, EAffinity.Knight);
            Character dummyCharacter3test5 = new Character("test2char1", 5, Erarity.Rare, 3, 1, EAffinity.Knight);
            Character dummyCharacter4test5 = new Character("test2char1", 5, Erarity.Rare, 3, 1, EAffinity.Knight);

            Assert.AreEqual(4, dummyCharacter1test5.EquipItem(test5equip1).Ap);
            Assert.AreEqual(2, dummyCharacter2test5.EquipItem(test5equip2).Rp);
            Assert.AreEqual(4, dummyCharacter3test5.EquipItem(test5equip3).Ap);
            Assert.AreEqual(2, dummyCharacter4test5.EquipItem(test5equip4).Rp);
        }

       [Test]
        public void TestEquipAffinity()//se prueba que un equipamento solo pueda equiparse si tiene la misma afinidad que el personaje al que se le quiere equipar, o en su defecto que sea para todos
        {
            Equip test6equip1 = new Equip("sajdnjf", 1, Erarity.Common, ETargetAtributte.RP, EEquipAffinity.Knight, 1);
            Equip test6equip2 = new Equip("sajdnjf", 1, Erarity.Common, ETargetAtributte.RP, EEquipAffinity.Mage, 1);
            Equip test6equip3 = new Equip("sajdnjf", 1, Erarity.Common, ETargetAtributte.RP, EEquipAffinity.Undead, 1);
            Equip test6equip4 = new Equip("sajdnjf", 1, Erarity.Common, ETargetAtributte.RP, EEquipAffinity.Knight, 1);

            Character dummyCharacter1test6 = new Character("test2char1", 5, Erarity.Rare, 3, 1, EAffinity.Knight);
            Character dummyCharacter2test6 = new Character("test2char1", 5, Erarity.Rare, 3, 1, EAffinity.Mage);
            Character dummyCharacter3test6 = new Character("test2char1", 5, Erarity.Rare, 3, 1, EAffinity.Undead);
            Character dummyCharacter4test6 = new Character("test2char1", 5, Erarity.Rare, 3, 1, EAffinity.Undead);

            Assert.AreEqual(2, dummyCharacter1test6.EquipItem(test6equip1).Rp);
            Assert.AreEqual(2, dummyCharacter2test6.EquipItem(test6equip2).Rp);
            Assert.AreEqual(2, dummyCharacter3test6.EquipItem(test6equip3).Rp);

            Assert.AreEqual(1, dummyCharacter4test6.EquipItem(test6equip4).Rp);

        }

        [Test]
        public void TestSupportSkillEffect() //se prueba que el atributo que se supone que afecta un skill, sea efectivamente afectado
        {
            SupportSkill supportSkill1Test7 = new SupportSkill("asfdbhjaf", 1, Erarity.Common, EEffectType.ReduceAp, 1);
            SupportSkill supportSkill2Test7 = new SupportSkill("asfdbhjaf", 1, Erarity.Common, EEffectType.ReduceRP, 1);
            SupportSkill supportSkill3Test7 = new SupportSkill("asfdbhjaf", 1, Erarity.Common, EEffectType.ReduceAll, 1);
            SupportSkill supportSkill4Test7 = new SupportSkill("asfdbhjaf", 1, Erarity.Common, EEffectType.ReduceAll, 1);
            SupportSkill supportSkill5Test7 = new SupportSkill("asfdbhjaf", 1, Erarity.Common, EEffectType.RestoreRP, 1);

            Character dummyCharacter1test7 = new Character("test2char1", 5, Erarity.Rare, 3, 2, EAffinity.Knight);
            Character dummyCharacter2test7 = new Character("test2char1", 5, Erarity.Rare, 3, 2, EAffinity.Knight);
            Character dummyCharacter3test7 = new Character("test2char1", 5, Erarity.Rare, 3, 2, EAffinity.Knight);
            Character dummyCharacter4test7 = new Character("test2char1", 5, Erarity.Rare, 3, 2, EAffinity.Knight);
            Character dummyCharacter5test7 = new Character("test2char1", 5, Erarity.Rare, 3, 2, EAffinity.Knight);

            Assert.AreEqual(2, supportSkill1Test7.UseSkill(dummyCharacter1test7).Ap);
            Assert.AreEqual(1, supportSkill2Test7.UseSkill(dummyCharacter2test7).Rp);
            Assert.AreEqual(2, supportSkill3Test7.UseSkill(dummyCharacter3test7).Ap);
            Assert.AreEqual(1, supportSkill4Test7.UseSkill(dummyCharacter4test7).Rp);
            Assert.AreEqual(3, supportSkill5Test7.UseSkill(dummyCharacter5test7).Rp);

        }
    }
}