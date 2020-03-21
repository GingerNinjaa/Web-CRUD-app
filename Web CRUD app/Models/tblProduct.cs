using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_CRUD_app.Models
{
    [Table("tblProduct")]
    public class tblProduct
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength (150)]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [MaxLength (20)]
        public string UnitOfMeasure { get; set; }
    }
}
