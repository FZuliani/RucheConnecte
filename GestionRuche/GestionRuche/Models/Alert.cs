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
        public TypeA TypeAId { get; set; }
        public Hive HiveId { get; set; }

    }
}
