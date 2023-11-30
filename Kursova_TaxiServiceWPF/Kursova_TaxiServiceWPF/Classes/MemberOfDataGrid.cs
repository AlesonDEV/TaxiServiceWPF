using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova_TaxiServiceWPF.Classes {
    class GroupTaxi {
        public System.Int32 GroupId { get; set; }

        public string GroupName { get; set; }

        public List<string> Details { get; set; }
    }
}
