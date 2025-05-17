using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SolidBlogsApi.Models
{
    public class Blog
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; } = default!;
        
        [Required]
        public string Content { get; set; } = default!;
        
        [Required]
        public string Category { get; set; } = default!;
        
        public List<string> Tags { get; set; } = new List<string>();
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
    }
}