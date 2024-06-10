using Sube1.HelloMVC.Models;
using System.Collections.Generic;

namespace Sube1.HelloMVC.ViewModels
{
    public class OgrenciViewModel
    {
        public Ogrenci Ogrenci { get; set; }
        public List<int> SelectedDersler { get; set; }
        public List<Ders> Dersler { get; set; }
    }
}
