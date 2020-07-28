using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class OrderStatusMap : EntityTypeConfiguration<OrderStatus>
    {
        public OrderStatusMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Order_Id).IsOptional().HasMaxLength(2);
            this.Property(t => t.Order_Status_Code).IsOptional();
            this.Property(t => t.UpdatedDate).IsOptional();
            this.Property(t => t.UpdatedBy).IsOptional();
            this.Property(t => t.IsActive).IsOptional();

            this.ToTable("Tbl_Order_Status_M");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Order_Id).HasColumnName("Order_Id");
            this.Property(t => t.Order_Status_Code).HasColumnName("Order_Status_Code");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
