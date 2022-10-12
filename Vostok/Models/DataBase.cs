using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vostok.Models
{
    internal class DataBase
    {
        public static readonly IEnumerable<City> Cities = new List<City>()
        {
            new City() { Id = 0, Name = "Moscow", IdsWorkshops = new List<int>() {0, 1} },
            new City() { Id = 1, Name = "Syktyvkar", IdsWorkshops = new List<int>() {1} },
            new City() { Id = 2, Name = "Ekaterinburg", IdsWorkshops = new List<int>() {0, 1, 2} },
            new City() { Id = 3, Name = "St. Petersburg", IdsWorkshops = new List<int>() {1, 2} },
            new City() { Id = 4, Name = "Irkutsk", IdsWorkshops = new List<int>() {1, 3} },
            new City() { Id = 5, Name = "Vladivostok", IdsWorkshops = new List<int>() {2} },
            new City() { Id = 6, Name = "Saratov", IdsWorkshops = new List<int>() {0, 2} },
            new City() { Id = 7, Name = "Sochi", IdsWorkshops = new List<int>() {1, 0} },
        };
        public static readonly IEnumerable<Workshop> Workshops = new List<Workshop>()
        {
            new Workshop() { Id = 0, Name = "Workshop 0", IdsEmployees = new List<int> { 1, 5 } },
            new Workshop() { Id = 1, Name = "Workshop 1", IdsEmployees = new List<int> { 1,4,7 } },
            new Workshop() { Id = 2, Name = "Workshop 2", IdsEmployees = new List<int> { 2,3} },
            new Workshop() { Id = 3, Name = "Workshop 3", IdsEmployees = new List<int> { 2,4,5,6,7 } },
        };
        public static readonly IEnumerable<Employee> Employees = new List<Employee>()
        {
            new Employee() { Id = 0, Name = "Human 0"},
            new Employee() { Id = 1, Name = "Human 1"},
            new Employee() { Id = 2, Name = "Human 2"},
            new Employee() { Id = 3, Name = "Human 3"},
            new Employee() { Id = 4, Name = "Human 4"},
            new Employee() { Id = 5, Name = "Human 5"},
            new Employee() { Id = 6, Name = "Human 6"},
            new Employee() { Id = 7, Name = "Human 7"},
        };
        public static readonly IEnumerable<Brigade> Brigades = new List<Brigade>()
        {
            new Brigade() { Id = 0, Name = "Brigade 0", Start = 8, End = 20 },
            new Brigade() { Id = 1, Name = "Brigade 1", Start = 20, End = 8 },
        };
        public static readonly IEnumerable<Change> Changes = new List<Change>();
    }
}
