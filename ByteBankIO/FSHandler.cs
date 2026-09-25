using System.Text;
using ByteBankIO;

partial class Program
{
    static void FSHandler(string[] args)
    {
        var fileAddress = "contas.txt";
        using (var fileStream = new FileStream(fileAddress, FileMode.Open))
        {
            var countBytesRead = -1 ;
    
    
            var buffer = new byte[1024]; //1KB
   
            // Devoluções:
            // O número total de bytes lidos do buffer. Isso poderá ser menor que o número de
            // bytes solicitados se esse número de bytyes não estiver disponível no momento, ou
            // zero, se o final do fluxo for atingido;
            while (countBytesRead != 0)
            {
                countBytesRead = fileStream.Read(buffer, 0, 1024);
                
                //Console.WriteLine($"Bytes lidos: {countBytesRead}");
                writeBuffer(buffer, countBytesRead);
            }
        
            fileStream.Close();
                
            Console.ReadLine();
        }
    }
    // public override int Read(byte    [] array, int offset, int count);
    // este array é chamado de buffer
    static void writeBuffer(byte[] buffer, int bytesRead)
    {
        
        var utf8 = new UTF8Encoding();
        
        //public virtual string GetString(byte[] butes, int index, int count);
        var text = utf8.GetString(buffer, 0, bytesRead);
        
        Console.Write(text);
        // foreach (var myByte in buffer)
        // {
        //     Console.Write(myByte);
        //     Console.Write(" ");
        // }
    }
}