using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameForHeroesAndMonsters.PlayerCharacter.Heroes.Interface
{
    public interface ICharecter
    {
        public int Strenght { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Range { get; set; }

        public int Health { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }

        public string CharacterSymbol { get; set; }
    }
}
