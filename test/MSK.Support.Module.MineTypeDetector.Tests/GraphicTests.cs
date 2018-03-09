using System.IO;
using MimeTypeDetector.Extensions;
using Xunit;

namespace MSK.Support.Module.MineTypeDetector.Tests
{
    public class GraphicTests
    {
        [Fact]
        public void IsPngFile()
        {
            var currentPath = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\.."));
            var fullFilePath = $"{currentPath}\\Resources\\Graphics\\TestPng.png";

            // https://msdn.microsoft.com/en-us/library/system.io.fileinfo.openread(v=vs.110).aspx
            var fileInfo = new FileInfo(fullFilePath);
            
            Assert.True(fileInfo.IsPng());
            Assert.True(!fileInfo.IsPdf());
        }

        private MemoryStream ReadFrom(string fileNameWithExt)
        {
            // https://stackoverflow.com/questions/8624071/save-and-load-memorystream-to-from-a-file
            using (MemoryStream ms = new MemoryStream())
            using (FileStream file = new FileStream(fileNameWithExt, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[file.Length];
                file.Read(bytes, 0, (int) file.Length);
                ms.Write(bytes, 0, (int) file.Length);
                return ms;
            }
        }
    }
}
