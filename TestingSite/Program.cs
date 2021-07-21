using PopsDogCatching_API.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSite
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfBreeds = CsvReader.ReadAllBreeds();

            foreach (var breed in listOfBreeds)
            {
                Console.WriteLine(breed.BreedName);
            }

            Console.ReadKey();
        }
    }
}
