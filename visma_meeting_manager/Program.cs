using System.IO;
using class_library;
using jonas_deksnys_task;

class program
{
    public static void Main(string[] args)
    {
        DbInitService.SetupDirectory();
        ActionProcessor.ProcessRequest();

    }
}