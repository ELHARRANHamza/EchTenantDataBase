using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace sample.Pages;

public class Index_Tests : sampleWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
