using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Services.Services
{
    public class GameServices
    {
        private readonly List<string> _responseList;

        public GameServices()
        {
            _responseList = GetDictionary();
        }

        public List<string> GetDictionary()
        {
            string rutaArchivo = "dictionary.txt";

            List<string> lineasArchivo = new List<string>();

            using (StreamReader sr = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    lineasArchivo.Add(linea);
                }
            }

            return lineasArchivo;
        }

        public List<string> GetCombinations(string inputLetters, int inputLength)
        {
            List<string> validWords = new List<string>();
            List<char> chars = new List<char>(inputLetters.ToCharArray());

            foreach (string word in _responseList)
            {
                // Clonar la lista de caracteres para que no se modifique la original
                List<char> remainingChars = new List<char>(chars);

                bool isValid = true;

                // Iterar sobre cada letra en la palabra
                foreach (char letter in word)
                {
                    // Buscar la letra en la lista de caracteres
                    int index = remainingChars.IndexOf(letter);

                    // Si la letra no se encuentra en la lista, la palabra no es válida
                    if (index == -1)
                    {
                        isValid = false;
                        break;
                    }

                    // Si la letra se encuentra en la lista, quitarla de la lista para no utilizarla de nuevo
                    remainingChars.RemoveAt(index);
                }

                // Si la palabra es válida, añadirla a la lista de palabras válidas
                if (isValid)
                {
                    validWords.Add(word);
                }
            }

            validWords = validWords.FindAll(x => x.Length == inputLength);
            return validWords;
        }
    }
}
