class Program{
    public static void Main(){
        Console.WriteLine("Calculadora do AQ-10");
        Console.WriteLine("Digite o nome do paciente!");
        Paciente paciente = new Paciente(Console.ReadLine());
        paciente.preencheRespostas();
        paciente.exibeGabaritoPreenchido();
        Console.WriteLine($"Nota geral: {paciente.converteParaNota()}");
        Console.WriteLine("Deseja salvar os resultados? Se sim, digite 's' minúsculo!");
        if(Console.ReadLine() == "s"){
            paciente.SalvarResultados();
        }
    }
}