using  AreadeUsuario.Usuario;
UsuarioLogin u = new UsuarioLogin();
bool menu = true;
while(menu)
{
    
    Console.WriteLine("Bem vindo ao programa  oque você deseja:  ");
    Console.WriteLine("Entrar   ");
    Console.WriteLine("Cadastrar  ");
    Console.WriteLine("Sair  ");
     Console.WriteLine("0  ");
    string opcao = Console.ReadLine();
    switch(opcao.ToUpper())
    {
        case "ENTRAR":
        u.Login();
        break;
        case "CADASTRAR":
        u.Cadastro();
        break;
        default:
        Console.WriteLine("Vamos precisar que você digite uma das alternativas validas se você deseja Entrar, se Cadastrar ou Sair");
        break;
        case "SAIR":
        menu = false;
        Console.WriteLine("Obrigado por utilizar nosso serviço");
        break;
        case "0":
        u.consulta();
        break;
        case "1":
        u.consulta2();
        break;
    }
}
Console.WriteLine("Precione  qualquer tecla");
