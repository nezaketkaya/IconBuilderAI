namespace IconBuilderAI.Domain.Common
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}


// IEntity: Veritabanına kaydedilecek olan verilerin en saf ve işlenmemiş halini temsil eden arayüzdür.
