using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KENO
{
    internal class NapiKeno
    {
        public int Ev { get; }
        public int Het { get; }
        public int Nap { get; }
        public string HuzasDatum { get; }
        public List<int> HuzottSzamok { get; }

        // 3. feladat:
        public NapiKeno(string sor)
        {
           
            var mezok = sor.Split(';', StringSplitOptions.RemoveEmptyEntries);

            Ev = int.Parse(mezok[0]);
            Het = int.Parse(mezok[1]);
            Nap = int.Parse(mezok[2]);
            HuzasDatum = mezok[3];

            HuzottSzamok = new List<int>();
            for (int i = 4; i < mezok.Length; i++)
            {
                
                if (int.TryParse(mezok[i], out int szam))
                    HuzottSzamok.Add(szam);
            }
        }

        // 4. feladat: 
        public int TalalatSzam(List<int> tippek)
        {
            int db = 0;
            foreach (var t in tippek)
                if (HuzottSzamok.Contains(t)) db++;
            return db;
        }

        // 5. feladat:
        public bool Helyes
        {
            get
            {
                if (HuzottSzamok.Count != 20) return false;
                return HuzottSzamok.Distinct().Count() == 20;
            }
        }
    }
}
