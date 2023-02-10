using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public int PassportNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int TelNumber { get; set; }  

        public IList<Flight> flights { get; set; }

        public override string ToString()
        {
            return $"BirthDate: {BirthDate}, PassportNumber: {PassportNumber}, EmailAddress: {EmailAddress}, FirstName: {FirstName}, LastName: {LastName}, TelNumber: {TelNumber}";
        }

        public bool CheckProfile(string nom , string prenom)
        {
            return FirstName==nom&& LastName==prenom ;
        }

        public bool CheckProfile(string nom, string prenom,string email)
        {
            return FirstName == nom && LastName == prenom && EmailAddress==email;
        }

        

        public  virtual void passengerType()
        {
            Console.WriteLine("Hi I'am a person ");
        }
       
        
    }
}
