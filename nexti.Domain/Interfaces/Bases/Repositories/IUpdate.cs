namespace nexti.Domain.Interfaces.Bases.Repositories
{
    public interface IUpdate<T>
    {
        T Update(T entity);
    }
}
