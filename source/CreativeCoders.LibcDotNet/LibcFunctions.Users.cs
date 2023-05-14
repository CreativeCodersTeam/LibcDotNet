using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Tmds.Linux;

namespace CreativeCoders.LibcDotNet;

public static unsafe partial class LibcFunctions
{
    [DllImport(LibcConstants.LibcLibrary, EntryPoint = "getpwuid")]
    private static extern void* _getpwuid(uint uid);
    
    public static unsafe passwd? Getpwuid(uint uid)
    {
        var result = _getpwuid(uid);

        return Unsafe.Read<passwd>(result);
    }
}