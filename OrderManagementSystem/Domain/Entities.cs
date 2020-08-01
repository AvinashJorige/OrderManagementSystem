using System;

namespace Domain
{
    public class Entities
    {
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
        public Nullable<Guid> CreatedBy { get; set; }
        public Nullable<Guid> UpdatedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }

    #region -- USP_GET_CUSTOMERORDERS -- 
    public class CustomerOrders
    {
        public Customer CustomerDetails { get; set; }
        public System.Collections.Generic.ICollection<OrderDetails> CustOrderDetailList { get; set; }
        public System.Collections.Generic.ICollection<Products> CustProductList { get; set; }
        public System.Collections.Generic.ICollection<OrderShipping> CustOrderShippingDetails { get; set; }
    }
    #endregion
}
