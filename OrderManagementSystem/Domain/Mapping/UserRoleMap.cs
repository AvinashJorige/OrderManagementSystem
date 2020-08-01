using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
namespace Domain.Mapping
{
    public class UserRoleMap : EntityTypeConfiguration<UserRoles>
    {
        public UserRoleMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.User_Role)     .IsOptional().HasMaxLength(50);
            this.Property(t => t.CreatedDate)   .IsOptional();
            this.Property(t => t.CreatedBy)     .IsOptional();
            this.Property(t => t.IsActive)      .IsOptional();
            this.Property(t => t.User_Role_Id)  .IsOptional();

            this.ToTable("Tbl_User_Role_M");
            this.Property(t => t.Id)            .HasColumnName("Id");
            this.Property(t => t.User_Role)     .HasColumnName("User_Role");
            this.Property(t => t.CreatedDate)   .HasColumnName("CreatedDate");
            this.Property(t => t.CreatedBy)     .HasColumnName("CreatedBy");
            this.Property(t => t.IsActive)      .HasColumnName("IsActive");
            this.Property(t => t.User_Role_Id)  .HasColumnName("User_Role_Id");
        }
    }
}
