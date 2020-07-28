using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{
    public class OrderDetailsMap : EntityTypeConfiguration<OrderDetails>
    {
        public OrderDetailsMap()
        {
            this.HasKey(t=> t.Id);
            this.Property(t => t.OrderId)       .IsOptional().HasMaxLength(50);
            this.Property(t => t.CustId)        .IsOptional().HasMaxLength(20);
            this.Property(t => t.ProductId)     .IsOptional().HasMaxLength(30);
            this.Property(t => t.Ord_sale_date) .IsOptional();
            this.Property(t => t.Delivery_date) .IsOptional();
            this.Property(t => t.OrderStatus)   .IsOptional();
            this.Property(t => t.Quantity)      .IsOptional();
            this.Property(t => t.Amount)        .IsOptional();
            this.Property(t => t.CreatedDate)   .IsOptional();
            this.Property(t => t.UpdatedDate)   .IsOptional();
            this.Property(t => t.CreatedBy)     .IsOptional();
            this.Property(t => t.UpdatedBy)     .IsOptional();
            this.Property(t => t.IsActive)      .IsOptional();

            this.ToTable("Tbl_Order_Details");
            this.Property(t => t.Id)            .HasColumnName("Id");
            this.Property(t => t.CustId)        .HasColumnName("CustId");
            this.Property(t => t.ProductId)     .HasColumnName("ProductId");
            this.Property(t => t.Ord_sale_date) .HasColumnName("Ord_sale_date");
            this.Property(t => t.Delivery_date) .HasColumnName("Delivery_date");
            this.Property(t => t.OrderStatus)   .HasColumnName("OrderStatus");
            this.Property(t => t.Quantity)      .HasColumnName("Quantity");
            this.Property(t => t.Amount)        .HasColumnName("Amount");
            this.Property(t => t.CreatedDate)   .HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedDate)   .HasColumnName("UpdatedDate");
            this.Property(t => t.CreatedBy)     .HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedBy)     .HasColumnName("UpdatedBy");
            this.Property(t => t.IsActive)      .HasColumnName("IsActive");
        }
    }
}
