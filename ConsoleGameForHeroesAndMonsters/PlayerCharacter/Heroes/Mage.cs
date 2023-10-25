using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameForHeroesAndMonsters.PlayerCharacter.Heroes
{
    //Strenght = 2; Agility = 1; Intelligence = 3; Range = 3; символ на полето: *
    public class Mage:Charecter
    {
        public Mage()
        {
            base.Strenght = 2;
            base.Agility = 1;
            base.Intelligence = 3;
            base.Range = 3;
            base.CharacterSymbol = "*";
        }
    }
}
