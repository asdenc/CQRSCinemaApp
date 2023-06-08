using MediatR;
using Microsoft.AspNetCore.Mvc;
using static CinemaApp.Screen.CommandModels.ScreenCommands;
using static CinemaApp.Screen.QueryModels.ScreenQueries;

namespace CQRSCinemaApp.Controllers
{
    public class ScreenController : Controller
    {
        private readonly IMediator _mediator;

        public ScreenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllScreenQuery()));
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await _mediator.Send(new GetScreenByIdQuery() { Id = id }));
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateScreenCommand command)
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
        public async Task<IActionResult> Update(int id, UpdateScreenCommand command)
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
        public async Task<IActionResult> Delete(int id, DeleteScreenCommand command)
        {
            try
            {
                await _mediator.Send(new DeleteScreenCommand() { Id = id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
