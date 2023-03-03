using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();



        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].Destination == destination)
                {
                    dates.Add(Flights[i].FlightDate);
                }
            }
            return dates;
        }
        /*   public List<DateTime> GetFlightDates2(string destination)
           {
               List<DateTime> dates = new List<DateTime>();
               Flights.ForEach(f =>
               {
                   if (f.Destination == destination)
                   {
                       dates.Add(f.FlightDate);
                   };
               }
               );
               return dates;
           }*/

        //Linq
        public IList<DateTime> GetFlightDate(string destination)
        {

           /* var query = from f in Flights
                        where f.Destination == destination
                        select f.FlightDate;
            reutrn query.ToList();*/


                var qurey=Flights.Where(f=>f.Destination== destination)
                .Select(f=>f.FlightDate);

            return qurey.ToList();


        }




        public void showFlightsDetails(Plane plane)
        {
            /* var req = from f in Flights
                 where (f.plane == plane)
                 select new { f.FlightDate, f.Destination 
                 };

             foreach (var item in req) {
                 Console.WriteLine(item.Destination + "" + item.FlightDate);
             }*/



            var req = Flights
                .Where(f => f.plane == plane)
                .Select(f => new { f.FlightDate, f.Destination });

            foreach(var item in req) {
                Console.WriteLine(item.Destination + "" + item.FlightDate);
            }

        }



        public int programmeFlightsNumber(DateTime startTime)
        {
           /* var req = from f in Flights
                   //   where (f.FlightDate > startTime && f.FlightDate<startTime.AddDays(7))
                   where f.FlightDate>startTime && (f.FlightDate - startTime).TotalDays<7
                   select f;

            return req.Count();*/


            return Flights
                .Where(f =>  f.FlightDate > startTime && (f.FlightDate - startTime).TotalDays < 7)
                .Count();



        }



        public double durationAverage(string destination)
        {
            /* var query = from f in Flights
                         where f.Destination == destination
                         select f.EstimatedDuration;

             return query.Average();*/


            var query = Flights
                .Where(f => f.Destination == destination)
                .Average(f=>f.EstimatedDuration);

            return query;


        }



        public IList<Flight> orderDurationFlights()
        {
            /*var query = from f in Flights
                        orderby f.EstimatedDuration descending
                        select f;
            return query.ToList();*/


            var q = Flights
                .OrderByDescending(f=>f.EstimatedDuration).ToList();
            return q;
        }




        public IList<Traveller> seniorTravellers(Flight fl)
        {
            var query = (from f in Flights
                        where f.FlightId == fl.FlightId
                        select f).Single();


            return query.passangers
                .OfType<Traveller>().ToList().OrderBy(p=>p.BirthDate).Take(3).ToList();
        }




        public IList<IGrouping<string, Flight>> destinationGroupedFlights()
        {
            var req= Flights
                .GroupBy(f => f.Destination).ToList();

            foreach (var item in req)
            {
                Console.WriteLine(item.Key);
                foreach (var item2 in item)
                {

                    Console.WriteLine(item2.FlightDate);
                }
            }
            return req;

        }


        Action<Plane> flightDetailsDel;
        Func<string, double> durationAverageDel;


        public ServiceFlight()
        {

            flightDetailsDel =  plane=>
        {
                /* var req = from f in Flights
                     where (f.plane == plane)
                     select new { f.FlightDate, f.Destination 
                     };

                 foreach (var item in req) {
                     Console.WriteLine(item.Destination + "" + item.FlightDate);
                 }*/



                var req = Flights
                    .Where(f => f.plane == plane)
                    .Select(f => new { f.FlightDate, f.Destination });

                foreach (var item in req)
                {
                    Console.WriteLine(item.Destination + "" + item.FlightDate);
                }

            };
            durationAverageDel =  destination=>
        {
                /* var query = from f in Flights
                             where f.Destination == destination
                             select f.EstimatedDuration;

                 return query.Average();*/


                var query = Flights
                    .Where(f => f.Destination == destination)
                    .Average(f => f.EstimatedDuration);

                return query;


            };


        }


        



        public IEnumerable<DateTime> GettFlightDates(string destination)
        {

            foreach (Flight flight in Flights)
            {
                if (flight.Destination == destination)
                {

                    yield return flight.FlightDate;
                }
            }

        }

        public void GetFlights(string filterValue, Func<string, Flight, Boolean> func)
        {

            Func<string, Flight, Boolean> Condition = func;
            foreach (var item in Flights)
            {
                if (Condition(filterValue, item))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }   
    }
