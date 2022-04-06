using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerOopScripting.Clases
{
    public class Character : Card
    {
        private int ap;
        private int rp;
        private List<Equip> equipment;
        private EAffinity affinity;

        public Character() : base()
        {
            equipment = new List<Equip>();
            Ap = 1;
            Rp = 1;
            Affinity = EAffinity.Knight;
        }

        public Character(string name, int costPoints, Erarity rarity, int ap, int rp, EAffinity affinity) : base(name, costPoints, rarity)
        {
            equipment = new List<Equip>();
            Ap = ap;
            Rp = rp;
            Affinity = affinity;
        }


        public int Ap { get => ap; set => ap = value; }
        public int Rp { get => rp; set => rp = value; }
        public EAffinity Affinity { get => affinity; set => affinity = value; }
        public List<Equip> Equipment { get => equipment; set => equipment = value; }

        public Character Attack(Character target)
        {
            int actualAp = this.ap;

            if(this.rp > 0 && target.rp > 0) //la idea es que no se pueda usar si los rp del personaje pues son 0 o menos
            {
                if(this.affinity == EAffinity.Knight && target.affinity == EAffinity.Mage || this.affinity == EAffinity.Mage && target.affinity == EAffinity.Undead || this.affinity == EAffinity.Undead && target.affinity == EAffinity.Knight)
                {
                    this.ap += 1;
                }
                else if (this.affinity == EAffinity.Knight && target.affinity == EAffinity.Undead || this.affinity == EAffinity.Mage && target.affinity == EAffinity.Knight || this.affinity == EAffinity.Undead && target.Affinity == EAffinity.Mage)
                {
                    this.ap -= 1;
                }

                target.rp -= this.ap;

                this.ap = actualAp;

                return target;
            }
            else
            {
                return target;
            }
        }

        public Character EquipItem(Equip item)
        {
            if (this.Rp > 0) //Comprueba que el personaje no este destruido
            {
                if (this.Equipment.Count <=2) //comprueba que no hayan mas de 3 items en el equipamento
                {
                    if(this.affinity == EAffinity.Knight && item.Affinity == EEquipAffinity.Knight || this.affinity == EAffinity.Mage && item.Affinity == EEquipAffinity.Mage || this.affinity == EAffinity.Undead && item.Affinity == EEquipAffinity.Undead || item.Affinity == EEquipAffinity.All)
                    {
                        this.Equipment.Add(item);

                        if(item.TargetAtributte == ETargetAtributte.AP) this.Ap += item.EffectPoints;
                        else if (item.TargetAtributte == ETargetAtributte.RP) this.Rp += item.EffectPoints;
                        else if (item.TargetAtributte == ETargetAtributte.ALL)
                        {
                            this.Ap += item.EffectPoints;
                            this.Rp += item.EffectPoints;
                        }

                        return this;
                    }
                    else
                    {
                        return this;
                    }

                    
                }
                else
                {
                    return this;
                }
            }
            else
            {
                return this;
            }
        }

    }

    

}
