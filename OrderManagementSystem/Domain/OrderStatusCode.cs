using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    #region -- Tbl_Order_Status_Code_M -- 
    public class OrderStatusCode
    {
        public Nullable<int> Id { get; set; }
        public string StatusCode { get; set; }
        public string StatusName { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<Guid> CreatedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
    #endregion
}
