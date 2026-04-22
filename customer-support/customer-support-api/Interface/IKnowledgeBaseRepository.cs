using customer_support_api.Dtos;
using customer_support_api.Models;

namespace customer_support_api.Interface
{
    public interface IKnowledgeBaseRepository
    {
        List<KnowledgeBaseArticle> GetAllArticles();
        KnowledgeBaseArticle GetArticle(Guid id);
        List<KnowledgeBaseArticle> SearchArticles(string? title, string? content);

        void AddArticle(KnowledgeBaseArticleAddDto dto);
        void UpdateArticle(Guid id, KnowledgeBaseUpdateDto dto);
        bool DeleteArticle(Guid id);
    }
}
