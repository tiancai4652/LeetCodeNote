using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FirstLevel._2
{
    //给出两个 非空 的链表用来表示两个非负的整数。其中，它们各自的位数是按照 逆序 的方式存储的，并且它们的每个节点只能存储 一位 数字。

    //如果，我们将这两个数相加起来，则会返回一个新的链表来表示它们的和。

    //您可以假设除了数字 0 之外，这两个数都不会以 0 开头。

    //示例：

    //输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
    //输出：7 -> 0 -> 8
    //原因：342 + 465 = 807

    //输入：(1 -> 8 ) + (0)
    //输出：7 -> 0 -> 8
    //原因：81 + 0 = 81
    public class TwoNumAdd
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            string str1 = "";
            ListNode x1 = l1;
            string str2 = "";
            ListNode x2 = l2;
            while (x1 != null)
            {
                str1 += x1.val;
                x1 = x1.next;
            }
            while (x2 != null)
            {
                str2 += x2.val;
                x2 = x2.next;
            }

            int int1 = int.Parse(str1);
            int int2 = int.Parse(str2);

            int total = int1 + int2;

            ListNode listNode = new ListNode(0);
            if (total != 0)
            {
                listNode = GetListNode(ref listNode,total);
            }

            return listNode;
        }

        ListNode GetListNode(ref ListNode p, int total)
        {

            p.val = total % 10;
            total = total / 10;
            if (total != 0)
            {
                p.next = new ListNode(0);
                p.next = GetListNode(ref p.next, total);
            }
            return p;
        }

        public ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
        {
            if (l1.val == 0 && l1.next == null)
            {
                return l2;
            }
            if (l2.val == 0 && l2.next == null)
            {
                return l1;
            }
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            ListNode x1 = l1;
            while (x1 != null)
            {
                list1.Add(x1.val);
                x1 = x1.next;
            }
            ListNode x2 = l2;
            while (x2 != null)
            {
                list2.Add(x2.val);
                x2 = x2.next;
            }
            List<int> total = new List<int>();

            int count = list1.Count > list2.Count ? list1.Count : list2.Count;

            GetInt(ref total, list1, list2, 0, 0, count);

            ListNode listNode = new ListNode(0);
            return GetListNode2(ref listNode, total);
        }

        ListNode GetListNode2(ref ListNode p, List<int> total)
        {
            p.val = total[0];
            total.Remove(total.First());
            if (total.Count != 0)
            {
                p.next = new ListNode(0);
                p.next = GetListNode2(ref p.next, total);
            }
            return p;
        }

        void GetInt(ref List<int> total, List<int> l1, List<int> l2, int index, int extra, int count)
        {
            int para1 = 0;
            if(index<=l1.Count-1)
            {
                para1=l1[index];
            }
            int para2 = 0;
            if (index <= l2.Count - 1)
            {
                para2 = l2[index];
            }

            int x = para1 + para2 + extra;
            if (x >= 10)
            {
                total.Add(x - 10);
                index += 1;
                if (index <= count - 1)
                {
                    GetInt(ref total, l1, l2, index, 1, count);
                }
                else
                {
                    total.Add(1);
                }
            }
            else
            {
                total.Add(x);
                index += 1;
                if (index <= count - 1)
                {
                    GetInt(ref total, l1, l2, index , 0, count);
                }
            }
        }

        [Fact]
        public void test()
        {
            ListNode num1 = new ListNode(2);
            ListNode num11 = num1.next = new ListNode(4);
            ListNode num111 = num11.next = new ListNode(3);
            ListNode num2 = new ListNode(5);
            ListNode num22 = num2.next = new ListNode(6);
            ListNode num222 = num22.next = new ListNode(4);

            var result = AddTwoNumbers2(num1, num2);
        }

        [Fact]
        public void test1()
        {
            ListNode num1 = new ListNode(5);
            ListNode num2 = new ListNode(5);
            var result = AddTwoNumbers2(num1, num2);
        }

        [Fact]
        public void test2()
        {
            ListNode num1 = new ListNode(1);
            ListNode num11 = num1.next = new ListNode(8);
            ListNode num2 = new ListNode(0);
            var result = AddTwoNumbers2(num1, num2);
        }

        [Fact]
        public void test3()
        {
            ListNode num1 = new ListNode(9);
            ListNode num11 = num1.next = new ListNode(8);
            ListNode num2 = new ListNode(1);
            var result = AddTwoNumbers2(num1, num2);
        }

    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
