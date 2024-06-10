using System.Collections;

namespace Sube1.CollectionsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayList al = new ArrayList();
            //int sayi1 = 5;
            //int sayi2 = 6;

            //int[] array = new int[2];
            //array[0] = sayi1;
            //array[1] = sayi2;
            //Console.WriteLine(array[0] + array[1]);

            //al.Add(sayi1);
            //al.Add(sayi2);

            //al.Capacity = al.Count;
            //Console.WriteLine($"Capacity:{al.Capacity}\nCount:{al.Count}");

            //Console.WriteLine((int)al[0] + (int)al[1]);
            //Console.ReadKey();

            //var d = new Deneme<int, string>();
            //d.value1 = 1;
            //d.value2 = 2;
            //d.Yazdir(5);

            //List<int> lst = new List<int>();
            //lst.Add(5);
            //Dictionary<string,object> viewdata= new Dictionary<string,object>();
            //viewdata.Add("ogrenci", ogr);
        }
    }

    class Deneme<T, U> where T : struct
                       where U : class
    {
        public T value1;
        public U value2;

        public void Yazdir(T value)
        {
            Console.WriteLine(value);
        }
    }
}
//Generic Constraints(where T:struct)