
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EnumStruct2
{
    class Program
    {
        #region Opgave
//        1. Maak een struct ‘Tijd’ die de tijd kan bijhouden(uren en minuten). Maak een methode
//‘BerekenDuur’ die de duur kan berekenen tussen 2 tijden.Schrijf een testprogramma in Main
//om de methode BerekenDuur te testen.(maak ook methodes om tijden in te kunnen lezen en
//te kunnen tonen)
//2. Breid het programma uit vorige oefening uit met een struct Afspraak, bestaande uit een
//begintijd en een eindtijd.Maak een methode die een afspraak kan tonen: begintijd, eindtijd
//en de duur van de afspraak.Maak ook een methode die een nieuwe afspraak kan inlezen.
//Schrijf een testprogramma in Main met een menu met 3 opties.Afspraken toevoegen,
//afspraken tonen en de laatste optie om het programma af te sluiten.
//3. Breid het programma uit vorige oefening uit.Een afspraak heeft een AfspraakType(enum). Er
//zijn 2 mogelijkheden: prive of werk.
//Breid het menu uit met 2 mogelijkheden om enkel de prive afspraken te zien of enkel de
//werk afspraken.
        #endregion

        static void Main(string[] args)
        {
            List<Afspraak> afspraken = new List<Afspraak>();
            List<Afspraak> wanted = new List<Afspraak>();
            afspraken.Add(new Afspraak("test1", AfspraakType.Prive, new Tijd(30, 15), new Tijd(15, 16)));
            afspraken.Add(new Afspraak("test2", AfspraakType.Werk, new Tijd(30, 14), new Tijd(15, 16)));
            afspraken.Add(new Afspraak("test3", AfspraakType.Prive, new Tijd(23, 09), new Tijd(30, 17)));
            afspraken.Add(new Afspraak("test4", AfspraakType.Werk, new Tijd(00, 9), new Tijd(30, 17)));
            afspraken.Add(new Afspraak("test5", AfspraakType.Prive, new Tijd(48, 6), new Tijd(15, 16)));
            int menuOption;
            bool menuOpen = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Wat wilt u doen?\n1: afspraak toevoegen\n2: alle afspraken tonen\n3: alle werk afspraken tonen\n4: alle privé afspraken tonen\n5: stoppen");
                menuOption = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (menuOption)
                {
                    case 1:
                        afspraken.Add(AskAfspraak());
                        menuOpen = true;
                        break;
                    case 2:
                        foreach (var item in afspraken)
                        {
                            Console.WriteLine(item.ToString() + Environment.NewLine);
                        }
                        menuOpen = true;
                        Console.ReadLine();
                        break;
                    case 3:
                        wanted = afspraken.Where(e => e.AfspraakType == AfspraakType.Werk).ToList();
                        foreach (var item in wanted)
                        {
                            Console.WriteLine(item.ToString() + Environment.NewLine);
                        }
                        Console.ReadLine();
                        break;
                    case 4:
                        wanted = afspraken.Where(e => e.AfspraakType == AfspraakType.Prive).ToList();
                        foreach (var item in wanted)
                        {
                            Console.WriteLine(item.ToString() + Environment.NewLine);
                        }
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("Doei");
                        menuOpen = false;
                        break;
                    default:
                        menuOpen = true;
                        break;
                }
            } while (menuOpen);
            Console.ReadLine();
        }

        private static Afspraak AskAfspraak()
        {
            Console.WriteLine("Geef de naam van de afspraak");
            string afspraakNaam = Console.ReadLine();
            Tijd starttijd = AskTijd();
            Tijd eindtijd = AskTijd();
            Console.WriteLine("wilt u \n1: werkafspraak\n2: priveafspraak");
            int choice = int.Parse(Console.ReadLine());
            AfspraakType afspraakType = (AfspraakType)choice;
            Console.Clear();
            return new Afspraak(afspraakNaam, afspraakType, starttijd, eindtijd);
        }

        //SOC
        //SEPERATIONS OF CONCERNS
        private static Tijd AskTijd()
        {
            int[] time;
            Console.WriteLine("Geef de tijd (HH:MM)");
            time = Array.ConvertAll(Console.ReadLine().Split(':'), e => int.Parse(e));
            return new Tijd(time[1], time[0]);
        }
    }
    struct Tijd
    {
        #region PROPERTIES
        public int Hours;
        public int Minutes;
        #endregion
        #region CONSTRUCTOR
        public Tijd(int minutes, int hours)
        {
            Minutes = minutes;
            Hours = hours;
        }
        #endregion
        #region METHODS
        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}";
        }
        #endregion
    }
    struct Afspraak
    {
        public string Naam;
        public AfspraakType AfspraakType;
        public Tijd Starttijd;
        public Tijd Eindtijd;
        public int Duur;
        public Afspraak(string naam, AfspraakType afspraakType, Tijd starttijd, Tijd eindtijd)
        {
            AfspraakType = afspraakType;
            Naam = naam;
            Starttijd = starttijd;
            Eindtijd = eindtijd;
            Duur = BerekenDuur(starttijd, eindtijd);
        }
        private static int BerekenDuur(Tijd starttijd, Tijd eindtijd)
        {
            int totalStartMinutes, totalEndMinutes, duur;
            totalStartMinutes = TotalMinutes(starttijd);
            totalEndMinutes = TotalMinutes(eindtijd);
            duur = totalEndMinutes - totalStartMinutes;
            return duur;
        }
        private static int TotalMinutes(Tijd tijd)
        {
            return tijd.Hours * 60 + tijd.Minutes;
        }
        public override string ToString()
        {
            return $"Afspraak: {Naam}\nAfspraakType: {AfspraakType}\nStarttijd: {Starttijd}\nEindtijd: {Eindtijd}\nDuur: {Duur / 60:D2}:{Duur % 60:D2}";
        }
    }
    enum AfspraakType
    {
        Werk,
        Prive
    }
}