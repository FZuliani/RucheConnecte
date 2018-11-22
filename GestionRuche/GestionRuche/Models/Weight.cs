using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche.DAL.Models
{
    public class Weight
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int weight { get; set; }
        public int HiveId { get; set; }

    }
}
