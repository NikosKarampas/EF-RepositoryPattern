using RepositoryPattern.Core.Domain;
using RepositoryPattern.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RepositoryPattern.Persistence.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly PlutoContext _context;

        public CourseRepository(PlutoContext context) 
            : base(context)
        {
            this._context = context;
        }

        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            return _context.Courses.OrderByDescending(c => c.FullPrice).Take(count).ToList();
        }

        public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize = 10)
        {
            return _context.Courses
                .Include(c => c.Author)
                .OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        //Alternative without context injection
        //public PlutoContext PlutoContext
        //{
        //    get { return Context as PlutoContext; }
        //}
    }
}