using ZAnalyzers.Core;

namespace ZAnalyzers.Test.Service
{

    /// <summary>
    /// 另一个示例服务接口
    /// </summary>
    public interface IhubTestService
    {
        string GetRepositoryInfo(string repoName);
    }

    /// <summary>
    /// GitHub服务实现 - 继承自FantasyService，只生成服务注册，不生成HTTP端点
    /// </summary>
    public class GithubTestService : FantasyService, IhubTestService
    {
        public string GetRepositoryInfo(string repoName)
        {
            return $"Repository: {repoName}, Stars: 100, Forks: 50";
        }
    }
}
