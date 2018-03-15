using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Flight
    {
        //class variable
        private static int number;
        //object variables
        enum currency
        {
            BAM,
            CHF,
            EUR,
            USD,
        }
        enum category
        {
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


        //Constructor
        public Flight(string fc, string fd, string dT, string dA, string aT, string desA, double price, Airplane plane)
        {
            this.flightCode = fc;
            this.flightDate = fd;
            this.departureTime = dT;
            this.departureAirport = dA;
            this.arrivalTime = aT;
            this.destinationAirport = desA;
            this.price = price;
            this.plane = plane;
            number++;
        }

        //Methods
        public double getPrice()
        {
            return this.price;
        }
        public Airplane getAirplane()
        {
            return this.plane;
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

    class Airplane
    {
        //class variable
        public static int numberOfPlanes;
        //object variables
        private string airPlaneRegistrationCode;
        private string airPlaneType;
        private int numberOfSeats;
        //Constructor
        public Airplane(string aPC, int nOfS, string airType)
        {
            this.airPlaneRegistrationCode = aPC;
            this.numberOfSeats = nOfS;
            this.airPlaneType = airType;
            numberOfPlanes++;
        }

        //Methods
        public string getAirPlaneCode()
        {
            return this.airPlaneRegistrationCode;
        }
        public int getNumberOfSeats()
        {
            return this.numberOfSeats;
        }
        public string getTypeOfPlane()
        {
            return this.airPlaneType;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int input;
            Airplane a01 = new Airplane("T9-OHU", 180, "A320");
            Flight f01 = new Flight("WZ123", "13.03.2018", "08:00", "Sarajevo", "09:15", "Vienna", 127.00, a01);

            Console.WriteLine("Airplane => Registration\t: " + a01.getAirPlaneCode() +" Anzahl der Sitzplaetze\t: " + a01.getNumberOfSeats() + " Flugzeugtyp\t: " + a01.getTypeOfPlane());
            Console.WriteLine("Flug => Folgendes Flugzeug wird auf dem Flug eingesetzt: "+ f01.getAirplane().getAirPlaneCode());
            
        }
    }
}