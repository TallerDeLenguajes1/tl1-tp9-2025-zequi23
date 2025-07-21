using System.Text;

public class Id3v1Tag
{
    //campos
    public readonly string Titulo;
    public readonly string Artista;
    public readonly string Album;
    public readonly int Año;
    public readonly string Comentario;
    public readonly byte Genero;

    //constructor
    public Id3v1Tag(byte[] arr)//recibe un arreglo de bytes
    {
        string parsed = Encoding.GetEncoding("latin1").GetString(arr); //captura el arreglo de bytes, obtiene un string con la codificacion de latin1

        Titulo = parsed.Substring(3, 30);
        Artista = parsed.Substring(33, 30);
        Album = parsed.Substring(63, 30);
        Año = int.Parse(parsed.Substring(93, 4));
        Comentario = parsed.Substring(97, 30);
        Genero = arr[127];
    }


}