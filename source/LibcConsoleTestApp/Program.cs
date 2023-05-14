// See https://aka.ms/new-console-template for more information

using CreativeCoders.LibcDotNet;
using CreativeCoders.LibcDotNet.Users;


PrintStat(args.FirstOrDefault());

Console.WriteLine("Program done");

void PrintStat(string? fileName)
{
    if (fileName == null)
    {
        return;
    }
    
    try
    {
        Console.WriteLine($"File: {fileName}");
        
        var stat = LibcFunctions.Stat(fileName);

        var userName = new LibcUsers().GetOwnerName((uint)stat.st_uid);
        
        Console.WriteLine($"  User: {userName}");
        
        var groupName = new LibcUsers().GetOwnerName((uint)stat.st_gid);
        
        Console.WriteLine($"  Group: {groupName}");

        foreach (var field in stat.GetType().GetFields())
        {
            Console.WriteLine($"{field.Name}: {field.GetValue(stat)}");
        }
    }
    catch (LibcException e)
    {
        Console.WriteLine(e);
        Console.WriteLine($"{e.ErrorNum}: {e.ErrorText}");
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}