using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChituPlistPrint.Objs
{
    class Dialog
    {
        public class DialogListItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string talker { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string lchar { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string rchar { get; set; }
            /// <summary>
            /// 八云紫
            /// </summary>
            public string lcharn { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string rcharn { get; set; }
            /// <summary>
            /// 呐~陌生人哟，平淡无奇的生活很无趣吧，想过要打破现在的处境吗？
            /// </summary>
            public string message { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string bgid { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DialogListItem> dialogList { get; set; }
    }
}
