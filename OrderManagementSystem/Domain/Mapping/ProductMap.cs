using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Products>
    {
        public ProductMap()
        {

            this.HasKey(t => t.Id);
            this.Property(t => t.Prod_Id)                   .IsOptional().HasMaxLength(20);
            this.Property(t => t.Prod_Name)                 .IsOptional().HasMaxLength(30);
            this.Property(t => t.Prod_Weight)               .IsOptional();
            this.Property(t => t.Prod_W_UOM)                .IsOptional();
            this.Property(t => t.Prod_Height)               .IsOptional();
            this.Property(t => t.Prod_H_UOM)                .IsOptional();
            this.Property(t => t.Prod_Image_Url)            .IsOptional().HasMaxLength(50);
            this.Property(t => t.Prod_SKU)                  .IsOptional();
            this.Property(t => t.Prod_Barcode)              .IsOptional().HasMaxLength(20);
            this.Property(t => t.Prod_Unit_Price)           .IsOptional();
            this.Property(t => t.Prod_Unit_Cost)            .IsOptional();
            this.Property(t => t.Prod_AvailableQuantity)    .IsOptional();
            this.Property(t => t.CreatedDate)               .IsOptional();
            this.Property(t => t.UpdatedBy)                 .IsOptional();
            this.Property(t => t.CreatedBy)                 .IsOptional();
            this.Property(t => t.UpdatedDate)               .IsOptional();
            this.Property(t => t.IsActive)                  .IsOptional();


            this.ToTable("Tbl_Product_T");
            this.Property(t => t.Id)                        .HasColumnName("Id");
            this.Property(t => t.Prod_Id)                   .HasColumnName("Prod_Id");
            this.Property(t => t.Prod_Name)                 .HasColumnName("Prod_Name");
            this.Property(t => t.Prod_Weight)               .HasColumnName("Prod_Weight");
            this.Property(t => t.Prod_W_UOM)                .HasColumnName("Prod_W_UOM");
            this.Property(t => t.Prod_Height)               .HasColumnName("Prod_Height");
            this.Property(t => t.Prod_H_UOM)                .HasColumnName("Prod_H_UOM");
            this.Property(t => t.Prod_Image_Url)            .HasColumnName("Prod_Image_Url");
            this.Property(t => t.Prod_SKU)                  .HasColumnName("Prod_SKU");
            this.Property(t => t.Prod_Barcode)              .HasColumnName("Prod_Barcode");
            this.Property(t => t.Prod_Unit_Price)           .HasColumnName("Prod_Unit_Price");
            this.Property(t => t.Prod_Unit_Cost)            .HasColumnName("Prod_Unit_Cost");
            this.Property(t => t.Prod_AvailableQuantity)    .HasColumnName("Prod_AvailableQuantity");
            this.Property(t => t.CreatedDate)               .HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedBy)                 .HasColumnName("UpdatedBy");
            this.Property(t => t.CreatedBy)                 .HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedDate)               .HasColumnName("UpdatedDate");
            this.Property(t => t.IsActive)                  .HasColumnName("IsActive");
        }
    }
}
