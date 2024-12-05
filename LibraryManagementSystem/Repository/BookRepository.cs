using LibraryManagementSystem.Enums;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository.Interfaces;
using Newtonsoft.Json;

namespace LibraryManagementSystem.Repository
{
    public class BookRepository : ReadAndWrite, IBookRepository
    {


        public BookRepository() : base(FilePathEnum.Books)
        {

        }

        public List<Book>? GetAll()
        {
            var books = JsonConvert.DeserializeObject<List<Book>>(ReadFile());
            return books;
        }

        public string Add(Book entity)
        {
            var books = GetAll();

            var matchedBook = books.FirstOrDefault<Book>(b => b.Id == entity.Id);
            if (matchedBook != null)
            {
                return "Eklemek istediğiniz kitap id'si sahip bir kitap mevcut";
            }
            else
            {
                books.Add(entity);

                WriteFile(books);

                return "Kitap başarılı şekilde eklendi";
            }
        }

        public string Delete(int id)
        {
            var books = GetAll();
            var book = books.FirstOrDefault<Book>(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
                WriteFile(books);
                return "Kitap başarılı şekilde silindi";
            }
            else return "Silmek istediğiniz kitap bulunamadı.";
        }
        public string Update(Book entity)
        {
            var books = GetAll();
            var index = books.FindIndex(b => b.Id == entity.Id);
            if (index != -1)
            {
                books[index] = entity;
                return "Kitap başarılı bir şekilde güncellendi.";
            }
            else return "Güncellemek istediğiniz kitap bulunamadı.";
        }
        public Book? GetById(int id)
        {
            var books = GetAll();
            var book = books.FirstOrDefault<Book>(b => b.Id == id);
            return book;
        }

    }
}
