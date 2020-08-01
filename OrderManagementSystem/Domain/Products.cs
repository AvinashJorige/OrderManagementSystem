using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
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
}
