using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetComments()
        {
            var comments = _context.UserComments.ToList();
            return Ok(comments);

        }
        [HttpPost]
        public IActionResult PostComment([FromBody] UserComment comment)
        {
            _context.UserComments.Add(comment);
            _context.SaveChanges();
            return Ok("yorum eklendi");

        }

        [HttpPut]
        public IActionResult PutComment([FromBody] UserComment comment)
        {
            _context.UserComments.Update(comment);
            _context.SaveChanges();
            return Ok("yorum güncellendi");
        }
        [HttpDelete()]
        public IActionResult DeleteComment(int id)
        {
            var comment = _context.UserComments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }
            _context.UserComments.Remove(comment);
            _context.SaveChanges();
            return Ok("yorum silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var comment = _context.UserComments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);

        }

        [HttpGet("commentListByProductId")]
        public IActionResult GetCommentListByProductId(string productId)
        {
            var comments = _context.UserComments.Where(c => c.ProductId == productId).ToList();
            return Ok(comments);
        }
    }
}
