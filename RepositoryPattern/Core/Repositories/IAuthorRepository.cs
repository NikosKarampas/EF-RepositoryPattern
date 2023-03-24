using RepositoryPattern.Core.Domain;

namespace RepositoryPattern.Core.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author GetAuthorWithCourses(int id);
    }
}