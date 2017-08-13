using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

struct s_backpack 
{
    string[5] items = {"","","","",""};
    int last_index = 0;
};
   

namespace Övning2_Ryggsäcken
{

    class Program
    {
        static void Main(string[] args)
        {
            Welcome(); // Hämtar metoden Welcome.
            string[] backPack = new string[5] {"", "", "", "" ,"" }; // Skapa en vector/array istället för en vanligt sträng.
            int counter = 0;
            bool isActive = true; // Används för att enklare kunna hantera min loop.
            while (isActive) { //loop som gör att man kan hoppa fram och tillbaka mellan de olika valen och får upp listan igen.
                Console.WriteLine("[1] Lägg till ett föremål!");
                Console.WriteLine("[2] Skriv ut innehållet!");
                Console.WriteLine("[3] Rensa innehållet!");
                Console.WriteLine("[4] Avsluta");
                Console.Write("Välj: ");
                String choice = Console.ReadLine(); // Avläsa talet som användaren vill använda sig utav.
                int nr = 0; // För att switch ska fungera nedan med hjälp av ett tal.
                try //Försöka göra om informationen i choice till ett tal istället och adderar det till int nr samt stoppa programmet från att sluta fungera ifall man skriver annat än tal.
                {
                    nr = Convert.ToInt32(choice);
                }
                catch //Ifall användaren inte skriver in ett tal möts användaren utav nedan felmeddelande, men kan fortsätta igenom att trycka in en ny siffra.
                {
                    Console.WriteLine("Förlåt! Men du får inte skriva bokstäver! Enbart siffror!");
                }

                switch (nr) // Eftersom vi enbart använder oss utav 4 val väljer jag att utnyttja switch satsen. Detta eftersom switch är mer kompatibel (och enklare) för ett menyval. Samt blir mer tydligare eftersom jag i koden använder både if satser samt loops.
                {
                    case 1:
                        Add(backPack, counter);
                        counter++; // Adderar 1 till vårn counter för varje objekt som har lagts till.


                        break;
                    case 2:
                        Information(backPack);

                        break;
                    case 3:

                        Remove(backPack);
                        counter = 0; //resettar countern till 0.
                        break;


                    case 4:
                        isActive = false; //Avslutar loopen
                        break;

                    default:
                        break;  // Gör att vi kommer tillbaka till menyn ifall inget mellan 1-4 väljs. 
                }
                
            }
            
        }

        /* ==================================================Metoder!=================================================================================================================================
         * I denna delen av koden kommer jag att skriva in alla de metoder som används ovan. Jag har valt att försöka skapa så många metoder som möjligt för att lära mig och enklare kunna hantera
         * kod för framtida syften. Det jag har lärt mig med metoder är att det är väldigt likt att ha koden direkt i main men med metoder kan du underlätta din kod för framtida bruk samt att få 
         * den att se snyggare ut. Dock finns det vissa saker som man måste lägga till för att koden ska fungera, exempelvis argument som sedan utnyttjas av metoden.
         * Varje metod kommer ha en liten kommentar om vad den gör + varför jag valt att skapa den utöver lärdom.
         * ===========================================================================================================================================================================================
         */
        public static void Welcome()
        /* ==================================================Metod!===================================================================================================================================
        Ger användaren ett välkomstmeddelande enbart när de startar programmet samt ger ut dagens datum. Skriver in det här för att jag missade jobba med det i förra projektet.
        * ============================================================================================================================================================================================
        */

        {
            Console.WriteLine("Välkommen till Ryggsäcken! Dagens datum är: " + DateTime.Now.ToShortDateString());
        }

        public static void Add(string[] x, int z)
        /* ==================================================Metod!===================================================================================================================================
        I denna metoden jobbar vi med att låta kunden kunna lägga till objekt i våran ryggsäck. För att underlätta för användaren så har jag valt att göra en for loop så att användaren kan lägga
        till fler objekt samma gång. Med hjälp av min int counter i main metoden och med hjälp av int counter kommer vi att kunna hoppa ut ur Add metoden och hoppa in igen för att fortsätta
        i våran array ifrån där vi slutade skriva förra gången (så länge man inte väljer att rensa ryggsäcken). För att komma åt Add functionen krävs det att Add(metodanropet) i main tilldelar vad
        för värden som skall komma in i koden. Detta görs med hjälp av argumenten x(backPack(våran array/vector)) och z(counter(våran counter)). I självaste metoden är vi tvungen att ha en intern
        räknare som vi kallar lastIndex, den kommer dock först att kopiera värdet från z (som är våran counter).
        * ============================================================================================================================================================================================
        */
        {
            int lastindex = z;
            for (int i = lastindex; i < x.Length; i++)
            {
                Console.Write("Vad vill du lägga till? ");
                x[lastindex] = Console.ReadLine();
                Console.Write("Vill du lägga till fler produkter i din ryggsäck?(j/n): ");
                string answer = Console.ReadLine().ToLower(); //gör om svaret till enbart små bokstäver så man slipper använda en or statement i if-satsen.
                lastindex++;
                if (answer.Equals("n")) // ifall användaren skriver n så kommer for loopen att avbrytas.
                {
                    break;
                }

            }
        }

