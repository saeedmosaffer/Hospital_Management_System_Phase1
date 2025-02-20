using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management_System__Phase_1_.Models;
using Hospital_Management_System__Phase_1_.Data;

namespace Hospital_Management_System__Phase_1_.Services
{
    internal class DoctorService
    {
        private readonly HospitalContext _context;

        public DoctorService(HospitalContext context)
        {
            _context = context;
        }

        public void AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public List<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();
        }

        public Doctor GetDoctorById(int id)
        {
            return _context.Doctors.FirstOrDefault(d => d.DoctorId == id);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {
            var doctor = GetDoctorById(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
        }
    }
}
