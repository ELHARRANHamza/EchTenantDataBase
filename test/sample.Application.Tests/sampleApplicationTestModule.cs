using Volo.Abp.Modularity;

namespace sample;

[DependsOn(
    typeof(sampleApplicationModule),
    typeof(sampleDomainTestModule)
    )]
public class sampleApplicationTestModule : AbpModule
{

}
