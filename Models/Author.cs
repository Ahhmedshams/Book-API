using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Book_API.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        [AllowNull]
        public string? Biographpy { get; set; }

        [AllowNull]
        public string ImageName { get; set; }




    }
}