        public static void Information(string[] y)
        /* ==================================================Metod!===================================================================================================================================
          I denna metoden jobbar vi med att låta kunden veta vad vi har i ryggsäcken. I koden kommer den skriva ut i vilken ordning som användaren har skrivit in sina objekt. Tack vare att vi har
          gjort denna metoden är det enkelt att vid senare skede kunna gå in och göra förändringar så som att kunna låta användaren välja vart i ryggsäcken (placering) som objektet ska ligga. På 
          samma sätt som i metoden Add har vi argumentation för att denna koden ska fungera, men här behöver vi just nu idag enbart en argumentation. I denna argumentationen skickar vi in backPack
          via y argumentationen. Jag valde y som ett argumentation då jag inte använder y någonstans i min övriga kod, förutom för att ta in information av användaren men ingen direkt händelse för
          y. Koden kommer visa först raden "I din ryggsäck har du just nu följande objekt: " följt av en ny rad för varje objekt (med hjälp av for loopen). Med hjälp av if koden kommer vi enbart
          att få upp de platser som enbart har något objekt i sig. Detta eftersom if letar efter ifall raden i är blank eller inte, om den är blank så skippar den att skriva ut raden.
        * ============================================================================================================================================================================================
        */
        {
            Console.WriteLine("I din ryggsäck har du just nu följande objekt: ");
            for (int i = 0; i < y.Length; i++)
            {
                if (y[i] != "")
                    Console.WriteLine(i + 1 + ": " + y[i]);
            }
        }



