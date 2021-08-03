using System.Xml;
using System.IO.MemoryMappedFiles;
using Movies.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<Movie> Movies { get; set; } 

        DbSet<Comment> Comments { get; set; } 

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
