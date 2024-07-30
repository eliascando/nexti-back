namespace nexti.Domain.Interfaces.Bases.Repositories
{
    public interface IDelete
    {
        bool Delete(long idEntity, long idUser);
    }
}
