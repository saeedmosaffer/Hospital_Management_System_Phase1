using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System__Phase_1_.Models
{
    internal class PrescriptionMedication
    {
        // Composite key: PrescriptionId + MedicationId
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        public int MedicationId { get; set; }
        public Medication Medication { get; set; }

        public string Dosage { get; set; } // e.g., "2 pills daily"
    }
}
