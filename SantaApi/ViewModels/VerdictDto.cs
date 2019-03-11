using SantaApi.Models;

namespace SantaApi.ViewModels
{
    public class VerdictDto: CreateVerdictDto
    {
        public string Id { get; set; }
       
    }

    public class CreateVerdictDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Verdict? Verdict { get; set; }
    }
}