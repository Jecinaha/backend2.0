using Umbraco.Cms.Core.Services;
using UmbracoCMS.ViewModels;

namespace UmbracoCMS.Services;

public class FormSubmissionsService(IContentService contentService)
{
    private readonly IContentService _contentService = contentService;

    // ----------------------------------------------------
    // Save Callback Request (för callback-formulär)
    // ----------------------------------------------------
    public bool SaveCallbackRequest(CallbackFormViewModel model)
    {
        try
        {
            var container = _contentService.GetRootContent()
                .FirstOrDefault(x => x.ContentType.Alias == "formSubmissions");

            if (container == null)
                return false;

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {model.Name}";
            var request = _contentService.Create(requestName, container, "callbackRequest");

            request.SetValue("callbackRequestName", model.Name);
            request.SetValue("callbackRequestEmail", model.Email);
            request.SetValue("callbackRequestPhone", model.Phone);
            request.SetValue("callbackRequestOption", model.SelectedOption);

            var saveResult = _contentService.Save(request);
            return saveResult.Success;
        }
        catch
        {
            return false;
        }
    }


    // ----------------------------------------------------
    // Save Easy Contact Email (för InfoCard mini-form)
    // ----------------------------------------------------
    public bool SaveEasyContact(EasyContactFormViewModel model)
    {
        try
        {
            var container = _contentService.GetRootContent()
                .FirstOrDefault(x => x.ContentType.Alias == "formSubmissions");

            if (container == null)
                return false;

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {model.Email}";
            var request = _contentService.Create(requestName, container, "easyContactSubmission");

            request.SetValue("easyContactEmail", model.Email);

            var saveResult = _contentService.Save(request);
            return saveResult.Success;
        }
        catch
        {
            return false;
        }
    }


    // ----------------------------------------------------
    // Save Question Request (för stora Questions-formulär)
    // ----------------------------------------------------
    public bool SaveQuestionRequest(QuestionFormViewModel model)
    {
        try
        {
            var container = _contentService.GetRootContent()
                .FirstOrDefault(x => x.ContentType.Alias == "formSubmissions");

            if (container == null)
                return false;

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {model.QuestionName}";
            var request = _contentService.Create(requestName, container, "questionRequest");

            request.SetValue("questionName", model.QuestionName);
            request.SetValue("questionEmail", model.QuestionEmail);
            request.SetValue("questionText", model.QuestionText);

            var saveResult = _contentService.Save(request);
            return saveResult.Success;
        }
        catch
        {
            return false;
        }
    }
}
