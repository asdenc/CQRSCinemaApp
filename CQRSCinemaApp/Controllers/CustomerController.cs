using MediatR;
using Microsoft.AspNetCore.Mvc;
using static CinemaApp.Customer.CommandModels.CustomerCommands;
using static CinemaApp.Customer.QueryModels.CustomerQueries;

namespace CQRSCinemaApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllCustomerQuery()));
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await _mediator.Send(new GetCustomerByIdQuery() { Id = id }));
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
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
        public async Task<IActionResult> Update(int id, UpdateCustomerCommand command)
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
        public async Task<IActionResult> Delete(int id, DeleteCustomerCommand command)
        {
            try
            {
                await _mediator.Send(new DeleteCustomerCommand() { Id = id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
