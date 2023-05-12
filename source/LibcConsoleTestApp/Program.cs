// See https://aka.ms/new-console-template for more information

using CreativeCoders.LibcDotNet.FileSystem;
using CreativeCoders.LibcDotNet.Users;

var fileName = args.FirstOrDefault();

if (!File.Exists(fileName))
{
    Console.WriteLine("File does not exist");
    return;
}

var fileStat = new LibcFileSystem().Stat64(fileName, out var statBuffer);

var userName = new LibcUsers().GetOwnerName((uint)statBuffer.st_uid);

Console.WriteLine($"Username: {userName}");
Console.WriteLine("Hello, World!");