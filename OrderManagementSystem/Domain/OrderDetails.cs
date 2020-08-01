using System;

namespace Domain
{
    #region -- Tbl_Order_details --
    public class OrderDetails : Entities
    {
        public Nullable<int> Id { get; set; }
        public string OrderId { get; set; }
        public string CustId { get; set; }
        public string ProductId { get; set; }
        public Nullable<DateTime> Ord_sale_date { get; set; }
        public Nullable<DateTime> Delivery_date { get; set; }
        public Nullable<int> OrderStatus { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
    }
    #endregion
}
