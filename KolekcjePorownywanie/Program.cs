using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolekcjePorownywanie
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string strFilePath2 = @"C:\Users\Dominika\Desktop\detalhurt.csv";
            

            List<Ceny> c = new List<Ceny>();
            List<Ceny1> c1 = new List<Ceny1>();

            File.Delete(strFilePath2);
            

            using (StreamWriter str = new StreamWriter((strFilePath2), true, Encoding.GetEncoding(1252)))
            {
                str.WriteLine(@"Symbol;Nazwa;CenaBruttoDetalBaza;CenaBruttoDetalSubiekt;CenaBruttoHurtBaza;CenaBruttoHurtSubiekt;");
            }

            using (TextReader reader = File.OpenText(@"C:\Users\Dominika\Desktop\baza2345.csv"))
            using (TextReader reader1 = File.OpenText(@"C:\Users\Dominika\Desktop\lukisubiekt.csv"))
            {
                CsvReader csv = new CsvReader(reader);
                CsvReader csv1 = new CsvReader(reader1);

                csv.Configuration.Delimiter = ";";
                csv.Configuration.MissingFieldFound = null;

                csv1.Configuration.Delimiter = ";";
                csv1.Configuration.MissingFieldFound = null;

                while (csv.Read())
                {
                    Ceny Record = csv.GetRecord<Ceny>();
                    c.Add(Record);
                }

                while (csv1.Read())
                {
                    Ceny1 Record1 = csv1.GetRecord<Ceny1>();
                    c1.Add(Record1);

                }
                foreach (Ceny ce in c)
                    foreach(Ceny1 ce1 in c1)
                {
                        if (ce.Symbol.Equals(ce1.Symbol))
                        {
                            if (ce.CenaBruttoDetal != ce1.CenaBruttoDetal)
                            {

                                using (StreamWriter str = new StreamWriter((strFilePath2), true, Encoding.GetEncoding(1252)))
                                {

                                    str.WriteLine(String.Format("{0}; {1}; {2}; {3}; {4}; {5};", ce.Symbol, ce.Nazwa, ce.CenaBruttoDetal, ce1.CenaBruttoDetal, ce.CenaBruttoHurt, ce1.CenaBruttoHurt));


                                    str.Close();
                                }
                                //Console.WriteLine("Nie sa równe " + ce.CenaNetto1 + " " + ce1.CenaNetto1);
                            }

                            if (ce.CenaBruttoHurt != ce1.CenaBruttoHurt)
                            {
                                using (StreamWriter str = new StreamWriter((strFilePath2), true, Encoding.GetEncoding(1252)))
                                {

                                    str.WriteLine(String.Format("{0}; {1}; {2}; {3}; {4}; {5};", ce.Symbol, ce.Nazwa, ce.CenaBruttoDetal, ce1.CenaBruttoDetal, ce.CenaBruttoHurt, ce1.CenaBruttoHurt));


                                    str.Close();
                                }
                            }
                           
                        }
                }

            }
            Console.WriteLine("Zakończono. Dane zostały zapisane do pliku");
            Console.ReadKey(true);


                }

        
    }
        }




        

