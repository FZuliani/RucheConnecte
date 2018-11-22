using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche.DAL.Models
{
    public class Location
    {

        public int id { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Latitude { get; set; }
        public int longitude { get; set; }
        public string Orientation { get; set; }
        public string Nectar_Type { get; set; }
        public int Hive_id { get; set; }
        public int Zone_id { get; set; }
        public int Flower_id { get; set; }
               
    }
}
