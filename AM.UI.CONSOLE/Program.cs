// See https://aka.ms/new-console-template for more information


using AM.ApplicationCore.Domain;

Person person = new Person();
person.Id = 0;
person.Nom = "test";
person.Prenom = "test";
person.Password = "dddd";
person.Email = "test@gmail.com";
person.DateNaissance = new DateTime(2022, 12, 31);
//person.DateNaissance= DateTime.Now;
Console.WriteLine(person);  


Person p = new Person(1,"test","test","test@gmail.com","azgiyda",DateTime.Now);
Console.WriteLine(p);

//pas d'ordre de propriete
Person per = new Person() { 
    Id=1,
    Nom="dhuozah",
    Prenom="dajda",
    Email="aidhaod",
    Password="iahdad",
    DateNaissance=DateTime.Now
};


Plane plane = new Plane();
plane.Capacity = 1; 
plane.PlaneId= 1;
plane.ManufactureDate = DateTime.Now;
plane.PlaneType = PlaneType.Boing;

Plane plane1= new Plane() { 
    Capacity= 1 ,
    PlaneId= 1 ,
    ManufactureDate=DateTime.Now,
    PlaneType=PlaneType.Airbus
   
};

Plane plane3 = new Plane(2, DateTime.Now, 1, PlaneType.Boing );



Passenger passenger = new Passenger();
passenger.passengerType();

Passenger Passenger1 = new Staff();
Passenger1.passengerType();

Passenger Passenger2 = new Traveller();
Passenger2.passengerType();







