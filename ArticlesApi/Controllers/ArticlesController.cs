using ArticlesApi.Contracts.Dto;
using ArticlesApi.Contracts.Model;
using ArticlesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArticlesApi.Controllers
{
    [Controller]
    [Route("/api/articles")]
    public class ArticlesController : Controller
    {
        private Service<Articles, ArticlesRequest, ArticlesResponse, ArticlesUpdate> _assembler;
        public ArticlesController(Service<Articles, ArticlesRequest, ArticlesResponse, ArticlesUpdate> assembler)
        {
            _assembler = assembler;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOneArticle([FromRoute] int id)
        {
            return Ok(_assembler.GetById(id));
        }

        [HttpGet]
        public IActionResult GetArticles([FromQuery] int offset, [FromQuery] int limit)
        {
            Page<ArticlesResponse> page = _assembler.GetAll(offset, limit);
            Response.Headers.Add("X-Total-Count", page.TotalItems.ToString());
            return Ok(page.Elements);
        }

        [HttpPost]
        public IActionResult Save([FromBody] ArticlesRequest req)
        {
            ArticlesResponse response = _assembler.Create(req);
            return Created("", response);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Modify([FromRoute(Name = "id")] int articlesId, [FromBody] ArticlesUpdate update)
        {
            ArticlesResponse? response = _assembler.Update(update, articlesId);
            if (response == null) return BadRequest(new ArticlesResponse());
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _assembler.Delete(id);
            return NoContent();
        }
    }
}
