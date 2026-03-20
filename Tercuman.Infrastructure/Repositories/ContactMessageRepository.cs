using Tercuman.Application.Interfaces;
using Tercuman.Domain.Entities;
using Tercuman.Infrastructure.Persistence;

namespace Tercuman.Infrastructure.Repositories;

public class ContactMessageRepository : GenericRepository<ContactMessage>, IContactMessageRepository
{
    private readonly AppDbContext _context;

    public ContactMessageRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public IQueryable<ContactMessage> Query()
    {
        return _context.Set<ContactMessage>().AsQueryable();
    }
}
