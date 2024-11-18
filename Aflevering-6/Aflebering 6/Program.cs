namespace Aflebering_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til IP/Binær konverteringsprogrammet!");
            Console.WriteLine("Tryk ESC for at afslutte.");

            while (true)
            {
                Console.WriteLine("Skriv 'IP' for at konvertere en IP-adresse til binært.");
                Console.WriteLine("Skriv 'BI' for at konvertere en binær IP-adresse til decimal.");
                Console.Write("Dit valg: ");

                string valg = Console.ReadLine().ToUpper();

                if (valg == "IP")
                {
                    KonverterIpTilBinær();
                }
                else if (valg == "BI")
                {
                    KonverterBinærTilIp();
                }
                else
                {
                    Console.WriteLine("Ugyldigt valg. Prøv igen.");
                }

                Console.WriteLine("Vil du lave en ny konvertering? Tryk ESC for at afslutte.");
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Farvel!");
                    break;
                }
            }
        }

        static void KonverterIpTilBinær()
        {
            Console.Write("Indtast en IP-adresse (fx 192.168.1.1): ");
            string ipInput = Console.ReadLine();
            string[] decimalGroups = ipInput.Split('.'); // Opdel IP-adressen i grupper
            List<string> binGroups = new List<string>();

            foreach (string decimalGroup in decimalGroups)
            {
                if (int.TryParse(decimalGroup, out int decInput) && decInput >= 0 && decInput <= 255)
                {
                    List<int> binResultat = new List<int>();
                    while (decInput > 0)
                    {
                        binResultat.Add(decInput % 2); // Gem resten
                        decInput /= 2;
                    }

                    while (binResultat.Count < 8)
                    {
                        binResultat.Add(0); // Fyld op med 0'er for at få 8 bits
                    }

                    binResultat.Reverse(); // Omvend rækkefølgen
                    binGroups.Add(string.Join("", binResultat)); // Saml binærstreng
                }
                else
                {
                    Console.WriteLine($"'{decimalGroup}' er ikke en gyldig IP-adresse del.");
                    return;
                }
            }

            Console.WriteLine("Binært resultat: " + string.Join(".", binGroups));
        }

        static void KonverterBinærTilIp()
        {
            Console.Write("Indtast en binær IP-adresse (fx 11000000.10101000.00000001.00000001): ");
            string binInput = Console.ReadLine();
            string[] binGroupsInput = binInput.Split('.');
            List<int> decGroups = new List<int>();

            foreach (string binGroup in binGroupsInput)
            {
                if (binGroup.Length == 8 && binGroup.Trim('0', '1').Length == 0)
                {
                    int decResultat = 0;
                    int power = 1;

                    for (int i = binGroup.Length - 1; i >= 0; i--)
                    {
                        if (binGroup[i] == '1')
                        {
                            decResultat += power;
                        }
                        power *= 2;
                    }

                    decGroups.Add(decResultat); // Gem resultatet
                }
                else
                {
                    Console.WriteLine($"'{binGroup}' er ikke en gyldig binær del.");
                    return;
                }
            }

            Console.WriteLine("Decimal resultat: " + string.Join(".", decGroups));
        }
    }
}

//string binStrinput = Console.ReadLine();
//bool[] arrBool = new bool[binStrinput.Length];
//int = int = 0; 
//foreach (char c in binStrinput)
//{
//    Console.WriteLine(c);
//    if (c == '1')
//    {
//        arrBool[0] = true;
//    }
//    else if (c=='0')
//    {
//        arrBool[0] = false;
//    }
//    else { throw new Exception ("Input er ikke binært! kun 1ere og 0ere tak!") }


//indtast binær streng, feks 1100101
///Konverter til binær array

//    bool[] binArr = { true, true, false, false, true, false, true };

//int power = 1;
//int decResultat = 0;
//foreach (bool b in binArr)
//{
//    Console.WriteLine($"pos {power}" + b);
//    if (b) decResultat = decResultat + power;
//    Console.WriteLine("Decimal delresultat " + decResultat);
//    power = power + power;





