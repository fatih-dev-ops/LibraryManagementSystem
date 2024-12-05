namespace LibraryManagementSystem.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int MemberId { get; set; }

        public int BookId { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public string State { get; set; }

    }
}
