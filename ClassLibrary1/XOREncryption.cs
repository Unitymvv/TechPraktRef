using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public class XOREncryption
    {
        public static void ProcessFiles(ListBox listBox)
        {
            foreach (string file in listBox.Items)
            {
                if (!file.Contains(".crypt"))
                    ProcessFile(file);
            }
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                if (!listBox.Items[i].ToString().Contains(".crypt"))
                    listBox.Items[i] += ".crypt";
            }
        }

        public static void DecodeFiles(ListBox listBox)
        {
            foreach (string file in listBox.Items)
            {
                if (file.Contains(".crypt"))
                    DecodeFile(file);
            }
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                if (listBox.Items[i].ToString().Contains(".crypt"))
                    listBox.Items[i] = listBox.Items[i].ToString().Replace(".crypt", "");
            }
        }

        public static byte[] ReadFile(string path)
        {
            return File.ReadAllBytes(path);
        }

        public static byte[] XORencode(byte[] data, byte[] key)
        {
            byte[] result = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)(data[i] ^ key[i % key.Length]);
            }
            return result;
        }

        public static void SaveFile(string path, byte[] data, byte[] key)
        {
            string encryptedFilePath = path + ".crypt";
            string keyFilePath = path + ".temp";

            File.WriteAllBytes(encryptedFilePath, data);
            File.WriteAllBytes(keyFilePath, key);
            File.Delete(path);
        }

        public static byte[] GenerateKey(int length)
        {
            byte[] key = new byte[256];
            Random random = new Random();
            random.NextBytes(key);
            return key;
        }

        public static void ProcessFile(string path)
        {
            byte[] data = ReadFile(path);
            byte[] key = GenerateKey(data.Length);
            byte[] encodedData = XORencode(data, key);
            SaveFile(path, encodedData, key);
        }

        public static void DecodeFile(string encryptedFilePath)
        {
            string keyFilePath = encryptedFilePath.Replace(".crypt", ".temp");
            string originalFilePath = encryptedFilePath.Replace(".crypt", "");

            byte[] encryptedData = ReadFile(encryptedFilePath);
            byte[] key = ReadFile(keyFilePath);
            byte[] decodedData = XORencode(encryptedData, key);

            File.WriteAllBytes(originalFilePath, decodedData);
            File.Delete(encryptedFilePath);
            File.Delete(keyFilePath);
        }
    }
}