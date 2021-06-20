namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public decimal? UnitCost { get; set; }

        public int? Quantity { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        [StringLength(500)]
        public string Decription { get; set; }

        public bool? Status { get; set; }
    }
}
