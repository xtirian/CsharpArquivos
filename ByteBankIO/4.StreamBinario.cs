
partial class Program
{
    static void EscritaBinaria()
    {
        using (var fs  = new FileStream("contaCorrente.txt", FileMode.Create))
        using (var escritor = new BinaryWriter(fs))
        {
            escritor.Write(444);
            escritor.Write(55431);
            escritor.Write(19021995.13);
            escritor.Write("Matheus Fernandes");
        }
    }

    static void LerBinario()
    {
        using (var fs  = new FileStream("contaCorrente.txt", FileMode.Open))
        using (var leitor = new BinaryReader(fs))
        {
            var agencia = leitor.ReadInt32();
            var numero = leitor.ReadInt32();
            var saldo = leitor.ReadDouble();
            var titular =  leitor.ReadString();
            
            Console.WriteLine($"{agencia}/{numero} || {titular}, Saldo: {saldo}");
        }
             
    }

}