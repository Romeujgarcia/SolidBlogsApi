using Microsoft.AspNetCore.Mvc;
using SolidBlogsApi.Models;
using SolidBlogsApi.Services;

namespace SolidBlogsApi.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogsService _blogsService;
        private readonly ILogger<BlogsController> _logger;

        public BlogsController(IBlogsService blogsService, ILogger<BlogsController> logger)
        {
            _blogsService = blogsService;
            _logger = logger;
        }

        /// <summary>
        /// Get all blog posts with optional search
        /// </summary>
        /// <param name="term">Optional search term for filtering</param>
        /// <returns>List of blog posts</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBlogs([FromQuery] string term = null)
        {
            var blogs = await _blogsService.GetAllBlogsAsync(term);
            return Ok(blogs);
        }

        /// <summary>
        /// Get a specific blog post by ID
        /// </summary>
        /// <param name="id">Blog post ID</param>
        /// <returns>Blog post details</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var blog = await _blogsService.GetBlogByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        /// <summary>
        /// Create a new blog post
        /// </summary>
        /// <param name="blog">Blog post data</param>
        /// <returns>Created blog post</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBlog([FromBody] Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdBlog = await _blogsService.CreateBlogAsync(blog);
            return CreatedAtAction(nameof(GetBlogById), new { id = createdBlog.Id }, createdBlog);
        }

        /// <summary>
        /// Update an existing blog post
        /// </summary>
        /// <param name="id">Blog post ID</param>
        /// <param name="blog">Updated blog post data</param>
        /// <returns>Updated blog post</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBlog(int id, [FromBody] Blog blog)
        {
            if (!ModelState.IsValid || blog == null || id != blog.Id)
            {
                return BadRequest(ModelState);
            }

            var updatedBlog = await _blogsService.UpdateBlogAsync(blog);
            if (updatedBlog == null)
            {
                return NotFound();
            }
            return Ok(updatedBlog);
        }

        /// <summary>
        /// Delete a blog post
        /// </summary>
        /// <param name="id">Blog post ID</param>
        /// <returns>No content if successful</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var deleted = await _blogsService.DeleteBlogAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}