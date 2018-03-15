/*
 *  Author          : Emir Sinanovic
 *  Name            : Flight Managment System
 *  Date            : 14.03.2018
 *  Last modified   : 14.03.2018 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3{
    //Flight
    class Flight{
        //class variable
        public static int numberOfFlights;
        //object variables
        enum currency{
            BAM,
            CHF,
            EUR,
            USD,
        }
        enum category{
            business,
            economy
        }
        private string flightCode;
        private string flightDate;
        private string departureTime;
        private string departureAirport;
        private string arrivalTime;
        private string destinationAirport;
        private double price;
        Airplane plane;
        HumanResources.Staff staff;


        //Constructor
        public Flight(string fc, string fd, string dT, string dA, string aT, string desA, double price, Airplane plane, HumanResources.Staff st){
            this.flightCode = fc;
            this.flightDate = fd;
            this.departureTime = dT;
            this.departureAirport = dA;
            this.arrivalTime = aT;
            this.destinationAirport = desA;
            this.price = price;
            this.plane = plane;
            staff = st;
            numberOfFlights++;
        }

        //Methods
        private double getPrice()
        {
            return this.price;
        }
        public double calculatePrice(string currency)
        {
            if (currency == "BAM")
            {
                return getPrice() * 1.95;
            }
            else if (currency == "CHF")
            {
                return getPrice() * 1.16;
            }
            else if (currency == "EUR")
            {
                return getPrice() * 1.00;
            }
            else
            {
                return getPrice() * 1.34;
            }
        }

    }
    //Airplane
    class Airplane
    {
        public static int numberOfPlanes;

        //Instance variables
        private string registrationID;
        private string type;
        private int numberOfBusinessSeats;
        private int numberOfEconomySeats;

        public Airplane(string regid, string tp, int busSeat, int ecoSeat) {
            registrationID = regid;
            type = tp;
            numberOfBusinessSeats = busSeat;
            numberOfEconomySeats = ecoSeat;
            numberOfPlanes++;
        }
    }

    //Staff
    interface GlobalDeclaration {
        void printData();
    }
    namespace HumanResources
    {
        class Staff : GlobalDeclaration
        {
            public static int numberOfStaff;

            private string personID;
            private string firstName;
            private string lastName;
            private string gender;
            private bool availability;

            //Staff Constructor
            public Staff(string piD, string fName, string lName, string gend, bool avail)
            {
                personID = piD;
                firstName = fName;
                lastName = lName;
                gender = gend;
                availability = avail;

                numberOfStaff++;
            }

            public static int getNumberOfStaff()
            {
                return numberOfStaff;
            }
            public void printData()
            {
            }
        }
        //Crew extends Staff
        class Crew : Staff
        {
            public static int numberOfCrew;

            private string language;

            public Crew(string piD, string fName, string lName, string gender, bool avail, string lang)
                : base(piD, fName, lName, gender, avail)
            {
                language = lang;
                numberOfCrew++;
            }

            public static int getNumberOfCrew()
            {
                return numberOfCrew;
            }
            public string getlanguage()
            {
                return language;
            }
        }
        //Pilot
        class Pilot : Staff
        {
            public static int numberOfPilots;

            private string role;
            private string typeRating;

            public Pilot(string piD, string fName, string lName, string gender, bool avail, string ro, string typeR)
                : base(piD, fName, lName, gender, avail)
            {
                role = ro;
                typeRating = typeR;
                numberOfPilots++;
            }
            public static int getNumberOfPilots()
            {
                return numberOfPilots;
            }
            public string getRole()
            {
                return role;
            }
            public string getTypeRating()
            {
                return typeRating;
            }
        }
    }

    //Main program
    class Program{
        static void Main(string[] args){
            int input;
            Console.WriteLine("OOM - Task 3");
            Console.WriteLine("Flight Management System");
            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("Staff\n" +
                              "Anzahl der Mitarbeiter ("+ HumanResources.Staff.getNumberOfStaff()+") | "+
                              "Anzahl der FlugbegleiterInnen (" + HumanResources.Crew.getNumberOfCrew() + ") | " +
                              "Anzahl der PilotInnen("+ HumanResources.Pilot.getNumberOfPilots()+")");

            Console.WriteLine("Airplane\n" +
                              "Anzahl der Flugzeuge (" + Airplane.numberOfPlanes + ")");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Console.Write("Geben Sie Ihre Wahl ein [" +
                "0 - Beenden\n" +
                "\t\t\t 1 - Mitarbeiter einfuegen\n" +
                "\t\t\t 2 - Flugzeug einfuegen\n" +
                "\t\t\t 3 - Flugdaten einfuegen]: ");
            input = Convert.ToInt32(Console.ReadLine());
            do {

                if (input == 1)
                {
                    //Staff
                    HumanResources.Crew crew_member1 = new HumanResources.Crew("12001", "Dona", "Muster", "female", true, "English");
                    HumanResources.Pilot cabine_member1 = new HumanResources.Pilot("21001", "Emir", "Sinanovic", "Male", true, "Captain", "A320");
                    HumanResources.Pilot cabine_member2 = new HumanResources.Pilot("22002", "Tarik", "Sinanov", "Male", true, "Copilot", "A320");
                    HumanResources.Crew crew_member2 = new HumanResources.Crew("11002", "Lisa", "Musterfrau", "female", true, "English");
                    HumanResources.Crew crew_member3 = new HumanResources.Crew("11003", "Maya", "Sinanova", "female", true, "German");
                }
                else if (input == 2)
                {
                    //Airplane
                    Airplane a01 = new Airplane("OE-ATA", "A320", 30, 200);
                    Airplane a02 = new Airplane("OE-ATB", "A190", 20, 170);
                }
                else if (input == 3)
                {
                    if (Flight.numberOfFlights == 0)
                    {
                        Console.WriteLine("Derzeit existieren keine Fluege. Bitte fuegen Sie zuerts Flugzeug und/oder Mitarbeiter ein!");
                    }
                }
                else {
                    Console.WriteLine("Ungueltige Eingabe!");
                }

                Console.WriteLine("Staff\n" +
                  "Anzahl der Mitarbeiter (" + HumanResources.Staff.getNumberOfStaff() + ") | " +
                  "Anzahl der FlugbegleiterInnen (" + HumanResources.Crew.getNumberOfCrew() + ") | " +
                  "Anzahl der PilotInnen(" + HumanResources.Pilot.getNumberOfPilots() + ")");

                Console.WriteLine("Airplane\n" +
                  "Anzahl der Flugzeuge (" + Airplane.numberOfPlanes + ")");


                Console.Write("Geben Sie Ihre Wahl ein [0 - Beenden]: ");
                input = Convert.ToInt32(Console.ReadLine());
            } while (input!=0);
            
        }
    }
}
