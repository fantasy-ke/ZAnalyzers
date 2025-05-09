# ZAnalyzers 项目套件

ZAnalyzers是一系列用于简化ASP.NET Core开发的代码生成器和分析器工具集。通过代码生成和静态分析技术，减少重复代码编写，提高开发效率。

## 子项目

### [ZAnalyzers.Core](./src/ZAnalyzers.Core/README.md)

基础核心库，提供套件中其他组件共用的基础类型和接口。

### [ZAnalyzers.MinimalApiSG](./src/ZAnalyzers.MinimalApiSG/README.md)

Minimal API的源代码生成器，用于自动生成API路由映射和依赖注入注册代码。通过继承`FantasyApi`基类和按照命名约定创建服务类，无需手动编写路由映射代码。

### [ZAnalyzers.Test](./src/ZAnalyzers.Test/ZAnalyzers.Test/README.md)

示例和测试项目，展示ZAnalyzers套件的各种功能和用法。包括自定义路由、授权、过滤器和API分组等功能演示。

## 快速入门

1. 安装所需包：

```bash
dotnet add package ZAnalyzers.Core
dotnet add package ZAnalyzers.MinimalApiSG
```

2. 创建API服务类：

```csharp
using ZAnalyzers.Core;

namespace YourApp.Services
{
    public class ProductService : FantasyApi
    {
        public async Task<List<Product>> GetProducts()
        {
            // 实现逻辑
            return new List<Product>();
        }
        
        public async Task<Product> GetProduct(int id)
        {
            // 实现逻辑
            return new Product { Id = id };
        }
    }
}
```

3. 在Program.cs中配置：

```csharp
var builder = WebApplication.CreateBuilder(args);

// 注册服务
builder.Services.WithFantasyLife();

var app = builder.Build();

// 映射API路由
app.MapFantasyApi();

app.Run();
```

## 特性

- 自动发现和注册API服务
- 基于命名约定推断HTTP方法和路由
- 支持授权、过滤器、API分组等
- 自动处理接口与实现的依赖注入
- 源代码生成，不引入运行时依赖

## 开发与发布

项目使用GitHub Actions自动化工作流进行NuGet包的发布。当推送新的版本标签（如：`v1.0.0`）时，工作流将自动构建、测试并发布包到NuGet.org。

详细说明请查看[GitHub Actions使用说明](./docs/github-actions.md)。

## 致谢

本项目参考并改造自[FastService](https://github.com/AIDotNet/FastService)项目，根据自身业务需求进行了定制化开发。感谢FastService项目团队的开源贡献。

## 许可证

MIT