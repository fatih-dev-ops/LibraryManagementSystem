using LibraryManagementSystem.Enums;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository.Interfaces;
using Newtonsoft.Json;

namespace LibraryManagementSystem.Repository
{
    public class LoanRepository : ReadAndWrite, ILoanRepository
    {
        public LoanRepository() : base(FilePathEnum.Loans) { }

        public string Add(Loan entity)
        {
            var loans = GetAll();
            var matchedLoan = loans.FirstOrDefault<Loan>(m => m.Id == entity.Id);
            if (matchedLoan != null)
            {
                return "Eklemek istediğiniz loan mevcut.";
            }
            else
            {
                loans.Add(entity);
                WriteFile(loans);
                return "Eklemek istediğiniz loan başarılı bir şekilde eklendi.";
            }
        }

        public string Delete(int id)
        {
            //Loanlar silinemez.
            return "";
        }

        public List<Loan> GetAll()
        {
            List<Loan>? loans = JsonConvert.DeserializeObject<List<Loan>>(ReadFile());

            return loans ?? [];
        }

        public Loan? GetById(int id)
        {
            var loans = GetAll();

            var loan = loans.FirstOrDefault(l=> l.Id == id);
            return loan;
        }

        public string Update(Loan entity)
        {
            var members = GetAll();
            var matchedIndex = members.FindIndex(m => m.Id == entity.Id);

            if (matchedIndex != -1)
            {
                members[matchedIndex] = entity;
                WriteFile(members);
                return "Güncellemek istediğiniz üye başarılı bir şekilde güncellendi";
            }
            else return "Güncellemek istediğiniz üye bulunamadı.";
        }
    }
}
