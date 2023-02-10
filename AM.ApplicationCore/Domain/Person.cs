using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateNaissance { get; set; }

        public override string ToString()
        {
            return $"[{Id},{Nom},{Prenom},{Password},{Email},{DateNaissance}]";
        }

        public Person(int id, string nom, string prenom, string email, string password, DateTime dateNaissance)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Password = password;
            DateNaissance = dateNaissance;
        }

        public Person() { }

        public bool Login(string username, string password)
        {
            return username == Nom && password == Password;
        }

        public bool Login(string username , string password , string email)
        {

            return username == Nom && password == Password && email ==Email;
        }

        public virtual void getMyType()
        {
            Console.WriteLine("Hi I'am a person ");
        }
    }
}
