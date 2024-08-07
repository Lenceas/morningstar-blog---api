﻿namespace MorningStar.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Description("用户表")]
    public class UserMongoEntity : BaseMongoEntity
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        [Description("用户名称"), BsonElement(Order = 1)]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 登录账号
        /// </summary>
        [Description("登录账号"), BsonElement(Order = 2)]
        public string Account { get; set; } = string.Empty;

        /// <summary>
        /// 登录密码（MD5加密）
        /// </summary>
        [Description("登录密码"), BsonElement(Order = 3)]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 角色ID
        /// </summary>
        [Description("角色ID"), BsonElement(Order = 4)]
        public long RoleID { get; set; }

        /// <summary>
        /// 最后登录时间（UTC）
        /// </summary>
        [Description("最后登录时间"), BsonElement(Order = 5)]
        public DateTime? LastLoginTime { get; set; } = null;

        /// <summary>
        /// 最后登录IPv4
        /// </summary>
        [Description("最后登录IPv4"), BsonElement(Order = 6)]
        public string LastLoginIPv4 { get; set; } = string.Empty;

        /// <summary>
        /// 最后登录Token
        /// </summary>
        [Description("最后登录Token"), BsonElement(Order = 7)]
        public string LastLoginToken { get; set; } = string.Empty;

        /// <summary>
        /// 是否首次登录（首次登录强制跳转更改密码页面）
        /// </summary>
        [Description("是否首次登录"), BsonElement(Order = 8)]
        public bool IsFirstLogin { get; set; } = true;
    }
}