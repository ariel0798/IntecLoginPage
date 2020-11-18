using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace IntecLoginPage
{

    public static class UsersFile
    {
        public static List<string> GetUserList()
        {
            string filePath = "Users.txt";

            List<string> lines = File.ReadAllLines(filePath).ToList();

            return lines;
        }

        public static void AddLines(List<string> lines)
        {
            string filePath = "Users.txt";

            File.WriteAllLines(filePath, lines);
        }
    }
}
