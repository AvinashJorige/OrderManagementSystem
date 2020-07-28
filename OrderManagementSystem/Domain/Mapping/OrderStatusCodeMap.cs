using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class OrderStatusCodeMap : EntityTypeConfiguration<OrderStatusCode>
    {
        public OrderStatusCodeMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.StatusCode)    .IsOptional().HasMaxLength(2);
            this.Property(t => t.StatusName)    .IsOptional().HasMaxLength(30);
            this.Property(t => t.CreatedDate)   .IsOptional();
            this.Property(t => t.CreatedBy)     .IsOptional();
            this.Property(t => t.IsActive)      .IsOptional();


            this.ToTable("Tbl_Order_Status_Code_M");
            this.Property(t => t.Id)            .HasColumnName("Id");
            this.Property(t => t.StatusCode)    .HasColumnName("StatusCode");
            this.Property(t => t.StatusName)    .HasColumnName("StatusName");
            this.Property(t => t.CreatedDate)   .HasColumnName("CreatedDate");
            this.Property(t => t.CreatedBy)     .HasColumnName("CreatedBy");
            this.Property(t => t.IsActive)      .HasColumnName("IsActive");
        }
    }
}
