namespace MimeTypeDetector
{
    /// <summary>
    /// Little data structure to hold information about file types. 
    /// Holds information about binary header at the start of the file
    /// </summary>
    public class FileType
    {
        /// <summary>
        /// The header bytes, normally we only use 8 bytes, 
        /// but some of special case, we need 16 bytes.
        /// </summary>
        public byte?[] Header { get; set; }

        /// <summary>
        /// The offset of header bytes.
        /// </summary>
        public int HeaderOffset { get; set; }

        /// <summary>
        /// File extensions
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Mine type of the file or stream.
        /// </summary>
        public string Mime { get; set; }

        /// <summary>
        /// Public constructor for object initialized
        /// <see cref="FileType"/> class.
        /// </summary>
        public FileType()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileType"/> class.
        /// Default construction with the header offset being set to zero by default
        /// </summary>
        /// <param name="header">Byte array with header.</param>
        /// <param name="extension">String with extension.</param>
        /// <param name="mime">The description of MIME.</param>
        public FileType(byte?[] header, string extension, string mime)
        {
            Header = header;
            Extension = extension;
            Mime = mime;
            HeaderOffset = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileType"/> struct.
        /// Takes the details of offset for the header
        /// </summary>
        /// <param name="header">Byte array with header.</param>
        /// <param name="offset">The header offset - how far into the file we need to read the header</param>
        /// <param name="extension">String with extension.</param>
        /// <param name="mime">The description of MIME.</param>
        public FileType(byte?[] header, int offset, string extension, string mime)
        {
            Header = null;
            Header = header;
            HeaderOffset = offset;
            Extension = extension;
            Mime = mime;
        }

        /// <summary>
        /// Compare 2 <see cref="FileType"/> instances.
        /// </summary>
        /// <param name="other">The second <see cref="FileType"/> instance.</param>
        /// <returns>
        ///     <c>true</c> if 2 instances are equal; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object other)
        {
            if (!(other is FileType)) return false;

            FileType otherType = (FileType)other;

            if (this.Extension == otherType.Extension && this.Mime == otherType.Mime) return true;

            return base.Equals(other);
        }

        /// <summary>
        /// Calculate the hashcode for the current instance
        /// </summary>
        /// <returns>The hashcode computed.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Overrides current ToString method, normally returns the extension
        /// </summary>
        /// <returns>Extension of this instance.</returns>
        public override string ToString()
        {
            return Extension;
        }
    }
}
