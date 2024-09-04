using AutoMapper;
using SocialPlatformApp.Repos.DataLayer;
using SocialPlatformApp.Repos.Interfaces;

namespace SocialPlatformApp.Repos.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IUserRepository UsersRepo { get; private set; }


        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
