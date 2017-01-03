using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ChituPlistPrint.Objs
{
    class Blueprint
    {
        static private string SEPARATOR = ConfigurationSettings.AppSettings["separator"];
        public class NeedequipmentItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string equipmentid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string max { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string min { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string needNumber { get; set; }

            public string ToString()
            {
                return "[" + equipmentid + SEPARATOR + max + SEPARATOR + min + SEPARATOR + needNumber + "]"; 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string developtype { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string blueprintid { get; set; }
        /// <summary>
        /// 圣诞节
        /// </summary>
        public string typename { get; set; }
        /// <summary>
        /// 圣诞长袜
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<NeedequipmentItem> needequipment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gold { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string typelevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
    }
}
