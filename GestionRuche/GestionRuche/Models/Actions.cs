using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche.Models
{
    public class Actions
    {

        public int id { get; set; }
        public DateTime DateAction { get; set; }
        public string Description { get; set; }
        public int Hive_id { get; set; }
        
    }
}
