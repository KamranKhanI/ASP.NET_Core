using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tesr
{
    public partial class CustomerCustomerDemo
    {
        [StringLength(5)]
        public string CustomerID { get; set; }
        [StringLength(10)]
        public string CustomerTypeID { get; set; }

        [ForeignKey("CustomerID")]
        [InverseProperty("CustomerCustomerDemo")]
        public virtual Customers Customer { get; set; }
        [ForeignKey("CustomerTypeID")]
        [InverseProperty("CustomerCustomerDemo")]
        public virtual CustomerDemographics CustomerType { get; set; }
    }
}