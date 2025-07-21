// See https://aka.ms/new-console-template for more information

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "";
        while (true)
        {
            path = Utilidades.LeerString("Ingresa la ruta del archivo .mp3");

            if (path == null || path.Length == 0)
            {
                Utilidades.PrintError("No has ingresado nada...");
                continue;
            }
            //continue; reinicia el bucle
            if (!File.Exists(path))
            {
                Utilidades.PrintError("El archivo no existe");
                continue;
            }

            if (!path.ToLower().Contains(".mp3"))
            {
                Utilidades.PrintError("El archivo no tiene la extension objetivo...");
                continue;
            }

            break;

        }

        Id3v1Tag tags = null;
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[128];
            fs.Seek(-128, SeekOrigin.End);//Se utiliza para mover el cabezal de lectura, lo muevo al final con Seekorigin.end y retrocedo 128 bytes
            int n = fs.Read(buffer, 0, 128);//esta línea lee 128 bytes del archivo y los guarda en nuestro contenedor buffer.
            try
            {
                tags = new Id3v1Tag(buffer);
            }
            catch (Exception e)
            {
                
            }
            
        }

        if (tags != null)
        {
            Utilidades.PrintSuccess("¡Etiquetas encontradas!");
            Console.WriteLine("Titulo: " + tags.Titulo);
            Console.WriteLine("Artista: " + tags.Artista);
            Console.WriteLine("Album: " + tags.Album);
            Console.WriteLine("Año: " + tags.Año);
            Console.WriteLine("Comentario: " + tags.Comentario);
            Console.WriteLine("Genero: " + tags.Genero);
        }
        else
        {
            Utilidades.PrintError("El archivo no tenia etiquetas en formato Id3v1");
        }

    }
}
