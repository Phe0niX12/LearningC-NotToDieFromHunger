using Training.Model;

namespace Training.DOTs.CowsDTOs
{
    public class CowDTO
    {
        public required string Name { get; set; }
        public int Age { get; set; }
        public string? Color { get; set; }
        public string? Description { get; set; }
    }
}
