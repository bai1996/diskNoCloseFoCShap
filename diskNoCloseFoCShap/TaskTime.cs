using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diskNoCloseFoCShap
{
    class TaskTime : System.Timers.Timer
    {
        /// <summary>
        /// 执行次数
        /// </summary>
        private static int execNum = 1;

        /// <summary>
        /// 文件名
        /// </summary>
        public String fileName;

        /// <summary>
        /// 文件夹地址
        /// </summary>
        public String dirPath;

        public long runRate;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="executeTime">定时什么时候发送</param>
        /// <param name="action">要执行什么任务，这是一个委托，string[]是参数，当然也可以用模型</param>
        /// <param name="actionArgs">要执行任务的参数，与action的参数相对应</param>
        /// <param name="callback">执行完的回调函数</param>
        /// <param name="callbackArgs">回调函数的参数，与回调函数里的参数类型相对应</param>
        public void schedule(DateTime executeTime, Action<string[]> action, string[] actionArgs, Action<string[]> callback, string[] callbackArgs) {
            double interval = (executeTime - DateTime.Now).TotalMilliseconds;
            //这里做下限制，不能超过最大值
            if (interval >= int.MaxValue)
            {
                throw new ArgumentOutOfRangeException("不能超过最大值24天!");
            }
            base.Elapsed += (obj, e) => action(actionArgs);
            base.Elapsed += (obj, e) => callback(callbackArgs);
            base.AutoReset = false; //TODO: 循环执行暂不支持
            base.Interval = interval > 0 && interval < int.MaxValue ? interval : 100;
            base.Enabled = true;
        }

        /// <summary>
        /// 要执行的任务
        /// </summary>
        /// <param name="strarr">这里的入参我传的是数组，你完全可以传入的一个包含很多属性值的对象</param>
        public void ActionTask(string[] strarr)
        {
            int taskId = 0;
            if (strarr.Length > 0)
            {
                int.TryParse(strarr[0], out taskId);
            }
            try
            {
                Console.WriteLine();
                Console.Write("******************************************************");
                Console.Write("开始执行任务");
                Console.Write("******************************************************");
                Console.WriteLine();

                //Console.Write("第(");
                //Console.Write(execNum);
                //Console.WriteLine(")次执行");

                Console.WriteLine("第({0})次执行", execNum);
                execNum++;
                if (fileName == null || "".Equals(fileName))
                {
                    fileName = "temp.txt";
                }
                if (dirPath == null || "".Equals(dirPath))
                {
                    Console.WriteLine("缺少文件路径!");
                    return;
                }
                FileTools.CreateFile(dirPath, fileName);
                FileTools.DeleteFile(dirPath, fileName);
            }
            catch (Exception e)
            {
                //Console.WriteLine("执行任务出现错误：\n{0}\n详细错误如下：\n{1}", e.Message,e.ToString());
                Console.WriteLine("--error");
                //Console.WriteLine("输入/help获取帮助");
                Console.WriteLine("\t执行任务出现错误：\n\t{0}", e.Message);
                //Console.WriteLine("\t{0}", e.Message);
                Console.WriteLine("--error end");
            }
        }

        /// <summary>
        /// 任务执行完毕的操作
        /// </summary>
        /// <param name="args">这里同样可以传入对象，用作处理</param>
        public void CallBackFun(string[] strarr)
        {
            int taskId = 0;
            if (strarr.Length > 0)
            {
                int.TryParse(strarr[0], out taskId);
            }
            try
            {
                DateTime date = DateTime.Now;
                Console.Write("执行时间：");
                Console.WriteLine(date.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo));
                Console.WriteLine();
                Console.Write("********************************************************");
                Console.Write("运行结束");
                Console.Write("********************************************************");
                Console.WriteLine();

                //任务完成-执行下一次任务
                string[] strArr = new string[] {};
                string[] strArr2 = new string[] {};
                TaskTime t = new TaskTime
                {
                    fileName = fileName,
                    dirPath = dirPath,
                    runRate = runRate
                };
                t.schedule(DateTime.Now.AddMilliseconds(runRate), t.ActionTask, strArr, t.CallBackFun, strArr2);
            }
            catch (Exception e)
            {
                //Console.WriteLine("添加新任务出现错误：\n{0}\n详细错误如下：\n{1}", e.Message,e.ToString());
                Console.WriteLine("--error");
                Console.WriteLine("\t添加新任务出现错误：\n\t{0}", e.Message);
                //Console.WriteLine("\t{0}", e.Message);
                Console.WriteLine("--error end");
            }
        }

    }
}
