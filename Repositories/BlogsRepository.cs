using Microsoft.EntityFrameworkCore;
using SolidBlogsApi.Models;
using SolidBlogsApi.Data;

namespace SolidBlogsApi.Repositories
{
    public class BlogsRepository : IBlogsRepository
    {
        private readonly AppDbContext _context;

        public BlogsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetAllBlogsAsync(string searchTerm = null)
        {
            var query = _context.Blogs.AsQueryable();
            
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(b => 
                    b.Title.ToLower().Contains(searchTerm) || 
                    b.Content.ToLower().Contains(searchTerm) || 
                    b.Category.ToLower().Contains(searchTerm));
            }
            
            return await query.ToListAsync();
        }

        public async Task<Blog?> GetBlogByIdAsync(int id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<Blog?> UpdateBlogAsync(Blog blog)
        {
            var existingBlog = await _context.Blogs.FindAsync(blog.Id);
            if (existingBlog == null)
                return null;
                
            _context.Entry(existingBlog).CurrentValues.SetValues(blog);
            await _context.SaveChangesAsync();
            return existingBlog;
        }

        public async Task<int> DeleteBlogAsync(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }
    }
}