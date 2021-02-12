using System;
using System.Collections.Generic;
using System.IO;

namespace TameOfThrones
{
    class Program
    {

        private static Dictionary<string, string> KingDomEmblems = new Dictionary<string, string>(){
    {"SPACE", "GORILLA"},
    {"LAND", "PANDA"},
    {"WATER", "OCTOPUS"}, 
    {"ICE", "MAMMOTH"},
    {"AIR", "OWL"},
    {"FIRE", "DRAGON"}
};

      
        static void Main(string[] args)
        {
            BecomeKing(Convert.ToString(args[0]));
        }

        private static void BecomeKing(string filePath)
        {
            List<string> acquiredKingdoms = new List<string>();

            if (File.Exists(filePath))
            {
                string line;
                StreamReader file =
                       new StreamReader(filePath);

              
                while ((line = file.ReadLine()) != null)
                {
                    string[] message = line.Split(' ');
                    string kingDom = message[0];
                    string cipher = string.Empty;
                    for (int noOfcipherWords = 1; noOfcipherWords < message.Length; noOfcipherWords++)
                    {
                         cipher = cipher + message[noOfcipherWords].Trim();
                    }

                    if (!acquiredKingdoms.Contains(kingDom) && Cipher.CheckCipher(KingDomEmblems[kingDom], cipher))
                    {
                        acquiredKingdoms.Add(kingDom);
                    }
                }

                file.Close();
            }
            PrintResult(acquiredKingdoms);

        }

        private static void PrintResult(List<string> acquiredKingdoms)
        {
            if (acquiredKingdoms.Count >= 3)
            {
                Console.Write("SPACE ");
                foreach (string acquiredKindom in acquiredKingdoms)
                {
                    Console.Write(acquiredKindom + " ");
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }

      
    }
}
