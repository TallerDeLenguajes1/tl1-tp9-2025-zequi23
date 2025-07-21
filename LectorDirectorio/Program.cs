// See https://aka.ms/new-console-template for more information



string path = "";

do
{
    Console.WriteLine("Ingrese la ruta de la carpeta");
    path = Console.ReadLine();
} while (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path));


if (Directory.Exists(path))
{
    var directorios = Directory.GetDirectories(path); // me devuelve un arreglo de strings
    var files = Directory.GetFiles(path); // arreglo de strings

    //Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine($"Listados de directorios en {path}");
    if (directorios.Length != 0)
    {
            
        foreach (var directory in directorios)
        {
            var nameDirectorio = Path.GetFileName(directory);
            Console.WriteLine(nameDirectorio);
        }   
    }else
    {
        Console.WriteLine($"El directorio {path} no contiene subdirectorios");
    }

    Console.WriteLine();

    if (files.Length != 0)
    {

        Console.WriteLine($"Listados de archivos en {path}");
        foreach (var pathFile in files)
        {
            var nameFile = Path.GetFileName(pathFile);
            var info = new FileInfo(pathFile); // creo un objeto de tipo fileInfo sobre la ruta del archivo
            var tamanio = info.Length / 1024.0;
            Console.WriteLine($"{nameFile} - Tamaño:{tamanio} KB");
        }

        string path_file = "reporte_archivos.csv";
        string path_reporte = Path.Combine(path, path_file);
        //string pathRelative = Path.GetRelativePath(path, path_file);
        using (var stream = new StreamWriter(path_reporte)) //el bloque using libera todos los recursos cuando termine
        {
            stream.WriteLine("Archivo,Tamaño en KB,Fecha de ultima modificacion");
            foreach (var item in files)
            {
                string nombre = Path.GetFileName(item);
                var info = new FileInfo(item); // creo un objeto de tipo fileInfo sobre la ruta del archivo
                var tamanio = info.Length / 1024.0;
                var date = info.LastWriteTime;
                stream.WriteLine($"{nombre},{tamanio},{date}");
            }
        }

    }
    else
    {
        Console.WriteLine($"El directorio {path} no contiene archivos");
    }
    
}