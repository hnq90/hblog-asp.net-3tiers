using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Entities;

namespace Commons
{
    public class BlogCommons
    {
        public const string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=blog;Integrated Security=True";
        public const string _email_pattern = @"^[a-z0-9][a-z0-9_\.-]{0,}[a-z0-9]@[a-z0-9][a-z0-9_\.-]{0,}[a-z0-9][\.][a-z0-9]{2,4}$";
        public const string _password_pattern = @"^[a-zA-Z]\w{3,14}$";
        public const string _username_pattern = @"^([a-zA-Z])[a-zA-Z_-]*[\w_-]*[\S]$|^([a-zA-Z])[0-9_-]*[\S]$|^[a-zA-Z]*[\S]$";

        public static List<User> _usersource { get; set; }
        public static List<User> _currentuser { get; set; }
        public static List<Post> _postsource { get; set; }
        public static List<Post> _currentpost { get; set; }
        public static List<Category> _catsource { get; set; }
        public static List<Category> _currentcat { get; set; }
        public static List<Comment> _commentsource { get; set; }
        public static List<Comment> _currentcomment { get; set; }

        public static byte[] EncryptData(string data)
        {
            var md5Hasher = new MD5CryptoServiceProvider();
            var encoder = new UTF8Encoding();
            return md5Hasher.ComputeHash(encoder.GetBytes(data));
        }

        public static string MD5(string data)
        {
            return BitConverter.ToString(EncryptData(data)).Replace("-", "").ToLower();
        }
    }


    /// <summary>
    ///     Methods to remove HTML from strings.
    /// </summary>
    public static class HtmlRemoval
    {
        /// <summary>
        ///     Compiled regular expression for performance.
        /// </summary>
        private static readonly Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

        /// <summary>
        ///     Remove HTML from string with Regex.
        /// </summary>
        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }

        /// <summary>
        ///     Remove HTML from string with compiled Regex.
        /// </summary>
        public static string StripTagsRegexCompiled(string source)
        {
            return _htmlRegex.Replace(source, string.Empty);
        }

        /// <summary>
        ///     Remove HTML tags from string using char array.
        /// </summary>
        public static string StripTagsCharArray(string source)
        {
            var array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
    }
}