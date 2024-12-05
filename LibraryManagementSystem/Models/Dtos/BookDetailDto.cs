
namespace LibraryManagementSystem.Models.Dtos
{
    public class BookDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public string Category { get; set; }
        public string AuthorName { get; set; }
        public DateTime PrintDate { get; set; }
    }
}
