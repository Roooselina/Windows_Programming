namespace _9주차_실습코드
{
    internal class Program
    {
        class Product : IComparable
        {
            public String Name { get; set; }
            public int Price { get; set; }
            public override string ToString()
            {
                return Name + " : " + Price + "원";
            }
            // sort 쓰려면 이거 반드시 상속 오버라이드
            public int CompareTo(object other)
            {
                return this.Price.CompareTo((other as Product).Price);
            }


        }

        class Dummy : Product, IDisposable, Interface1
        {
            // 클래스 1개만 상속, 인터페이스는 다중 상속 가능
            // :로 두개 모두 상속 가능
            public void Dispose()
            {
                Console.WriteLine("파일 닫기");
            }

            public string ma(int n)
            {
                throw new NotImplementedException();
            }

            public int met()
            {
                throw new NotImplementedException();
            }
        }

        interface It
        {

        }

        static void Main(string[] args)
        {
            List<Product> list = new List<Product>() {
            new Product(){Name = "고구마", Price = 1500},
            new Product(){Name = "사과", Price = 2400},
            new Product(){Name = "바나나", Price = 100},
            new Product(){Name = "배", Price = 3000},
            };
            list.Sort();
            // error 발생 : 비교 기준 없어서


            foreach (Product p in list)
            {

                Console.WriteLine(p);

            }
            Dummy dummy = new Dummy();
            dummy.Dispose();
            // using block 사용 끝날 시, 호출
            // 보통 닫았다 이런거 알려줌 (try exception 비슷
        }
    }
}
