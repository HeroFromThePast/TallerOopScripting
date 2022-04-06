using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerOopScripting.Clases
{
    public enum EEffectType
    {
        ReduceAp,
        ReduceRP,
        ReduceAll,
        DestroyEquip,
        RestoreRP
    }
    public class SupportSkill : Card
    {
        private int effectPoints;
        private EEffectType effectType;

        public SupportSkill() : base()
        {
            effectPoints = 1;
            effectType = EEffectType.ReduceAp;
        }

        public SupportSkill(string name, int costPoints, Erarity rarity, EEffectType effectType, int effectPoints ) : base(name, costPoints, rarity)
        {
            EffectPoints = effectPoints;
            EffectType = effectType;
        }


        public int EffectPoints { get => effectPoints; set => effectPoints = value; }
        public EEffectType EffectType { get => effectType; set => effectType = value; }

        public Character UseSkill(Character target) 
        {

            if(this.effectType == EEffectType.DestroyEquip)
            {
                target.Equipment.RemoveAt(0);             
            }
            else if (this.effectType == EEffectType.ReduceRP) target.Rp -= this.effectPoints;
            else if (this.effectType == EEffectType.ReduceAp) target.Ap -= this.effectPoints;
            else if (this.effectType == EEffectType.ReduceAll)
            {
                target.Rp -= this.effectPoints;
                target.Ap -= this.effectPoints;
            }
            else if (this.effectType == EEffectType.RestoreRP) target.Rp += this.effectPoints;

            return target;
        }

    }

}
