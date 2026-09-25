using System.Text;
using ByteBankIO;

partial class Program
{
    static void CreatingFile()
    {
        var newFile = "contasExportadas.csv";

        using (var stream = new FileStream(newFile, FileMode.Create))
        {
            var accAsString = "223,1223,1833.99,Josiane Becker";

            var encoding = Encoding.UTF8;
            
            var bytes = encoding.GetBytes(accAsString);
            
            stream.Write(bytes, 0, bytes.Length); 
        }

    }
    
    static void CreatingFileWithWrite()
    {
        var newFile = "contasExportadas.csv";

        using (var stream = new FileStream(newFile, FileMode.Create))
        using (var writer = new StreamWriter(stream))
        {
            writer.Write("223,1223,1833.99,Pedro Fernandes");
        }
    }
}