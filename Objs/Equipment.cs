using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ChituPlistPrint.Objs
{
    class Equipment
    {
        static private string SEPARATOR = ConfigurationSettings.AppSettings["separator"];
        public class BuffValuesItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string buff_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string buff_type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string value { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string value_type { get; set; }

            public string ToString()
            {
                return buff_name + SEPARATOR + buff_type + SEPARATOR + value + SEPARATOR + value_type;
            }
        }

        public class BuffListItem
        {
            /// <summary>
            /// 
            /// </summary>
            public List<BuffValuesItem> buffValues { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string buff_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string not_remove { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string target_count { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string target_type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string time { get; set; }

            public string ToString()
            {
                string s = "";
                foreach(BuffValuesItem b in buffValues)
                    s += "[" + b.ToString() + "]";
                s += SEPARATOR + buff_id + SEPARATOR + not_remove + SEPARATOR + target_count + SEPARATOR + target_type + SEPARATOR + time;
                return s;
            }
        }
        public class Buff
        {
            /// <summary>
            /// 
            /// </summary>
            public List<BuffValuesItem> buffValues { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string buff_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string not_remove { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string target_count { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string target_type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string time { get; set; }

            public string ToString()
            {
                string s = "";
                foreach (BuffValuesItem b in buffValues)
                    s += "[" + b.ToString() + "]";
                s += SEPARATOR + buff_id + SEPARATOR + not_remove + SEPARATOR + target_count + SEPARATOR + target_type + SEPARATOR + time;
                return s;
            }
        }

        public class TriggerListItem
        {
            /// <summary>
            /// 
            /// </summary>
            public Buff buff { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string buff_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string count { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string damage { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string damage_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string spell { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string spell_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string target_count { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string target_type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string trigger_condition { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string trigger_rate { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string trigger_type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string triggerid { get; set; }

            public string ToString()
            {
                return buff.ToString() + SEPARATOR + buff_id + SEPARATOR
                    + count + SEPARATOR + damage + SEPARATOR + damage_id
                    + SEPARATOR + spell + SEPARATOR + spell_id + SEPARATOR
                    + target_count + SEPARATOR + target_type + SEPARATOR
                    + time + SEPARATOR + trigger_condition + SEPARATOR
                    + trigger_rate + SEPARATOR + triggerid;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string atk_mel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string atk_rang { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string avoid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string block { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<BuffListItem> buffList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cardids { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cardnames { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string crit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string damageList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string def { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string equipmentid { get; set; }
        /// <summary>
        /// 圣诞布丁
        /// </summary>
        public string equipmentname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string faith { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string food { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string giftflag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hitrate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string level { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lucky { get; set; }
        /// <summary>
        /// 使用：每回合恢复全队20生命。
        /// </summary>
        public string property { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string range { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rarity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sellflag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sellgold { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string speed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string stack { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<TriggerListItem> triggerList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string useflag { get; set; }
    }
}
