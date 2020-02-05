using System;
using System.IO;
using System.Drawing;

namespace LabFive
{
    internal class TaskFive
    {
        internal static void Execute()
        { 
            String bmpPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"/test.bmp";
            Console.WriteLine(bmpPath);
            FileStream bmpFile = new FileStream(bmpPath, FileMode.Open);
            Bitmap bitmap = new Bitmap(bmpPath, true);
            Console.WriteLine("Name: "+bmpFile.Name);
            Console.WriteLine("Size: " + bmpFile.Length);
            Console.WriteLine("Width: " + bitmap.Width);
            Console.WriteLine("Height: " + bitmap.Height);
            Console.WriteLine("Bits per pixel: " + bmpFile.Length/(bitmap.Width*bitmap.Height));
            Console.WriteLine("Horizontal Resolution: " + bitmap.Height);
            Console.WriteLine("Vertical Resolution: " + bitmap.Width);
            //Console.WriteLine("Compression: " + bitmap.);
        }
    }
}