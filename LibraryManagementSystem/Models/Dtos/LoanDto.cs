namespace LibraryManagementSystem.Models.Dtos
{
    public class LoanDto
    {
        public int Id { get; set; }
        public int MemberId { get; set; }

        public int BookId { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public string State { get; set; }
        public double? DelayTime { get; set; }

        public LoanDto()
        {
            if (ReturnedDate is null)
            {
                DelayTime = null;
            }
            else
            {
                DelayTime = ReturnedDate?.Subtract(BorrowDate).TotalDays;
            }
        }
    }
}
