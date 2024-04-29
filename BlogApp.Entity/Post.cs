namespace BlogApp.Entity
{
    public class Post
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
        public DateTime PublishedOn { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }

        // Relational Properties
        
        public virtual User User { get; set; } = null!;
        public virtual List<Tag> Tags { get; set; } = new List<Tag>();
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
