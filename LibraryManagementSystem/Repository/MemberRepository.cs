using LibraryManagementSystem.Enums;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository.Interfaces;
using Newtonsoft.Json;

namespace LibraryManagementSystem.Repository
{
    public class MemberRepository : ReadAndWrite, IMemberRepository
    {
        public MemberRepository() : base(FilePathEnum.Members) { }

        public string Add(Member entity)
        {
            var members = GetAll();
            var matchedMember = members.FirstOrDefault<Member>(m => m.Id == entity.Id);
            if (matchedMember != null)
            {
                return "Eklemek istediğiniz üye mevcut.";
            }
            else
            {
                members.Add(entity);
                WriteFile(members);
                return "Eklemek istediğiniz üye başarılı bir şekilde eklendi.";
            }
        }

        public string Delete(int id)
        {
            var members = GetAll();
            var matchedMember = members.FirstOrDefault<Member>(m => m.Id == id);
            if (matchedMember != null)
            {
                members.Remove(matchedMember);
                WriteFile(members);
                return "Silmek istediğiniz üye başarılı bir şekilde silindi.";
            }
            else return "Silmek istediğiniz üye bulunamadı";
        }

        public List<Member> GetAll()
        {
            List<Member>? members = JsonConvert.DeserializeObject<List<Member>>(ReadFile());

            return members ?? [];
        }

        public Member? GetById(int id)
        {
            var members = GetAll();
            var member = members.FirstOrDefault<Member>(x => x.Id == id);
            return member;
        }

        public string Update(Member entity)
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
