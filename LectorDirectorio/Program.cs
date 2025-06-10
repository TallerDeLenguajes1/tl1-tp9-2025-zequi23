// See https://aka.ms/new-console-template for more information

bool validacion = false;
string ubicacion = ""; 

do
{
    Console.WriteLine("Ingrese una ruta: (ubicacion de archivo)");
    ubicacion = Console.ReadLine(); // Ahora actualizamos la variable declarada fuera

    if (Directory.Exists(ubicacion))
    {
        validacion = true;
    }
    else
    {
        Console.WriteLine("Ingrese una ruta válida");
    }    
} while (!validacion);

///Carpetas

string[] carpetas = Directory.GetDirectories(ubicacion);
foreach (var carpeta in carpetas)
{
    Console.WriteLine($"Carpeta:{Path.GetFileName(carpeta)}");
}

///Archivos
string[] archivos = Directory.GetFiles(ubicacion);
foreach (string archivo in archivos)
{
    FileInfo info2 = new FileInfo(archivo);
    Console.WriteLine($"Archivo: {info2.Name}, Tamaño: {info2.Length / 1024.0:F2} KB, Última Modificación: {info2.LastWriteTime}");
}


string rutaCSV = Path.Combine(ubicacion, "reporte_archivos.csv");
using FileStream fs = File.Create(rutaCSV);
using var sr = new StreamWriter(fs);


sr.WriteLine($"reporte_archivos.csv,Tamano(KB):");

//La primer linea es el Encabezado
List<string> lineasCsv = new List<string>();
//{
//   "Nombre del archivo, Tamano(KB), Fecha de ultima modificacion"
//}

lineasCsv.Add("Nombre del archivo; Tamano(KB); Fecha de ultima modificacion");

File.WriteAllLines(rutaCSV, lineasCsv);//Inserta todo de la lista en la ruta del CSV
