using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common
{
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string name { get; set; }
        
        [Required]
        public int availability { get; set; }

        [Required]
        public string description { get; set; }
    }
}
