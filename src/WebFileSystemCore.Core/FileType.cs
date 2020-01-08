namespace WebFileSystemCore
{
    public enum FileType
    {
        /// <summary>
        /// -
        /// </summary>
        RegularFile = 0,

        /// <summary>
        /// d
        /// </summary>
        Directory = 1,

        /// <summary>
        /// c
        /// </summary>
        CharacterDeviceFile = 2,

        /// <summary>
        /// b
        /// </summary>
        BlockDeviceFile = 3,

        /// <summary>
        /// s
        /// </summary>
        LocalSocketFile = 4,

        /// <summary>
        /// p
        /// </summary>
        NamedPipe = 5,

        /// <summary>
        /// l
        /// </summary>
        SymbolicLink = 6
    }

    public static class FileTypeExt
    {
        public static string ToIdentifier(this FileType fileType)
        {
            switch (fileType)
            {
                case FileType.BlockDeviceFile:
                    return "b";
                case FileType.CharacterDeviceFile:
                    return "c";
                case FileType.Directory:
                    return "d";
                case FileType.LocalSocketFile:
                    return "s";
                case FileType.NamedPipe:
                    return "p";
                case FileType.RegularFile:
                    return "-";
                case FileType.SymbolicLink:
                    return "l";
            }
            throw new System.Exception();
        }
        public static FileType ToFileType(this string fileTypeStr)
        {
            switch (fileTypeStr)
            {
                case "b":
                    return FileType.BlockDeviceFile;
                case "c":
                    return FileType.CharacterDeviceFile;
                case "d":
                    return FileType.Directory;
                case "s":
                    return FileType.LocalSocketFile;
                case "p":
                    return FileType.NamedPipe;
                case "-":
                    return FileType.RegularFile;
                case "l":
                    return FileType.SymbolicLink;
            }
            throw new System.Exception();
        }
    }
}
