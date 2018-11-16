using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche
{
    class Location
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public Hive HiveId { get; set; }
        public Flower FlowerId { get; set; }


    }
}
