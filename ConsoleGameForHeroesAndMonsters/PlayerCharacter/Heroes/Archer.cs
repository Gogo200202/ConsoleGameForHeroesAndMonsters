using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameForHeroesAndMonsters.PlayerCharacter.Heroes
{
    //Strenght = 2; Agility = 4; Intelligence = 0; Range = 2; символ на полето: #
    public class Archer:Charecter
    {

        public Archer()
        {
            base.Strenght = 2;
            base.Agility = 4;
            base.Intelligence = 0;
            base.Range = 2;
            base.CharacterSymbol = "#";
        }
    }
}
