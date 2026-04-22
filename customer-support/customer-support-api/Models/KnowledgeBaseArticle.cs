namespace customer_support_api.Models
{
    public class KnowledgeBaseArticle
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Tags { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
