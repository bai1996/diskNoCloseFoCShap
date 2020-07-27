using System;
using System.IO;

namespace diskNoCloseFoCShap
{
    static class FileTools
    {
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        static Boolean MkDir(string filePath) {
            Console.WriteLine("创建文件夹:" + filePath);
            Directory.CreateDirectory(filePath);
            return false;
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        static Boolean DelDir(string filePath) {
            Console.WriteLine("删除文件夹:" + filePath);
            Directory.Delete(filePath);
            return false;
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        static Boolean MkFile(string filePath) {
            Console.WriteLine("创建文件:" + filePath);
            StreamWriter file = File.CreateText(filePath);
            file.WriteLine("DNC自动生成文件！！！");
            file.Close();
            return false;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        static Boolean DelFile(string filePath) {
            Console.WriteLine("删除文件:" + filePath);
            File.Delete(filePath);
            return false;
        }

        /// <summary>
        /// 创建文件（包含文件夹）
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        public static void CreateFile(string filePath,string fileName)
        {
            if (filePath != null) {
                MkDir(filePath);
            }
            if (fileName != null) {
                MkFile(filePath + fileName);
            }
        }

        /// <summary>
        /// 删除文件，及文件夹
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        public static void DeleteFile(string filePath,string fileName)
        {
            if (fileName != null)
            {
                DelFile(filePath + fileName);
            }
            if (filePath != null)
            {
                //DelDir(filePath);
            }

        }
    }
}
