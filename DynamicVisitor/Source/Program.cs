using System;

namespace PatternSampales
{
    internal class Program
    {
        private static void ActionVisitor()
        {
            Console.WriteLine("Action Visitor");
            IActionVisitor<Letter> visitor = Visitor.For<Letter>();
            visitor.Register<A>(x => Console.WriteLine(x.GetType().Name));
            visitor.Register<B>(x => Console.WriteLine(x.GetType().Name));

            Letter a = new A();
            Letter b = new B();
            visitor.Visit(a);
            visitor.Visit(b);
        }

        private static void FuncVisitor()
        {
            Console.WriteLine("Func Visitor");
            IFuncVisitor<Letter, string> visitor = Visitor.For<Letter, string>();
            visitor.Register<A>(x => x.GetType().Name);
            visitor.Register<B>(x => x.GetType().Name);

            Letter a = new A();
            Letter b = new B();
            Console.WriteLine(visitor.Visit(a));
            Console.WriteLine(visitor.Visit(b));
        }

        private static void Main()
        {
            ActionVisitor();
            Console.WriteLine();
            FuncVisitor();
            Console.ReadKey();
        }
    }
}