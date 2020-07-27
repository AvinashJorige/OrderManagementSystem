using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Entities
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }

    #region  -- Customer -- 
    public class Customer
    {
        public int Id { get; set; }
        public string Cust_Id { get; set; }
        public string Cust_Name { get; set; }
        public string Cust_Email { get; set; }
        public string Cust_Password { get; set; }
        public DateTime Cust_DOJ { get; set; }
        public string Cust_Address { get; set; }
        public string Cust_City { get; set; }
        public int Cust_Role { get; set; }
        public bool IsActive { get; set; }
    }
    #endregion

    #region -- Tbl_Order_details --
    public class OrderDetails : Entities
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string  CustId { get; set; }
        public string ProductId { get; set; }
        public DateTime Ord_sale_date { get; set; }
        public DateTime Delivery_date { get; set; }
        public int OrderStatus { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
    }
    #endregion

    #region -- Tbl_Order_Shipping_T --
    public class OrderShipping : Entities
    {
        public int Id { get; set; }
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
        public int Id { get; set; }
        public string StatusCode { get; set; }
        public string StatusName { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
    #endregion

    #region -- Tbl_Order_Status_M -- 
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Order_Id { get; set; }
        public int Order_Status_Code { get; set; }        
        public DateTime UpdatedDate { get; set; }        
        public Guid UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
    #endregion

    #region -- Tbl_Product_T -- 
    public class Products : Entities
    {
        public int Id { get; set; }
        public string Prod_Id { get; set; }
        public string Prod_Name { get; set; }
        public decimal Prod_Weight { get; set; }
        public int Prod_W_UOM { get; set; }
        public string Prod_Height { get; set; }
        public string Prod_H_UOM { get; set; }
        public string Prod_Image_Url { get; set; }
        public string Prod_SKU { get; set; }
        public string Prod_Barcode { get; set; }
        public string Prod_Unit_Price { get; set; }
        public string Prod_Unit_Cost { get; set; }
        public string Prod_AvailableQuantity { get; set; }
    }
    #endregion

    #region -- Tbl_Unit_of_measure_M --
    public class UnitOfMeasure
    {
        public int Id { get; set; }
        public string UOM_Name { get; set; }
        public string UOM_Code { get; set; }
        public bool IsActive { get; set; }
    }
    #endregion

    #region -- Tbl_User_Role_M --
    public class UserRoles
    {
        public int Id { get; set; }
        public string User_Role { get; set; }
        public Guid User_Role_Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
    #endregion

    #region -- Tbl_Users_T -- 
    public class Users : Entities
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string HireDate { get; set; }
        public string BirthDate { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhotoPath { get; set; }
        public string LastDate { get; set; }
        public string Notes { get; set; }
        public string UserPassword { get; set; }
    }
    #endregion
}
