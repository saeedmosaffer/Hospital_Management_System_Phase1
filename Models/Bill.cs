using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System__Phase_1_.Models
{
    public enum BillStatus
    {
        Paid,
        Unpaid
    }
    internal class Bill
    {
        public int BillId { get; set; }
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public decimal Amount { get; set; }
        public DateTime BillDate { get; set; }
        public BillStatus Status { get; set; }
    }
}
