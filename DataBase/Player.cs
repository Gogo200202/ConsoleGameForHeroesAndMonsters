using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Player
    {
        [Key]
        public string Id { get; set; }
        public int Range { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }

        public int Strenght { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }

        public DateTime TimeOfCreate { get; set; }
        
    }
}
