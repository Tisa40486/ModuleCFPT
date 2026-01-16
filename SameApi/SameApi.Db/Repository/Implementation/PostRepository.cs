using SameApi.Data.Repository;
using SameApi.Db.DbContexts;
using SameApi.Model;

namespace SameApi.Db.Repository.Implementation
{
    public  class PostRepository : BaseRepository<IApiSameDbContext, PostDao>, IPostRepository
    {
        public PostRepository(IApiSameDbContext context) : base(context)
        { }
    }
}
