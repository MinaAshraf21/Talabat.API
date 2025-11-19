namespace Company.Talabat.Domain.Common
{
    public abstract class BaseAuditableEntity<TKey> : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }

        public required string CreatedBy { get; set; }
        public required string LastModifiedBy { get; set; }

    }
}
