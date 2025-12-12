using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZAnalyzers.Core;
using ZAnalyzers.Test.Attr;
using ZAnalyzers.Test.Filter;

namespace ZAnalyzers.Test.Service;

public interface ITestService
{
    Task<string> CreateAsync();

    Task<string> UpdateAsync();

    Task<string> UploadAvatarAsync(IFormFile avatar);


    Task<string> FilterAsync();
}

[Core.Route("api/Test")]
[Tags("Test")]
[Filter(typeof(TestFilter))]
[TestAuthorize("Test.Page", "Test.Update")]
//[Authorize(Roles = "Admin")]
public class TestService: FantasyApi,  ITestService
{
    [Authorize(Roles = "Admin")]
    public async Task<string> CreateAsync()
    {
        return await Task.FromResult("asd");
    }

    /// <summary>
    /// 自定义权限特性
    /// </summary>
    /// <returns></returns>
    [Authorize("Test.Page")]
    public async Task<string> UpdateAsync()
    {
        return await Task.FromResult("asd");
    }

    /// <summary>
    /// 方法级别过滤
    /// </summary>
    /// <returns></returns>
    [Filter(typeof(Test1Filter))]
    public Task<string> FilterAsync()
    {
        return Task.FromResult("asd");
    }

    /// <summary>
    /// 忽悠防伪 添加 DisableAntiforgery
    /// </summary>
    /// <param name="avatar"></param>
    /// <returns></returns>
    [IgnoreAntiforgeryToken]
    public async Task<string> UploadAvatarAsync(IFormFile avatar)
    {
        return await Task.FromResult("asd");
    }


}