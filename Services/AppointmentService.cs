using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management_System__Phase_1_.Models;
using Hospital_Management_System__Phase_1_.Data;

namespace Hospital_Management_System__Phase_1_.Services
{
    internal class AppointmentService
    {
        private readonly HospitalContext _context;

        public AppointmentService(HospitalContext context)
        {
            _context = context;
        }

        public void ScheduleAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public List<Appointment> GetAppointmentsByPatient(int patientId)
        {
            return _context.Appointments.Where(a => a.PatientId == patientId).ToList();
        }

        public List<Appointment> GetAppointmentsByDoctor(int doctorId)
        {
            return _context.Appointments.Where(a => a.DoctorId == doctorId).ToList();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _context.Appointments.FirstOrDefault(a => a.AppointmentId == id);
        }

        public void CancelAppointment(int id)
        {
            var appointment = GetAppointmentById(id);
            if (appointment != null)
            {
                appointment.Status = AppointmentStatus.Canceled;
                _context.SaveChanges();
            }
        }
    }
}
