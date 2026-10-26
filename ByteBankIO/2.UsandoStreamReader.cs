using ByteBankIO;

partial class Program
{
    static void UsandoStramReader(string[] args)
    {
        string enderecoDoArquivo = "contas.txt";
        
        using (var fs = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fs);
            
            //var linha = leitor.ReadLine();
            
            //var textoCompleto = leitor.ReadToEnd();

            //var byte = leitor.Read();

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                ContaCorrente conta = ConverterStringParaContaCorrente(linha);
                EnviaMensagem(conta);
            }
        }
        
    }

    static void EnviaMensagem(ContaCorrente conta)
    {
        string msg = $"Titular: {conta.Titular.Nome} ({conta.Agencia}-{conta.Numero}) >>> Saldo: R$${conta.Saldo}";
        Console.WriteLine(msg);
    }

    static ContaCorrente ConverterStringParaContaCorrente(string texto)
    {
        // 375,4644,2483.13,Jonatan Silva
        int agencia = int.Parse(texto.Split(",")[0]);
        int conta = int.Parse(texto.Split(",")[1]);
        double saldo = double.Parse(texto.Split(",")[2].Replace('.', ','));
        Cliente titular = new Cliente();
        titular.Nome = texto.Split(",")[3];


        var resultado = new ContaCorrente(agencia, conta);
        resultado.Depositar(saldo);
        resultado.Titular = titular;
        
        return resultado;
    }
}