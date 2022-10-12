using System.Collections.Generic;

namespace Vostok.Models
{
    internal class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<int>? IdsWorkshops { get; set; }
    }
}