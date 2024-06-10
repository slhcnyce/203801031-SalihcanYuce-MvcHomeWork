using Microsoft.EntityFrameworkCore;

namespace Sube1.EntityApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//var ogr = new Ogrenci { Ad = "Ahmet", Soyad = "Mehmet", Numara = 456 };
			//using (var ctx = new OkulDbContext())
			//{
			//	ctx.Ogrenciler.Add(ogr);
			//	int sonuc = ctx.SaveChanges();
			//	Console.WriteLine(sonuc > 0 ? "Başarılı" : "Başarısız");
			//}

			//using (var ctx = new OkulDbContext())
			//{
			//	var ogr = ctx.Ogrenciler.Find(1);
			//	if (ogr != null)
			//	{
			//		ogr.Numara = 789;
			//		Console.WriteLine(ctx.SaveChanges() > 0 ? "Güncelleme Başarılı" : "Güncelleme Başarısız");

			//	}
			//	else { Console.WriteLine("Ögrenci Bulunamadı!"); }
			//}

			//using (var ctx = new OkulDbContext())
			//{
			//	var ogr = ctx.Ogrenciler.Find(1);

			//	if (ogr != null)
			//	{
			//		ctx.Ogrenciler.Remove(ogr);
			//		ctx.SaveChanges();
			//	}


			//}

			//using (var ctx = new OkulDbContext())
			//{
			//	var lst = ctx.Ogrenciler.ToList();

			//	foreach (var item in lst)
			//	{
			//		Console.WriteLine(item.Ad);
			//	}
			//}
		}
	}
}