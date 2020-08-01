using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    #region -- Tbl_User_Role_M --
    public class UserRoles
    {
        public Nullable<int> Id { get; set; }
        public string User_Role { get; set; }
        public Nullable<Guid> User_Role_Id { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<Guid> CreatedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
    #endregion
}
