using System.Runtime.InteropServices;
using System.Text;
using Tmds.Linux;

namespace CreativeCoders.LibcDotNet;

public static unsafe partial class LibcFunctions
{
    public static unsafe int Stat(string path, out stat stat)
    {
        ArgumentNullException.ThrowIfNull(path);
        
        stat = new stat();
        
        fixed (stat* statBuffer = &stat)
        {
            fixed (byte* pathBuffer = Encoding.UTF8.GetBytes(path))
            {
                return LibC.stat(pathBuffer, statBuffer);
            }
        }
    }

    public static bool TryStat(string path, out stat stat)
    {
        var result = Stat(path, out stat);

        return result == 0;
    }

    public static stat Stat(string path)
    {
        Marshal.SetLastPInvokeError(0);
        
        var result = Stat(path, out var buf);

        if (result == 0)
        {
            return buf;
        }

        var errno = Marshal.GetLastPInvokeError();

        if (errno == LibC.ENOENT)
        {
            throw new FileNotFoundException("File for stat not found", path);
        }

        throw new LibcException(errno);
    }
}
