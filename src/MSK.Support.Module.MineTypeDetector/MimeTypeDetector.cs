using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MimeTypeDetector
{
    public class MimeTypeDetector
    {
        public static FileType LearnMimeType(FileInfo file, string mimeType, int headerSize, int offset = 0)
        {
            byte?[] data = new byte?[headerSize];
            using (FileStream stream = file.OpenRead())
            {
                int b = 0;
                for (int i = 0; i < headerSize; i++)
                {
                    data[i] = (byte)((b = stream.ReadByte()) == -1 ? 0 : b);
                    if (b == -1)
                        break;
                }
            }
            return new FileType(data, offset, file.Extension, mimeType);
        }

        public static FileType LearnMimeType(FileInfo first, FileInfo second, string mimeType, int maxHeaderSize = 12, int minMatches = 2, int maxNonMatch = 3)
        {
            byte?[] header = null;

            List<byte?> headerList = new List<byte?>();

            using (Stream firstFile = first.OpenRead())
            using (Stream secondFile = second.OpenRead())
            {
                bool match = false;
                int missmatchCounter = 0;       // missmatches after first match

                int bFst = 0, bSnd = 0;         // current bytes
                int index = 0;
                int offset = 0;             // index of first match

                // Read from both files until one of the file streams reaches the end.
                while ((bFst = firstFile.ReadByte()) != -1 &&
                      (bSnd = secondFile.ReadByte()) != -1)
                {

                    bFst = firstFile.ReadByte();
                    bSnd = secondFile.ReadByte();

                    if (bFst == bSnd)
                    {
                        if (!match)
                        {
                            match = true;       // first match
                            offset = index;
                        }

                        headerList.Add((byte)bFst);     // add match to header 
                    }
                    else
                    {
                        if (match)
                        {      // if there was a match before 

                            // no more matching

                            if (missmatchCounter < maxNonMatch)
                            {
                                headerList.Add(null);       // Add a null header, this could be non generic, file size for example
                                missmatchCounter++;
                            }
                            else
                                break;  // too much missmatches after the first match 
                        }
                    }
                    if (headerList.Count == maxHeaderSize)
                        break;
                    index++;
                }

                FileType type = null;

                if (headerList.Count((b) => b != null) >= minMatches)       // check for enough non null byte? ´s.
                {
                    header = headerList.ToArray();
                    type = new FileType(header, offset, first.Extension, mimeType);
                }

                return type;
            }
        }
    }
}
