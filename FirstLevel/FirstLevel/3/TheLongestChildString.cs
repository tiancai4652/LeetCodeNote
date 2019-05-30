﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
    public class TheLongestChildString
    {
        public int LengthOfLongestSubstring(string s)
        {
            while (!CheckIsStrAllCharSingle(s))
            {
                s = GetlongestStrByTheMostChar(s);
                //Thread.Sleep(50);
            }
            return s.Length;
        }

        public string GetlongestStrByTheMostChar(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (var item in s)
            {
                if (dic.Keys.Contains(item))
                {
                    dic[item] += 1;
                }
                else
                {
                    dic.Add(item, 1);
                }
            }
            ;
            char devideChar = dic.OrderByDescending(t => t.Value).First().Key;
            string replace = ";" + devideChar;
            string charStr =new StringBuilder().Append(devideChar).ToString() ;
            s = s.Replace(charStr, replace);
            string[] list = s.Split(';');
            return list.OrderByDescending(t => t.Length).First();
        }

        public bool CheckIsStrAllCharSingle(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (var item in s)
            {
                if (dic.Keys.Contains(item))
                {
                    dic[item] += 1;
                }
                else
                {
                    dic.Add(item, 1);
                }
            }
            if (dic.Values.Max() == 1)
            {
                return true;
            }
            return false;
        }


        [Theory]
        [InlineData("abcabcbb", 3)]
        [InlineData("bbbbb", 1)]
        [InlineData("pwwkew", 3)]
        public void test(string s,int result)
        {
            Assert.Equal(LengthOfLongestSubstring(s), result);
        }


    }
}
