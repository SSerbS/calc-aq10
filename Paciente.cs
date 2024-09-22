class Paciente{
    string nome;
    public Paciente(string nome){
        this.nome = nome;
    }
    int[] respostas= new int[10];
    
    int[] arConc = [1,5,7,10];
    public void preencheRespostas(){
        Console.WriteLine($"Preenchendo os dados de {nome}!");
        for(int i = 0; i < respostas.Length; i++){ //lembrar que i sempre estará um abaixo do item de fato
            if(i == 0){
                Console.WriteLine($"Preenchendo a questão {i+1}");
            }
            else{
                Console.WriteLine($"Preenchendo a questão {i+1}! Se quiser corrigir a anterior, digite 'b' em minúsculas!");
            }
            var respAtualString = Console.ReadLine();
            if(respAtualString != "b" || i == 0){ //segue na iteração atual caso digite b ou esteja na primeira iteração
                if(int.TryParse(respAtualString, out int respAtualOK)){ //se for um número, segue
                    if(respAtualOK > 0 && respAtualOK < 5){ //verifica se é 1, 2, 3 ou 4
                        respostas[i] = respAtualOK;
                    }
                    else{
                        //Console.Clear();
                        Console.WriteLine("Digite um número válido (1,2,3,4)! Tente novamente!");
                        i--;
                        continue;
                    }
                }
                else{ //caso alguma letra tenha sido digitada
                    //Console.Clear();
                    Console.WriteLine("Digite apenas números! Tente novamente");
                    i--; //repete a tentativa de preencher o valor atual
                    continue;
                }
            }
            else{// caso tenha digitado "b"
            //Console.Clear();
            i = i-2;
            continue;
            }
        }
        Console.WriteLine("Respostas computadas!");
    }

    public void exibeGabaritoPreenchido(){
        for(int i = 0; i < respostas.Length; i++){
            Console.WriteLine($"Questão {i+1} marcou gabarito {respostas[i]}");
        }
    }
    public int converteParaNota(){
        int soma = 0;
        for(int i = 0; i < respostas.Length; i++){
            if(arConc.Contains(i+1)){//verifica se o item atual é do Concordo
                if(respostas[i] == 1 || respostas[i] == 2){
                    soma++;
                }
            }
            else{
                if(respostas[i] == 3 || respostas[i] == 4){
                    soma++;
                }
            }
        }
        return soma;
    }
    public void SalvarResultados(){
        string local = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string filename = @$"AQ10_{nome}.txt";
        string path = Path.Combine(local, filename);
        int contador = 1;

        while(File.Exists(path)){
            filename = @$"AQ10_{nome}{contador}.txt";
            path = Path.Combine(local, filename);
            contador++;
        }
        if(!File.Exists(path)){
            using(StreamWriter sw = File.CreateText(path)){
                for(int i = 0; i < respostas.Length; i++){
                sw.WriteLine($"Questão {i+1} marcou gabarito {respostas[i]+1}");
                }
                sw.WriteLine();
                sw.WriteLine($"Soma geral: {converteParaNota()}");
                Console.WriteLine("Arquivo salvo!");
            }
        }
    } 
}