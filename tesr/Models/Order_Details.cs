using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tesr
{
    [Table("Order Details")]
    public partial class Order_Details
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        [ForeignKey("OrderID")]
        [InverseProperty("Order_Details")]
        public virtual Orders Order { get; set; }
        [ForeignKey("ProductID")]
        [InverseProperty("Order_Details")]
        public virtual Products Product { get; set; }
    }
}