using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tesr
{
    public partial class EmployeeTerritories
    {
        public int EmployeeID { get; set; }
        [StringLength(20)]
        public string TerritoryID { get; set; }

        [ForeignKey("EmployeeID")]
        [InverseProperty("EmployeeTerritories")]
        public virtual Employees Employee { get; set; }
        [ForeignKey("TerritoryID")]
        [InverseProperty("EmployeeTerritories")]
        public virtual Territories Territory { get; set; }
    }
}