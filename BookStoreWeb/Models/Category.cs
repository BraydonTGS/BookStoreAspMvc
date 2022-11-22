using System.ComponentModel.DataAnnotations;

namespace BookStoreWeb.Models
{
    public class Category
    {
        // Data Annotations for when we create our script for the DB and our Models //
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }   
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;


    }
}
