using System.Text;

partial class Program
{
    static void CriandoArquivo()
    {
        string caminhoDoArquivo = "contas_exportadas.csv";


        using (var fs = new FileStream(caminhoDoArquivo, FileMode.Create))
        {
            var accountAsString = "111,2222,3333.44,Joe Doe";

            var encoding = Encoding.UTF8;
            
            var bytes = encoding.GetBytes(accountAsString);
            
            fs.Write(bytes, 0, bytes.Length);
        }
    }

    static void CriarArquivoComWriter()
    {
        string caminhoDoArquivo = "contas_exportadas.csv";

        using (var fs  = new FileStream(caminhoDoArquivo, FileMode.Create))
        using (var escritor = new StreamWriter(fs))
        {
            
        }
    }

    static void TestaEscrita()
    {
        
        string caminhoDoArquivo = "teste.txt";

        using (var fs  = new FileStream(caminhoDoArquivo, FileMode.Create))
        using (var escritor = new StreamWriter(fs))
        {
            for (int i = 0; i < 1000000; i++)
            {
                escritor.WriteLine($"Linha {i}");
                escritor.Flush(); // Despeja o buffer para o Stream
                Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter");
                Console.ReadLine();
            }
            

        }
    }
    
    
}