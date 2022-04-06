using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerOopScripting.Clases
{
    public enum ETargetAtributte
    {
        AP, 
        RP, 
        ALL
    }

    public enum EEquipAffinity
    {
        Knight,
        Mage, 
        Undead,
        All
    }
    public class Equip : Card
    {
        private ETargetAtributte targetAtributte;
        private EEquipAffinity affinity;
        private int effectPoints;

        public Equip(string name, int costPoints, Erarity rarity, ETargetAtributte targetAtributte, EEquipAffinity affinity, int effectPoints) : base(name, costPoints, rarity)
        {
            TargetAtributte = targetAtributte;
            Affinity = affinity;
            EffectPoints = effectPoints;
        }

        public Equip() : base()
        {
            targetAtributte = ETargetAtributte.AP;
            Affinity = EEquipAffinity.All;
            effectPoints = 1;
        }

        public ETargetAtributte TargetAtributte { get => targetAtributte; set => targetAtributte = value; }
        public EEquipAffinity Affinity { get => affinity; set => affinity = value; }
        public int EffectPoints { get => effectPoints; set => effectPoints = value; }


       

    }
}
