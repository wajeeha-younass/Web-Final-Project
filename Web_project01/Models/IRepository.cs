namespace Web_project01.Models
{
    public interface IRepository<TEntity>
    {
        void AddEntity(TEntity entity);
        void DeleteById(int id);
        void UpdateById(TEntity updatedEntity);
        TEntity FindById(int id);
        List<TEntity> GetAll(); // Add this method
    }
}
