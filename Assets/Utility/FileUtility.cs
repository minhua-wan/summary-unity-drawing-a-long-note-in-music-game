using System.IO;

namespace Utility
{
    public static class FileUtility
    {
        private static string GetFullPath(string path)
        {
            return PathUtility.GetPersistentFullPath(path);
        }

        private static void CreateDirectoryIfNeed(string fullPath)
        {
            var directoryName = Path.GetDirectoryName(fullPath);
            if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
        }

        public static string ReadFile(string path)
        {
            string fullPath = GetFullPath(path);
            if (!File.Exists(fullPath))
            {
                return null;
            }

            return File.ReadAllText(fullPath);
        }

        public static void WriteFile(string path, string content)
        {
            string fullPath = GetFullPath(path);
            CreateDirectoryIfNeed(fullPath);
            File.WriteAllText(fullPath, content);
        }

        public static void WriteFile(string path, byte[] content)
        {
            string fullPath = GetFullPath(path);
            CreateDirectoryIfNeed(fullPath);
            File.WriteAllBytes(fullPath, content);
        }

        public static void DeleteFile(string path)
        {
            string fullPath = GetFullPath(path);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        public static void DeleteDirectory(string path, bool recursive = true)
        {
            string fullPath = GetFullPath(path);
            string directoryName = Path.GetDirectoryName(fullPath);
            if (!string.IsNullOrEmpty(directoryName) && Directory.Exists(directoryName))
            {
                Directory.Delete(directoryName, recursive);
            }
        }

        public static byte[] StringToBytes(string content)
        {
            return System.Text.Encoding.UTF8.GetBytes(content);
        }

        public static string BytesToString(byte[] content)
        {
            return System.Text.Encoding.UTF8.GetString(content);
        }
    }
}