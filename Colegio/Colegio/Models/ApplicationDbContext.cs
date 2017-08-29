using Colegio.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Colegio.Controllers
{
    public class ApplicationDbContext:DbContext // Herdando de DbContext
    {
        public DbSet<Aluno> Alunos { get; set; } // Apontando para o banco
    }
}