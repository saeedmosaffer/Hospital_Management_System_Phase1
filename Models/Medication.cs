using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System__Phase_1_.Models
{
    internal class Medication
    {
        public int MedicationId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
    }
}
