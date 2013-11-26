using System;
using TimeRegistration.Core.DL.SQLite;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace TimeRegistration.Core.BL.Contracts
{
    public abstract class BusinessEntityBase : IBusinessEntity
    {
        public BusinessEntityBase()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
