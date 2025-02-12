using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HabsForum.Models
{
    public class Discussion
    {
        //primary key 
        public int DiscussionId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        [Display(Name = "Filename")]
        public string ImageFilename { get; set; } = string.Empty;

        [NotMapped] // Not mapped with EF
        [Display(Name = "Image")]
        public IFormFile? ImageFile { get; set; } // nullable (photo upload optional)

        [Display(Name = "Created")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        //navigation property
        public List<Comment>? Comments { get; set; }
    }
}
