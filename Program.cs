using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning2_Ryggsäcken
{

    class Program
    {
        static void Main(string[] args)
        {
            Welcome(); // Hämtar metoden Welcome.
            // string objects = ""; //Lägger denna strängen här uppe för att den ska vara tillgänglig ifrån våran loop nedan. (OBS GAMMAL KOD)
            int nr = 0; //Måste lägga min int nr här uppe för att inte låsa in den under try metoden!
            string[] backPack = new string[5] {"", "", "", "" ,"" }; // Skapa en vector/array istället för en vanligt sträng.
            int lastIndex = 0;
            bool isActive = true; // Används för att enklare kunna hantera min loop.
            while (isActive) { //loop som gör det möjligt att användaren kan välja olika val baserat på vad dem vill göra samt återkomma till menyn när de är klara med sitt val.
                Console.WriteLine("[1] Lägg till ett föremål!");
                Console.WriteLine("[2] Skriv ut innehållet!");
                Console.WriteLine("[3] Rensa innehållet!");
                Console.WriteLine("[4] Avsluta");
                Console.Write("Välj: ");
                String choice = Console.ReadLine(); // Avläsa talet som användaren vill använda sig utav.
                try //Försöka göra om informationen i choice till ett tal istället och adderar det till int nr samt stoppa programmet från att sluta fungera ifall man skriver annat än tal.
                {
                    nr = Convert.ToInt32(choice);
                }
                catch //Ifall användaren inte skriver in ett tal möts användaren utav nedan felmeddelande, men kan fortsätta.
                {
                    Console.WriteLine("Förlåt! Men du får inte skriva bokstäver! Enbart siffror!");
                }

                switch (nr) // Eftersom vi enbart använder oss utav 4 val väljer jag att utnyttja switch satsen. Detta eftersom switch är mer kompatibel (och enklare) för ett menyval. Samt blir mer tydligare eftersom jag i koden använder både if satser samt loops.
                {
                    case 1:
                        /* =========================== GAMMAL KOD =================================
                         *                       Console.Write("Vad vill du lägga till? ");
                        objects += Console.ReadLine() + ", ";

                        bool loop = true; //Extra i arbetet för att undvika användaren att alltid hoppa ut och in för att lägga till flera objekt i ryggsäcken.
                        while (loop) { 
                        Console.Write("Önskar du lägga till fler objekt i din ryggsäck? (y/n)");
                        string answer = Console.ReadLine();
                            if (answer == "y")
                            {
                                Console.WriteLine("Vad vill du lägga till? ");
                                objects += Console.ReadLine() + " ";
                            } else if (answer == "n")
                            {
                                loop = false;
                            } else
                            {
                                continue;
                            }
                            =======================================================================*/
                        // ======================================NY KOD ==========================
                        /* for (int i = lastIndex; i <= backPack.Length - 1; i++)
                         {
                             Console.Write("Vad vill du lägga till? ");
                             backPack[lastIndex] = Console.ReadLine();
                               lastIndex += 1;
                               if (lastIndex != 5)
                               {
                                   Console.Write("Vill du lägga till fler produkter i din ryggsäck?(j/n): ");
                                   string answer = Console.ReadLine().ToLower();

                                   if (answer.Equals("n"))
                                   {
                                       break;
                                   }
                               }
                               else
                                   Console.WriteLine("Din ryggsäck är nu full");

                           }*/

                        Case1(backPack, LastIndex(0));

                        
                        continue;
                    case 2:
                        /*Console.WriteLine("I din ryggsäck har du just nu följande objekt: ");
                            for (int i = 0; i < backPack.Length; i++)
                            {
                                if (backPack[i] != "")
                            {
                                Console.WriteLine(i+1 + ": " + backPack[i]);
                            }
                            }*/
                        Case2(backPack);

                        continue;
                    case 3:
                        if(backPack[0] != "")
                        {
                            Console.WriteLine("I din ryggsäck har du just nu följande objekt: ");

                        
                        for (int i = 0; i < backPack.Length - 1; i++)
                        {
                            if (backPack[i] != "")
                            {
                                Console.WriteLine(i+1 + ": " + backPack[i]);
                            }
                        }
                        }

                        if (backPack[0] != "") { 
                        Console.WriteLine("Tömmer listan!");
                            for(int i = 0; i<backPack.Length -1; i++)
                            {
                                backPack[i] = "";
                            }
                         
                        Console.WriteLine("Listan är nu tom!");
                            lastIndex = 0;
                        } else
                        {
                            Console.WriteLine("Din lista är redan tom!");
                        }
                        continue;
                    case 4:
                        isActive = false;
                        break;

                    default:
                        continue;  // Gör att vi kommer tillbaka till menyn ifall inget mellan 1-4 väljs. 
                }
                
            }
            
        }
        public static void Welcome() 
            // Anledningen att jag skapar denna metoden är för att slippa se "Välkommen till Ryggsäcken" varje gång vi återkommer till menyn!
        {
            Console.WriteLine("Välkommen till Ryggsäcken! Dagens datum är: " + DateTime.Now.ToShortDateString());
        }
       
        

        public static void Case2(string[] y)//För att hämta information från våran ryggsäck.
        {
            Console.WriteLine("I din ryggsäck har du just nu följande objekt: ");
            for (int i = 0; i < y.Length; i++)
            {
                if (y[i] != "")
                {
                    Console.WriteLine(i + 1 + ": " + y[i]);
                }
            }
        }

        public static void Case1(string[] x, int z) //För att ändra våran ryggsäck.
        {
            int lastindex = z;
            for(int i = lastindex; i<x.Length; i++)
            {
                Console.Write("Vad vill du lägga till? ");
                x[lastindex] = Console.ReadLine();
                Console.Write("Vill du lägga till fler produkter i din ryggsäck?(j/n): ");
                string answer = Console.ReadLine().ToLower();
                lastindex++;
                LastIndex(lastindex);
                if (answer.Equals("n"))
                {
                    break;
                }
                
            }
        }
        public static int LastIndex(int x)
        {
            int lastIndex = 0;
            if (x >= lastIndex)
            {
                lastIndex = x;
                Console.WriteLine(lastIndex);
            }else if (x <= lastIndex)
            {
                x = lastIndex;
                Console.WriteLine(lastIndex);
            }
            return lastIndex;
        }


    }
    
}
