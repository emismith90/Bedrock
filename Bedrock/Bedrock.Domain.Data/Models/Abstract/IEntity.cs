namespace Bedrock.Domain.Data.Models.Abstract
{
    public interface IEntity<T>
    {
        T Id { get; }

        bool Equals(object obj);
        
        int GetHashCode();

        string ToString();
    }
}
