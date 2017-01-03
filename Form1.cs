using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChituPlistPrint.Utils;
using ChituPlistPrint.Objs;
using Newtonsoft.Json;
using System.Reflection;
using System.Configuration;

namespace ChituPlistPrint
{
    ///<summary>
    ///主窗口
    ///</summary>
    public partial class Form1 : Form
    {
        //读入内存的数据
        private List<Blueprint> blueprints;
        private List<Card> cards;
        private List<Dialog> dialogs;
        private List<Equipment> equipments;
        private List<Map> maps;
        private List<Quests> quests;
        private List<Skin> skins;
        private List<Spell> spells;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Environment.CurrentDirectory + "\\plist\\";
            textBox2.Text = Environment.CurrentDirectory + "\\plist\\";
        }
        ///<summary>
        ///选择读取plist的文件夹
        ///</summary>
        ///<param name="sender">sender对象</param>
        ///<param name="e">事件参数</param>
        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
        }
        ///<summary>
        ///选择输出格式化文件的文件夹
        ///</summary>
        ///<param name="sender">sender对象</param>
        ///<param name="e">事件参数</param>
        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.ShowDialog();
            textBox2.Text = folderBrowserDialog2.SelectedPath;
        }
        ///<summary>
        ///读取按钮
        ///</summary>
        ///<param name="sender">sender对象</param>
        ///<param name="e">事件参数</param>
        private void button3_Click(object sender, EventArgs e)
        {
            init();
            //用dictionary存放读入的plist数据
            Dictionary<string, List<Item>> dic = new XmlUtil().ReadFolder(textBox1.Text);
            foreach (KeyValuePair<string, List<Item>> kvp in dic)
            {
                comboBox1.Items.Add(kvp.Key);
                switch (kvp.Key)
                {
                    case "blueprint":
                        foreach(Item item in kvp.Value)
                            blueprints.Add(JsonConvert.DeserializeObject<Blueprint>(item.Str));
                        break;
                    case "card":
                        foreach (Item item in kvp.Value)
                            cards.Add(JsonConvert.DeserializeObject<Card>(item.Str));
                        break;
                    case "dialog":
                        foreach (Item item in kvp.Value)
                            dialogs.Add(JsonConvert.DeserializeObject<Dialog>(item.Str));
                        break;
                    case "equipment":
                        foreach (Item item in kvp.Value)
                            equipments.Add(JsonConvert.DeserializeObject<Equipment>(item.Str));
                        break;
                    case "map":
                        foreach (Item item in kvp.Value)
                            maps.Add(JsonConvert.DeserializeObject<Map>(item.Str));
                        break;
                    case "quests":
                        foreach (Item item in kvp.Value)
                            quests.Add(JsonConvert.DeserializeObject<Quests>(item.Str));
                        break;
                    case "skin":
                        foreach (Item item in kvp.Value)
                            skins.Add(JsonConvert.DeserializeObject<Skin>(item.Str));
                        break;
                    case "spell":
                        foreach (Item item in kvp.Value)
                            spells.Add(JsonConvert.DeserializeObject<Spell>(item.Str));
                        break;
                    default:
                        break;
                }
            }
            //分类存储完后清空dictionary
            dic.Clear();
            if(comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            //new XmlUtil().SaveFolder(dic, textBox2.Text);
            //new XmlUtil().Print(dic);
        }
        ///<summary>
        ///输出按钮
        ///</summary>
        ///<param name="sender">sender对象</param>
        ///<param name="e">事件参数</param>
        private void button4_Click(object sender, EventArgs e)
        {
            //string output = "";
            string content = "";
            string format = textBox3.Text;

            //格式化数据
            switch (comboBox1.Text)
            {
                case "blueprint":
                    foreach (Blueprint b in blueprints)
                    {
                        content += new Replacer().replaceBlueprint(format, b);
                    }
                    break;
                case "card":
                    foreach(Card c in cards)
                    {
                        content += new Replacer().replaceCard(format, c);
                    }
                    break;
                case "dialog":
                    
                    break;
                case "equipment":
                    foreach (Equipment equipment in equipments)
                    {
                        content += new Replacer().replaceEquipment(format, equipment);
                    }
                    break;
                case "map":
                    foreach (Map m in maps)
                    {
                        content += new Replacer().replaceMap(format, m);
                    }
                    break;
                case "quests":
                    foreach (Quests q in quests)
                    {
                        content += new Replacer().replaceQuests(format, q);
                    }
                    break;
                case "skin":
                    foreach (Skin s in skins)
                    {
                        content += new Replacer().replaceSkin(format, s);
                    }
                    break;
                case "spell":
                    foreach (Spell s in spells)
                    {
                        content += new Replacer().replaceSpell(format, s);
                    }
                    break;
                default:
                    break;
            }
            //存文件
            new XmlUtil().SaveFolder(content, textBox2.Text, ConfigurationSettings.AppSettings["filename"]);
        }
        ///<summary>
        ///初始化
        ///</summary>
        private void init() 
        {
            blueprints = new List<Blueprint>();
            cards = new List<Card>();
            dialogs = new List<Dialog>();
            equipments = new List<Equipment>();
            maps = new List<Map>();
            quests = new List<Quests>();
            skins = new List<Skin>();
            spells = new List<Spell>();
            comboBox1.Items.Clear();
            button4.Enabled = true;
            button5.Enabled = true;
        }
        ///<summary>
        ///插入文本
        ///</summary>
        ///<param name="sender">sender对象</param>
        ///<param name="e">事件参数</param>
        private void button5_Click(object sender, EventArgs e)
        {
            //插入格式化标识符
            textBox3.Text += "{" + comboBox2.Text + "}";
        }
        ///<summary>
        ///'文件'下拉栏标志改变动作
        ///</summary>
        ///<param name="sender">sender对象</param>
        ///<param name="e">事件参数</param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            Type t;
            //刷新'属性'下拉栏
            switch (comboBox1.Text)
            {
                case "blueprint":
                    t = typeof(Blueprint);
                    foreach (PropertyInfo pi in t.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    {
                        comboBox2.Items.Add(pi.Name);
                    }
                    t = typeof(Blueprint.NeedequipmentItem);
                    /*foreach (PropertyInfo pi in t.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    {
                        comboBox2.Items.Add("needequipment." + pi.Name);
                    }*/
                    break;
                case "card":
                    t = typeof(Card);
                    foreach (PropertyInfo pi in t.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    {
                        comboBox2.Items.Add(pi.Name);
                    }
                    break;
                case "dialog":
                    t = typeof(Dialog);
                    foreach (PropertyInfo pi in t.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    {
                        comboBox2.Items.Add(pi.Name);
                    }
                    break;
                case "equipment":
                    t = typeof(Equipment);
                    foreach (PropertyInfo pi in t.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    {
                        comboBox2.Items.Add(pi.Name);
                    }
                    break;
                case "map":
                    t = typeof(Map);
                    foreach (PropertyInfo pi in t.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    {
                        comboBox2.Items.Add(pi.Name);
                    }
                    break;
                case "quests":
                    t = typeof(Quests);
                    foreach (PropertyInfo pi in t.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    {
                        comboBox2.Items.Add(pi.Name);
                    }
                    break;
                case "skin":
                    t = typeof(Skin);
                    foreach (PropertyInfo pi in t.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    {
                        comboBox2.Items.Add(pi.Name);
                    }
                    break;
                case "spell":
                    t = typeof(Spell);
                    foreach (PropertyInfo pi in t.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    {
                        comboBox2.Items.Add(pi.Name);
                    }
                    break;
                default:
                    break;
            }
            textBox3.Text = ConfigurationSettings.AppSettings[comboBox1.Text];
            comboBox2.SelectedIndex = 0;
        }

    }
}
