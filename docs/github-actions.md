# GitHub Actions 使用说明

## NuGet包发布工作流

项目已配置自动化工作流用于发布NuGet包。当您创建新的版本标签时，工作流会自动构建项目并将包发布到NuGet.org。

### 工作流触发条件

推送以`v`开头的标签（例如：`v1.0.0`）将触发发布流程。

### 工作流步骤

1. 检出代码
2. 设置.NET环境（安装.NET 9和.NET 6以支持.NET Standard 2.0目标框架）
3. 恢复项目依赖
4. 构建项目
5. 运行测试
6. 从标签提取版本号
7. 打包各个项目
8. 将包推送到NuGet.org
9. 创建GitHub发布版本

### 发布新版本

要发布新版本，请按照以下步骤操作：

1. 更新项目版本号（在`Directory.Build.props`文件中）
2. 提交并推送更改
3. 创建新的版本标签并推送：

```bash
git tag v1.0.0
git push origin v1.0.0
```

### 配置NuGet API密钥

此工作流需要一个名为`NUGET_API_KEY`的GitHub仓库密钥。请按照以下步骤设置：

1. 在NuGet.org获取您的API密钥
2. 转到GitHub仓库的"Settings" > "Secrets and variables" > "Actions"
3. 点击"New repository secret"
4. 名称填写为`NUGET_API_KEY`，值填写为您的NuGet API密钥
5. 点击"Add secret"保存

### 注意事项

- 确保在标签名称中使用语义化版本号（例如：`v1.0.0`）
- 工作流会使用标签中的版本号覆盖`Directory.Build.props`文件中的版本号
- 如需添加新项目，请在工作流文件中添加相应的打包步骤
- 工作流配置了.NET 9和.NET 6环境，以支持项目中使用的.NET 9和.NET Standard 2.0目标框架 