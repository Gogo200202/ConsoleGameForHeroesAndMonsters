using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameForHeroesAndMonsters.Map.MapInterface;
using ConsoleGameForHeroesAndMonsters.PlayerCharacter.Heroes;

namespace ConsoleGameForHeroesAndMonsters.Map
{
    public class MapManipulations:IMapManipulations
    {
        private Charecter _charecter;
        private Monster _monster;
        private string[,] map;
        private List<Monster> monsters;

        public MapManipulations(Charecter charecter,Monster monster, string[,] Map)
        {
            this._charecter= charecter;
            this._monster= monster;
            this.map = Map;
            this.monsters=new List<Monster>();
            this.monsters.Add(monster);
            
            
        }

        public void renderMap()
        {
            
            Console.Clear();
            Console.SetCursorPosition(0,0);
            Console.WriteLine("Health: "+_charecter.Health+" Mana: "+_charecter.Mana);

            monsters.RemoveAll(x=>x.Health<=0);


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == this._charecter.points.X&& j == this._charecter.points.Y)
                    {
                        map[i, j] = this._charecter.CharacterSymbol;
                    }else if (this.monsters.Any(x=>x.points.X==i&&x.points.Y==j))
                    {
                        map[i, j] = this._monster.CharacterSymbol;
                    }
                    else
                    {
                        map[i, j] = "█";
                    }
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }



            
        }

        public void addMonster()
        {

            Monster m = new Monster();
            m.Setup();
            this.monsters.Add(m);
        }

        public void moveCharecter(string button)
        {
            if (button.Equals("s"))
            {
                _charecter.points.X += _charecter.Range;
            }
            else if(button.Equals("w"))
            {
                _charecter.points.X -= _charecter.Range;
            }else if (button.Equals("d"))
            {
                _charecter.points.Y += _charecter.Range;
            }
            else if (button.Equals("a"))
            {
                _charecter.points.Y -= _charecter.Range;
            }
            else if (button.Equals("e"))
            {
                _charecter.points.X -= _charecter.Range;
                _charecter.points.Y += _charecter.Range;
            }
            else if (button.Equals("z"))
            {
                _charecter.points.X += _charecter.Range;
                _charecter.points.Y -= _charecter.Range;
            }
            else if (button.Equals("q"))
            {
                _charecter.points.X -= _charecter.Range;
                _charecter.points.Y -= _charecter.Range;
            }
            else if (button.Equals("x"))
            {
                _charecter.points.X += _charecter.Range;
                _charecter.points.Y += _charecter.Range;
            }



            if (_charecter.points.X >= map.GetLength(0))
            {
                _charecter.points.X = map.GetLength(0)-1;
            }
            else if (_charecter.points.X <0)
            {
                _charecter.points.X = 0;
            }

            if (_charecter.points.Y >= map.GetLength(1))
            {
                _charecter.points.Y = map.GetLength(1) - 1;
            }
            else if (_charecter.points.Y < 0)
            {
                _charecter.points.Y = 0;
            }
        }
        
        public void moveMonsters()
        {
            for (int i = 0; i < this.monsters.Count; i++)
            {
                if (_charecter.points.Y-1 > this.monsters[i].points.Y)
                {
                    this.monsters[i].points.Y++;
                }
                else if (_charecter.points.Y-1 < this.monsters[i].points.Y)
                {
                    this.monsters[i].points.Y--;
                }
                
                    if (_charecter.points.X-1 > this.monsters[i].points.X)
                    {
                        this.monsters[i].points.X++;
                    }
                    else if (_charecter.points.X-1 < this.monsters[i].points.X)
                    {
                        this.monsters[i].points.X--;
                    }
                

               
            }
            
            
        }

        public List<Monster> chekForMonsters()
        {
            
            //all possible position
            List<Monster>monstersInRainge=new List<Monster>();
            for (int i = 0; i < 8; i++)
            {
                int curetnX = _charecter.points.X;
                int curetnY = _charecter.points.Y;
                for (int j = 0; j < _charecter.Range; j++)
                {
                    if (i==0)
                    {
                        curetnX++;
                    }
                    else if(i == 1)
                    {
                        curetnX--;
                    }
                    else if (i == 2)
                    {
                        curetnY--;
                    }
                    else if (i == 3)
                    {
                        curetnY++;
                    }
                    else if (i == 4)
                    {
                        curetnX++;
                        curetnY--;
                    }
                    else if (i == 5)
                    {
                        curetnX++;
                        curetnY++;
                    }
                    else if (i == 6)
                    {
                        curetnX--;
                        curetnY--;
                    }
                    else if (i == 7)
                    {
                        curetnX--;
                        curetnY++;
                    }

                    if (this.monsters.Any(x=>x.points.X== curetnX&&x.points.Y== curetnY))
                    {
                        monstersInRainge.Add(this.monsters.Find(x=>x.points.X== curetnX&&x.points.Y== curetnY));
                    }

                   
                }
            }

            return monstersInRainge;
        }

        public List<Monster> canMonstersAttack()
        {
            List<Monster> monstersInRainge = new List<Monster>();
            for (int k = 0; k < this.monsters.Count; k++)
            {
                for (int i = 0; i < 8; i++)
                {
                    int curetnX = _monster.points.X;
                    int curetnY = _monster.points.Y;
                    for (int j = 0; j < 1; j++)
                    {
                        if (i == 0)
                        {
                            curetnX++;
                        }
                        else if (i == 1)
                        {
                            curetnX--;
                        }
                        else if (i == 2)
                        {
                            curetnY--;
                        }
                        else if (i == 3)
                        {
                            curetnY++;
                        }
                        else if (i == 4)
                        {
                            curetnX++;
                            curetnY--;
                        }
                        else if (i == 5)
                        {
                            curetnX++;
                            curetnY++;
                        }
                        else if (i == 6)
                        {
                            curetnX--;
                            curetnY--;
                        }
                        else if (i == 7)
                        {
                            curetnX--;
                            curetnY++;
                        }

                        if (this._charecter.points.X== curetnX&&this._charecter.points.Y== curetnY)
                        {
                            monstersInRainge.Add(this.monsters[k]);
                        }
                    }
                }
            }
            

            return monstersInRainge;
        }


        public int getTotalMonsters()
        {
            return this.monsters.Count;
        }
    }
}
