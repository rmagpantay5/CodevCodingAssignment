using System.Collections.Generic;

namespace CodingAssignment.Models
{
    public class Details
    {
        public int key { get; set; }
        public ICollection<DetailValues> values { get; set; }
    }
}