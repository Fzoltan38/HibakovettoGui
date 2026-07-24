using HibaKovetoWpf.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HibaKovetoWpf.Services
{
    internal class HibaTar
    {
        public static List<Hibajegy> Hibajegyek { get; } = new List<Hibajegy>
         {
             new Hibajegy
             {
                 Cim = "Bejelentkezés nem működik Firefox alatt",
                 Leiras = "A bejelentkező gomb kattintásra nem vált oldalt Firefoxban, Chrome-ban rendben van.",
                 Komponens = "UI",
                 Sulyossag = "Magas",
                 SurgosBeavatkozas = true,
                 Megoldva = false,
                 Bejelentve = DateTime.Now.AddDays(-3)
             },
             new Hibajegy
             {
                 Cim = "Lassú lekérdezés a felhasználói listánál",
                 Leiras = "1000 felhasználó felett a lista betöltése 8 másodpercnél is tovább tart.",
                 Komponens = "Adatbázis",
                 Sulyossag = "Közepes",
                 SurgosBeavatkozas = false,
                 Megoldva = false,
                 Bejelentve = DateTime.Now.AddDays(-2)
             },
             new Hibajegy
             {
                 Cim = "API időtúllépés nagy terhelés alatt",
                 Leiras = "Csúcsidőben a /api/orders végpont időnként 504-et ad vissza.",
                 Komponens = "Backend",
                 Sulyossag = "Kritikus",
                 SurgosBeavatkozas = true,
                 Megoldva = false,
                 Bejelentve = DateTime.Now.AddDays(-1)
             },
             new Hibajegy
             {
                 Cim = "Helytelen dátumformátum a számlán",
                 Leiras = "A generált PDF számlán amerikai dátumformátum jelenik meg magyar helyett.",
                 Komponens = "Backend",
                 Sulyossag = "Alacsony",
                 SurgosBeavatkozas = false,
                 Megoldva = true,
                 Bejelentve = DateTime.Now.AddDays(-7)
             },
             new Hibajegy
             {
                 Cim = "VPN kapcsolat megszakad teszt környezetben",
                 Leiras = "A teszt szerverre VPN-en keresztül csatlakozva a kapcsolat kb. 10 percenként megszakad.",
                 Komponens = "Hálózat",
                 Sulyossag = "Közepes",
                 SurgosBeavatkozas = false,
                 Megoldva = true,
                 Bejelentve = DateTime.Now.AddDays(-5)
             }
         };

        public static void HibajegyHozzaadas(Hibajegy hibajegy)
        {
            Hibajegyek.Add(hibajegy);
        }

    }
}
