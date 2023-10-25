using ConsoleGameForHeroesAndMonsters.Map;
using ConsoleGameForHeroesAndMonsters.PlayerCharacter.CharacterManipulation;
using ConsoleGameForHeroesAndMonsters.PlayerCharacter.Heroes;
using DataBase;

namespace ConsoleGameForHeroesAndMonsters
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Press any key to play.");
            Console.ReadKey();

            Charecter? player = default;

            Console.WriteLine("Choose character type: ");
            Console.WriteLine("Options: ");
            Console.WriteLine("1) Warrior");
            Console.WriteLine("2) Archer");
            Console.WriteLine("3) Mage");
            Console.WriteLine("Your pick:");
            while (true)
            {
                int typeHero = int.Parse(Console.ReadLine());
                if (typeHero == 1)
                {
                    player = new Warrior();
                    break;
                }
                else if (typeHero == 2)
                {
                    player = new Archer();
                    break;
                }
                else if (typeHero == 3)
                {
                    player = new Mage();
                    break;
                }
                else
                {
                    Console.WriteLine("Not valid number");
                }
            }
            


            Console.WriteLine("Would you like to buff up your stats before starting?");
            Console.WriteLine("Response (Y\\N): ");
            string responseForBuf= Console.ReadLine();
            if (responseForBuf.Equals("Y"))
            {
                int points = 3;
                while (points>0)
                {
                    Console.WriteLine("Remaining points: "+ points);
                    Console.WriteLine("Add to Strenght: ");
                    Console.WriteLine("Add to Agility: ");
                    Console.WriteLine("Add to Intelligence:");
                    string whereToAddPoints= Console.ReadLine();
                    while (points > 0)
                    {
                        
                     if (whereToAddPoints.Equals("Add to Strenght"))
                        {
                            if (player.Strenght>=3)
                            {
                                break;
                            }

                            player.Strenght++;

                        }
                        else if (whereToAddPoints.Equals("Add to Agility"))
                        {

                            if (player.Agility >= 3)
                            {
                                break;
                            }

                            player.Agility++;
                        }
                        else if (whereToAddPoints.Equals("Add to Intelligence"))
                        {

                            if (player.Intelligence >= 3)
                            {
                                break;
                            }

                            player.Intelligence++;

                        }
                        else
                        {
                            Console.WriteLine("Not valid status");
                        }

                        points--;
                    }
                }

            }else if (responseForBuf.Equals("N"))
            {

            }
            else
            {
                Console.WriteLine("Not valid answer");
            }
            player.Setup();
            Console.WriteLine("Please wait:");
            PlayerDataBase dataBae=new PlayerDataBase();
            DateTime currentDateTime = DateTime.Now;
            
            Player dataBasePlayer = new Player();
            dataBasePlayer.Id = Guid.NewGuid().ToString();
            dataBasePlayer.Agility=player.Agility;
            dataBasePlayer.Intelligence = player.Intelligence;
            dataBasePlayer.Range= player.Range;
            dataBasePlayer.Damage= player.Damage;
            dataBasePlayer.Strenght= player.Strenght;
            dataBasePlayer.Mana = player.Mana;
            dataBasePlayer.TimeOfCreate = currentDateTime;
            dataBasePlayer.Health= player.Health;

            dataBae.Player.Add(dataBasePlayer);
            
            dataBae.SaveChanges();

            string[,] map = new string[10, 10];
           
            Monster monster = new Monster();
            monster.Setup();
            MapManipulations mapManipulationsCharecter = new MapManipulations(player, monster, map);
            CharacterManipulation characterManipulation=new CharacterManipulation();


            while (true)
            {
                if (mapManipulationsCharecter.getTotalMonsters() == 0)
                {
                    Console.WriteLine("hero Wins");
                    break;
                }

                if (player.Health<=0)
                {
                    Console.WriteLine("Monsters Wins");
                    break;
                }
                mapManipulationsCharecter.renderMap();

                List<Monster>allMonsterValidForAtackingPlayer= mapManipulationsCharecter.canMonstersAttack();
                if (allMonsterValidForAtackingPlayer.Count>0)
                {
                    for (int i = 0; i < allMonsterValidForAtackingPlayer.Count; i++)
                    {
                        characterManipulation.Attack(allMonsterValidForAtackingPlayer[i], player);
                    }
                    
                }
                Console.WriteLine("1)Attack");
                Console.WriteLine("2)Move");
                string comand = Console.ReadLine();


                
                if (comand.Equals("2"))
                {
                    
                    string moveTo = Console.ReadLine();
                    if (String.IsNullOrEmpty(moveTo))
                    {
                        Console.WriteLine("Not valid position");
                        continue;
                    }
                    mapManipulationsCharecter.moveCharecter(moveTo);
                    mapManipulationsCharecter.moveMonsters();
                }
                else if (comand.Equals("1"))
                {
                   List<Monster> monsterInRange= mapManipulationsCharecter.chekForMonsters();
                   if (monsterInRange.Count==0)
                   {
                       Console.WriteLine("No monsters in the range");
                   }
                   else
                   {
                       Console.WriteLine("Enter the target between 0 and"+ (monsterInRange.Count-1));
                       for (int i = 0; i < monsterInRange.Count; i++)
                       {
                           Console.WriteLine("Number "+i+ " Health" + monsterInRange[i].Health);
                       }

                       int numberOfMonster = int.Parse(Console.ReadLine());
                       characterManipulation.Attack(player, monsterInRange[numberOfMonster]);

                   }

                   
                }

                mapManipulationsCharecter.addMonster();
            }



           



        }
    }
}