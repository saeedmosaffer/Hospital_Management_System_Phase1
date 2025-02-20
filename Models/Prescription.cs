using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System__Phase_1_.Models
{
    internal class Prescription
    {
        public int PrescriptionId { get; set; }
        public DateTime PrescriptionDate { get; set; }

        // Foreign keys and navigation properties
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
    }
}
