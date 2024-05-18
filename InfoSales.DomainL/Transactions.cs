using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InfoSales.DomainL
{
    public class Transactions
    {
        [Key]
        public int TransactionId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a customer.")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a product.")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity should be greater than 0.")]
        public int Quantity { get; set; } = 1;

        [Column(TypeName = "decimal(18, 2)")]
        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }

        [NotMapped]
        public string CustomerName
        {
            get
            {
                return Customer == null ? "" : Customer.Name;
            }
        }

        [NotMapped]
        public string ProductName
        {
            get
            {
                return Product == null ? "" : Product.Title;
            }
        }

        [NotMapped]
        public decimal ProductRate
        {
            get
            {
                return Product == null ? 0 : Product.Rate;
            }
        }

        [NotMapped]
        public string FormattedAmount
        {
            get
            {
                return TotalAmount.ToString("C2");
            }
        }
        [NotMapped]
        public string ProductTitle { get; set; } = string.Empty;
    }
}
