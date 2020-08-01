using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    #region -- Tbl_Order_Status_M -- 
    public class OrderStatus
    {
        public Nullable<int> Id { get; set; }
        public string Order_Id { get; set; }
        public Nullable<int> Order_Status_Code { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
        public Nullable<Guid> UpdatedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
    #endregion
}
