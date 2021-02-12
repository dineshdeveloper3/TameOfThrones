using System;
using System.Collections.Generic;
using System.Text;

namespace TameOfThrones
{
    class Cipher
    {
        private static char[] Alphabets = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public static bool CheckCipher(string emblem, string _cipher)
        {
            int emblemLength = emblem.Length;
            bool matched = true;
            foreach (char c in emblem)
            {
                char cipherAlp = CipherAlphabet(c, emblemLength);
                if (_cipher.Contains(cipherAlp.ToString()))
                {
                    _cipher = _cipher.Remove(_cipher.IndexOf(cipherAlp), 1);
                }
                else
                {
                    matched = false;
                    break;
                }
            }

            return matched;
        }

        private static char CipherAlphabet(char alphabet, int emblemLength)
        {
            int matchedIndex = Array.IndexOf(Alphabets, alphabet);

            int neededCharacterIndex = matchedIndex + emblemLength;
            if (neededCharacterIndex >= Alphabets.Length)
            {
                return Alphabets[neededCharacterIndex - Alphabets.Length];
            }
            else
                return Alphabets[neededCharacterIndex];

        }


    }
}
