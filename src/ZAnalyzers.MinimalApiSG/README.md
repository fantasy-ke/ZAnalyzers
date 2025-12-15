# ZAnalyzers.MinimalApiSG

## 项目概述

ZAnalyzers.MinimalApiSG是一个代码生成器，用于简化ASP.NET Core Minimal API的开发。它通过扫描继承自`FantasyApi`的服务类，自动生成路由映射和依赖注入配置代码，使开发者可以专注于业务逻辑而不必编写重复的API注册代码。

## 核心功能

- 自动发现继承自`ZAnalyzerApi`的服务类
- 根据命名约定自动推断HTTP方法和路由
- 支持通过特性自定义路由
- 自动注册服务到依赖注入容器
- 支持过滤器和授权特性
- 支持API分组和标签

## 使用方法

### 1. 引用必要的包

```csharp
<PackageReference Include="ZAnalyzers.Core" Version="x.x.x" />
<PackageReference Include="ZAnalyzers.MinimalApiSG" Version="x.x.x" />
```

### 2. 创建服务类

```csharp
using ZAnalyzers.Core;

namespace YourNamespace
{
    // 可选：指定路由前缀
    [Route("/api/your-route")]
    // 可选：添加API标签
    [Tags("YourTag")]
    public class YourService : ZAnalyzerApi
    {
        // 会映射为 GET /api/your-route/items
        public async Task<IEnumerable<Item>> GetItems()
        {
            // 实现逻辑
            return await Task.FromResult(new List<Item>());
        }

        // 会映射为 POST /api/your-route/item
        public async Task<Item> CreateItem(Item item)
        {
            // 实现逻辑
            return await Task.FromResult(item);
        }

        // 带有HTTP方法特性的方法
        [HttpPut("custom-route/{id}")]
        public async Task<Item> UpdateItem(int id, Item item)
        {
            // 实现逻辑
            return await Task.FromResult(item);
        }

        // 使用过滤器
        [Filter(typeof(YourCustomFilter))]
        public async Task<Item> GetItemWithFilter(int id)
        {
            // 实现逻辑
            return await Task.FromResult(new Item());
        }

        // 使用授权
        [AuthorizeAttribute]
        public async Task<Item> GetProtectedItem(int id)
        {
            // 实现逻辑
            return await Task.FromResult(new Item());
        }

        // 忽略不需要映射为API的方法
        [IgnoreRoute]
        public void SomeInternalMethod()
        {
            // 内部逻辑
        }
    }
}
```

### 3. 配置程序启动

在`Program.cs`中配置服务和API映射：

```csharp
var builder = WebApplication.CreateBuilder(args);

// 注册服务到DI容器（默认为Scoped生命周期）
builder.Services.WithZMinmalLife();
// 或指定生命周期
// builder.Services.WithZMinmalLife(ServiceLifetime.Singleton);

var app = builder.Build();

// 注册所有API路由
app.MapZMinimalApis();

app.Run();
```

## 命名约定

### HTTP方法推断

如果没有显式指定HTTP方法特性，代码生成器将根据方法名前缀推断HTTP方法：

- `Get*` → GET
- `Post*`, `Create*`, `Add*`, `Insert*` → POST
- `Put*`, `Update*`, `Modify*` → PUT
- `Delete*`, `Remove*` → DELETE

### 路由推断

如果没有显式指定路由，路由将基于以下规则生成：

- 类级别：`/api/{类名去掉Service后缀}`
- 方法级别：`/{方法名去掉HTTP方法前缀和Async后缀}`

## 特性支持

### 路由特性

```csharp
[Route("/custom/route")]  // 类级别
[HttpGet("items/{id}")]   // 方法级别
```

### 标签特性

```csharp
[Tags("YourTag")]
```

### 过滤器特性

```csharp
[Filter(typeof(YourFilter))]  // 类或方法级别
```

### 授权特性

```csharp
[Authorize]                      // 基本授权
[Authorize(Roles = "Admin")]     // 基于角色
[Authorize(Policy = "PolicyName")] // 基于策略
```

### 忽略路由特性

```csharp
[IgnoreRoute]  // 不将此方法映射为API
```

## 接口实现支持

如果服务类实现了接口（接口名为`I+类名`），生成器将自动注册接口到服务实现的映射：

```csharp
public interface IYourService
{
    Task<Item> GetItem(int id);
}

public class YourService : ZAnalyzerApi, IYourService
{
    public Task<Item> GetItem(int id) { ... }
}

// 生成：services.AddScoped<IYourService, YourService>();
``` 