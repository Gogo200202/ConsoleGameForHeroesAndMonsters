using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameForHeroesAndMonsters.PlayerCharacter.Heroes;

namespace ConsoleGameForHeroesAndMonsters.PlayerCharacter.CharacterManipulation
{
    public class CharacterManipulation
    {
        public void Attack(Charecter player1, Charecter player2)
        {
            player2.Health -= player1.Damage;
        }
    }
}
