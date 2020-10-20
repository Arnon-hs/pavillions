namespace Pavilions.dataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string login { get; set; }

        [Required]
        [StringLength(255)]
        public string password { get; set; }

        [Required]
        [StringLength(255)]
        public string role { get; set; }

        [Required]
        [StringLength(255)]
        public string phone { get; set; }

        [Required]
        [StringLength(255)]
        public string sex { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string avatar { get; set; }
    }
}
