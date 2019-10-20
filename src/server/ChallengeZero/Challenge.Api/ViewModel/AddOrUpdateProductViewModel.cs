using System;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Api.ViewModel
{
    public class AddOrUpdateProductViewModel
    {
        public AddOrUpdateProductViewModel()
        {
            Id = Guid.NewGuid();
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

        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Category")]
        public Guid CategoryId { get; set; }
    }
}
