# Hospital Management System (Phase 1)

A console-based **Hospital Management System (HMS)** built with **.NET** and **Entity Framework Core** using the **Code-First** approach. This application manages essential hospital operations, including **patient registration, doctor management, appointment scheduling, prescription and medication management, and automatic billing.**

## Table of Contents

- [Features](#features)
- [Technologies](#technologies)
- [Setup & Installation](#setup--installation)
- [Usage Instructions](#usage-instructions)
- [Project Structure](#project-structure)
- [License](#license)

## Features

### **Patient Management**
- Add, view, update, and delete patient records.

### **Doctor Management**
- Add, view, update, and delete doctor records.

### **Appointment Management**
- Schedule appointments between patients and doctors.
- View and cancel appointments.

### **Prescription Management**
- Issue prescriptions linking patients, doctors, and medications.
- Supports many-to-many relationships between prescriptions and medications (including dosage details).

### **Medication Management**
- Add, view, and update medication details.
- Manage medication inventory.

### **Billing Management**
- Automatically generate bills when a prescription is issued.
- View and update bill statuses (e.g., mark as Paid).

## Technologies

- **.NET Core / .NET 5/6/7** - Console Application
- **Entity Framework Core** - ORM with Code-First approach
- **Microsoft SQL Server / LocalDB** - Database

## Setup & Installation

### **1. Clone the Repository**

```bash
git clone https://github.com/saeedmosaffer/Hospital_Management_System_Phase1.git
cd Hospital_Management_System_Phase1
```

### **2. Restore Dependencies**
Ensure you have the required .NET SDK installed, then run:

```bash
dotnet restore
```

### **3. Update the Database**
Check that your connection string in **HospitalContext.cs** is correct, then apply migrations:

```bash
dotnet ef database update
```

### **4. Build the Application**

```bash
dotnet build
```

### **5. Run the Application**

```bash
dotnet run
```

## Usage Instructions

Once the application is running, a console menu will appear with the following options:

### **1. Patient Management**
- Add, view, update, or delete patient records.

### **2. Doctor Management**
- Add, view, update, or delete doctor records.

### **3. Appointment Management**
- Schedule new appointments.
- View existing appointments (by patient or doctor).
- Cancel appointments.

### **4. Prescription Management**
- Issue prescriptions (link medications with dosage details).
- Automatically generate bills.

### **5. Medication Management**
- Add, view, or update medication details.

### **6. Billing Management**
- View all bills.
- Update bill statuses (e.g., mark as Paid).

Simply enter the corresponding number for the option you want to execute and follow the prompts.

## Project Structure

```
Hospital Management System (Phase 1)
│
├── Data
│   └── HospitalContext.cs           # EF Core database context
│
├── Models
│   ├── Patient.cs                   # Patient entity
│   ├── Doctor.cs                    # Doctor entity
│   ├── Appointment.cs               # Appointment entity and status enum
│   ├── Prescription.cs              # Prescription entity
│   ├── Medication.cs                # Medication entity
│   ├── PrescriptionMedication.cs    # Join entity for Prescription-Medication (includes dosage)
│   └── Bill.cs                      # Bill entity and status enum
│
├── Services                         # Service layer for business logic
│   ├── PatientService.cs
│   ├── DoctorService.cs
│   ├── AppointmentService.cs
│   ├── PrescriptionService.cs
│   ├── MedicationService.cs
│   └── BillingService.cs
│
├── Program.cs                       # Console user interface and entry point
│
└── README.md                        # Project documentation
```

## License

This project is licensed under the **MIT License**. See the LICENSE file for details.

---
### **Contributing**
Contributions are welcome! Feel free to open an issue or submit a pull request.

If you find this project useful, consider giving it a ⭐ on GitHub!
