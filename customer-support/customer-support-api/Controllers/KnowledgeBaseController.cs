using customer_support_api.Dtos;
using customer_support_api.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace customer_support_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeBaseController : ControllerBase
    {
        private readonly IKnowledgeBaseRepository _knowledgeBase;

        public KnowledgeBaseController(IKnowledgeBaseRepository knowledgeBase)
        {
            _knowledgeBase = knowledgeBase;
        }
        
        [HttpGet]
        public IActionResult GetAllArticles()
        {
            var articles = _knowledgeBase.GetAllArticles();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public IActionResult GetArticle(Guid id)
        {
            var article = _knowledgeBase.GetArticle(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpGet("search")]
        public IActionResult SearchArticles(string? title, string? content)
        {
            var articles = _knowledgeBase.SearchArticles(title, content);
            if (articles == null || articles.Count == 0)
            {
                return NotFound();
            }
            return Ok(articles);
        }

        [HttpPost]
        public IActionResult AddArticle(KnowledgeBaseArticleAddDto dto)
        {
            try
            {
                _knowledgeBase.AddArticle(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateArticle(Guid id, KnowledgeBaseUpdateDto dto)
        {
            try
            {
                _knowledgeBase.UpdateArticle(id, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArticle(Guid id)
        {
            try
            {
                var result = _knowledgeBase.DeleteArticle(id);
                if (!result)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
    }
}
