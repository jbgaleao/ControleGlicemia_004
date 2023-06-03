using ControleGlicemia_002.Models;

using Microsoft.EntityFrameworkCore;
using ControleGlicemia_002.ViewModel;

namespace ControleGlicemia_002.Context
{
    public class GlicemiaContext : DbContext
    {
        public GlicemiaContext(DbContextOptions<GlicemiaContext> options) : base(options)
        {

        }

        public DbSet<Glicemia> GLICEMIAS { get; set; }
        //public object GlicemiaViewModel { get; internal set; }
        //public DbSet<ControleGlicemia_002.ViewModel.GlicemiaViewModel>? GlicemiaViewModel_1 { get; set; }

        //internal Task SaveChangesAsync(Glicemia glicemia)
        //{
        //    throw new NotImplementedException();
        //}

        //public DbSet<ControleGlicemia_002.ViewModel.GlicemiaViewModel>? GlicemiaViewModel { get; set; }
    }
}
