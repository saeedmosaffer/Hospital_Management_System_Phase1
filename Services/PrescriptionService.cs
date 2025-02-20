using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management_System__Phase_1_.Models;
using Hospital_Management_System__Phase_1_.Data;

namespace Hospital_Management_System__Phase_1_.Services
{
    internal class PrescriptionService
    {
        private readonly HospitalContext _context;

        public PrescriptionService(HospitalContext context)
        {
            _context = context;
        }

        public void IssuePrescription(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            _context.SaveChanges();
        }

        public List<Prescription> GetPrescriptions()
        {
            return _context.Prescriptions.ToList();
        }

        public Prescription GetPrescriptionById(int id)
        {
            return _context.Prescriptions.FirstOrDefault(p => p.PrescriptionId == id);
        }
    }
}
