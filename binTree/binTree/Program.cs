using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binTree
{
    //=====
     class node {
        int val;
        node left, right, parent;

        

        public node(int val_ = 0 , node l_ = null, node r_ = null, node p_ = null) {
            val = val_;
            left = l_;
            right = r_;
            parent = p_;
        }
        //=========
        public void add(int x) {
            if (x < val)
            {
                if (left != null)
                    left.add(x);
                else
                    left = new node(x, null, null, this);
            }
            else
                if (right != null)
                    right.add(x);
                else
                    right = new node(x, null, null, this);
        }

    

  


        //-------------------------------
       static public void print_asc(node r) {
            if (r.left != null)
                print_asc(r.left);
            Console.WriteLine(r.val);

            if (r.right != null)
                print_asc(r.right);
        }
        // output
        static public int outputMassPointer = 0;

        static public void print_asc(node r, ref int[] mass)
        {
            if (r.left != null)
                print_asc(r.left, ref mass);
            mass[outputMassPointer] = r.val;

            if (outputMassPointer < mass.Length)
            outputMassPointer++;

            if (r.right != null)
                print_asc(r.right, ref mass);
        }

    }


    


    //=====
    class Program
    {
        static public void sort(ref int[] a) {
            node root = new node(a[0], null, null, null);

            for (int i = 1; i < a.Length; i++)
                root.add(a[i]);

            node.print_asc(root, ref a);
            node.outputMassPointer = 0;
        }

        //===========================
        static public void tester(int tests)
        {
            Console.WriteLine("test on " + tests  +" mass");

            // подготовка
           int[] a = new int[tests];
            Random R = new Random(999);

            for (int i = 0; i < tests; i++)
                a[i] = R.Next(90);

            // тест
            DateTime time = System.DateTime.Now;
            sort(ref a);

            Console.WriteLine("time passed: " + (DateTime.Now - time));


            bool check = true;
            for (int i = 1; i < tests; i++)
                if (a[i] < a[i - 1]) check = false;

            Console.WriteLine("is sorted: " + check);
        }


        //===================



        static void Main(string[] args)
        {
            Console.WriteLine("binary tree tests\n");

            tester(1000);
            tester(5000);
            tester(20000);
            tester(50000);
            tester(100000);

            Console.WriteLine("\nfinished");

            Console.ReadLine();
        }
    }
}
