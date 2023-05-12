using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace CreativeCoders.LibcDotNet.FileSystem;

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public struct Stat64 {
    public ulong st_dev;
    public ulong st_ino;
    public ulong st_mode;
    public ulong st_nlink;
    public ulong st_uid;
    public ulong st_gid;
    public ulong __pad0;
    public ulong st_rdev;
    public long st_size;
    public long st_blksize;
    public long st_blocks;
    public long st_atime;
    public long st_atime_nsec;
    public long st_mtime;
    public long st_mtime_nsec;
    public long st_ctime;
    public long st_ctime_nsec;
    public ulong __unused4;
    public ulong __unused5;
}