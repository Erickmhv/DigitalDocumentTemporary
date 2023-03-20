using AutoMapper;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
  public class BaseDropdownRepository<T> : IBaseDropdownRepository<T> where T : BaseDropdownDbModel
  {
    private readonly SqlServerContext _context;
    private readonly IMapper _mapper;

    public BaseDropdownRepository(SqlServerContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    async Task<IEnumerable<T>> IBaseDropdownRepository<T>.GetAll()
    {
      IEnumerable<T> entries = await _context.Set<T>().OrderBy(a => a.Name).ToListAsync();

      return entries;
    }
  }
}
