namespace LibraryManagementSystem.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public List<T>? GetAll();
        public string Add(T entity);
        public string Delete(int id);
        public string Update(T entity);
        public T? GetById(int id);

    }
}
