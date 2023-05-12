using System.Runtime.InteropServices;

namespace CreativeCoders.LibcDotNet.FileSystem;

public class LibcFileSystem : ILibcFileSystem
{
    [DllImport(LibcConstants.LibcLibrary, EntryPoint = "stat64")]
    private static extern int _stat64([MarshalAs(UnmanagedType.LPWStr)] string path, out Stat64 buf);

    public int Stat64(string path, out Stat64 buf)
    {
        return _stat64(path, out buf);
    }
}