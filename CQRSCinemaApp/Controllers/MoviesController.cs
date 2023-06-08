using MediatR;
using Microsoft.AspNetCore.Mvc;
using static CinemaApp.Movies.CommandModels.MoviesCommand;
using static CinemaApp.Movies.QueryModels.MoviesQueries;

namespace CQRSCinemaApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllMoviesQuery()));
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await _mediator.Send(new GetMoviesByIdQuery() { Id = id }));
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMovieCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(command);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(command);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateMovieCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(command);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(command);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, DeleteMovieCommand command)
        {
            try
            {
                await _mediator.Send(new DeleteMovieCommand() { Id = id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
