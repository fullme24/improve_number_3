using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using improve_number_3.Models;

namespace improve_number_3.Models.ViewModels
{
    public class MovieListViewModel
    {
        public IEnumerator<MovieDataBase> Movies { get; set; }
    }
}
