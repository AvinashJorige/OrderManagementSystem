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

    #region -- Tbl_Order_details --
    public class OrderDetails : Entities
    {
        public Nullable<int> Id { get; set; }
        public string OrderId { get; set; }
        public string  CustId { get; set; }
        public string ProductId { get; set; }
        public Nullable<DateTime> Ord_sale_date { get; set; }
        public Nullable<DateTime> Delivery_date { get; set; }
        public Nullable<int> OrderStatus { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
    }
    #endregion

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

    #region -- Tbl_Product_T -- 
    public class Products : Entities
    {
        public Nullable<int> Id { get; set; }
        public string Prod_Id { get; set; }
        public string Prod_Name { get; set; }
        public decimal Prod_Weight { get; set; }
        public Nullable<int> Prod_W_UOM { get; set; }
        public decimal Prod_Height { get; set; }
        public Nullable<int> Prod_H_UOM { get; set; }
        public string Prod_Image_Url { get; set; }
        public Nullable<int> Prod_SKU { get; set; }
        public string Prod_Barcode { get; set; }
        public decimal Prod_Unit_Price { get; set; }
        public decimal Prod_Unit_Cost { get; set; }
        public Nullable<int> Prod_AvailableQuantity { get; set; }
    }
    #endregion

    #region -- Tbl_Unit_of_measure_M --
    public class UnitOfMeasure
    {
        public Nullable<int> Id { get; set; }
        public string UOM_Name { get; set; }
        public string UOM_Code { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
    #endregion

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
