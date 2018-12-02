using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Model
{
    public class T_User:BaseModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户编码
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 微信号码
        /// </summary>
        public string WebChat { get; set; }
        /// <summary>
        /// QQ账号
        /// </summary>
        public string QQ { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 固定电话号码
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 性别0-男，1-女
        /// </summary>
        public int Gender { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime LastTime { get; set; }
        /// <summary>
        /// 坐标
        /// </summary>
        public string Coordinate { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 用户类别
        /// </summary>
        public int UserType { get; set; }
        /// <summary>
        /// 省份id
        /// </summary>
        public string ProvinceId { get; set; }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// 市id
        /// </summary>
        public string CityId { get; set; }
        /// <summary>
        /// 市名称
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 县区id
        /// </summary>
        public string CountyId { get; set; }
        /// <summary>
        /// 县区名称
        /// </summary>
        public string CountyName { get; set; }
       /// <summary>
       /// 村id
       /// </summary>
        public string VillageId { get; set; }
        /// <summary>
        /// 村名称
        /// </summary>
        public string VillageName { get; set; }
        /// <summary>
        /// 头像url
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
