using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZzukBot.Engines.CustomClass;

namespace something
{
    public class EmuWarrior : CustomClass
    {

        public override byte DesignedForClass
        {
            get
            { 
                return PlayerClass.Warrior;
            }
        }

        public override string CustomClassName
        {
            get
            {
                return "EmuWarrior";
            } 
        }

		 private bool TargetCanBleed()
        {
            return (this.Target.CreatureType != CreatureType.Elemental && this.Target.CreatureType != CreatureType.Mechanical);
        }
		
        public override void PreFight()
        {
            this.SetCombatDistance(30);
            this.Player.Attack();
            if (this.Player.GetSpellRank("Shoot Bow") != 0)
            {
                if (this.Player.CanUse("Shoot Bow"))
                {
                    this.Player.Cast("Shoot Bow");
					return;
                }
            }

        }

        public override void Fight()
        {
            this.SetCombatDistance(30);
			this.Player.Attack();

            if (this.Player.GetSpellRank("Battle Shout") != 0)
            {
                if (this.Player.Rage >= 10 && !this.Player.GotBuff("Battle Shout"))
                {
                    this.Player.Cast("Battle Shout");
					return;
                }
            }

            if (this.Player.GetSpellRank("Rend") != 0)
            {
				if(TargetCanBleed())
                if (!this.Target.GotDebuff("Rend") && this.Player.Rage >= 10 & this.Target.HealthPercent > 66)
                {
                    this.Player.Cast("Rend");
                    return;
                }
            }

            if (this.Player.GetSpellRank("Shield Slam") != 0)
            {
                if (this.Player.Rage >= 20 & this.Target.HealthPercent > 5)
                {
                    this.Player.Cast("Shield Slam");
					return;
                }
            }

            if (this.Player.GetSpellRank("Revenge") != 0)
            {
                if (this.Player.Rage >= 5 && this.Player.GotBuff("Defensive Stance"))
                {
                    this.Player.Cast("Revenge");
					return;
                }
            }

         if (this.Player.GetSpellRank("Shield Bash") != 0)
            {
                if (!this.Target.GotDebuff("Shield Bash") && this.Player.Rage >= 10 && this.Target.IsCasting != "" || this.Target.IsChanneling != "")
                {
                    this.Player.Cast("Shield Bash");
					return;
                }
            }
   
         if (this.Player.GetSpellRank("War Stomp") != 0)
            {
                if (!this.Target.GotDebuff("War Stomp") && this.Target.IsCasting != "" || this.Target.IsChanneling != "")
                {
                    this.Player.Cast("War Stomp");
					return;
                }
            }

         if (this.Player.GetSpellRank("Concussion Blow") != 0)
            {
                if (!this.Target.GotDebuff("Concussion Blow") && this.Player.Rage >= 15 && this.Target.HealthPercent > 15 && this.Target.IsCasting != "" || this.Target.IsChanneling != "")
                {
                    this.Player.Cast("Concussion Blow");
					return;
                }
            }

			  if (this.Player.GetSpellRank("Heroic Strike") != 0)
            {
                if (this.Player.Rage >= 15 && this.Target.GotDebuff("Rend"))
                {
                    this.Player.Cast("Heroic Strike");
					return;
                }
            }
			

            if (this.Player.GetSpellRank("Shield Block") != 0)
            {
                if (this.Player.Rage >= 10 && !this.Player.GotBuff("Shield Block"))
                {
                    this.Player.Cast("Shield Block");
                    return;
                }
            }

            if (this.Player.GetSpellRank("Demoralizing Shout") != 0)
            {
                if (!this.Target.GotDebuff("Demoralizing Shout") && this.Player.Rage >= 10 & this.Target.HealthPercent > 33)
                {
                    this.Player.Cast("Demoralizing Shout");
                    return;
                }
            }

            if (this.Player.Rage <= 50 && this.Player.HealthPercent >= 50)
            {
                if (this.Player.GetSpellRank("Bloodrage") !=0  && this.Player.CanUse("Bloodrage"))
                {
                    this.Player.Cast("Bloodrage");
                    return;
                }

            }

            if (this.Player.GetSpellRank("Shield Wall") != 0)
            {
                if (this.Player.HealthPercent <= 10 && !this.Player.GotBuff("Shield Wall") && this.Player.CanUse("Shield Wall"))
                {
                    this.Player.Cast("Shield Wall");
					return;
                }
            }

            if (this.Player.GetSpellRank("Last Stand") != 0)
            {
                if (this.Player.HealthPercent <= 8 && !this.Player.GotBuff("Last Stand") && this.Player.CanUse("Last Stand"))
                {
                    this.Player.Cast("Last Stand");
					return;
                }
            }

            if (this.Player.HealthPercent <= 5 && this.Player.CanUse("Major Healing Potion") && this.Player.ItemCount("Major Healing Potion") > 0)
            {
                this.Player.UseItem("Major Healing Potion");
				return;
            }

       if(!this.Player.GotBuff("Defensive Stance"))
       {
                this.Player.Cast("Defensive Stance");
                return;
            }

        }

public override bool Buff()
        {

            //True means we are done buffing, or cannot buff
            return true;
        }
    }
}