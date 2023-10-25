using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameForHeroesAndMonsters.PlayerCharacter.Heroes
{
    public class Monster:Charecter
    {
        //o	За чудовищата: Strength, Agility, Intelligence са случайни между 1 и 3, Range е винаги 1; символ на полето: ◙
        public Monster()
        {
            Random rnd = new Random();
            base.points.Y = rnd.Next(0,10);
            base.points.X = rnd.Next(0, 10);
            base.Strenght = rnd.Next(1,4);
            base.Agility = rnd.Next(1, 4);
            base.Intelligence = rnd.Next(1, 4);
            base.Range = 1;
            base.CharacterSymbol = "O";
        }
    }
}
