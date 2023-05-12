using System.Runtime.InteropServices;

namespace CreativeCoders.LibcDotNet.Users;

public interface ILibcUsers
{
    
}

public class LibcUsers : ILibcUsers
{
    [DllImport(LibcConstants.LibcLibrary, EntryPoint = "getpwuid")]
    private static extern IntPtr _getpwuid(uint uid);
    
    // Get the owner's name from the UID
    public string? GetOwnerName(uint uid) {
        IntPtr pwPtr = _getpwuid(uid);
        if (pwPtr == IntPtr.Zero) {
            return "unknown";
        }
        return Marshal.PtrToStringAnsi(Marshal.ReadIntPtr(pwPtr, 0));
    }
}
