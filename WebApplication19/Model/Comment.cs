using System.ComponentModel.DataAnnotations;

namespace WebApplication19.Model
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [MaxLength(32)]
        [Required]
        public string CommentTitle { get; set; }

        [Required]
        public int CommentRate { get; set; }

        [MaxLength(100)]
        [Required]
        public string CommentDescription { get; set; }

        [MaxLength(32)]
        [Required]
        public string Email { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
    public class CommentDto
    {
        public string CommentTitle { get; set; }

        [Required]
        public int CommentRate { get; set; }

        [MaxLength(100)]
        [Required]
        public string CommentDescription { get; set; }
        public int ProductId { get; set; }


    }
}
