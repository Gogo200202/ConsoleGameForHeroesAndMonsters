using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameForHeroesAndMonsters.PlayerCharacter.Heroes;

namespace ConsoleGameForHeroesAndMonsters.Map.MapInterface
{
    public interface IMapManipulations
    {

        public void renderMap();

        public void moveCharecter(string button);
        public void moveMonsters();

        public List<Monster> chekForMonsters();

        public List<Monster> canMonstersAttack();
    }
}
