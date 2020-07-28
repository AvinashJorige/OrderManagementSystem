using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{
    public class UnitOfMeasureMap: EntityTypeConfiguration<UnitOfMeasure>
    {
        public UnitOfMeasureMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.UOM_Name).IsOptional().HasMaxLength(30);
            this.Property(t => t.UOM_Code).IsOptional().HasMaxLength(5);
            this.Property(t => t.IsActive).IsOptional();

            this.ToTable("Tbl_Unit_of_measure_M");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UOM_Name).HasColumnName("UOM_Name");
            this.Property(t => t.UOM_Code).HasColumnName("UOM_Code");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
