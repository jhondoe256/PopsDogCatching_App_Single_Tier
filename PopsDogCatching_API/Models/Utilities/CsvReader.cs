using PopsDogCatching_API.Models.Data_POCOs.Dogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PopsDogCatching_API.Models.Utilities
{
    public static class CsvReader
    {
        //when using cloned version get the 'fci-breeds_MODIFIED.csv' file from:
        // \Dogs\Stuff\fci-breeds\fci-breeds_MODIFIED.csv 
        //Right-click the fci-breeds_MODIFIED.csv file and choose properties
        //in properties menu choose take the full path file location and copy it 
        //and paste it below...(it should be different than mine...)
        private static string _csvFilePath=
        @"D:\_MyElevenFiftyFiles\RestaurantRaterAPI_SingleTier\PopsDogCatching\PopsDogCatching_App\PopsDogCatching_API\Models\Data_POCOs\Dogs\Stuff\fci-breeds\fci-breeds_MODIFIED.csv";

        public static List<Breed> ReadAllBreeds()
        {
            List<Breed> breeds =  new List<Breed>();

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                //read header line
                sr.ReadLine();

                string csvLine;
                while ((csvLine = sr.ReadLine()) != null && (csvLine = sr.ReadLine()) !="")
                {
                    breeds.Add(ReadBreedFromCsvLine(csvLine));
                }
            }

            return breeds;
        }
        private static Breed ReadBreedFromCsvLine(string csvLine)
        {
            string[] breedObjSections = csvLine.Split(',');

            string breedName = breedObjSections[0];
            string section = breedObjSections[1];
            string country = breedObjSections[2];
       
            var breed = new Breed(breedName, section, country);
            return breed;
        }
    }
}