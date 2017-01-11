using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebUI.Utils {
    public static class SecurityHelper {
        /// <summary>
        /// 加密明文密码
        /// </summary>
        /// <param name="plainPwd">明文密码</param>
        /// <returns></returns>
        public static string encryptPlainPwd(string plainPwd) {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] md5PwdByte = md5.ComputeHash(Encoding.Default.GetBytes(plainPwd));
            return encryptMD5Pwd(BitConverter.ToString(md5PwdByte));
        }

        /// <summary>
        /// md5加密后再加密
        /// </summary>
        /// <param name="md5Pwd">md5密码</param>
        /// <returns></returns>
        public static string encryptMD5Pwd(string md5Pwd) {

            return md5Pwd.Replace("-","x");

        }

        public static string isLoginSessionId { get { return "isLogin"; } }

    }
}