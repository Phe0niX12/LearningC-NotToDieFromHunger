namespace Training.Model
{
    public class Shops: BaseEntity
    {
        public required string name { set; get; }
        public string? description { set; get; }
        public int? customersPerYear { set; get; }
        public string? managerName { set; get; }

        public virtual ICollection<Traiding>? Traidings { get; set; }
       
    }
}
