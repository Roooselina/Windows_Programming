namespace _5주차_실습
{
    internal class Program
    {
        class Parent
        {
            public virtual int Question() { return 10; }
        }
        class Child : Parent
        {
            public new int Question() { return 20; }
        }


        static void Main(string[] args)
        {
            Child child = new Child();
            Console.WriteLine(child.Question());  // → 20

        }

    }
}
