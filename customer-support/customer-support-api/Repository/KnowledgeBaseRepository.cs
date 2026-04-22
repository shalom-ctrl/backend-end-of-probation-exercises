using customer_support_api.Data;
using customer_support_api.Dtos;
using customer_support_api.Interface;
using customer_support_api.Models;

namespace customer_support_api.Repository
{
    public class KnowledgeBaseRepository : IKnowledgeBaseRepository
    {
        private readonly ApplicationDbContext _context;

        public KnowledgeBaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddArticle(KnowledgeBaseArticleAddDto dto)
        {
            var article = new KnowledgeBaseArticle
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Content = dto.Content,
                Author = dto.Author,
                Tags = dto.Tags,
                CreatedAt = DateTime.UtcNow
            };
            _context.KnowledgeBaseArticles.Add(article);
            _context.SaveChanges();
        }

        public bool DeleteArticle(Guid id)
        {
            var articleexists = _context.KnowledgeBaseArticles.Find(id);
            if(articleexists == null)
            {
                return false;
            }
            _context.KnowledgeBaseArticles.Remove(articleexists);
            _context.SaveChanges();
            return true;
        }

        public List<KnowledgeBaseArticle> GetAllArticles()
        {
            return _context.KnowledgeBaseArticles.ToList();
        }

        public KnowledgeBaseArticle GetArticle(Guid id)
        {
            var article = _context.KnowledgeBaseArticles.FirstOrDefault(a => a.Id == id);
            return article;
        }

        public List<KnowledgeBaseArticle> SearchArticles(string? title, string? content)
        {
            var query = _context.KnowledgeBaseArticles.Where(a => (string.IsNullOrEmpty(title) || a.Title.Contains(title)) &&
                                        (string.IsNullOrEmpty(content) || a.Content.Contains(content)));
            return query.ToList();  
        }

        public void UpdateArticle(Guid id, KnowledgeBaseUpdateDto dto)
        {
            var existingArticle = _context.KnowledgeBaseArticles.Find(id);
            if(existingArticle == null)
            {
                throw new Exception("Article not found");
            }
            existingArticle.Title = dto.Title;
            existingArticle.Content = dto.Content;
            existingArticle.Author = dto.Author;
            existingArticle.Tags = dto.Tags;
            _context.KnowledgeBaseArticles.Update(existingArticle);
            _context.SaveChanges();
        }
    }
}
