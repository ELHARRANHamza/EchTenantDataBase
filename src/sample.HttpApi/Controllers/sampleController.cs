using sample.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace sample.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class sampleController : AbpControllerBase
{
    protected sampleController()
    {
        LocalizationResource = typeof(sampleResource);
    }
}
