using System.Runtime.InteropServices;
using Tmds.Linux;

namespace CreativeCoders.LibcDotNet;

public static unsafe partial class LibcFunctions
{
    public static unsafe string GetErrorString(int errno)
    {
        const int bufferLength = 1024;
        var buffer = stackalloc byte[bufferLength];

        var result = LibC.strerror_r(errno, buffer, bufferLength);
        
        return result == 0
            ? (Marshal.PtrToStringAnsi((IntPtr)buffer) ?? string.Empty)
            : $"errno {errno}";
    }

}