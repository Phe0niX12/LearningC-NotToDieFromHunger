namespace Training.Model
{
    public class Traiding:BaseEntity
    {
        public virtual Farmer? Farmer { get; set; }
        public virtual Shops? Shops { get; set; }

    }
}