        public static void Remove(string[] x)
        /* ==================================================Metod!===================================================================================================================================
        I denna metoden skriver vi först ut vad användaren har för objekt i sin lista. Tanken med detta var för att vid senare skede kunna lägga till ett nytt menyval där de får välja mellan 3 
        punkter:
        1. Tömma hela listan
        2. Tömma visa objekt i listan.
        3. Inte tömma något alls.
        Eftersom uppgiften bad om att bara rensa har jag inte valt att lägga till det i denna metoden eftersom jag lagt till flera andra saker i andra av mina metoder som är överflödiga för uppgiften
        men med hjälp av att detta är en metod är det enklare att i senare skede kunna gå in och ändra om detta till att göra ovan nämnd menyval. När väl listan raderas skrivs det ut mot användaren
        och när listan är tom kommer den också att skriva ut att listan nu är tom. Jag har lagt till så att ifall användaren inte har något i listan så gör inte metoden något mer än att skriver ut:
        "Din ryggsäck är redan tom!. I mina ögon ger detta en bättre användar upplevelse samt att jag får öva mer på if satsen. I övrigt använder vi oss utav en argument för att kunna lägga in våran
        array/vector till metoden.
        * ============================================================================================================================================================================================
        */
        {
            if (x[0] != "")
            {
                Console.WriteLine("I din ryggsäck har du just nu följande objekt: ");
                for(int i = 0; i < x.Length; i++) {
                    if (x[i] != "") 
                        Console.WriteLine(i + 1 + ": " + x[i]);
                }
                Console.WriteLine("Tömmer nu listan!");
                for (int i = 0; i < x.Length; i++)
                        x[i] = "";
                Console.WriteLine("Listan är nu tom!");             
            }else
            {
                Console.WriteLine("Din ryggsäck är redan tom!");
            }

        }
        /*==================================================Övrigt!=================================================================================================================================
         * I detta kommentarsfältet kommer jag lägga in tankar och funderingar över övningen.
         * Att jobba med vectorer/arrays är ett bättre val än att enbart jobba med strings. Detta eftersom du kan enklare strukturera utdatan mot användaren samt att du kan bestämma vad maximalt
         * med object (strängar) kan vara i projektet. Detta ger dig som en programmerar mer kontroll över vad som händer och kan därefter enklare felsöka längst vägen eller leta fel i ditt program.
         * I valet mellan att använda en lista eller en vector valde jag att använda vector då vi jobbar med något som i vardagen har en maximal plats. Du kan alltid köpa en ny väska men det innebär
         * inte att objekten i din gamla väska automatiskt flyttas över, utan du måste ta ut föremålet ur väska a för att lägga det i väska B. Därför kände jag att en vektor var mer passande i detta 
         * fallet. Samt att ifall du använder en vector har du möjlighet att jobba i flera dimensioner än vad du kan göra i en lista. Exempelvis hade vi kunna tilldela olika fack i ryggsäcken olika
         * objekt.
         * Under uppgiftens gång började jag att göra koden enkel med att enbart använda en sträng för att spara ner vad användaren skrev in under Case1 (switch) för att sedan läsas upp som en lång
         * rad i Case2(switch). I Case3 (switch) så skrev jag in att strängen ska sedan bara bli "" igenom att skriva objects (namnet på strängen) = "" ;. När jag hade kodat allt för att fungera som
         * tanken var så började jag gå djupare in med att lägga till olika if scenarion för att få en bättre användare upplevelse. När alla mina If statements fungerade efter planering började jag 
         * jobba med vectorer istället och fick göra om lite i den dåvarande koden för att komma iväg ifrån strängen. Nu började jag även lägga in både If statements och for loops i de olika 
         * casen(switch) och när väl dessa har kommit i sin ordning samt att fått till en indexering (count) gick jag vidare till att säkerställa så att koden inte slutar fungera ifall du anger
         * ett felaktigt värde i menyn. Detta med hjälp av en try och catch metod (enligt boken). I detta skede när allting fungerade som det skulle utan att kunna hitta några uppenbara buggar gick
         * jag vidare till att börja jobba med metoder. Denna perioden var den tuffaste då jag var osäker på hur man skulle få de olika metoderna att jobba tillsammans men efter mycket trial and
         * error samt informations sökning både på internet och i boken lyckades jag att hitta de svar och lösningar som behövdes för att få allting att fungera ihop. Jag väljer därför att nu skicka
         * in ovan skriven kod som är den sista delen i mitt kodande och inte skriva med någon gammal kod.
         * ==================================================Lärdom!=================================================================================================================================
         * Under uppgiftens gång har jag fått lära mig väldigt många saker, allt ifrån att söka efter informationen på internet till att tänka på hur koden fungerar i bakgrunden. Detta har gjort
         * att kodandet i slutskedet har känts mer naturligt och lättsamt då jag vet att jag kan göra det ifall jag verkligen försöker hitta det via internet eller i kursliteraturen. Självfallet
         * har jag fått en större förståelse för hur vectorer fungerar och hur du kan manipulera den data som finns i den för att kunna exempelvis presentera den på ett snyggt sätt mot användaren.
         * När det kommer till metoder har jag lärt mig hur man kan strukturera dem med hjälp av olika argument för att skicka in data till dem och bearbeta exempelvis en vector.
         * Jag har även fått upp en större nyfikenhet för att ständigt förbättra koden och göra den enklare + mer lätttilgänglig. 
         * Jag har även fått öva med att använda de olika klammertyperna, allt ifrån att enbart använda en kodblock till att använda flera underkoblock samt även kodblock utan klammerparenteser.
         * Kortsiktigt för vad dessa innebär är:
         * Kodblock = mellan { och } skrivs kod som skall användas, den första kodblocken i en kod är den under namespaces, som sedan följs av classens kodblock och därefter de olika metoderna.
         * Underkodblock = Kan användas för att göra flera olika funktioner under det första kodblocket, exempelvis om du har en if statement som ska göra A men för att kunna göra A behöver den en
         * yttligare if statement inom den första if statementen. Eller lägga till en if statement i en redan starta for loop. Se exempel på rad 94-104 under Add metoden.
         * Kodblock utan klammerparentes = Om du gör en if-sats eller annan typ av loop m.m och koden som ska utföras enbart är en rad (exempelvis rad 123-124 i Information metoden) behöver man inte
         * använda sig av {} då komplimatorn förstår att den raden är en del av din loop/if sats. Detta gör att koden blir snyggare men annars har samma funktion som ett vanligt kodblock med flera
         * utförande inom sig. Men om du har flera utförande inom en loop/if statement som ska utföras måste du använda {} (Se exempel på rad 94-104).
       * ============================================================================================================================================================================================
       */
    }

}


