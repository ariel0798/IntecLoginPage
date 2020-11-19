using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace IntecLoginPage
{

    public static class UsersFile
    {
        public static List<string> GetUserList()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Users.txt");

            if (!File.Exists(filePath))
                File.CreateText(filePath);

            List<string> lines = File.ReadAllLines(filePath).ToList();

            return lines;
        }

        public static void AddLines(List<string> lines)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Users.txt");

            if (!File.Exists(filePath))
                File.CreateText(filePath);

            File.WriteAllLines(filePath, lines);
        }
    }
}
