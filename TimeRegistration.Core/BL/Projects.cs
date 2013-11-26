using System;
using TimeRegistration.Core.BL.Contracts;
using TimeRegistration.Core.DL.SQLite;

namespace TimeRegistration.Core.BL
{
    public class Projects : IBusinessEntity
    {
        public Projects()
        {
        }
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
    }
}
