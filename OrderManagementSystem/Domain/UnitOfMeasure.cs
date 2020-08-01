using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    #region -- Tbl_Unit_of_measure_M --
    public class UnitOfMeasure
    {
        public Nullable<int> Id { get; set; }
        public string UOM_Name { get; set; }
        public string UOM_Code { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
    #endregion
}
