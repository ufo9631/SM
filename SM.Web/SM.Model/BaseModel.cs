using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SM.Model
{
    public class BaseModel
    {
        public virtual int id { get; set; }
        /// <summary>
        /// 是否删除0-否，1-是
        /// </summary>
        [DefaultValue(0)]
        public virtual int IsDelete { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}
