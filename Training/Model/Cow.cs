namespace Training.Model {
    public class Cow: BaseEntity {
        
        public required string Name { get; set; }
        public int Age { get; set; }
        public string? Color { get; set; }
        public string? Description { get; set; }
        = string.Empty;

        public virtual Farmer? Farmer { get; set; }


    }
}
