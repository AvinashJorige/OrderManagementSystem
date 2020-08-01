using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{
    public class CustomerMapping: EntityTypeConfiguration<Customer>
    {
        public CustomerMapping()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Cust_Id)       .IsOptional().HasMaxLength(20);
            this.Property(t => t.Cust_Name)     .IsOptional().HasMaxLength(50);
            this.Property(t => t.Cust_Email)    .IsOptional().HasMaxLength(60);
            this.Property(t => t.Cust_DOJ)      .IsOptional();
            this.Property(t => t.Cust_Address)  .IsOptional().HasMaxLength(100);
            this.Property(t => t.Cust_City)     .IsOptional().HasMaxLength(30);
            this.Property(t => t.Cust_Role)     .IsOptional();
            this.Property(t => t.Cust_Password) .IsOptional();
            this.Property(t => t.IsActive)      .IsOptional();

            this.ToTable("Tbl_Customer_T");
            this.Property(t => t.Id)            .HasColumnName("Id");
            this.Property(t => t.Cust_Id)       .HasColumnName("Cust_Id");
            this.Property(t => t.Cust_Name)     .HasColumnName("Cust_Name");
            this.Property(t => t.Cust_Email)    .HasColumnName("Cust_Email");
            this.Property(t => t.Cust_DOJ)      .HasColumnName("Cust_DOJ");
            this.Property(t => t.Cust_Address)  .HasColumnName("Cust_Address");
            this.Property(t => t.Cust_City)     .HasColumnName("Cust_City");
            this.Property(t => t.Cust_Role)     .HasColumnName("Cust_Role");
            this.Property(t => t.Cust_Password) .HasColumnName("Cust_Password");
            this.Property(t => t.IsActive)      .HasColumnName("IsActive");
        }
    }
}
