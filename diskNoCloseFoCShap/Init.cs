using System;

namespace diskNoCloseFoCShap
{
    class Init
    {
        static void Main(string[] args)
        {
            String dirPath = "";
            String fileName = "";
            long runRate = 60 * 1000L;
            if (args == null || args.Length <= 0){
                dirPath = @"M:\temp\";
                fileName = "temp.txt";
                Console.WriteLine("将使用：" + dirPath + fileName + "作为缓存文件,每" + (runRate / 1000) + "秒执行一次");
            } else {
                if (args.Length == 1) {
                    string arg = args[0];
                    arg = arg.ToLower();
                    if ("-h".Equals(arg) || "/h".Equals(arg) || "-help".Equals(arg) || "/help".Equals(arg))
                    {
                        Console.WriteLine("向指定路径写入文件后删除文件，以保证硬盘驱动器（针对移动硬盘,尤其是带节电的）不关闭");
                        Console.WriteLine("特别是当游戏放在移动硬盘里，游戏载入到内存后，硬盘不会读取、写入，等开启了节电再次读取游戏数据的时候会造成音画不同步，如果出现此问题，那么开启此工具会解决此问题");
                        Console.WriteLine("dnc [filePath] [fileName] [runRate]");
                        Console.WriteLine("\t" + @"filePath:文件夹路径(如：Z:\temp\)");
                        Console.WriteLine("\t" + "fileName:文件名：(如：temp.txt)");
                        Console.WriteLine("\t" + "runRate:执行频率(单位：秒)");
                        return;
                    }
                    //验证文件夹路径
                    else if (arg.IndexOf(":") != -1 && arg.IndexOf(@"\") != -1)
                    {
                        //使用第一个参数
                        dirPath = args[0];
                        Console.WriteLine("将使用：" + dirPath + fileName + "作为缓存文件,每" + (runRate / 1000) + "秒执行一次");
                    }
                    else {
                        Console.WriteLine("输入的参数有有误,输入/help获取帮助");
                        return;
                    }
                } else if (args.Length == 2) {
                    dirPath =args[0];
                    //验证文件夹路径
                    if (dirPath.IndexOf(":") == -1 || dirPath.IndexOf(@"\") == -1) {
                        Console.WriteLine("输入的参数有有误,输入/help获取帮助");
                        return;
                    }
                    fileName = args[1];
                    Console.WriteLine("将使用：" + dirPath + fileName + "作为缓存文件,每" + (runRate / 1000) + "秒执行一次");
                } else if (args.Length == 3) {
                    dirPath = args[0];
                    //验证文件夹路径
                    if (dirPath.IndexOf(":") == -1 || dirPath.IndexOf(@"\") == -1)
                    {
                        Console.WriteLine("输入的参数有有误,输入/help获取帮助");
                        return;
                    }
                    fileName = args[1];
                    runRate = 1000L;
                    long rate = long.Parse(args[2]);
                    runRate = rate * runRate;
                    Console.WriteLine("将使用：" + dirPath + fileName + "作为缓存文件,每" + (runRate / 1000) + "秒执行一次");
                }
            }
            Console.WriteLine("********************************************************初始化**********************************************************");
            Console.WriteLine("name:dnc");
            Console.WriteLine("full Name:diskNoClose");
            Console.WriteLine("version:1.0");
            Console.WriteLine("author:我家兔子没耳朵 -  My rabbit has no ears");
            Console.WriteLine("summary:向指定路径写入文件后删除文件，以保证硬盘驱动器（针对移动硬盘,尤其是带节电的）不关闭");
            //创建计时器
            string[] strArr = new string[] { };
            string[] strArr2 = new string[] { };
            TaskTime t = new TaskTime
            {
                fileName = fileName,
                dirPath = dirPath,
                runRate = runRate
            };
            //在定时器执行结束后再按时间间隔再启动一个定时任务
            //立即执行
            t.schedule(DateTime.Now, t.ActionTask, strArr, t.CallBackFun, strArr2);
            Console.WriteLine("定时任务已启动，每" + (runRate / 1000) + "秒执行一次");
            Console.WriteLine("*******************************************************初始化成功*******************************************************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
