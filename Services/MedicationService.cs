using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management_System__Phase_1_.Models;
using Hospital_Management_System__Phase_1_.Data;

namespace Hospital_Management_System__Phase_1_.Services
{
    internal class MedicationService
    {
        private readonly HospitalContext _context;

        public MedicationService(HospitalContext context)
        {
            _context = context;
        }

        public void AddMedication(Medication medication)
        {
            _context.Medications.Add(medication);
            _context.SaveChanges();
        }

        public List<Medication> GetMedications()
        {
            return _context.Medications.ToList();
        }

        public Medication GetMedicationById(int id)
        {
            return _context.Medications.FirstOrDefault(m => m.MedicationId == id);
        }

        public void UpdateMedication(Medication medication)
        {
            _context.Medications.Update(medication);
            _context.SaveChanges();
        }
    }
}
