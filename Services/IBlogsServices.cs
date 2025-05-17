using SolidBlogsApi.Models;

namespace SolidBlogsApi.Services
{
    // Service Interface - Abstraction (Dependency Inversion)
    public interface IBlogsService
    {
        Task<IEnumerable<Blog>> GetAllBlogsAsync(string searchTerm = null);
        Task<Blog?> GetBlogByIdAsync(int id);
        Task<Blog> CreateBlogAsync(Blog blog);
        Task<Blog?> UpdateBlogAsync(Blog blog);
        Task<bool> DeleteBlogAsync(int id);
    }
}
