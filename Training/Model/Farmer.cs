namespace Training.Model
{
    public class Farmer:BaseEntity
    {
        public required string name { get; set; }
        public string? description { get; set; }

        public string? address { get; set; }


    }
}
