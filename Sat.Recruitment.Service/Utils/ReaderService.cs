namespace Sat.Recruitment.Service.Utils
{
    public class ReaderService
    {
        public static StreamReader ReadUsersFromFile()
        {
            var path = $@"{Directory.GetCurrentDirectory()}\Files\Users.txt";
            FileStream fileStream = new FileStream(path, FileMode.Open);
            return new StreamReader(fileStream);
        }
    }
}