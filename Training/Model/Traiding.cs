namespace Training.Model
{
    public class Traiding:BaseEntity
    {
        public virtual Shops? Farmer { get; set; }
        public virtual Shops? Shops { get; set; }

    }
}
