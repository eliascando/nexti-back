namespace nexti.Domain.Interfaces.Bases.Services
{
    public interface IServiceBase<T, TGet,TNew, TCreated, TUpd> :
        INewEntity<TNew, TCreated>,
        IGetEntity<TGet>,
        IDeleteEntity,
        IUpdateEntity<TGet, TUpd>
    {

    }
}
