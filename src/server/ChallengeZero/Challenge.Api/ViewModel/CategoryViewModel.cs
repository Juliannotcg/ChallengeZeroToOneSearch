using System;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Api.ViewModel
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [MinLength(2, ErrorMessage = "The minimum name length is {1}")]
        [MaxLength(150, ErrorMessage = "Maximum name length is {1}")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
