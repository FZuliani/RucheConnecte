using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche.DAL.Models
{
    public class Hive
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int InitWeight { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }
        public int ZoneId { get; set; }
    }
}
