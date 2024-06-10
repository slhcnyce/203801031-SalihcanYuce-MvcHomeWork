namespace Sube1.HelloMVC.Models
{
    public class Ders
    {
        public int Dersid { get; set; }
        public required string Dersad { get; set; }
        public byte Kredi { get; set; }

        public ICollection<OgrenciDers> OgrenciDersler { get; set; }
    }
}
