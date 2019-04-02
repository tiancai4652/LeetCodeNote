using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FirstLevel
{
    public class TwoSum
    {
        //Given an array of integers, return indices of the two numbers such that they add up to a specific target.
        //You may assume that each input would have exactly one solution, and you may not use the same element twice.
        //Example:
        //Given nums = [2, 7, 11, 15], target = 9,
        //Because nums[0] + nums[1] = 2 + 7 = 9,
        //return [0, 1].
        /// <summary>
        /// https://leetcode.com/problems/two-sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum1(int[] nums, int target)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                int num1 = nums[i];
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (num1 + nums[j] == target)
                    {
                        if (i < j)
                        {
                            return new int[] { i, j };
                        }
                        else
                        {
                            return new int[] { j, i };
                        }
                    }
                }
            }

            return new int[] { };
        }


        public int[] TwoSum2(int[] nums, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                dic.Add(i, nums[i]);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int num1 = nums[i];
                dic.Remove(i);
                try
                {
                    int x = dic.Keys.First(t => dic[t].Equals(target - num1));
                    return new[] { i, x };
                }
                catch
                { }
                finally
                {
                    if (!dic.Keys.Contains(i))
                    {
                        dic.Add(i, nums[i]);
                    }
                }
            }
            return new int[] { };
        }
        [Theory]
        //[InlineData(new int[] { 2, 7, 11, 15 }, 9)]
        //[InlineData(new int[] { 3,3 }, 6)]
        [InlineData(new int[] { 0,4,3,0 }, 0)]
        public void test(int[] nums, int target)
        {
            var result = TwoSumGo(nums, target);
            Assert.True(result[0].Equals(0) && result[1].Equals(1) && result.Count() == 2);
        }

      
    }


}
