using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSales.DomainL
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Title is Required.")]
        public string Title { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
        public decimal Rate { get; set; }

        public bool Status { get; set; } = true;
    }
}
