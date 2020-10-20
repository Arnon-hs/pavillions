namespace Pavilions.dataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShoppingCenter")]
    public partial class ShoppingCenter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShoppingCenter()
        {
            Pavilions = new HashSet<Pavilions>();
        }

        [Key]
        [StringLength(100)]
        public string centerName { get; set; }

        [Required]
        [StringLength(255)]
        public string state { get; set; }

        public double pavilionsQuantity { get; set; }

        [Required]
        [StringLength(255)]
        public string city { get; set; }

        public double price { get; set; }

        public double? priceCoefficient { get; set; }

        public double floors { get; set; }

        [Column(TypeName = "image")]
        public byte[] image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pavilions> Pavilions { get; set; }
    }
}
