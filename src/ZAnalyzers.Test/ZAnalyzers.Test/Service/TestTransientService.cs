using ZAnalyzers.Core;

namespace ZAnalyzers.Test.Service;

public interface ITestTransientService
{
    Guid GetInstanceId();
}

public class TestTransientService : ITestTransientService, ITransientDependency
{
    private readonly Guid _instanceId = Guid.NewGuid();
    
    public Guid GetInstanceId()
    {
        return _instanceId;
    }
}