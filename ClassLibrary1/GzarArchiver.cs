using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

public class GzarArchiver
{
    private const string ArchiveDirectory = "E:\\Унік\\1 Курс\\Лаби ООП\\lab_13\\archives\\";
    private const string TempFileName = "fileinfo.txt";
    private const string ArchiveExtension = ".gzar";
    private const string CryptExtension = ".crypt";
    private const string TempExtension = ".temp";
    private static readonly string TempFilePath = Path.Combine(Path.GetTempPath(), TempFileName);

    public static void CreateArchive(ListBox listBox)
    {
        List<string> files = FilterFilesForArchive(listBox);

        if (files.Count == 0)
        {
            return;
        }

        WriteFileListToTemp(files);

        string zipFilePath = GetArchivePath(files[0]);

        CreateZipArchive(files, zipFilePath);

        FinalizeArchive(zipFilePath, files, listBox);
    }

    private static List<string> FilterFilesForArchive(ListBox listBox)
    {
        List<string> files = new List<string>();

        foreach (string file in listBox.Items)
        {
            if (file.EndsWith(ArchiveExtension)) continue;

            if (file.Contains(CryptExtension))
            {
                files.Add(file);
                files.Add(file.Replace(CryptExtension, TempExtension));
                continue;
            }

            files.Add(file);
        }

        return files;
    }

    private static void WriteFileListToTemp(List<string> files)
    {
        using (StreamWriter writer = new StreamWriter(TempFilePath))
        {
            foreach (string file in files)
            {
                writer.WriteLine(file);
            }
        }
    }

    private static string GetArchivePath(string firstFile)
    {
        return Path.Combine(ArchiveDirectory, Path.GetFileNameWithoutExtension(firstFile) + ".zip");
    }

    private static void CreateZipArchive(List<string> files, string zipFilePath)
    {
        using (FileStream archiveStream = new FileStream(zipFilePath, FileMode.Create))
        using (ZipArchive archive = new ZipArchive(archiveStream, ZipArchiveMode.Create))
        {
            archive.CreateEntryFromFile(TempFilePath, TempFileName);

            foreach (string file in files)
            {
                string entryName = Path.GetFileName(file);
                archive.CreateEntryFromFile(file, entryName);
            }
        }
    }

    private static void FinalizeArchive(string zipFilePath, List<string> files, ListBox listBox)
    {
        string finalArchivePath = Path.ChangeExtension(zipFilePath, ArchiveExtension);
        File.Move(zipFilePath, finalArchivePath);
        File.Delete(TempFilePath);

        foreach (string file in files)
        {
            File.Delete(file);
        }

        listBox.Items.Clear();
        listBox.Items.Add(finalArchivePath);
    }

    public static void ExtractArchive(ListBox listBox)
    {
        List<string> oldFiles = new List<string>();
        List<string> newFiles = new List<string>();

        foreach (string archivePath in listBox.Items)
        {
            if (!archivePath.EndsWith(ArchiveExtension))
            {
                oldFiles.Add(archivePath);
                continue;
            }

            ExtractFilesFromArchive(archivePath, newFiles);
            File.Delete(archivePath);
        }

        UpdateListBoxWithExtractedFiles(listBox, oldFiles, newFiles);
    }

    private static void ExtractFilesFromArchive(string archivePath, List<string> newFiles)
    {
        using (FileStream archiveStream = new FileStream(archivePath, FileMode.Open))
        using (ZipArchive archive = new ZipArchive(archiveStream, ZipArchiveMode.Read))
        {
            var tempEntry = archive.GetEntry(TempFileName);
            if (tempEntry == null)
            {
                throw new FileNotFoundException($"Metadata file {TempFileName} not found in archive.");
            }

            tempEntry.ExtractToFile(TempFilePath, true);

            List<string> fileMappings = ReadFileMappings();

            foreach (string filePath in fileMappings)
            {
                string fileName = Path.GetFileName(filePath);
                var fileEntry = archive.GetEntry(fileName);

                if (fileEntry != null)
                {
                    fileEntry.ExtractToFile(filePath, true);
                    if (!filePath.EndsWith(TempExtension))
                        newFiles.Add(filePath);
                }
            }
        }
        File.Delete(TempFilePath);
    }

    private static List<string> ReadFileMappings()
    {
        List<string> fileMappings = new List<string>();
        using (StreamReader reader = new StreamReader(TempFilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                fileMappings.Add(line);
            }
        }
        return fileMappings;
    }

    private static void UpdateListBoxWithExtractedFiles(ListBox listBox, List<string> oldFiles, List<string> newFiles)
    {
        listBox.Items.Clear();

        foreach (string file in oldFiles)
            listBox.Items.Add(file);

        foreach (string file in newFiles)
            listBox.Items.Add(file);
    }
}
