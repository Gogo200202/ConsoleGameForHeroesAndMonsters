using ConsoleGameForHeroesAndMonsters.PlayerCharacter.Heroes.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameForHeroesAndMonsters.PlayerCharacter.Heroes.Coordinations;

namespace ConsoleGameForHeroesAndMonsters.PlayerCharacter.Heroes
{
    public abstract class Charecter: ICharecter
    {
        public int Range { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }

        public int Strenght { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public string CharacterSymbol { get; set; }

        public Points points { get; set; }

        public Charecter()
        {
            points=new Points();
        }

       public void Setup()
        {
            this.Health = this.Strenght * 5;
            this.Mana = this.Intelligence * 3;
            this.Damage = this.Agility * 2;
        }

    }
}
