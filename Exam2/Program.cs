    using System;
    using System.Runtime.ConstrainedExecution;

    List<Person> people = new List<Person>
            {
                new Person { Id = 1, Name = "Ali", Age = 25, CityId = 1 },
                new Person { Id = 2, Name = "Madina", Age = 30, CityId = 2 },
                new Person { Id = 3, Name = "Jasur", Age = 28, CityId = 3 },
                new Person { Id = 4, Name = "Dilnoza", Age = 22, CityId = 1 },
                new Person { Id = 5, Name = "Kamol", Age = 35, CityId = 4 },
                new Person { Id = 6, Name = "Bobur", Age = 40, CityId = 5 }
            };


    List<City> cities = new List<City>
            {
                new City { Id = 1, Aholisi = 300000000, Name = "Piter", CountryId = "Rus" },
                new City { Id = 2, Aholisi = 3200000000, Name = "Samarqand", CountryId = "Uzb" },
                new City { Id = 3, Aholisi = 2000000, Name = "Buxoro", CountryId = "Uzb" },
                new City { Id = 4, Aholisi = 1200000, Name = "Moskva", CountryId = "Rus" },
                new City { Id = 5, Aholisi = 9000000000,  Name = "Namangan", CountryId = "Uzb" },
                new City { Id = 6, Aholisi = 800000,  Name = "Farg'ona", CountryId = "Uzb" }
            };


    List<Countries> countries = new List<Countries>
            {
                new Countries { Id = 1, Cityname = "Toshkent" },
                new Countries { Id = 2, Cityname = "Samarqand" },
                new Countries { Id = 3, Cityname = "Buxoro" },
                new Countries { Id = 4, Cityname = "Andijon" },
                new Countries { Id = 5, Cityname = "Namangan" },
                new Countries { Id = 6, Cityname = "Farg'ona" }
            };

    Console.WriteLine("================ 1 ==================\n");
    var result1 = from city in cities
                 where city.Aholisi > 3000000000
                 select city;
    foreach (var city in result1)
    {
        Console.WriteLine("Shahar nomi: " + city.Name + ", Aholi soni: " + city.Aholisi);
    }

    Console.WriteLine("================ 2 ==================\n");

var result2 = from city in cities
              group city by city.CountryId into g
              let avgPop = g.Average(c => c.Aholisi)
              from c in g
              where c.Aholisi > avgPop
              select new
              {
                  Country = g.Key,
                  CityName = c.Name,
                  Population = c.Aholisi,
                  AvgPopulation = avgPop
              };

foreach (var city in result2)
{
    Console.WriteLine($"Mamlakat: {city.Country}, Shahar: {city.CityName}," +
        $" Aholisi: {city.Population}, O‘rtacha: {city.AvgPopulation}");
}


Console.WriteLine("================ 3 ==================\n");

var result3 = from city in cities
              group city by city.CountryId into g
              select new
              {
                  Country = g.Key,
                  CityName = g.First().Name
              };

foreach (var item in result3)
{
    Console.WriteLine($"Mamlakat: {item.Country}, Shahar: {item.CityName}");
}
Console.WriteLine("================ 4 ==================\n");

var result4 = from person in people
              join city in cities
              on person.CityId equals city.Id
              join country in countries
              on city.Name equals country.Cityname
              select new
              {
                  PersonName = person.Name,
                  CityName = city.Name,
                  CountryName = city.CountryId 
              };

foreach (var item in result4)
{
    Console.WriteLine($"Odam: {item.PersonName}, Shahar: {item.CityName}, Davlat: {item.CountryName}");
}

Console.WriteLine("================ 5 ==================\n");
var result5 = from person in people
              where person.Name.ToLower() == "bobur"
              select person;

foreach (var item in result5)
{
    Console.WriteLine($"Ism: {item.Name}, Yosh: {item.Age}");
}
Console.WriteLine("================ 6 ==================\n");
var result6 = from person in people
              group person by person.CityId into g
              let maxAge = g.Max(p => p.Age)
              from p in g
              where p.Age == maxAge
              select new
              {
                  CityId = g.Key,
                  PersonName = p.Name,
                  Age = p.Age
              };

foreach (var item in result6)
{
    var cityName = cities.First(c => c.Id == item.CityId).Name;
    Console.WriteLine($"Shahar: {cityName}: {item.PersonName}, Yoshi: {item.Age}");
}
Console.WriteLine("================ 7 ==================\n");
var result = from city in cities
             group city by city.CountryId into g
             let maxCity = g.OrderByDescending(c => c.Aholisi).First()
             select maxCity;

foreach (var city in result)
{
    Console.WriteLine($"Mamlakat: {city.CountryId}, Shahar: {city.Name}, Aholisi: {city.Aholisi}");
}
Console.WriteLine("================ 8 ==================\n");
int desiredLength = 6; 

var result8 = from person in people
              join city in cities
              on person.CityId equals city.Id
              where city.Name.Length == desiredLength
              select new
              {
                  PersonName = person.Name,
                  CityName = city.Name
              };

foreach (var item in result8)
{
    Console.WriteLine($"Odam: {item.PersonName}, Shahar: {item.CityName}");
}
Console.WriteLine("================ 9 ==================\n");

var result9 = from person in people
              join city in cities
              on person.CityId equals city.Id
              group new { person, city } by city.CountryId into g
              let minAge = g.Min(x => x.person.Age)
              from x in g
              where x.person.Age == minAge
              select new
              {
                  Country = g.Key,
                  PersonName = x.person.Name,
                  CityName = x.city.Name,
                  Age = x.person.Age
              };

foreach (var item in result9)
{
    Console.WriteLine($"Mamlakat: {item.Country}, Shahar: {item.CityName}, Odam: {item.PersonName}, Yosh: {item.Age}");
}
Console.WriteLine("================ 10 ==================\n");

var result10 = from person in people
               group person by person.CityId into g
               select new
               {
                   CityId = g.Key,
                   Count = g.Count()
               };

foreach (var item in result10)
{
    var cityName = cities.First(c => c.Id == item.CityId).Name;
    Console.WriteLine($"Shahar: {cityName}, Odamlar soni: {item.Count}");
}






public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int CityId { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public long Aholisi { get; set; }
        public string Name { get; set; }
        public string CountryId { get; set; }   // Davlat nomi
    }
    public class Countries
    {
        public int Id { get; set; }
        public string Cityname { get; set; }
    }
