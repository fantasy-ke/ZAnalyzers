using ZAnalyzers.Core;

namespace ZAnalyzers.Test.Service;

public interface ITestSingletonService
{
    Guid GetInstanceId();
}

public class TestSingletonService : ITestSingletonService, ISingletonDependency
{
    private readonly Guid _instanceId = Guid.NewGuid();
    
    public Guid GetInstanceId()
    {
        return _instanceId;
    }
}