using System;
using TimeRegistration.Core.BL.Contracts;
using TimeRegistration.Core.DL.SQLite;

namespace TimeRegistration.Core.BL
{
    public class TimeRegistrations : IBusinessEntity
    {
        public TimeRegistrations()
        {
        }
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int CustomerID { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime RegistrationHourFrom { get; set; }
        public DateTime RegistrationHourTo { get; set; }
        public bool IsToBeInvoiced { get; set; }
        public int Status { get; set; }
        
    }
}
