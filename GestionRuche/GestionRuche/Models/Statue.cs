using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche.Models
{
    public class Statue
    {

        public int id { get; set; }
        public DateTime Date { get; set; }
        public bool Agressivity { get; set; }
        public bool Queen { get; set; }
        public int Age_Queen { get; set; }
        public int NB_Cadres { get; set; }
        public bool Morte { get; set; }
        public int Hive_id { get; set; }

    }
}
