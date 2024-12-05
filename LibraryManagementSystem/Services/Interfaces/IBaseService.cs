namespace LibraryManagementSystem.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        public string Add(T entity);
        public string Delete(int id);

        public string Update(T entity);

        //public List<T> GetAll();
    }
}
