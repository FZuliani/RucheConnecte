using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche.DAL.Models
{
    public class Statistic
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int AirQuality { get; set; }
        public int HiveId { get; set; }
    }
}
