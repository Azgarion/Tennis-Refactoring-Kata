using System.IO;
using System.Linq;

namespace ApprovedToReceive
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var directory = new DirectoryInfo(
                args.FirstOrDefault() ?? Directory.GetCurrentDirectory()
            );

            foreach (var enumerateFile in directory
                .EnumerateFiles()
                .Where(file => file.Name.EndsWith(".received.txt")))
            {
                var withoutExtension = enumerateFile.Name
                    .Replace(".received.txt", string.Empty);

                File.Copy(
                    enumerateFile.FullName, 
                    Path.Combine(directory.FullName, withoutExtension + ".approved.txt"), 
                    true);
            }
        }
    }
}
