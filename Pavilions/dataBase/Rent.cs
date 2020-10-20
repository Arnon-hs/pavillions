namespace Pavilions.dataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rent")]
    public partial class Rent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rentID { get; set; }

        public int tenantID { get; set; }

        [Required]
        [StringLength(100)]
        public string centerName { get; set; }

        public int staffId { get; set; }

        [Required]
        [StringLength(30)]
        public string pavilionNum { get; set; }

        [Required]
        [StringLength(50)]
        public string state { get; set; }

        [Column(TypeName = "date")]
        public DateTime rentStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime rentEnd { get; set; }
    }
}
