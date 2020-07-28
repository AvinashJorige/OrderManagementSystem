using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{
    public class OrderShippingMap : EntityTypeConfiguration<OrderShipping>
    {
        public OrderShippingMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.OrderId)           .IsOptional().HasMaxLength(30);
            this.Property(t => t.Shipping_Id)       .IsOptional().HasMaxLength(50);
            this.Property(t => t.Address_1)         .IsOptional().HasMaxLength(60);
            this.Property(t => t.Address_2)         .IsOptional().HasMaxLength(60);
            this.Property(t => t.Address_3)         .IsOptional().HasMaxLength(60);
            this.Property(t => t.City)              .IsOptional().HasMaxLength(50);
            this.Property(t => t.State)             .IsOptional().HasMaxLength(50);
            this.Property(t => t.Country)           .IsOptional().HasMaxLength(30);
            this.Property(t => t.PostalCode)        .IsOptional().HasMaxLength(30);
            this.Property(t => t.CreatedBy)         .IsOptional();
            this.Property(t => t.CreatedDate)       .IsOptional();
            this.Property(t => t.UpdatedDate)       .IsOptional();
            this.Property(t => t.UpdatedBy)         .IsOptional();
            this.Property(t => t.IsActive)          .IsOptional();

            this.ToTable("Tbl_Order_Shipping_T");
            this.Property(t => t.Id)            .HasColumnName("Id");
            this.Property(t => t.OrderId)       .HasColumnName("OrderId");
            this.Property(t => t.Shipping_Id)   .HasColumnName("Shipping_Id");
            this.Property(t => t.Address_1)     .HasColumnName("Address_1");
            this.Property(t => t.Address_2)     .HasColumnName("Address_2");
            this.Property(t => t.Address_3)     .HasColumnName("Address_3");
            this.Property(t => t.City)          .HasColumnName("City");
            this.Property(t => t.State)         .HasColumnName("State");
            this.Property(t => t.Country)       .HasColumnName("Country");
            this.Property(t => t.PostalCode)    .HasColumnName("PostalCode");
            this.Property(t => t.CreatedBy)     .HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate)   .HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedDate)   .HasColumnName("UpdatedDate");
            this.Property(t => t.UpdatedBy)     .HasColumnName("UpdatedBy");
            this.Property(t => t.IsActive)      .HasColumnName("IsActive");
        }
    }
}
