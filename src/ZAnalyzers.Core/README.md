# ZAnalyzers.Core

## 项目概述

ZAnalyzers.Core是ZAnalyzers系列的核心基础库，提供了基础类型和接口定义，用于支持其他ZAnalyzers组件（如ZAnalyzers.MinimalApiSG）的功能实现。

## 核心组件

### FantasyApi

`FantasyApi`是一个抽象基类，作为ZAnalyzers.MinimalApiSG代码生成器的基础标记类型。通过继承此类，您的服务类会被自动识别并处理为Minimal API端点。

```csharp
namespace ZAnalyzers.Core
{
    public abstract class FantasyApi
    {
    }
}
```

## 使用方法

ZAnalyzers.Core通常不需要单独使用，它主要作为ZAnalyzers其他组件的依赖项存在。在使用ZAnalyzers.MinimalApiSG或其他ZAnalyzers组件时，您需要同时引用ZAnalyzers.Core包。

### 安装

```xml
<PackageReference Include="ZAnalyzers.Core" Version="x.x.x" />
```

### 示例用法

创建继承自`FantasyApi`的服务类：

```csharp
using ZAnalyzers.Core;

namespace YourNamespace
{
    public class UserService : FantasyApi
    {
        public async Task<User> GetUser(int id)
        {
            // 实现逻辑
            return await Task.FromResult(new User { Id = id, Name = "Test User" });
        }
    }
}
```

## 与ZAnalyzers.MinimalApiSG的关系

- ZAnalyzers.Core提供基础类型定义
- ZAnalyzers.MinimalApiSG依赖ZAnalyzers.Core，并使用其中的类型进行代码生成
- 使用ZAnalyzers.MinimalApiSG时，必须同时引用ZAnalyzers.Core

详细的API使用说明，请参考[ZAnalyzers.MinimalApiSG文档](../ZAnalyzers.MinimalApiSG/README.md)。 