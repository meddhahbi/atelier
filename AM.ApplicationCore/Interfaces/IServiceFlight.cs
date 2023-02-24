using AM.ApplicationCore.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight
    {
        public List<DateTime> GetFlightDates(String destination);
        public IEnumerable<DateTime> GettFlightDates(String destination);
        // public void GetFlights(String filterType,String filterValue)


        public void showFlightsDetails(Plane plane);



        public int programmeFlightsNumber(DateTime startTime);


        public double durationAverage(string destination);


        public IList<Flight> orderDurationFlights();


        public IList<Traveller> seniorTravellers(Flight fl);


        public IList<IGrouping<string, Flight>> destinationGroupedFlights();


        
}
}
