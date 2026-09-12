# AsyncTaskLearning

这是一个从基础数据结构逐步升级到企业异步任务系统的练习仓库。

## 学习顺序

```text
01 Deque
→ 02 PriorityQueue
→ 03 async/await
→ 04 Channel
→ 05 BackgroundService
→ 06 ASP.NET Core Task API
```

每个模块独立运行，练习时遵循：

```text
先看需求
→ 自己设计
→ 自己写代码
→ 自己测试
→ 提交代码和结果
→ 接受教师与工程师评审
```

## 运行模块

```powershell
dotnet run --project src/01-Deque
dotnet run --project src/02-PriorityQueue
```

后续模块按同样方式运行。

## 工程规则

- 每个练习先写预期结果。
- 代码必须通过编译和运行验证。
- 正常、边界和失败路径都要测试。
- 命名、职责、输入校验和异常处理按工程规范检查。
- 参考答案只能用于复盘，不能替代独立实现。
