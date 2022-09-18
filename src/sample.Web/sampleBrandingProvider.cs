using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace sample.Web;

[Dependency(ReplaceServices = true)]
public class sampleBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "sample";
}
