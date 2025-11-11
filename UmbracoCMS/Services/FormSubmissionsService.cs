using Umbraco.Cms.Core.Services;
using UmbracoCMS.ViewModels;

namespace UmbracoCMS.Services;

public class FormSubmissionsService(IContentService contentService)
{
    private readonly IContentService _contentService = contentService;

    public bool SaveCallbackRequest (CallbackFormViewModel model)
    {
        try
        {
            var container = contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "formSubmissions");
            if (container == null)
                return false;

            var requestName = $"{DateTime.Now:yyy-MM-dd HH:mm} - {model.Name}";
            var request = contentService.Create(requestName, container, "callbackRequest");

            request.SetValue("callbackRequestName", model.Name);
            request.SetValue("callbackRequestEmail", model.Email);
            request.SetValue("callbackRequestPhone", model.Phone);
            request.SetValue("callbackRequestOption", model.SelectedOption);

            var savedResult = _contentService.Save(request);
            return savedResult.Success;
        }
        catch (Exception ex)
        {
            return false;
        }


    }
}
