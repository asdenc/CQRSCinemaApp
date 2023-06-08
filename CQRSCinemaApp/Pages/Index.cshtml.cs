using CinemaApp.Models.Models;
using CinemaApp.Movies.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CQRSCinemaApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMoviesService _moviesService;
        public IEnumerable<Movies> movieList { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IMoviesService moviesService)
        {
            _logger = logger;
            _moviesService = moviesService;
        }

        public async Task OnGet()
        {
            movieList = await _moviesService.GeMoviesList();
        }
    }
}