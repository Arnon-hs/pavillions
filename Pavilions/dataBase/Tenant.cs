namespace Pavilions.dataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tenant")]
    public partial class Tenant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tenantId { get; set; }

        public int rentId { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(30)]
        public string number { get; set; }

        [Required]
        [StringLength(150)]
        public string address { get; set; }
    }
}
