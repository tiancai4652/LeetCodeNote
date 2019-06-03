using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace FirstLevel._3
{
    //给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。

    //示例 1:

    //输入: "abcabcbb"
    //输出: 3 
    //解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
    //示例 2:

    //输入: "bbbbb"
    //输出: 1
    //解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
    //示例 3:

    //输入: "pwwkew"
    //输出: 3
    //解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
    //请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
    public class TheLongestChildString2
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            int length = s.Length;
            string temp = s;
            int i = 0;
            if (CheckIsStrAllCharSingle(temp))
            {
                return temp.Length;
            }
            while (true)
            {
                length--;
                i++;
                for (int j = 0; j <=i; j++)
                {
                    temp= GetFixedLengthStr(s, length, j);
                    if (CheckIsStrAllCharSingle(temp))
                    {
                        return temp.Length;
                    }
                }
            }
        }

        public bool CheckIsStrAllCharSingle(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (var item in s)
            {
                if (dic.Keys.Contains(item))
                {
                    dic[item] += 1;
                    return false;
                }
                else
                {
                    dic.Add(item, 1);
                }
            }
            return true; ;
        }

        public string GetFixedLengthStr(string s, int length, int index)
        {
            return s.Substring(index, length);
        }




        [Theory]
        [InlineData("abcabcbb", 3)]
        [InlineData("bbbbb", 1)]
        [InlineData("pwwkew", 3)]
        [InlineData("", 0)]
        [InlineData("cdd", 2)]
        [InlineData("abba", 2)]
        [InlineData("abcb", 3)]
        [InlineData("aab", 2)]
        public void test(string s,int result)
        {
            Assert.Equal(LengthOfLongestSubstring(s), result);
        }


    }
}
