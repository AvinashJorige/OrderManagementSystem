using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    #region  -- Customer -- 
    public class Customer
    {
        public Nullable<int> Id { get; set; }
        public string Cust_Id { get; set; }
        public string Cust_Name { get; set; }
        public string Cust_Email { get; set; }
        public string Cust_Password { get; set; }
        public Nullable<DateTime> Cust_DOJ { get; set; }
        public string Cust_Address { get; set; }
        public string Cust_City { get; set; }
        public Nullable<int> Cust_Role { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
    #endregion
}
