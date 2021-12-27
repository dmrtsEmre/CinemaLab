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
}
