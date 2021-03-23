using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace improve_number_3.Models
{
    public class MovieDataBaseContext : DbContext
    {
        public MovieDataBaseContext (DbContextOptions<MovieDataBaseContext> options) : base(options)
        {

        }

        public DbSet<MovieDataBase> Movies { get; set; }
    }
}
