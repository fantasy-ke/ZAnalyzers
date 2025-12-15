# ZAnalyzers.ServiceInjectionSG

这是一个源生成器，用于自动注册实现了以下接口的服务：

- `IScopeDependency` - 注册为作用域生命周期的服务
- `ISingletonDependency` - 注册为单例生命周期的服务
- `ITransientDependency` - 注册为瞬态生命周期的服务

## 使用方法

在你的 ASP.NET Core 项目中，在 `Program.cs` 或 `Startup.cs` 中调用扩展方法：

```csharp
var builder = WebApplication.CreateBuilder(args);

// 注册所有服务
builder.Services.AddZAnalyzerServices();

var app = builder.Build();
```

## 测试示例

项目中包含了以下测试服务：

1. **TestScopeService** - 实现了 `IScopeDependency` 接口，注册为作用域服务
2. **TestSingletonService** - 实现了 `ISingletonDependency` 接口，注册为单例服务
3. **TestTransientService** - 实现了 `ITransientDependency` 接口，注册为瞬态服务

通过访问以下端点可以测试这些服务的行为：

- `/test/scope` - 测试作用域服务
- `/test/singleton` - 测试单例服务
- `/test/transient` - 测试瞬态服务

每个端点都会显示服务实例的GUID，用于验证服务生命周期是否正确实现。