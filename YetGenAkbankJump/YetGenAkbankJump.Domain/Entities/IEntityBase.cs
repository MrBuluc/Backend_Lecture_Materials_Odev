namespace YetGenAkbankJump.Domain.Entities
{
    public interface IEntityBase<TKey> : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
