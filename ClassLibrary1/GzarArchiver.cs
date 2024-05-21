using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public class GzarArchiver
    {
        private const string TempFileName = "fileinfo.txt";
        private static string tempFilePath = Path.Combine(Path.GetTempPath(), TempFileName);
        public static void CreateArchive(ListBox listBox)
        {
            List<string> files = new List<string>();

            foreach (string file in listBox.Items)
            {
                if (file.EndsWith(".gzar"))
                {
                    continue;
                }
                if (file.Contains(".crypt"))
                {
                    files.Add(file);
                    files.Add(file.Replace(".crypt", ".temp"));
                    continue;
                }
                files.Add(file);
            }

            if(files.Count == 0)
            {
                return;
            }

            using (StreamWriter writer = new StreamWriter(tempFilePath))
            {
                foreach (string file in files)
                {
                    writer.WriteLine(file);
                }
            }

            string zipFilePath = Path.Combine("E:\\Унік\\1 Курс\\Лаби ООП\\lab_13\\archives\\", Path.GetFileNameWithoutExtension(files[0]) + ".zip");
            using (FileStream archiveStream = new FileStream(zipFilePath, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(archiveStream, ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile(tempFilePath, TempFileName);

                    foreach (string file in files)
                    {
                        string entryName = Path.GetFileName(file);
                        archive.CreateEntryFromFile(file, entryName);
                    }
                }
            }

            File.Move(zipFilePath, Path.ChangeExtension(zipFilePath, ".gzar"));
            File.Delete(tempFilePath);

            foreach (string file in files)
            {
                File.Delete(file);
            }

            listBox.Items.Clear();
            listBox.Items.Add(Path.ChangeExtension(zipFilePath, ".gzar"));
        }

        public static void ExtractArchive(ListBox listBox)
        {
            List<string> oldFiles = new List<string>();
            List<string> newFiles = new List<string>();
            foreach (string archivePath in listBox.Items)
            {
                if (archivePath.EndsWith(".gzar"))
                {
                    using (FileStream archiveStream = new FileStream(archivePath, FileMode.Open))
                    using (ZipArchive archive = new ZipArchive(archiveStream, ZipArchiveMode.Read))
                    {
                        var tempEntry = archive.GetEntry(TempFileName);

                        tempEntry.ExtractToFile(tempFilePath, true);

                        List<string> fileMappings = new List<string>();
                        using (StreamReader reader = new StreamReader(tempFilePath))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                fileMappings.Add(line);
                            }
                        }

                        foreach (string filePath in fileMappings)
                        {
                            string fileName = Path.GetFileName(filePath);
                            var fileEntry = archive.GetEntry(fileName);

                            string destinationPath = filePath;
                            fileEntry.ExtractToFile(destinationPath, true);
                            if(!filePath.EndsWith(".temp"))
                                newFiles.Add(filePath);
                        }
                    }
                    File.Delete(tempFilePath);
                    File.Delete(archivePath);
                }
                else
                    oldFiles.Add(archivePath);
            }

            listBox.Items.Clear();
            if (oldFiles.Count != 0)
                foreach (string file in oldFiles)
                    listBox.Items.Add(file);
            foreach (string file in newFiles)
                listBox.Items.Add(file);
        }
    }
}