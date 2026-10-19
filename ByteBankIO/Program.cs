using System.Text;
using ByteBankIO;

class Program
{
    static void Main(string[] args)
    {
        string enderecoDoArquivo = "contas.txt";

        using (var fs = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var buffer = new byte[fs.Length];

            fs.Read(buffer, 0, buffer.Length);
            
            EscreverBuffer(buffer);
            
            fs.Close();
        }
    }

    static void EscreverBuffer(byte[] buffer)
    {
        var utf8 = new UTF8Encoding();
        
        var texto = utf8.GetString(buffer);
        
        Console.Write(texto);
        
        // foreach (var b in buffer)
        // {
        //     Console.WriteLine(b);
        //     
        // }
    }
}