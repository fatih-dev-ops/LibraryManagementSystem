namespace LibraryManagementSystem.Models.Dtos
{
    public class LoanDetailDto
    {
        public int Id { get; set; }
        public int MemberId { get; set; }

        public int BookId { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public string? State { get; set; }
        public double? DelayTime { get; set; }

        public LoanDetailDto()
        {
            SetDelayTime();
        }

        public void SetDelayTime()
        {
            if (ReturnedDate != null)
            {
                DelayTime = ReturnedDate?.Subtract(BorrowDate).TotalDays;

            }
            else
            {
                DelayTime = null;

            }
        }
    }
}
