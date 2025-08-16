# LINQ Sample Project in C#

## Loyihaning maqsadi
Bu loyiha C# tilida LINQ (Language Integrated Query) yordamida turli ma’lumotlar bazasini manipulyatsiya qilish bo‘yicha misollarni o‘z ichiga oladi. Loyihada shaharlar, odamlar va mamlakatlar bilan bog‘liq bir nechta amaliy vazifalar yechilgan.  

## Ma’lumotlar tuzilmasi

### Person (Odamlar)
- `Id` – Odamning noyob identifikatori (int)
- `Name` – Odamning ismi (string)
- `Age` – Odamning yoshi (int)
- `CityId` – Qaysi shaharda yashaydi (int)

### City (Shaharlar)
- `Id` – Shaharning noyob identifikatori (int)
- `Name` – Shaharning nomi (string)
- `Aholisi` – Shahardagi aholining soni (long)
- `CountryId` – Shaharning qaysi mamlakatga tegishli ekanligi (string)

### Countries (Mamlakatlar)
- `Id` – Mamlakatning identifikatori (int)
- `Cityname` – Mamlakatdagi shahar nomi (string)

## Ma’lumotlar to‘plami

```csharp
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
    new City { Id = 1, Name = "Piter", Aholisi = 300000000, CountryId = "Rus" },
    new City { Id = 2, Name = "Samarqand", Aholisi = 3200000000, CountryId = "Uzb" },
    new City { Id = 3, Name = "Buxoro", Aholisi = 2000000, CountryId = "Uzb" },
    new City { Id = 4, Name = "Moskva", Aholisi = 1200000, CountryId = "Rus" },
    new City { Id = 5, Name = "Namangan", Aholisi = 9000000000, CountryId = "Uzb" },
    new City { Id = 6, Name = "Farg'ona", Aholisi = 800000, CountryId = "Uzb" }
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
```
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/24eb9455-7143-47a8-a43f-f55cfd398707" />

