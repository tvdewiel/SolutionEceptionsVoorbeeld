using AdresSysteem;
using System;

namespace ConsoleApp_1
{
    class Program
    {
        public static void ShowExceptionDetails(Exception e)
        {
            Console.WriteLine("-----------");
            Console.WriteLine($"Type: {e.GetType()}");
            Console.WriteLine($"Source: {e.Source}");
            Console.WriteLine($"TargetSite: {e.TargetSite.GetType()}");
            Console.WriteLine($"Message: {e.Message}");
            foreach (var x in e.Data)
            {
                Console.WriteLine($"data:", x);
            }
            Console.WriteLine("-----------");
        }
        public static string GetGemeentenaam()
        {
            Console.Write("Geef gemeentenaam :");
            return Console.ReadLine();
        }
        public static string GetStraatnaam()
        {
            Console.Write("Geef straatnaam :");
            return Console.ReadLine();
        }
        public static string GetHuisnummer()
        {
            Console.Write("Geef huisnummer :");
            return Console.ReadLine();
        }
        public static (string, string, string) GetAdres()
        {
            string gemeentenaam = GetGemeentenaam();
            string straatnaam = GetStraatnaam();
            string huisnummer = GetHuisnummer();
            return (gemeentenaam, straatnaam, huisnummer);
        }
        public static void VerwerkAdresInfo(string gemeentenaam, string straatnaam, string huisnummer, Adresbeheerder adresbeheerder)
        {
            Adres a1 = new Adres(gemeentenaam, straatnaam, huisnummer);
            adresbeheerder.VoegAdresToe(a1);
            Console.WriteLine($"[Adres] {a1.PrintPostAdresOpLijn()}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            bool detailMode = true;
            string gemeentenaam = "";
            string straatnaam = "";
            string huisnummer = "";
            Adresbeheerder adresbeheerder = new Adresbeheerder();

            int keuze;
            while (true)
            {
                try
                {
                    Console.WriteLine("Maak keuze : [1] adres toevoegen, [2] adressen tonen, [3] stoppen");
                    keuze = int.Parse(Console.ReadLine());
                    switch (keuze)
                    {
                        case 1:
                            (gemeentenaam, straatnaam, huisnummer) = GetAdres();
                            VerwerkAdresInfo(gemeentenaam, straatnaam, huisnummer, adresbeheerder); break;
                        case 2: adresbeheerder.PrintAdresssen(); break;
                        case 3: Environment.Exit(0); break;
                    }
                }
                catch (AdresException ex)
                {
                    if (detailMode) ShowExceptionDetails(ex);
                    //input is fout probeer invoer opnieuw
                    if (ex is GemeenteException) gemeentenaam = GetGemeentenaam();
                    if (ex is StraatnaamException) straatnaam = GetStraatnaam();
                    if (ex is HuisnummerException) huisnummer = GetHuisnummer();
                    try
                    {
                        VerwerkAdresInfo(gemeentenaam, straatnaam, huisnummer, adresbeheerder);
                    }
                    catch (Exception e)
                    {
                        if (detailMode) ShowExceptionDetails(e);
                        Console.WriteLine("sorry man - we proberen helemaal opnieuw");
                    }
                }
                
                catch (AdresbeheerderException ex)
                {
                    if (detailMode) ShowExceptionDetails(ex);
                    //beheer probleem - start de lus opnieuw
                }
                catch (Exception ex)
                {
                    if (detailMode) ShowExceptionDetails(ex);
                    Console.WriteLine("No adres exception - I quit");
                    Environment.Exit(1000);
                }
            }
        }
    }
}
