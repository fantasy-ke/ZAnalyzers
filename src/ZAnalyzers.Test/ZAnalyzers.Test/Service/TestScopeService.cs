using ZAnalyzers.Core.Dependencies;

namespace ZAnalyzers.Test.Service;

public interface ITestScopeService
{
    Guid GetInstanceId();
}

public class TestScopeService : ITestScopeService, IScopeDependency
{
    private readonly Guid _instanceId = Guid.NewGuid();
    
    public Guid GetInstanceId()
    {
        return _instanceId;
    }
}