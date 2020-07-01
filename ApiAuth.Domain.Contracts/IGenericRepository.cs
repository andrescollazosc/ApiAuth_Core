namespace ApiAuth.Domain.Contracts
{
    public interface IGenericRepository<T> : IGenericCUDRepository<T>, IGenericGetRepository<T> where T : class { }
}
