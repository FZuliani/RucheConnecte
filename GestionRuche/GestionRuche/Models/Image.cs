using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche
{
    class Image
    {


        public int Id { get; set; }
        public bool Result { get; set; }
        public DateTime Date { get; set; }
        public string ImagePos { get; set; }
        public User UserId { get; set; }
        public Hive HiveId { get; set; }

    }
}
