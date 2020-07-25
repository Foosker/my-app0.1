using System.IO;
using System.Text;

namespace TrainWindowsFormsApp
{
    class FileProvider
    {
        public static void Add(string path, string data)
        {
            using (var writer = new StreamWriter(path, true, Encoding.UTF8))
            {
                writer.WriteLine(data);
            }
        }

        public static void Save(string path, string data)
        {
            using (var writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                writer.WriteLine(data);
            }
        }

        public static string GetData(string path)
        {
            using (var reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }

        public static bool TryGet(string path, out string data)
        {
            if (Exist(path))
            {
                data = GetData(path);
                return true;
            }
            data = null;
            return false;
        }

        internal static bool Exist(string path)
        {
            return File.Exists(path);
        }
    }
}
