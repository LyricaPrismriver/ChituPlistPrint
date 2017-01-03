using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ChituPlistPrint.Objs
{
    class Quests
    {
        static private string SEPARATOR = ConfigurationSettings.AppSettings["separator"];
        public class UserEquipmentListItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string addnumber { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string countnumber { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string equipmentid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string userid { get; set; }

            public string ToString()
            {
                return "[" + addnumber + SEPARATOR + countnumber + SEPARATOR + equipmentid + SEPARATOR + userid + "]";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public List<string> acceptflags { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string blueprint { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cardid { get; set; }
        /// <summary>
        /// 村民
        /// </summary>
        public string cardname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string complete_flags { get; set; }
        /// <summary>
        /// 前来参拜的路上有许多毛玉在集结，希望能够退治一下。
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cycle { get; set; }
        /// <summary>
        /// 【主线】
        /// </summary>
        public string cyclename { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string difficulty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string exp { get; set; }
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
        public string gold { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string leather { get; set; }
        /// <summary>
        /// 退治神社附近的毛玉吗，是个简单的活呢。
        /// </summary>
        public string lm_message { get; set; }
        /// <summary>
        /// 毛玉退治
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string others { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string questsid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string skinid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string steel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string stone { get; set; }
        /// <summary>
        /// 退治【兽道】的【毛玉】
        /// </summary>
        public string true_content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<UserEquipmentListItem> userEquipmentList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wood { get; set; }
    }
}
