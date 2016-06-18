namespace Blog.Models.Commons
{
    public interface IEntity<TId>
    {
        TId Id { get; set; } 
    }
}