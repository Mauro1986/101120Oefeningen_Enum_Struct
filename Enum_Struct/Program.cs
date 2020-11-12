using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EnumStructOEF1
{
    class Program
    {
        static void Main(string[] args)
        {
            //D
            Temperatuur temp;
            //I
            Console.WriteLine("Deze applicatie kan temperaturen omrekenen tussen C F en K");
            Console.WriteLine("Geef de om te rekenen temperatuur in, gevolgd door C, F of K");
            string[] input = Console.ReadLine().Split(' ');
            temp = new Temperatuur(
                (Eenheid)Enum.Parse(typeof(Eenheid), input[1]),
                double.Parse(input[0]));

            //P&O
            Console.WriteLine(temp.CalculateTemperatures(temp.Eenheid, temp.Value));
            Console.ReadLine();
        }
    }
    public struct Temperatuur
    {
        public Eenheid Eenheid;
        public double Value;
        public Temperatuur(Eenheid eenheid, double value)
        {
            Eenheid = eenheid;
            Value = value;
        }
        public string CalculateTemperatures(Eenheid eenheid, double value)
        {
            double celcius, kelvin, farenheit;
            switch (eenheid)
            {
                case Eenheid.C:
                    celcius = value;
                    farenheit = value * 1.8 + 32;
                    kelvin = value + 273.15;
                    break;
                case Eenheid.F:
                    celcius = (value - 32) / 1.8;
                    farenheit = value;
                    kelvin = (value - 32) * (5 / 9) + 273.15;
                    break;
                case Eenheid.K:
                    celcius = value - 273.15;
                    farenheit = (value - 273.15) * (9 / 5) + 32;
                    kelvin = value;
                    break;
                default:
                    celcius = 0;
                    kelvin = 0;
                    farenheit = 0;
                    break;
            }
            return $"Omgerekend is dit:\n{celcius}°C\n{kelvin}K\n{farenheit}°F";
        }
    }
    public enum Eenheid
    {
        C,
        F,
        K
    }
}



//namespace Enum_Struct
//{

//    public enum EenheidEnum
//    {
//        C = 1,
//        F,
//        K,
//    }

//    class Program
//    {

//        //        Schrijf een programma dat de temperatuurconversie kan doen tussen °C, °F en K.
//        //        Je geeft de temperatuur in in de temperatuurschaal naar jou keuze en het programma converteert
//        //        de temperatuur naar de andere 2 schalen.
//        //        Maak een enum eenheid waarin je de eenheid(C/F/K) kan bijhouden
//        //        Maak een struct Temperatuur die een eenheid en een waarde bijhoud


//        static void Main(string[] args)
//        {
//            Temperatuur = temp;
//            Console.WriteLine("Deze applicatie kan temperaturen omrekenen in C/F/K\n" +
//            "Geef de om te rekenen temperatuur in, gevolgd door C, F, K");
//            string[] input = Console.ReadLine().Split(' ');
//            temp = new Temperatuur(
//            (EenheidEnum)Enum.Parse(typeof(EenheidEnum), input[1]),
//            double.Parse(input[0]));



//            public struct Temperatuur
//        {
//            public EenheidEnum Eenheid;
//            public int Waarde;
//            public Temperatuur(int waarde, EenheidEnum eenheid);
//            {
//                Waarde = waarde;
//                Eenheid = eenheid;
//            }

//    }


//            #region ongebruikt maar misschien nuttig
//            //EenheidEnum c = (EenheidEnum)1;     //c = waarde van enum plaats 1
//            //Console.WriteLine(c);

//            //EenheidEnum f = EenheidEnum.F;      //f = waarde van enum met waarde F
//            //Console.WriteLine(f);

//            //EenheidEnum k = EenheidEnum.K;      //k = plaats van enum K = 3
//            //Console.WriteLine((int)k);




//            //Temperatuur s1 = new Temperatuur();
//            //s1.Eenheid = 'K';
//            //s1.Waarde = +273;

//            //Temperatuur s2 = new Temperatuur();
//            //s2.Eenheid = 'C';
//            //s2.Waarde = -273;

//            //Temperatuur s3 = new Temperatuur();
//            //s3.Eenheid = 'F';
//            //s3.Waarde = 11;

//            //Console.WriteLine("Deze applicatie kan temperaturen omrekenen in C/F/K\n" +
//            //"Geef de om te rekenen temperatuur in, gevolgd door C, F, K");

//            //int temp = Convert.ToInt32(Console.ReadLine());
//            //var input = Enum.Parse(typeof(EenheidEnum), Console.ReadLine());

//            //Console.Clear();
//            //Console.WriteLine($"{temp} {input}");
//            #endregion

//            foreach (int i in Enum.GetValues(typeof(EenheidEnum)))              //Enum.GetValues(typof     Toont alle plaatsen 0,1,2,3,4(int)     ENUMARATE VALUES
//            {
//                Console.WriteLine(i);
//            }

//foreach (string j in Enum.GetNames(typeof(EenheidEnum)))            //Enum.GetNames(typeof     Toont alle dagen(strings)                ENUMARATE NAMES
//{
//    Console.WriteLine(j);
//}

//switch (switch_on)
//{
//    case
//            }
//        }

//        public struct Temperatuur
//{

//    public int Waarde;
//    public string Eenheid;
//    //C = (F-32)/1.8 
//    //F = C* 1.8 + 32
//    //C = K – 273.15 
//    //K = C + 273.15

//}
//    }
//}
