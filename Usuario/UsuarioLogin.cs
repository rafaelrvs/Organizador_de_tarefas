using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;



namespace AreadeUsuario.Usuario
{
    public class UsuarioLogin
    {
        private List<string> ListaTempo = new List<string>();
        private List<string> UsuarioPermitido = new List<string>();
        private List<string> SenhaPermitida = new List<string>();
        private List<string> ListaDeRotina = new List<string>();
        private List<string> DataDaRotina = new List<string>();
        private string _usuario;
        public string usuario
        {
            get => _usuario;
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Valor invalido o valor digitado não pode ser um valor em branco ");
                }
                _usuario = value;
            }
        }
        private string _senha;
        public string Senha
        {
            get => _senha;
            set
            {
                if (value == " ")
                {
                    throw new ArgumentException("Valor invalido o valor digitado não pode ser um valor em branco ");
                }
                _senha = value;
            }
        }
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (value == " ")
                {
                    throw new ArgumentException("O campo digitado não pode ficar em branco é uma informação importante para finalizar o cadastro");
                }
                _email = value;

            }
        }
        public void Cadastro()
        {


            Console.WriteLine("Ola, vamos começar o seu cadastro");
            Console.WriteLine("Digite o seu nome");
            try
            {
                usuario = Console.ReadLine();
            }
            catch
            {
                throw new ArgumentException(" O campo digitado não pode ser um campo vazio ");
            }
            while (usuario == " " ||
                usuario == "123456" || usuario == Email || UsuarioPermitido.Any(x => x.ToUpper() == usuario.ToUpper()))
            {
                Console.WriteLine(" usuario invalido, vamos tentar novamente? ");
                Console.WriteLine("Digite  seu nome ");
                usuario = Console.ReadLine();

            }

            Console.Clear();
            Console.WriteLine($"Muito bom conhecer você {usuario} vamos precisar agora de uma senha bem forte");
            Console.WriteLine("Digite sua senha ");
            try
            {
                Senha = Console.ReadLine();

            }
            catch
            {
                throw new ArgumentException("O campo Senha não pode ficar em branco");
            }
            while (Senha == usuario || usuario == Senha
                 || Senha == "123456" || Senha == Email || Email == Senha && Senha == Email || Senha == "" || UsuarioPermitido.Any(x => x.ToUpper() == Senha.ToUpper()))
            {
                Console.WriteLine("Sua senha não foi considerada uma senha valida, vamos tentar novamente?");
                Console.WriteLine("Digite sua senha ");
                Senha = Console.ReadLine();

            }

            Console.Clear();
            Console.WriteLine($"Muito bem {usuario} para finalizar o seu cadastro digite por favor o seu email");

            try
            {
                Email = Console.ReadLine();
            }
            catch

            {


                throw new ArgumentException(" O campo digitado não pode ser um campo vazio ");
            }
            while (Email == "" || UsuarioPermitido.Any(x => x.ToUpper() == Email.ToUpper()))
            {
                Console.WriteLine("O E-mail cadastrado é invalido ");
                Console.WriteLine("Digite seu E-mail novamente ");
                Email = Console.ReadLine();
            }


            UsuarioPermitido.Add(usuario);
            SenhaPermitida.Add(Senha);
            UsuarioPermitido.Add(Email);
            Console.Clear();
            Cadastrook();
        }
        public void Login()
        {
            Console.Clear();
            Console.WriteLine("Digite seu nome de usuario ou  o seu E-mail");
            usuario = Console.ReadLine();
            Console.Clear();
            if (usuario == " " && Senha == " " || usuario == " " || Senha == "" || UsuarioPermitido.Any(x => x.ToUpper() == usuario.ToUpper() || UsuarioPermitido.Any(x => x.ToUpper() == Email.ToUpper())))
            {
                Console.WriteLine("Digite sua senha");
                Senha = Console.ReadLine();

                if (SenhaPermitida.Any(x => x.ToUpper() == Senha.ToUpper()))
                {
                    Console.WriteLine("Usuario logado com sucesso");
                    Console.Clear();

                    Console.WriteLine("Aperte qualquer tecla para continuar");
                    usuarioLogado();
                }
                else
                {
                    Console.WriteLine("algo está errado, verifique as informações ");
                }


            }
            else
            {
                Console.WriteLine("Usuario não existe tente novamente ou realize um cadastro ");
            }

        }

        public void Cadastrook()
        {
            Console.Clear();
            Console.WriteLine("Agora que finalizou seu cadastro vamos entrar?");
            Login();


        }
        public void consulta()
        {
            foreach (string objeto in UsuarioPermitido)
            {
                Console.WriteLine(objeto);

            }
        }
        public void consulta2()
        {
            foreach (string objeto in SenhaPermitida)
            {
                Console.WriteLine(objeto);

            }
        }

        public void usuarioLogado()
        {


            Console.Clear();

            var date = DateTime.Now;
            bool menuc = true;
            while (menuc)
            {
                Console.WriteLine($"Ola {usuario}  agora é exatamente {date}");
                Console.WriteLine("O que você deseja");
                Console.WriteLine("Criar um cronograma? [ 1 ]          Meu tempo livre?[ 2 ]           Proxima tarefa [ 3 ]          Para sair [ 4] Remover tarefa [5]");
                switch (Console.ReadLine())
                {
                    case "1":
                        AdicionarRotina();
                        break;
                    case "2":
                        TempoLivre();
                        break;
                    case "3":
                        ProximaTarefa();
                        break;
                    case "4":
                        menuc = false;
                        break;
                    case "5":
                        RemoverTarefa();
                        break;

                }
            }

        }
        public void AdicionarRotina()
        {
            Console.Clear();
            var date = DateTime.Now;
            var Formatada = String.Format("{0:d}", date);
            Console.WriteLine(Formatada);
            Console.WriteLine("Escolha a data ");
            var DataEscolhida = Console.ReadLine();
            while (Formatada == DataEscolhida || DataEscolhida == "")
            {
                Console.WriteLine("Esta  data não pode ser gerado nenhuma rotina, o tempo limite foi ultrapassado");
                Console.WriteLine("Escolha a data ");
                DataEscolhida = Console.ReadLine();

            }
            DataDaRotina.Add(DataEscolhida);

            Console.Clear();
            Console.WriteLine("Digite o que irá fazer neste dia ");
            string Item = Console.ReadLine();
            while (Item == " ")
            {
                Console.WriteLine("Você tem que digitar alguma rotina ");
                Console.WriteLine("Digite sua tarefa");
                Item = Console.ReadLine();
            }
            ListaDeRotina.Add(Item);
        }
        public void ProximaTarefa()
        {
            var date = DateTime.Now;
            var Formatada = String.Format("{0:d}", date);
            Console.WriteLine($"Suas Taréfas {usuario} até {Formatada}");

            foreach (string objeto in ListaDeRotina)
            {


                foreach (string item in DataDaRotina)
                {
                    Console.WriteLine($"Sua atividade é {objeto}  ;  E a data é: {item}");
                }
            }

        }
        public void TempoLivre()
        {
            string tempo = "";
            Console.WriteLine("Escolha a data que você tem livre ");
            tempo = Console.ReadLine();

            while (tempo == "")
            {
                Console.WriteLine("Digite uma data valida");
                tempo = Console.ReadLine();

            }
            ListaTempo.Add(tempo);

            foreach (string item in ListaTempo)
            {
                Console.WriteLine($" Seu tempo livre é {item}");
            }


        }
        public void RemoverTarefa()
        {
            Console.WriteLine($" {usuario} Qual tarefa você desejá remover, escreva exatamente como está adicionado para a tarefa ser executada");
            Console.WriteLine("Qual e  a data que deseja remover ");
            string DataR = Console.ReadLine();
            if (DataDaRotina.Any(x => x.ToUpper() == DataR.ToUpper()))
            {
                Console.WriteLine($"{DataR}: Removido com sucesso");
                DataDaRotina.Remove(DataR);
            }
            else

            {
                Console.WriteLine($"O item {DataR} não está disponivel na sua lista ");
            }
               Console.WriteLine("Qual e  a tarefa que deseja remover ? ");
             string Tar = Console.ReadLine();
             if (ListaTempo.Any(x=>x.ToUpper()== Tar.ToUpper()))
             {
                Console.WriteLine($"{Tar}: Removido com sucesso");
                DataDaRotina.Remove(Tar);

             }


        }

    }
}