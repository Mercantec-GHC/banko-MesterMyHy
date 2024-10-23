
using System;
// bruger internal fordi jeg ikke bruger den i andre koder eller bedre sagt så jeg ikke kalder på noget jeg laver ved et uheld i andre koder
internal class Spil
{
    // det er pladerne som er her som kan ses på hvert ID, grunden til string og ikke int er at vi markere de tal som er blevet udelukket med et X
    private static void Main(string[] args)
    {
        string[,] plade1 = { { "1", "2", "3", "4", "5" }, { "6", "7", "8", "9", "11" }, { "12", "13", "14", "15", "16" } };
        string[,] plade2 = { { "1", "2", "3", "4", "5" }, { "6", "7", "8", "9", "11" }, { "12", "13", "14", "15", "16" } };
        string[,] plade3 = { { "1", "2", "3", "4", "5" }, { "6", "7", "8", "9", "11" }, { "12", "13", "14", "15", "16" } };


        // det er bare for at printe koden
        Console.WriteLine("Plade 1:");
        PrintPlade(plade1);

        Console.WriteLine("Plade2:");
        PrintPlade(plade2);

        Console.WriteLine("Plade3:");
        PrintPlade(plade3);

        // while true i dette tilfælde holder loopet kørende så den ikke bare stopper efter førse nummer er skrevet 
        while (true) { 

            Console.WriteLine("skriv de tal der bliver sagt");
            string svar = Console.ReadLine();
            if (svar.Trim().ToLower() == "exit")
            {
                break;
            }

            string[] inputnumbers = svar.Split(',');
            // giver lidt sig selv men den bruger en funktion til at udelukke numrene på pladen
            foreach (string number in inputnumbers)
            {
                if (int.TryParse(number.Trim(), out int num))
                {
                    RuleOutNumber(plade1, num.ToString());
                    RuleOutNumber(plade2, num.ToString());
                    RuleOutNumber(plade3, num.ToString());
                }
                else
                {
                    // hvis numeret ikke er på pladen skriver den det
                    Console.WriteLine("nummer er ikke med på pladen");
            
                }
                // bare det den skriver er nok forklaring men den opdatere pladerne
                Console.WriteLine("Pladerne er opdateret");

                Console.WriteLine("Plade 1:");
                PrintPlade(plade1);

                Console.WriteLine("Plade 2:");
                PrintPlade(plade2);

                Console.WriteLine("Plade 3:");
                PrintPlade(plade3);
            }
        }
       
       
    }

    //det er funktion vi bruger til udelukning af de numre som bliver sagt
    private static void RuleOutNumber(string[,] plade, string num)
    {
        for (int i = 0; i < plade.GetLength(0); i++)
        {
            for (int j = 0; j < plade.GetLength(1); j++)
            {
                //her siger vi hvis den finder det tal som er på pladen vil den markere det med et X og skrive den udelukker det
                if (plade[i, j] == num)
                {
                    plade[i, j] = "X"; 
                    Console.WriteLine($"udelukker {num} fra pladen");
                }
            }
        }

    }
        // det er den kode der bliver brugt til opsætning af selve pladen
        private static void PrintPlade(string[,] plade)
    {
        for (int i = 0; i < plade.GetLength(0); i++)
        {
            for (int j = 0; j < plade.GetLength(1); j++)
            {
                //den brokker sig men det er fordi tallende står ved siden af hinanden i steden for hele vejen ned
                Console.Write(plade[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
