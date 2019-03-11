

using System.ComponentModel.DataAnnotations;

namespace SantaApi.Models
{
    public class EmployeeCard
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Verdict Verdict { get; set; }
    }

    public enum Verdict
    {
        Good = 0,
        Bad = 1
    }
}