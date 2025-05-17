using SolidBlogsApi.Models;
using SolidBlogsApi.Repositories;

namespace SolidBlogsApi.Services
{
    public class BlogsService : IBlogsService
    {
        private readonly IBlogsRepository _blogsRepository;

        public BlogsService(IBlogsRepository blogsRepository)
        {
            _blogsRepository = blogsRepository;
        }

        public async Task<IEnumerable<Blog>> GetAllBlogsAsync(string searchTerm = null)
        {
            return await _blogsRepository.GetAllBlogsAsync(searchTerm);
        }

        public async Task<Blog?> GetBlogByIdAsync(int id)
        {
            return await _blogsRepository.GetBlogByIdAsync(id);
        }

        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            blog.CreatedAt = DateTime.UtcNow;
            blog.UpdatedAt = DateTime.UtcNow;
            
            // Ensure Tags is initialized
            if (blog.Tags == null)
                blog.Tags = new List<string>();
                
            return await _blogsRepository.CreateBlogAsync(blog);
        }

        public async Task<Blog?> UpdateBlogAsync(Blog blog)
        {
            var existingBlog = await _blogsRepository.GetBlogByIdAsync(blog.Id);
            if (existingBlog == null)
            {
                return null;
            }

            blog.CreatedAt = existingBlog.CreatedAt;
            blog.UpdatedAt = DateTime.UtcNow;
            
            // Ensure Tags is initialized
            if (blog.Tags == null)
                blog.Tags = new List<string>();
            
            return await _blogsRepository.UpdateBlogAsync(blog);
        }

        public async Task<bool> DeleteBlogAsync(int id)
        {
            var rowsAffected = await _blogsRepository.DeleteBlogAsync(id);
            return rowsAffected > 0;
        }
    }
}