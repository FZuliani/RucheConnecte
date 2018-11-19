using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche
{
    class User
    {

        public int Id { get; set; }
        public string Login { get; set; }
        public string Passwd { get; set; }
        public string Name { get; set; }
        public int Tel { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public bool ActiveBeeK { get; set; }
    }
}
