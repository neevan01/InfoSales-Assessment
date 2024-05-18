using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSales.DomainL
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Customer Name is Required.")]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Customer Address is Required.")]
        public string Address { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(10)")]
        [Required(ErrorMessage = "Customer Phone is Required.")]
        public string Phone { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
