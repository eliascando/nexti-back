namespace nexti.Domain.Interfaces.Bases.Services
{
    public interface INewEntity<TNew, TCreated>
    {
        TCreated Add(TNew entity);
    }
}
