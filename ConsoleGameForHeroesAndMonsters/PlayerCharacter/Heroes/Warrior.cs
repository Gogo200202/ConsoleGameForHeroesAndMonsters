using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameForHeroesAndMonsters.PlayerCharacter.Heroes
{
    //Strenght = 3; Agility = 3; Intelligence = 0; Range = 1; символ на полето: @
    public class Warrior:Charecter
    {
        public Warrior()
        {
            base.Strenght = 3;
            base.Agility = 3;
            base.Intelligence = 0;
            base.Range = 1;
            base.CharacterSymbol = "@";
        }
    }
}
