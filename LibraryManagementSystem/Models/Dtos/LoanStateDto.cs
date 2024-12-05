namespace LibraryManagementSystem.Models.Dtos
{
    public class LoanStateDto
    {

        public int Id { get; set; }
        public string? State { get; set; }

        public DateTime? ReturnedDate { get; set; }

    }
}
