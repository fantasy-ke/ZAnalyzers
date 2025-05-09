# ZAnalyzers.Test 测试项目

这是ZAnalyzers库的演示和测试项目，用于展示如何使用ZAnalyzers套件中的各种功能和组件。

## 项目结构

- **Service/** - 包含演示如何使用FantasyApi基类创建API服务的示例
- **Filter/** - 自定义过滤器示例
- **Attr/** - 自定义属性示例

## 功能演示

此项目演示了以下功能：

- 使用FantasyApi基类创建RESTful API
- 自定义路由配置
- 身份验证和授权
- 自定义过滤器应用
- 文件上传处理
- API分组和标签
- 接口与实现分离

## 如何运行

1. 确保已安装.NET 9.0 SDK
2. 在项目根目录执行：

```bash
dotnet run
```

3. 浏览至 https://localhost:端口/swagger 查看API文档

## 测试端点

项目包含以下测试端点：

- GET /weatherforecast - 默认天气预报示例
- 自动生成的API（来自TestService）:
  - POST /api/Test/Create - 需要Admin角色授权
  - PUT /api/Test/Update - 使用自定义授权
  - GET /api/Test/Filter - 应用自定义过滤器
  - POST /api/Test/UploadAvatar - 文件上传示例，禁用防伪令牌 