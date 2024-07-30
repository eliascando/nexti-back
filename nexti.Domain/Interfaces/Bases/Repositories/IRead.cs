namespace nexti.Domain.Interfaces.Bases.Repositories
{
    public interface IRead<T>
    {
        IEnumerable<T> GetAll();
        T GetById(long id);
    }
}
