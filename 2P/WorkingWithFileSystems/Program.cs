using static System.IO.Directory; // Create or kill folders
using static System.IO.Path; // Creates URLS // C://Documentos...
using static System.Environment; // OS, Users, permissions

#region Knowing directory Stuff    
SectionTitle("Cross Platform Environments");
WriteLine($"{"Path.PathSeparator",-33} {PathSeparator}");
WriteLine($"{"Path.DirectoryPathSeparator",-33} {DirectorySeparatorChar}");
WriteLine($"{"Directory.GetCurrentDirectory",-33} {GetCurrentDirectory()}");
WriteLine($"{"Directory.CurrentDirectory",-33} {CurrentDirectory}");
WriteLine($"{"Environment.SystemDirectory",-33} {SystemDirectory}");
WriteLine($"{"Path.GetTempPath",-33} {GetTempPath()}");
WriteLine($"{"Directory.SpecialFolder",-33} {GetFolderPath(SpecialFolder.System)}");
WriteLine($"{"Directory.ApplicationData",-33} {GetFolderPath(SpecialFolder.ApplicationData)}");
WriteLine($"{"Directory.MyDocuments",-33} {GetFolderPath(SpecialFolder.MyDocuments)}");
#endregion


#region Manage Drives
    SectionTitle("Manage Drives");
    WriteLine($"{"NAME",-30} | {"TYPE",-10} | {"FOMRAT",-7} | {"SIZE",18} | {"FREE SPACE",18}");
    foreach (DriveInfo drive in DriveInfo.GetDrives())
    {
        if(drive.IsReady)
        {
            WriteLine($"{drive.Name,-30} | {drive.GetType(),-10} | {drive.DriveFormat,-7} | {drive.TotalSize,18} | {drive.TotalFreeSpace,18}");
        }
    }
#endregion

#region Manage Directories
    SectionTitle("Manage Directories");
    string newFolder = Combine(GetFolderPath(SpecialFolder.MyDocuments), "New Folder");
    WriteLine("Working with New Folder");
    WriteLine("Creating New Folder");
    CreateDirectory(newFolder);
    WriteLine($"Does it exist? : {Path.Exists(newFolder)}");
    ReadLine();
#endregion

#region Managing Files
    SectionTitle("Managing Files");
    string dir = Combine(GetFolderPath(SpecialFolder.MyDocuments), "OutPutFiles");
    CreateDirectory(dir);
    string textFile = Combine(dir, "Dummy.txt");
    string backUpFile = Combine(dir, "Dummy.bak");
    WriteLine($"Working with {textFile}");
    WriteLine($"Does it Exists? : {Path.Exists(textFile)}");

    // Writing on files
    // StreamWriter
    StreamWriter textWriter = File.CreateText(textFile); // Create
    textWriter.WriteLine("Hello my bruuuther");
    textWriter.Close();
    // Close, if not, you can corrupt the file or the data
    WriteLine($"Does it Exists? : {Path.Exists(textFile)}");

    // backUp
    // Copy the data from original File to .bak File
    File.Copy(sourceFileName: textFile, destFileName: backUpFile, overwrite: true);
    WriteLine($"Does Back Up Exists? : {Path.Exists(backUpFile)}");
    ReadLine();

    // Assasinate textFile
    File.Delete(textFile);
    WriteLine($"Does it Exists? : {Path.Exists(textFile)}");

    //READ from file
    WriteLine($"Reading contents from {backUpFile}");
    StreamReader textReader = File.OpenText(backUpFile);
    WriteLine(textReader.ReadToEnd());
    textReader.Close();

#endregion
