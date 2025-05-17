using SolidBlogsApi.Models;

namespace SolidBlogsApi.Repositories
{
    public interface IBlogsRepository
    {
        Task<IEnumerable<Blog>> GetAllBlogsAsync(string searchTerm = null);
        Task<Blog?> GetBlogByIdAsync(int id);
        Task<Blog> CreateBlogAsync(Blog blog);
        Task<Blog?> UpdateBlogAsync(Blog blog);
        Task<int> DeleteBlogAsync(int id);
    }
}
