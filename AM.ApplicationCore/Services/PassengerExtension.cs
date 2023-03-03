using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public static class PassengerExtension
    {

        public static void fullNameUppercase(this Passanger p) { 
            
              
         p.FirstName = p.FirstName[0].ToString().ToUpper() + p.FirstName.AsSpan(1).ToString();
        p.LastName = char.ToUpper(p.LastName[0])+p.LastName.Substring(1);
        
        }




    }
}
