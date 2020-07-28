using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{
    public class UsersMap : EntityTypeConfiguration<Users>
    {
        public UsersMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.UserId)        .IsOptional().HasMaxLength(30);
            this.Property(t => t.UserName)      .IsOptional().HasMaxLength(30);
            this.Property(t => t.Email)         .IsOptional().HasMaxLength(60);
            this.Property(t => t.HireDate)      .IsOptional();
            this.Property(t => t.BirthDate)     .IsOptional();
            this.Property(t => t.Role)          .IsOptional();
            this.Property(t => t.Address)       .IsOptional().HasMaxLength(100);
            this.Property(t => t.City)          .IsOptional().HasMaxLength(20);
            this.Property(t => t.PostalCode)    .IsOptional().HasMaxLength(10);
            this.Property(t => t.PhotoPath)     .IsOptional().HasMaxLength(150);
            this.Property(t => t.LastDate)      .IsOptional();
            this.Property(t => t.Notes)         .IsOptional().HasMaxLength(10);
            this.Property(t => t.CreatedBy)     .IsOptional();
            this.Property(t => t.UpdatedBy)     .IsOptional();
            this.Property(t => t.CreatedDate)   .IsOptional();
            this.Property(t => t.UpdatedDate)   .IsOptional();
            this.Property(t => t.IsActive)      .IsOptional();
            this.Property(t => t.UserPassword)  .IsOptional();

            this.ToTable("Tbl_Users_T");
            this.Property(t => t.Id)            .HasColumnName("Id");
            this.Property(t => t.UserId)        .HasColumnName("UserId");
            this.Property(t => t.UserName)      .HasColumnName("UserName");
            this.Property(t => t.Email)         .HasColumnName("Email");
            this.Property(t => t.HireDate)      .HasColumnName("HireDate");
            this.Property(t => t.BirthDate)     .HasColumnName("BirthDate");
            this.Property(t => t.Role)          .HasColumnName("Role");
            this.Property(t => t.Address)       .HasColumnName("Address");
            this.Property(t => t.City)          .HasColumnName("City");
            this.Property(t => t.PostalCode)    .HasColumnName("PostalCode");
            this.Property(t => t.PhotoPath)     .HasColumnName("PhotoPath");
            this.Property(t => t.LastDate)      .HasColumnName("LastDate");
            this.Property(t => t.Notes)         .HasColumnName("Notes");
            this.Property(t => t.CreatedBy)     .HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedBy)     .HasColumnName("UpdatedBy");
            this.Property(t => t.CreatedDate)   .HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedDate)   .HasColumnName("UpdatedDate");
            this.Property(t => t.IsActive)      .HasColumnName("IsActive");
            this.Property(t => t.UserPassword)  .HasColumnName("UserPassword");
        }
    }
}
