using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SJmedia.Common
{
    public class File
    {
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="fileURL">文件路径</param>
        public void CreatFile(string fileURL)
        {
            if (!Directory.Exists(fileURL))//判断文件夹是否存在 
            {
                Directory.CreateDirectory(fileURL);//不存在则创建文件夹 
            }
        }
    }
}
