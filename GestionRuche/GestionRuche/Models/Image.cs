using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche.DAL.Models
{
    public class Image
    {


        public int Id { get; set; }
        public bool Result { get; set; }
        public DateTime Date { get; set; }
        public string ImagePos { get; set; }
        public int UserId { get; set; }
        public int HiveId { get; set; }

    }
}
