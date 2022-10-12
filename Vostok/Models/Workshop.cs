using System.Collections.Generic;

namespace Vostok.Models
{
    internal class Workshop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<int>? IdsEmployees { get; set; }
    }
}
