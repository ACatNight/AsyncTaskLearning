class PriorityQueueTest
{
    public static void Main(string[] args)
    {
        var queue = new PriorityQueue<string, int>();
        queue.Enqueue("工作日报提交", 3);
        queue.Enqueue("严重bug修复", 1);
        queue.Enqueue("客户聊天记录整理", 2);

        if (queue.TryPeek(out string? nextTask, out int nextPriority))
        {
            Console.WriteLine($"下一个要处理的任务:{nextTask},任务优先级别:{nextPriority}");
        }
        int Count = queue.Count;
        Console.WriteLine($"当前剩余的任务数量:{Count}");
        ProcessAll(queue);
        Console.WriteLine($"处理后剩余数量：{queue.Count}");

        if (!queue.TryPeek(out _, out _))
        {
            Console.WriteLine("队列为空，无法预览");
        }
        if (!queue.TryDequeue(out _, out _))
        {
            Console.WriteLine("队列为空，没有任务可以处理");
        }
        // 练习6：优先级校验
        PriorityQueue<TaskInfo, int> priorityQueue = new PriorityQueue<TaskInfo, int>();
        TaskInfo t1 = new TaskInfo(1, "今日工作日提交记录", 4);
        TaskInfo t2 = new TaskInfo(2, "客户聊天记录整理", 3);
        TaskInfo t3 = new TaskInfo(3, "代码调试报告", 2);
        TaskInfo t4 = new TaskInfo(4, "严重bug提交", 1);

        Console.WriteLine("练习6：优先级校验");
        Console.WriteLine($"加入任务1：{TryAddTask(priorityQueue, t1)}");
        Console.WriteLine($"加入任务2：{TryAddTask(priorityQueue, t2)}");
        Console.WriteLine($"加入任务3：{TryAddTask(priorityQueue, t3)}");
        Console.WriteLine($"加入任务4：{TryAddTask(priorityQueue, t4)}");

        while (priorityQueue.TryDequeue(out TaskInfo? task, out int priority))
        {
            if (task is null)
            {
                continue;
            }

            Console.WriteLine($"已处理:{task.Name}任务优先级别:{priority}");
        }

        // 练习7：相同优先级时保持加入顺序
        var queue1 = new PriorityQueue<TaskInfo, (int Priority, long Order)>();
        long order = 0;
        TaskInfo t5 = new TaskInfo(1, "A", 2);
        TaskInfo t6 = new TaskInfo(2, "B", 1);
        TaskInfo t7 = new TaskInfo(3, "C", 2);
        TaskInfo t8 = new TaskInfo(4, "D", 2);

        AddTask(queue1, t5, ref order);
        AddTask(queue1, t6, ref order);
        AddTask(queue1, t7, ref order);
        AddTask(queue1, t8, ref order);

        Console.WriteLine("练习7：稳定顺序");
        while (queue1.TryDequeue(
            out TaskInfo? taskInfo,
            out (int Priority, long Order) key))
        {
            if (taskInfo is null)
            {
                continue;
            }

            Console.WriteLine(
                $"{taskInfo.Name}，优先级：{key.Priority}，加入顺序：{key.Order}");
        }

        Console.WriteLine("==============");
        var queue2 = new PriorityQueue<string, int>();
        queue2.Enqueue("任务A", 1);
        queue2.Enqueue("任务B", 1);
        queue2.Enqueue("任务C", 2);
        queue2.Enqueue("任务D", 3);
        queue2.Enqueue("任务E", 3);
        int total = 0;
        int priorityOneCount = 0;
        int priorityTwoCount = 0;
        int priorityThreeCount = 0;
        while(queue2.TryDequeue(out string task,out int priority))
        {
            total++;
            if(priority == 1)
            {
                priorityOneCount++;
            }else if(priority == 2)
            {
                priorityTwoCount++;
            }else if(priority == 3)
            {
                priorityThreeCount++;
            }
            Console.WriteLine($"任务{task}已解决，当前优先级别{priority}");
        }
        Console.WriteLine($"已处理的任务数量{total}");
        Console.WriteLine($"任务优先1级别处理的数量{priorityOneCount}");
        Console.WriteLine($"任务优先2级别处理的数量{priorityTwoCount}");
        Console.WriteLine($"任务优先3级别处理的数量{priorityThreeCount}");

    }


    public static void AddTask(
        PriorityQueue<TaskInfo, (int Priority, long Order)> queue,
        TaskInfo task,
        ref long order)
    {
        var key = (task.Priority, order);
        queue.Enqueue(task, key);
        order++;
    }

    public static bool TryAddTask(
        PriorityQueue<TaskInfo, int> queue,
        TaskInfo taskInfo)
    {
        if (taskInfo.Priority < 1 || taskInfo.Priority > 3)
        {
            return false;
        }
        queue.Enqueue(taskInfo, taskInfo.Priority);
        return true;
    }

    public static void ProcessAll(PriorityQueue<string, int> queue)
    {

        while (queue.TryDequeue(out string? task, out int priority))
        {
            Console.WriteLine($"已处理:{task}任务优先级别:{priority}");
        }
    }
}

class TaskInfo
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public int Priority { get; init; }

    public TaskInfo()
    {

    }

    public TaskInfo(int id,string name,int priority)
    {
        Id = id;
        Name = name;
        Priority = priority;
    }
}
