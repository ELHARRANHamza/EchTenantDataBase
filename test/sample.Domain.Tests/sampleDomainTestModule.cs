using sample.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace sample;

[DependsOn(
    typeof(sampleEntityFrameworkCoreTestModule)
    )]
public class sampleDomainTestModule : AbpModule
{

}
