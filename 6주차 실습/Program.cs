namespace _6주차_실습
{
    internal class Program
    {
        class Parent
        {
            public int variable = 273;
            public void Method()
            {
                Console.WriteLine("P");
            }
        }
        class Child : Parent
        {
            public new int variable = 10;
            public new void Method()
            {
                Console.WriteLine("C");
            }
        }
        static void Main(string[] args)
        {
            Child child = new Child();
            Console.WriteLine((Parent)child.Method());
        }
    }
}
