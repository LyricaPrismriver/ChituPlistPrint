using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using CE.iPhone.PList;

namespace ChituPlistPrint.Utils
{
    ///<summary>
    ///读plist和存储文件
    ///</summary>
    class XmlUtil
    {
        ///<summary>
        ///从文件夹中读数据
        ///</summary>
        ///<param name="folderPath">文件夹路径</param>
        ///<returns>从文件中读取的dictionary格式的数据</returns>
        public Dictionary<string, List<Item>> ReadFolder(string folderPath)
        {
            Dictionary<string, List<Item>> dic = new Dictionary<string, List<Item>>();

            folderPath = folderPathDao(folderPath);
            DirectoryInfo di = new DirectoryInfo(folderPath);
            foreach (FileInfo NextFile in di.GetFiles())
            {
                //该死的&字符串
                if (NextFile.Name.Equals("spell.plist"))
                {
                    string str = File.ReadAllText(folderPath + NextFile.Name);
                    str = str.Replace("&", "&amp;");
                    File.WriteAllText(folderPath + NextFile.Name, str, Encoding.UTF8);
                }
                //取文件扩展名
                string suffix = NextFile.Extension;
                if (suffix.Equals(".plist") && 
                    !NextFile.Name.Equals("lm_dialog.plist")&&
                    !NextFile.Name.Equals("system.plist")&&
                    !NextFile.Name.Equals("banquet.plist"))
                {
                    List<Item> items = new List<Item>();
                    //读xml文件
                    PListRoot root = PListRoot.Load(NextFile.FullName);
                    PListDict pdic = (PListDict)root.Root;

                    foreach (KeyValuePair<string, IPListElement> ipl in pdic)
                    {
                        Item item = new Item();
                        item.Key = ipl.Key;
                        item.Str = ((PListString)ipl.Value).Value;
                        items.Add(item);
                        //NextFile.Name.Substring(0, NextFile.Name.LastIndexOf(".plist") - 1);
                    }
                    dic.Add(
                        NextFile.Name.Substring(0,NextFile.Name.LastIndexOf(".plist")), 
                        items);
                }
            }
            return dic;
        }
        ///<summary>
        ///存储到文件
        ///</summary>
        ///<param name="content">存储内容</param>
        ///<param name="folderPath">文件夹路径</param>
        ///<param name="fileName">文件名</param>
        public void SaveFolder(string content, string folderPath, string fileName)
        {
            folderPath = folderPathDao(folderPath);
            DirectoryInfo di = new DirectoryInfo(folderPath);
            
            File.WriteAllText(folderPath + fileName + ".txt", content, Encoding.UTF8);

        }
        ///<summary>
        ///测试用类
        ///</summary>
        ///<param name="dic">输出的dictionary</param>
        public void Print(Dictionary<string, List<Item>> dic)
        {
            foreach (KeyValuePair<string, List<Item>> items in dic)
            {
                foreach (Item item in items.Value)
                {
                    string str = "key:" + item.Key + " value:" + item.Str;
                    Console.WriteLine(str);
                }

            }
        }
        ///<summary>
        ///验证文件夹路径合法性
        ///</summary>
        ///<param name="folderPath">文件夹路径</param>
        ///<returns>合法的文件夹路径</returns>
        private String folderPathDao(string folderPath)
        {
            if (folderPath.Length < 2)
                folderPath = Environment.CurrentDirectory + "\\plist\\";
            else if (!folderPath.Substring(folderPath.Length - 2, 2).Equals("\\"))
                folderPath += "\\";
            if (!Directory.Exists(folderPath))
            {
                //指定目录不存在时默认使用程序下plist目录
                folderPath = Environment.CurrentDirectory + "\\plist\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\plist\\");
                }
            }
            return folderPath;
        }
    }
}
