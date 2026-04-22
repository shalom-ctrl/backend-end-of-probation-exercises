using customer_support_api.Data;
using customer_support_api.Interface;
using customer_support_api.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("CustomerSupportDB"));
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IKnowledgeBaseRepository, KnowledgeBaseRepository>();
var app = builder.Build();


using(var scope = app.Services.CreateScope())       
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if(!dbContext.Tickets.Any())
    {
        var ticket1 = new customer_support_api.Models.Ticket
        {
            Id = Guid.NewGuid(),
            Subject = "Issue with login",
            Description = "Unable to login with correct credentials.",
            CreatedAt = DateTime.UtcNow,
            status = customer_support_api.Enums.Status.Open,
            type = customer_support_api.Enums.TicketType.AccountIssue
        };
        var ticket2 = new customer_support_api.Models.Ticket
        {
            Id = Guid.NewGuid(),
            Subject = "Feature request: Dark mode",
            Description = "It would be great to have a dark mode option in the app.",
            CreatedAt = DateTime.UtcNow,
            status = customer_support_api.Enums.Status.Open,
            type = customer_support_api.Enums.TicketType.FeatureRequest
        };
        dbContext.Tickets.AddRange(ticket1, ticket2);
        dbContext.SaveChanges();
    }
}

using(var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if(!dbContext.KnowledgeBaseArticles.Any())
    {
        var article1 = new customer_support_api.Models.KnowledgeBaseArticle
        {
            Id = Guid.NewGuid(),
            Title = "How to reset your password",
            Content = "To reset your password, click on the 'Forgot Password' link on the login page and follow the instructions.",
            Author = "Admin",
            Tags = "password,reset,login",
            CreatedAt = DateTime.UtcNow
        };
        var article2 = new customer_support_api.Models.KnowledgeBaseArticle
        {
            Id = Guid.NewGuid(),
            Title = "Troubleshooting login issues",
            Content = "If you're having trouble logging in, try clearing your browser cache and cookies, or try using a different browser.",
            Author = "Admin",
            Tags = "login,troubleshooting",
            CreatedAt = DateTime.UtcNow
        };
        dbContext.KnowledgeBaseArticles.AddRange(article1, article2);
        dbContext.SaveChanges();
    }
} 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
