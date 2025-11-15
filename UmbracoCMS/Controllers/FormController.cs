using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using UmbracoCMS.Services;
using UmbracoCMS.ViewModels;

namespace UmbracoCMS.Controllers
{
    public class FormController(
        IUmbracoContextAccessor umbracoContextAccessor,
        IUmbracoDatabaseFactory databaseFactory,
        ServiceContext services,
        AppCaches appCaches,
        IProfilingLogger profilingLogger,
        IPublishedUrlProvider publishedUrlProvider,
        FormSubmissionsService formSubmissions
    )
        : SurfaceController(
            umbracoContextAccessor,
            databaseFactory,
            services,
            appCaches,
            profilingLogger,
            publishedUrlProvider
        )
    {
        private readonly FormSubmissionsService _formSubmissions = formSubmissions;

        // --------------------------------------------
        // CALLBACK FORM
        // --------------------------------------------
        [HttpPost]
        public IActionResult HandleCallbackForm(CallbackFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            var result = _formSubmissions.SaveCallbackRequest(model);

            if (!result)
            {
                TempData["FormError"] = "Ett fel uppstod vid sparandet av din förfrågan. Vänligen försök igen senare.";
                return RedirectToCurrentUmbracoPage();
            }

            TempData["FormSuccess"] = "Tack för din förfrågan! Vi kommer att kontakta dig inom kort.";
            return RedirectToCurrentUmbracoPage();
        }

        // --------------------------------------------
        // EASY CONTACT FORM
        // --------------------------------------------
        [HttpPost]
        public IActionResult HandleEasyContact(EasyContactFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["SubscribeError"] = "Ange en giltig e-postadress.";
                return RedirectToCurrentUmbracoPage();
            }

            var result = _formSubmissions.SaveEasyContact(model);

            if (!result)
            {
                TempData["SubscribeError"] = "Ett fel uppstod. Försök igen senare.";
                return RedirectToCurrentUmbracoPage();
            }

            TempData["SubscribeSuccess"] = "Tack! Vi hör av oss snart.";
            return RedirectToCurrentUmbracoPage();
        }

        // --------------------------------------------
        // QUESTIONS FORM
        // --------------------------------------------
        [HttpPost]
        public IActionResult HandleQuestionForm(QuestionFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            var result = _formSubmissions.SaveQuestionRequest(model);

            if (!result)
            {
                TempData["FormError"] = "Ett fel uppstod när din fråga skulle sparas. Försök igen senare.";
                return RedirectToCurrentUmbracoPage();
            }

            TempData["FormSuccess"] = "Tack! Din fråga har skickats in.";
            return RedirectToCurrentUmbracoPage();
        }
    }
}
