using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChituPlistPrint.Objs;
using System.Reflection;
using System.Configuration;

namespace ChituPlistPrint.Utils
{
    ///<summary>
    ///替换
    ///</summary>
    class Replacer
    {
        static private string SEPARATOR = ConfigurationSettings.AppSettings["separator"];
        ///<summary>
        ///格式化输出blueprints
        ///</summary>
        ///<param name="text">输入的字符串</param>
        ///<param name="blueprint">用于格式化输出的blueprint对象</param>
        ///<returns>格式化完成的字符串</returns>
        public string replaceBlueprint(string text, Blueprint blueprint)
        {
            string all = text;
            string temp = "";
            Type t = typeof(Blueprint);
            foreach(PropertyInfo pi in t.GetProperties())
            {
                object o = pi.GetValue(blueprint, null);
                if (o.GetType().Equals(typeof(string)))
                {
                    if (o.Equals(""))
                        all = all.Replace("{" + pi.Name + "}", "");
                    else
                        all = all.Replace("{" + pi.Name + "}", (string)o);
                }
                else if (o.GetType().Equals(typeof(List<Blueprint.NeedequipmentItem>)))
                {
                    foreach (Blueprint.NeedequipmentItem needequipment in (List<Blueprint.NeedequipmentItem>)o)
                        temp += "{" + needequipment.ToString() + SEPARATOR + "}";
                    all = all.Replace("{" + pi.Name + "}", temp);

                }
                temp = "";
            }
            return all;
        }
        ///<summary>
        ///格式化输出card
        ///</summary>
        ///<param name="text">输入的字符串</param>
        ///<param name="card">用于格式化输出的card对象</param>
        ///<returns>格式化完成的字符串</returns>
        public string replaceCard(string text, Card card)
        {
            string all = text;
            string temp = "";
            Type t = typeof(Card);
            foreach (PropertyInfo pi in t.GetProperties())
            {
                object o = pi.GetValue(card, null);
                if (o.GetType().Equals(typeof(string)))
                {
                    if (o.Equals(""))
                        all = all.Replace("{" + pi.Name + "}", "");
                    else
                        all = all.Replace("{" + pi.Name + "}", (string)o);
                }
                else if (o.GetType().Equals(typeof(List<string>)))
                {
                    foreach (string s in (List<string>)o)
                        temp += s + SEPARATOR;
                    all = all.Replace("{" + pi.Name + "}", temp);
                }
                temp = "";
            }
            return all;
        }

        ///<summary>
        ///格式化输出Equipment
        ///</summary>
        ///<param name="text">输入的字符串</param>
        ///<param name="equipment">用于格式化输出的Equipment对象</param>
        ///<returns>格式化完成的字符串</returns>
        public string replaceEquipment(string text, Equipment equipment)
        {
            string all = text;
            string temp = "";
            Type t = typeof(Equipment);
            foreach (PropertyInfo pi in t.GetProperties())
            {
                object o = pi.GetValue(equipment, null);
                if (o == null)
                    all = all.Replace("{" + pi.Name + "}", "");
                else if (o.GetType().Equals(typeof(string)))
                {
                    if (o.Equals(""))
                        all = all.Replace("{" + pi.Name + "}", "");
                    else
                        all = all.Replace("{" + pi.Name + "}", (string)o);
                }
                else if (o.GetType().Equals(typeof(List<Equipment.BuffListItem>)))
                {
                    foreach (Equipment.BuffListItem b in (List<Equipment.BuffListItem>)o)
                        temp += "{" + b.ToString() + SEPARATOR + "}";
                    all = all.Replace("{" + pi.Name + "}", temp);
                }
                else if (o.GetType().Equals(typeof(List<Equipment.TriggerListItem>)))
                {
                    foreach (Equipment.TriggerListItem tli in (List<Equipment.TriggerListItem>)o)
                        temp += "{" + tli.ToString() + SEPARATOR + "}";
                    all = all.Replace("{" + pi.Name + "}", temp);
                }
                temp = "";
                
            }
            return all;
        }
        ///<summary>
        ///格式化输出map
        ///</summary>
        ///<param name="text">输入的字符串</param>
        ///<param name="map">用于格式化输出的map对象</param>
        ///<returns>格式化完成的字符串</returns>
        public string replaceMap(string text, Map map)
        {
            string all = text;
            Type t = typeof(Map);
            foreach (PropertyInfo pi in t.GetProperties())
            {
                object o = pi.GetValue(map, null);
                if (o.Equals(""))
                    all = all.Replace("{" + pi.Name + "}", "");
                else
                    all = all.Replace("{" + pi.Name + "}", (string)o);
            }
            return all;
        }
        ///<summary>
        ///格式化输出quests
        ///</summary>
        ///<param name="text">输入的字符串</param>
        ///<param name="quests">用于格式化输出的quests对象</param>
        ///<returns>格式化完成的字符串</returns>
        public string replaceQuests(string text, Quests quests)
        {
            string all = text;
            string temp = "";
            Type t = typeof(Quests);
            foreach (PropertyInfo pi in t.GetProperties())
            {
                object o = pi.GetValue(quests, null);
                if (o == null)
                    all = all.Replace("{" + pi.Name + "}", "");
                else if (o.GetType().Equals(typeof(string)))
                {
                    if (o.Equals(""))
                        all = all.Replace("{" + pi.Name + "}", "");
                    else
                        all = all.Replace("{" + pi.Name + "}", (string)o);
                }
                else if (o.GetType().Equals(typeof(List<string>)))
                {
                    foreach (string s in (List<string>)o)
                        temp += s + SEPARATOR;
                    all = all.Replace("{" + pi.Name + "}", temp);
                }
                else if (o.GetType().Equals(typeof(List<Quests.UserEquipmentListItem>)))
                {
                    foreach (Quests.UserEquipmentListItem ueli in (List<Quests.UserEquipmentListItem>)o)
                        temp += "{" + ueli.ToString() + SEPARATOR + "}";
                    all = all.Replace("{" + pi.Name + "}", temp);
                }
                temp = "";
            }
            return all;
        }
        ///<summary>
        ///格式化输出skin
        ///</summary>
        ///<param name="text">输入的字符串</param>
        ///<param name="skin">用于格式化输出的skin对象</param>
        ///<returns>格式化完成的字符串</returns>
        public string replaceSkin(string text, Skin skin)
        {
            string all = text;
            Type t = typeof(Skin);
            foreach (PropertyInfo pi in t.GetProperties())
            {
                object o = pi.GetValue(skin, null);
                if (o.Equals(""))
                    all = all.Replace("{" + pi.Name + "}", "");
                else
                    all = all.Replace("{" + pi.Name + "}", (string)o);
            }
            return all;
        }
        ///<summary>
        ///格式化输出spell
        ///</summary>
        ///<param name="text">输入的字符串</param>
        ///<param name="spell">用于格式化输出的spell对象</param>
        ///<returns>格式化完成的字符串</returns>
        public string replaceSpell(string text, Spell spell)
        {
            string all = text;
            Type t = typeof(Spell);
            foreach (PropertyInfo pi in t.GetProperties())
            {
                object o = pi.GetValue(spell, null);
                if (o.Equals(""))
                    all = all.Replace("{" + pi.Name + "}", "");
                else
                    all = all.Replace("{" + pi.Name + "}", (string)o);
            }
            return all;
        }
    }
}
