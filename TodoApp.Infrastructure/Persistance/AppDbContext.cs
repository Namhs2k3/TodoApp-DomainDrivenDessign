using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoItem> Todos => Set<TodoItem>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
