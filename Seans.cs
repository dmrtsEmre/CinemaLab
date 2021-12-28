using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaLab
{
    class Seans
    {
        public int seansId { get; set; }
        public int seansSalonu { get; set; }
        public int filmId { get; set; }
        public int fiyat { get; set; }
        public List<int> alinanKoltuklar { get; set; }
    }

    class AnaSeans
    {
        public string kapakUrl { get; set; }
        public int seansSalonu { get; set; }
        public string filmIsim { get; set; }
        public int seansDili { get; set; }
        public DateTime seansTarihi { get; set; }
    }
}
