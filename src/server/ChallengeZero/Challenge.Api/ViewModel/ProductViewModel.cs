using System;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Api.ViewModel
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Id = Guid.NewGuid();
            Category = new CategoryViewModel();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [MinLength(2, ErrorMessage = "The minimum name length is {1}")]
        [MaxLength(150, ErrorMessage = "Maximum name length is {1}")]
        [Display(Name = "Product name")]
        public string Name { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid Currency Format")]
        public decimal Price { get; set; }

        public CategoryViewModel Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
