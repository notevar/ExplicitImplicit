using System;

namespace ExplicitImplicit
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal num = (decimal)new ClassA(200);//显示转换
            Console.WriteLine(num);//200
            string str = new ClassA(100);//隐示转换
            Console.WriteLine(str);//"100"
            ClassB classB = (ClassB)new ClassA(1000);
            Console.WriteLine(classB.p);//1000
            int total = new ClassA(200) + new ClassA(500); //操作符重载
            Console.WriteLine(total);//700
            Console.ReadKey();
        }
    }



    class ClassA
    {
        public int num { get; }
        public ClassA(int _num)
        {
            num = _num;
        }

        //重载加法运算符+  
        public static int operator +(ClassA a, ClassA b)
        {
            return a.num + b.num;
        }

        //声明隐式转换  相同的返回类型 隐式转换和显示转换只能定义一种 implicit/explicit
        public static implicit operator ClassA(string a)
        {
            return new ClassA(int.Parse(a));
        }

        //声明隐式转换
        public static implicit operator string(ClassA a)
        {
            return a.num.ToString();
        }

        //声明隐式转换  隐式转换和显示转换只能定义一种 implicit/explicit
        public static explicit operator decimal(ClassA a)
        {
            return a.num;
        }

        //声明显式转换
        public static explicit operator ClassB(ClassA a)
        {
            return new ClassB(a.num);
        }
    }

    class ClassB
    {
        public ClassB(float f)
        {
            p = f;
        }
        public float p { get; }
    }
}
