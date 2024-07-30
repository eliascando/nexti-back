namespace nexti.Domain.Interfaces.Bases.Services
{
    public interface IGetEntity<TGet>
    {
        IEnumerable<TGet> GetAll();
        TGet GetById(long id);
    }
}
