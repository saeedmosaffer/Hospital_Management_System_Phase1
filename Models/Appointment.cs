using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System__Phase_1_.Models
{
    public enum AppointmentStatus
    {
        Scheduled,
        Completed,
        Canceled
    }
    internal class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }

        // Foreign keys and navigation properties
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
