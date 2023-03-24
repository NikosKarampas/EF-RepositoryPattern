using RepositoryPattern.Core;
using RepositoryPattern.Core.Repositories;
using RepositoryPattern.Persistence.Repositories;
using System.Data.Entity.Core.Metadata.Edm;

namespace RepositoryPattern.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlutoContext _context;

        public UnitOfWork(PlutoContext context)
        {
            _context = context;

            //Alternative
            //Courses = new CourseRepository(_context);
            //Authors = new AuthorRepository(_context);
        }

        //Alternative
        //public ICourseRepository Courses { get; private set; }
        //public IAuthorRepository Authors { get; private set; }
        public ICourseRepository Courses => new CourseRepository(_context);

        public IAuthorRepository Authors => new AuthorRepository(_context);

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}