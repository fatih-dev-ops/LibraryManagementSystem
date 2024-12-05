using LibraryManagementSystem.Enums;

namespace LibraryManagementSystem.Extensions
{
    public static class EnumExtensions
    {
        public static string ToLowerCaseStr(this FilePathEnum sentence)
        {
            return sentence.ToString().ToLower();
        }
        
        public static string GetFilePath(this FilePathEnum filePathEnum)
        {

            switch (filePathEnum)
            {
                case FilePathEnum.Books:
                    return "C:\\Users\\bilstajer\\source\\repos\\LibraryManagementSystem\\LibraryManagementSystem\\JsonDatas\\Books.json";
                case FilePathEnum.Members:
                    return "C:\\Users\\bilstajer\\source\\repos\\LibraryManagementSystem\\LibraryManagementSystem\\JsonDatas\\Members.json";
                case FilePathEnum.Library:
                    return "C:\\Users\\bilstajer\\source\\repos\\LibraryManagementSystem\\LibraryManagementSystem\\JsonDatas\\Library.json";
                case FilePathEnum.Loans:
                    return "C:\\Users\\bilstajer\\source\\repos\\LibraryManagementSystem\\LibraryManagementSystem\\JsonDatas\\Loans.json";
                default:
                    return "C:\\Users\\bilstajer\\source\\repos\\LibraryManagementSystem\\LibraryManagementSystem\\JsonDatas\\Library.json";
                }
        }
    }
}
