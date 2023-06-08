using MediatR;
using Microsoft.AspNetCore.Mvc;
using static CinemaApp.Booking.CommandModels.BookingCommands;
using static CinemaApp.Booking.QueryModels.BookingQueries;

namespace CQRSCinemaApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index() 
        {
            return View(await _mediator.Send(new GetAllBookingQuery()));
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await _mediator.Send(new GetBookingByIdQuery() {Id = id }));
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookingCommand command)
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
        public async Task<IActionResult> Update(int id, UpdateBookingCommand command)
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
        public async Task<IActionResult> Delete(int id, DeleteBookingCommand command)
        {
            try
            {
               await _mediator.Send(new DeleteBookingCommand() { Id = id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
