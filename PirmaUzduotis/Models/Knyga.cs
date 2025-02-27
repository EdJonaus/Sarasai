using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirmaUzduotis.Models
{
    public class Knyga
    {
        public string Autorius { get; set; }
        public int Metai { get; set; }
        public string Pavadinimas { get; set; }
        public string Zanras { get; set; }
        public int Puslapiai { get; set; }
    }
}
