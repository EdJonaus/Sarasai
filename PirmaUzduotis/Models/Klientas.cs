using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirmaUzduotis.Models
{
    public class Klientas
    {
        public long ID { get; set; }
        public string Vardas { get; set; }
        public Knyga Pasiskolinta { get; set; }


        
    }

}
