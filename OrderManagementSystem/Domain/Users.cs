using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    #region -- Tbl_Users_T -- 
    public class Users : Entities
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Nullable<DateTime> HireDate { get; set; }
        public Nullable<DateTime> BirthDate { get; set; }
        public Nullable<int> Role { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhotoPath { get; set; }
        public Nullable<DateTime> LastDate { get; set; }
        public string Notes { get; set; }
        public string UserPassword { get; set; }
    }
    #endregion
}
