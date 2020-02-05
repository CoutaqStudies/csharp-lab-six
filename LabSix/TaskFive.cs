using System;
using System.IO;
using System.Drawing;

namespace LabFive
{
    internal class TaskFive
    {
        internal static void Execute()
        {
            String bmpPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\test.bmp";
            if (Program.FuckingUnix)
                bmpPath.Replace("\\", "/"); //yea i know this is discusting but what can you do
            FileStream bmpFile = new FileStream(bmpPath, FileMode.Open);
            Bitmap bitmap = new Bitmap(bmpFile);
            Console.WriteLine("Name: " + bmpFile.Name);
            Console.WriteLine("Size: " + bmpFile.Length + " bytes");
            Console.WriteLine("Width: " + bitmap.Width + " pixels");
            Console.WriteLine("Height: " + bitmap.Height + " pixels");
            byte[] bmpBytes = new byte[bmpFile.Length];
            bmpFile.Read(bmpBytes, 0, (int)bmpFile.Length);
            Console.WriteLine("Bits per pixel: " + bmpFile.Length / (bitmap.Width * bitmap.Height));
            bmpFile.Seek(30, SeekOrigin.Begin);
            BinaryReader reader = new BinaryReader(bmpFile);
            Console.Write("Encoding: ");
            switch (reader.ReadInt32())
            {
                case 0:
                    Console.Write("BI_RGB\n");
                    break;
                case 1:
                    Console.Write("BI_RLE8\n");
                    break;
                case 2:
                    Console.Write("BI_RLE4\n");
                    break;
            }
            reader.ReadInt32();
            Console.WriteLine("Horizontal Resolution: " + reader.ReadInt32());
            Console.WriteLine("Vertical Resolution: " + reader.ReadInt32());
        }
    }
}