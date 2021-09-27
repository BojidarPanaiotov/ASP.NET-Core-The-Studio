namespace ASP.NET_Core_The_Studio.Controllers
{
    using ASP.NET_Core_The_Studio.Models.Feedbacks;
    using ASP.NET_Core_The_Studio.Services.EmailSender;
    using Microsoft.AspNetCore.Mvc;

    public class ContactController : Controller
    {
        private readonly IEmailSender emailSender;

        public ContactController(IEmailSender emailSender) => this.emailSender = emailSender;

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(FeedbackFormModel feedback)
        {
            if (!this.ModelState.IsValid)
            {
                return View(feedback);
            }

            var sended = emailSender.Send(feedback.Sender, feedback.Subject, feedback.Content);

            var message = sended ? "" : "";

            //TODO: Show message

            return RedirectToAction("Index", "Home");
        }
    }
}
