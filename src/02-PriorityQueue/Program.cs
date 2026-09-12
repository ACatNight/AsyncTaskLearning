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

        if(!queue.TryPeek(out _,out _))
        {
            Console.WriteLine("队列为空，无法预览");
        }
        if (!queue.TryDequeue(out _, out _))
        {
            Console.WriteLine("队列为空，无法预览");
        }




    }

    public static void ProcessAll(PriorityQueue<string, int> queue)
    {

        {
            while (queue.TryDequeue(out string? task, out int priority))
            {
                Console.WriteLine($"已处理:{task}任务优先级别:{priority}");
            }
        }



    }
}
