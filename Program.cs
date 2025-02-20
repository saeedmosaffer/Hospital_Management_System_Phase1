using System;
using System.Linq;
using System.Collections.Generic;
using Hospital_Management_System__Phase_1_.Data;
using Hospital_Management_System__Phase_1_.Models;
using Hospital_Management_System__Phase_1_.Services;

namespace HospitalManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new HospitalContext())
            {
                var patientService = new PatientService(context);
                var doctorService = new DoctorService(context);
                var appointmentService = new AppointmentService(context);
                var prescriptionService = new PrescriptionService(context);
                var medicationService = new MedicationService(context);
                var billingService = new BillingService(context);

                bool exit = false;
                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine("Hospital Management System");
                    Console.WriteLine("1. Patient Management");
                    Console.WriteLine("2. Doctor Management");
                    Console.WriteLine("3. Appointment Management");
                    Console.WriteLine("4. Prescription Management");
                    Console.WriteLine("5. Medication Management");
                    Console.WriteLine("6. Billing Management");
                    Console.WriteLine("7. Exit");
                    Console.Write("Select an option: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            PatientMenu(patientService);
                            break;
                        case "2":
                            DoctorMenu(doctorService);
                            break;
                        case "3":
                            AppointmentMenu(appointmentService);
                            break;
                        case "4":
                            PrescriptionMenu(prescriptionService, medicationService, billingService);
                            break;
                        case "5":
                            MedicationMenu(medicationService);
                            break;
                        case "6":
                            BillingMenu(billingService);
                            break;
                        case "7":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid selection. Press any key to try again...");
                            Console.ReadKey();
                            break;
                    }
                }
            }
        }

        #region Patient Management Menu
        static void PatientMenu(PatientService patientService)
        {
            Console.Clear();
            Console.WriteLine("Patient Management");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. View Patients");
            Console.WriteLine("3. Update Patient");
            Console.WriteLine("4. Delete Patient");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddPatient(patientService);
                    break;
                case "2":
                    ViewPatients(patientService);
                    break;
                case "3":
                    UpdatePatient(patientService);
                    break;
                case "4":
                    DeletePatient(patientService);
                    break;
                default:
                    break;
            }
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        static void AddPatient(PatientService patientService)
        {
            Console.Clear();
            Console.WriteLine("Add New Patient");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Contact Number: ");
            string contact = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();

            var patient = new Patient
            {
                Name = name,
                Age = age,
                Gender = gender,
                ContactNumber = contact,
                Address = address
            };

            patientService.AddPatient(patient);
            Console.WriteLine("Patient added successfully!");
        }

        static void ViewPatients(PatientService patientService)
        {
            Console.Clear();
            Console.WriteLine("List of Patients:");
            var patients = patientService.GetPatients();
            foreach (var p in patients)
            {
                Console.WriteLine($"ID: {p.PatientId}, Name: {p.Name}, Age: {p.Age}, Gender: {p.Gender}");
            }
        }

        static void UpdatePatient(PatientService patientService)
        {
            Console.Clear();
            Console.Write("Enter Patient ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var patient = patientService.GetPatientById(id);
            if (patient != null)
            {
                Console.Write("New Name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                    patient.Name = name;

                Console.Write("New Age (leave blank to keep current): ");
                var ageInput = Console.ReadLine();
                if (int.TryParse(ageInput, out int newAge))
                    patient.Age = newAge;

                Console.Write("New Gender (leave blank to keep current): ");
                string gender = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(gender))
                    patient.Gender = gender;

                Console.Write("New Contact Number (leave blank to keep current): ");
                string contact = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(contact))
                    patient.ContactNumber = contact;

                Console.Write("New Address (leave blank to keep current): ");
                string address = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(address))
                    patient.Address = address;

                patientService.UpdatePatient(patient);
                Console.WriteLine("Patient updated successfully!");
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }

        static void DeletePatient(PatientService patientService)
        {
            Console.Clear();
            Console.Write("Enter Patient ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            patientService.DeletePatient(id);
            Console.WriteLine("Patient deleted successfully (if existed).");
        }
        #endregion

        #region Doctor Management Menu
        static void DoctorMenu(DoctorService doctorService)
        {
            Console.Clear();
            Console.WriteLine("Doctor Management");
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. View Doctors");
            Console.WriteLine("3. Update Doctor");
            Console.WriteLine("4. Delete Doctor");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddDoctor(doctorService);
                    break;
                case "2":
                    ViewDoctors(doctorService);
                    break;
                case "3":
                    UpdateDoctor(doctorService);
                    break;
                case "4":
                    DeleteDoctor(doctorService);
                    break;
                default:
                    break;
            }
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        static void AddDoctor(DoctorService doctorService)
        {
            Console.Clear();
            Console.WriteLine("Add New Doctor");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Contact Number: ");
            string contact = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Specialty: ");
            string specialty = Console.ReadLine();

            var doctor = new Doctor
            {
                Name = name,
                Age = age,
                Gender = gender,
                ContactNumber = contact,
                Email = email,
                Specialty = specialty
            };

            doctorService.AddDoctor(doctor);
            Console.WriteLine("Doctor added successfully!");
        }

        static void ViewDoctors(DoctorService doctorService)
        {
            Console.Clear();
            Console.WriteLine("List of Doctors:");
            var doctors = doctorService.GetDoctors();
            foreach (var d in doctors)
            {
                Console.WriteLine($"ID: {d.DoctorId}, Name: {d.Name}, Specialty: {d.Specialty}");
            }
        }

        static void UpdateDoctor(DoctorService doctorService)
        {
            Console.Clear();
            Console.Write("Enter Doctor ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var doctor = doctorService.GetDoctorById(id);
            if (doctor != null)
            {
                Console.Write("New Name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                    doctor.Name = name;

                Console.Write("New Age (leave blank to keep current): ");
                var ageInput = Console.ReadLine();
                if (int.TryParse(ageInput, out int newAge))
                    doctor.Age = newAge;

                Console.Write("New Gender (leave blank to keep current): ");
                string gender = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(gender))
                    doctor.Gender = gender;

                Console.Write("New Contact Number (leave blank to keep current): ");
                string contact = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(contact))
                    doctor.ContactNumber = contact;

                Console.Write("New Email (leave blank to keep current): ");
                string email = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(email))
                    doctor.Email = email;

                Console.Write("New Specialty (leave blank to keep current): ");
                string specialty = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(specialty))
                    doctor.Specialty = specialty;

                doctorService.UpdateDoctor(doctor);
                Console.WriteLine("Doctor updated successfully!");
            }
            else
            {
                Console.WriteLine("Doctor not found.");
            }
        }

        static void DeleteDoctor(DoctorService doctorService)
        {
            Console.Clear();
            Console.Write("Enter Doctor ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            doctorService.DeleteDoctor(id);
            Console.WriteLine("Doctor deleted successfully (if existed).");
        }
        #endregion

        #region Appointment Management Menu
        static void AppointmentMenu(AppointmentService appointmentService)
        {
            Console.Clear();
            Console.WriteLine("Appointment Management");
            Console.WriteLine("1. Schedule Appointment");
            Console.WriteLine("2. View Appointments");
            Console.WriteLine("3. Cancel Appointment");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ScheduleAppointment(appointmentService);
                    break;
                case "2":
                    ViewAppointments(appointmentService);
                    break;
                case "3":
                    CancelAppointment(appointmentService);
                    break;
                default:
                    break;
            }
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        static void ScheduleAppointment(AppointmentService appointmentService)
        {
            Console.Clear();
            Console.WriteLine("Schedule Appointment");
            Console.Write("Patient ID: ");
            int patientId = int.Parse(Console.ReadLine());
            Console.Write("Doctor ID: ");
            int doctorId = int.Parse(Console.ReadLine());
            Console.Write("Appointment Date (yyyy-MM-dd HH:mm): ");
            DateTime appointmentDate = DateTime.Parse(Console.ReadLine());

            var appointment = new Appointment
            {
                PatientId = patientId,
                DoctorId = doctorId,
                AppointmentDate = appointmentDate,
                Status = AppointmentStatus.Scheduled
            };

            appointmentService.ScheduleAppointment(appointment);
            Console.WriteLine("Appointment scheduled successfully!");
        }

        static void ViewAppointments(AppointmentService appointmentService)
        {
            Console.Clear();
            Console.WriteLine("View Appointments");
            Console.WriteLine("1. By Patient ID");
            Console.WriteLine("2. By Doctor ID");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            if (option == "1")
            {
                Console.Write("Enter Patient ID: ");
                int patientId = int.Parse(Console.ReadLine());
                var appointments = appointmentService.GetAppointmentsByPatient(patientId);
                foreach (var a in appointments)
                {
                    Console.WriteLine($"Appointment ID: {a.AppointmentId}, Date: {a.AppointmentDate}, Status: {a.Status}");
                }
            }
            else if (option == "2")
            {
                Console.Write("Enter Doctor ID: ");
                int doctorId = int.Parse(Console.ReadLine());
                var appointments = appointmentService.GetAppointmentsByDoctor(doctorId);
                foreach (var a in appointments)
                {
                    Console.WriteLine($"Appointment ID: {a.AppointmentId}, Date: {a.AppointmentDate}, Status: {a.Status}");
                }
            }
        }

        static void CancelAppointment(AppointmentService appointmentService)
        {
            Console.Clear();
            Console.Write("Enter Appointment ID to cancel: ");
            int id = int.Parse(Console.ReadLine());
            appointmentService.CancelAppointment(id);
            Console.WriteLine("Appointment canceled (if existed).");
        }
        #endregion

        #region Prescription Management Menu
        static void PrescriptionMenu(PrescriptionService prescriptionService, MedicationService medicationService, BillingService billingService)
        {
            Console.Clear();
            Console.WriteLine("Prescription Management");
            Console.WriteLine("1. Issue Prescription");
            Console.WriteLine("2. View Prescriptions");
            Console.WriteLine("3. Back to Main Menu");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    IssuePrescription(prescriptionService, medicationService, billingService);
                    break;
                case "2":
                    ViewPrescriptions(prescriptionService);
                    break;
                default:
                    break;
            }
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        static void IssuePrescription(PrescriptionService prescriptionService, MedicationService medicationService, BillingService billingService)
        {
            Console.Clear();
            Console.WriteLine("Issue Prescription");
            Console.Write("Patient ID: ");
            int patientId = int.Parse(Console.ReadLine());
            Console.Write("Doctor ID: ");
            int doctorId = int.Parse(Console.ReadLine());
            Console.Write("Medication ID: ");
            int medicationId = int.Parse(Console.ReadLine());
            Console.Write("Dosage (e.g., '2 pills daily'): ");
            string dosage = Console.ReadLine();

            var prescription = new Prescription
            {
                PatientId = patientId,
                DoctorId = doctorId,
                PrescriptionDate = DateTime.Now,
                PrescriptionMedications = new List<PrescriptionMedication>()
            };

            // Verify the medication exists
            var medication = medicationService.GetMedicationById(medicationId);
            if (medication == null)
            {
                Console.WriteLine("Medication not found.");
                return;
            }

            // Create join entity for medication with dosage details
            var prescriptionMedication = new PrescriptionMedication
            {
                MedicationId = medicationId,
                Dosage = dosage
            };

            prescription.PrescriptionMedications.Add(prescriptionMedication);

            // Issue the prescription
            prescriptionService.IssuePrescription(prescription);

            var bill = new Bill
            {
                PrescriptionId = prescription.PrescriptionId,
                Amount = medication.Price,
                BillDate = DateTime.Now,
                Status = BillStatus.Unpaid
            };
            billingService.AddBill(bill);

            Console.WriteLine("Prescription issued and bill generated successfully!");
        }

        static void ViewPrescriptions(PrescriptionService prescriptionService)
        {
            Console.Clear();
            Console.WriteLine("List of Prescriptions:");
            var prescriptions = prescriptionService.GetPrescriptions();
            foreach (var p in prescriptions)
            {
                Console.WriteLine($"Prescription ID: {p.PrescriptionId}, Date: {p.PrescriptionDate}, Patient ID: {p.PatientId}, Doctor ID: {p.DoctorId}");
                if (p.PrescriptionMedications != null && p.PrescriptionMedications.Any())
                {
                    foreach (var pm in p.PrescriptionMedications)
                    {
                        Console.WriteLine($"\tMedication ID: {pm.MedicationId}, Dosage: {pm.Dosage}");
                    }
                }
            }
        }
        #endregion

        #region Medication Management Menu
        static void MedicationMenu(MedicationService medicationService)
        {
            Console.Clear();
            Console.WriteLine("Medication Management");
            Console.WriteLine("1. Add Medication");
            Console.WriteLine("2. View Medications");
            Console.WriteLine("3. Update Medication");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddMedication(medicationService);
                    break;
                case "2":
                    ViewMedications(medicationService);
                    break;
                case "3":
                    UpdateMedication(medicationService);
                    break;
                default:
                    break;
            }
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        static void AddMedication(MedicationService medicationService)
        {
            Console.Clear();
            Console.WriteLine("Add Medication");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            var medication = new Medication
            {
                Name = name,
                Quantity = quantity,
                Price = price
            };

            medicationService.AddMedication(medication);
            Console.WriteLine("Medication added successfully!");
        }

        static void ViewMedications(MedicationService medicationService)
        {
            Console.Clear();
            Console.WriteLine("List of Medications:");
            var medications = medicationService.GetMedications();
            foreach (var m in medications)
            {
                Console.WriteLine($"ID: {m.MedicationId}, Name: {m.Name}, Quantity: {m.Quantity}, Price: {m.Price}");
            }
        }

        static void UpdateMedication(MedicationService medicationService)
        {
            Console.Clear();
            Console.Write("Enter Medication ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var medication = medicationService.GetMedicationById(id);
            if (medication != null)
            {
                Console.Write("New Name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                    medication.Name = name;

                Console.Write("New Quantity (leave blank to keep current): ");
                var qtyInput = Console.ReadLine();
                if (int.TryParse(qtyInput, out int newQty))
                    medication.Quantity = newQty;

                Console.Write("New Price (leave blank to keep current): ");
                var priceInput = Console.ReadLine();
                if (decimal.TryParse(priceInput, out decimal newPrice))
                    medication.Price = newPrice;

                medicationService.UpdateMedication(medication);
                Console.WriteLine("Medication updated successfully!");
            }
            else
            {
                Console.WriteLine("Medication not found.");
            }
        }
        #endregion

        #region Billing Management Menu
        static void BillingMenu(BillingService billingService)
        {
            Console.Clear();
            Console.WriteLine("Billing Management");
            Console.WriteLine("1. View Bills");
            Console.WriteLine("2. Update Bill (Mark as Paid)");
            Console.WriteLine("3. Back to Main Menu");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ViewBills(billingService);
                    break;
                case "2":
                    UpdateBill(billingService);
                    break;
                default:
                    break;
            }
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        static void ViewBills(BillingService billingService)
        {
            Console.Clear();
            Console.WriteLine("List of Bills:");
            var bills = billingService.GetBills();
            foreach (var b in bills)
            {
                Console.WriteLine($"Bill ID: {b.BillId}, Prescription ID: {b.PrescriptionId}, Amount: {b.Amount}, Status: {b.Status}, Date: {b.BillDate}");
            }
        }

        static void UpdateBill(BillingService billingService)
        {
            Console.Clear();
            Console.Write("Enter Bill ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var bill = billingService.GetBillById(id);
            if (bill != null)
            {
                Console.Write("Mark as Paid? (y/n): ");
                var confirm = Console.ReadLine();
                if (confirm.ToLower() == "y")
                {
                    bill.Status = BillStatus.Paid;
                    billingService.UpdateBill(bill);
                    Console.WriteLine("Bill updated to Paid.");
                }
            }
            else
            {
                Console.WriteLine("Bill not found.");
            }
        }
        #endregion
    }
}
