namespace PaySky.Infrastructure.Interfaces
{
    public interface IRepository<t> where t : class
    {
        //main CRUD Op
        Task<IEnumerable<t>> GetAllAsync();
        Task<t> GetByIdAsync(int id);
        Task AddAsync(t entity);
        void Update(t entity);
        Task Delete(t entity);
        Task SaveAsync();

    }

}
