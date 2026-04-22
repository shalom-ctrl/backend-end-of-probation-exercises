using customer_support_api.Models;
using Microsoft.EntityFrameworkCore;

namespace customer_support_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<BugReport> BugReports { get; set; } = null!;
        public DbSet<FeatureRequest> FeatureRequests { get; set; } = null!;
        public DbSet<KnowledgeBaseArticle> KnowledgeBaseArticles { get; set; } = null!;
    }
}
