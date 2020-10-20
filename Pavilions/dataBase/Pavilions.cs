namespace Pavilions.dataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pavilions
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string centerName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string pavilionNum { get; set; }

        [Key]
        [Column(Order = 2)]
        public double floor { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string state { get; set; }

        public double? square { get; set; }

        public double? meterPrice { get; set; }

        [Key]
        [Column(Order = 4)]
        public double priceCoefficient { get; set; }

        public virtual ShoppingCenter ShoppingCenter { get; set; }
    }
}
