using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche
{
    public class Alert
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool AlertA { get; set; }
        public int TypeAId { get; set; }
        public int HiveId { get; set; }

    }
}
