using ByteBankIO;
using System.Globalization;

partial class Program
{
    static void UsingStreamReader(string[] args)
    {
        var fileAddress = "contas.txt";

        using (var fs = new FileStream(fileAddress, FileMode.Open))
        {
            var reader = new StreamReader(fs);
            
            ///var line = reader.ReadLine();
            
            //Contudo, há uma ressalva. Anteriormente, quando trabalhamos com buffer de 1024 bytes, a ideia era evitar o carregamento de arquivos grandes de uma única vez, o que pode ser prejudicial em termos de memória.
            //var text = reader.ReadToEnd();

            // Traz o primeiro byte
            //var number = reader.Read();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                var contaCorrente = ConvertStringToContaCorrente(line);
                
                var msg = $"Conta corrente: {contaCorrente.Numero} || Agencia: {contaCorrente.Agencia} || Saldo: {contaCorrente.Saldo} || Titular: {contaCorrente.Titular.Nome}";
                
                Console.WriteLine(msg);
            }

        }
        Console.ReadLine();
    }

    static ContaCorrente ConvertStringToContaCorrente(string line)
    {
        var fields = line.Split(',');
        
        var agencia = int.Parse(fields[0]);
        var conta = int.Parse(fields[1]);
        
        var saldo = double.Parse(fields[2], CultureInfo.InvariantCulture);

        var titular = new Cliente();
        titular.Nome = fields[3];
        
        var result = new ContaCorrente(agencia, conta);
        result.Depositar(saldo);
        result.Titular = titular;
        
        return result;
    }
    
}