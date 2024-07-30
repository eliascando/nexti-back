namespace nexti.Domain.Interfaces.Bases.Repositories
{
    public interface ICreate<T>
    {
        T Create(T entity);
    }
}
