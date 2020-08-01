using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    #region -- Tbl_Order_Shipping_T --
    public class OrderShipping : Entities
    {
        public Nullable<int> Id { get; set; }
        public string OrderId { get; set; }
        public string Shipping_Id { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string Address_3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
    #endregion
}
