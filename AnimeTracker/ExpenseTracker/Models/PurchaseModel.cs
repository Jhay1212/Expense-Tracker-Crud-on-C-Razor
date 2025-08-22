using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name is Required")]
        [StringLength(128, ErrorMessage = "Max length is 128")]
        public string ProductName { get; set; } = "";

        [Range(0, 9999999, ErrorMessage = "Price must be a valid number")]
        public double ProductPrice { get; set; }

        public string Category { get; set; } = "";

        [Range(1, 999, ErrorMessage = "Quantity must be a valid number")]
        public int Quantity { get; set; } = 1;
        public double TotalPrice
        {
            get {return Quantity * ProductPrice; } // set the default value to the actual total price 
        }
        [DataType(DataType.Date)]
        public DateOnly DatePurchased { get; set; }


  
    }
    
  
}