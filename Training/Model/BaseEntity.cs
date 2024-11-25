namespace Training.Model {
    public abstract class BaseEntity {
        public Guid Id { get; set; }
        public required bool isDeleted { get; set; }
    }
}
