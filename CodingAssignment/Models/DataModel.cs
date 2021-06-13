using System.Collections.Generic;

namespace CodingAssignment.Models
{
    public class DataModel
    {
        public int Id { get; set; }
        public ICollection<Details> Details { get; set; }
    }
}