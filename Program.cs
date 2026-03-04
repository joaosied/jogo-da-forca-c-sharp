using System;

class Program
{
    static void Main()
    {

        string[] noErrorGame = new string[] {
            @"       ╔══════╗",
            @"       ║      ║",
            @"              ║",
            @"              ║",
            @"              ║",
            @"  ════════════╩",
        };

        string[] OneErrorGame = new string[] {
            @"       ╔══════╗",
            @"       ║      ║",
            @"       O      ║",
            @"              ║",
            @"              ║",
            @"  ════════════╩",
        };

        string[] TwoErrorGame = new string[] {
            @"       ╔══════╗",
            @"       ║      ║",
            @"       O      ║",
            @"       |      ║",
            @"              ║",
            @"  ════════════╩",
        };

        string[] ThreeErrorGame = new string[] {
            @"       ╔══════╗",
            @"       ║      ║",
            @"       O      ║",
            @"       |\     ║",
            @"              ║",
            @"  ════════════╩",
        };

        string[] FourErrorGame = new string[] {
            @"       ╔══════╗",
            @"       ║      ║",
            @"       O      ║",
            @"      /|\     ║",
            @"              ║",
            @"  ════════════╩",
        };

        string[] FiveErrorGame = new string[] {
            @"       ╔══════╗",
            @"       ║      ║",
            @"       O      ║",
            @"      /|\     ║",
            @"      /       ║",
            @"  ════════════╩",
        };

        string[] SixErrorGame = new string[] {
            @"     FIM   DE   JOGO   ",
            @"       ╔══════╗",
            @"       ║      ║",
            @"      X_X     ║",
            @"      /|\     ║",
            @"      / \     ║",
            @"  ════════════╩",
            @"      VOCE   PERDEU     ",
        };


        // definiçao de temas pre disponibilizados no sistema
        string[] themes = { "Objeto", "Futebol", "Informática", "Filmes ou Séries", "Comida", "Profissão" };

        // comeco do jogo - boas vindas e informe de nome
        Console.WriteLine("Vamos jogar o Jogo da Forca.");
        Console.WriteLine("Olá JOGADOR 1, me informe o seu nome: ");
        string namePlayer1 = Console.ReadLine() ?? "";

        // validacao de que o nome infrmado pelo usuario nao esta em branco
        while (string.IsNullOrWhiteSpace(namePlayer1))
        {
            Console.WriteLine("⚠️ Você precisa digitar uma palavra válida!");
            Console.Write("Digite novamente: ");
            namePlayer1 = Console.ReadLine() ?? "";
        }
        namePlayer1 = namePlayer1.ToUpper(); // o nome do usuario vai ser armazenado como maiusculo, por estilo e padronizacao

        Console.WriteLine();
        // escolha de time de futebol que torce - vai definir a cor predominante do jogo
        Console.WriteLine($"{namePlayer1} escolha o time que voce torce: ");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        Console.Write("1 - CORINTHIANS");
        Console.ResetColor();
        Console.WriteLine(" / 2 - cap / 3 - coxa / 4 - Nenhum");
        int teamChoice;

        // validacao para ter certeza de que o numero escolhido é uma opcao valida, e tambem armazenar a opcao do usuario.
        while (true)
        {
            Console.Write("Digite sua opção: ");
            string entrada = Console.ReadLine() ?? "";

            if (!int.TryParse(entrada, out teamChoice))
            {
                Console.WriteLine("⚠️ Digite apenas números (1 a 4).");
                continue;
            }

            if (teamChoice < 1 || teamChoice > 4)
            {
                Console.WriteLine("⚠️ Escolha apenas entre 1 e 4.");
                continue;
            }

            // regrinha diferente para opcao 4
            if (teamChoice == 4)
            {
                Console.WriteLine("Parabéns pela sua escolha! Agora você torce pro CORINTHIANS, mais um louco pro BANDO!!!! 😆");
                teamChoice = 1; // transforma em Corinthians
            }

            break;
        }

        // resultado final armazenado na variavel
        string timeEscolhido = teamChoice switch
        {
            1 => "Corinthians",
            2 => "CAP",
            3 => "Coxa",
            _ => "Desconhecido"
        };

        // mostrar visualmente para o usuario o time escolhido pelo mesmo
        TeamColor(timeEscolhido);
        Console.Clear();
        Console.WriteLine($"Time definido: {timeEscolhido}");

        Console.WriteLine($"é a vez do {namePlayer1} escolher a palavra");
        Console.WriteLine("1 - Quer escolher o tema/ 2 - Precisa de um tema pré definido");

        //jogador 1 escolhe o tema, com validacao.
        int themeChoice;

        while (!int.TryParse(Console.ReadLine(), out themeChoice) || (themeChoice != 1 && themeChoice != 2))
        {
            Console.WriteLine("Digite 1 ou 2");
        }

        string themePlayer = "";

        if (themeChoice == 1)
        {
            Console.WriteLine("Qual Tema é a sua palavra?");
            themePlayer = Console.ReadLine() ?? "";
        }
        else if (themeChoice == 2)
        {
            //criacao do random que gera numeros aleatorios
            Random random = new Random();
            //cria o indice com o valor maximo definido no tamanho da array themes
            int themeRandom = random.Next(themes.Length);
            //faz o sorteio na array
            themePlayer = themes[themeRandom];
            Console.WriteLine($"Então o tema será: {themePlayer}");
        }

        //escolha de palavra para o jgogador 2 acertar
        Console.WriteLine("Digite uma palavra e aperte enter");
        Console.WriteLine();
        Console.WriteLine("A palavra escolhida é: ");
        string palavraEscolhida = Console.ReadLine() ?? "";
        palavraEscolhida = palavraEscolhida.ToUpper();

        // validação de que nao é null
        while (string.IsNullOrWhiteSpace(palavraEscolhida))
        {
            Console.WriteLine("⚠️ Você precisa digitar uma palavra válida!");
            Console.Write("Digite novamente: ");
            palavraEscolhida = Console.ReadLine() ?? "";
        }

        Console.Clear();
        Console.WriteLine("AGORA É A VEZ DO SEGUNDO JOGADOR");
        Console.WriteLine("Olá Jogador 2, me informe o seu nome: ");
        string namePlayer2 = Console.ReadLine() ?? "";
        // validação obrigatória
        while (string.IsNullOrWhiteSpace(namePlayer2))
        {
            Console.WriteLine("⚠️ Você precisa digitar uma palavra válida!");
            Console.Write("Digite novamente: ");
            namePlayer2 = Console.ReadLine() ?? "";
        }
        namePlayer2 = namePlayer2.ToUpper();

        string[] letrasIdentificadas = new string[palavraEscolhida.Length];

        int limitErrors = 6;
        int quantityErrors = 0;
        int tamanhoPalavra = palavraEscolhida.Length;

        bool JogoAndamento = true;
        do
        {
            //apaga todo o console pro jogador nao ver a palavra
            Console.Clear();
            Console.WriteLine($"Vamos lá, {namePlayer2}");
            Console.WriteLine($"O tema da palavra é: {themePlayer}");

            string[] desenhoForca;

            switch (quantityErrors)
            {
                case 1:
                    desenhoForca = OneErrorGame;
                    break;
                case 2:
                    desenhoForca = TwoErrorGame;
                    break;
                case 3:
                    desenhoForca = ThreeErrorGame;
                    break;
                case 4:
                    desenhoForca = FourErrorGame;
                    break;
                case 5:
                    desenhoForca = FiveErrorGame;
                    break;
                case 6:
                    desenhoForca = SixErrorGame;
                    break;
                default:
                    desenhoForca = noErrorGame;
                    break;
            }

            for (int i = 0; i < desenhoForca.Length; i++)
            {
                Console.WriteLine(desenhoForca[i]);
            }

            if (quantityErrors == limitErrors)
            {
                break;
            }

            for (int i = 0; i < letrasIdentificadas.Length; i++)
            {
                string letraAtual = letrasIdentificadas[i];
                if (letraAtual == null)
                {
                    Console.Write("-");
                }
                else
                {
                    Console.Write(letraAtual);
                }
                Thread.Sleep(100);

            }
            Console.WriteLine();
            Console.WriteLine("Escolha uma letra para tentar adivinhar a palavra");
            string letraEscolhida;

            while (true)
            {
                Console.Write("A letra escolhida é: ");
                letraEscolhida = Console.ReadLine() ?? "";

                // validações
                if (string.IsNullOrWhiteSpace(letraEscolhida))
                {
                    Console.WriteLine("⚠️ Digite uma letra!");
                    continue;
                }

                if (letraEscolhida.Length != 1)
                {
                    Console.WriteLine("⚠️ Digite apenas UMA letra!");
                    continue;
                }

                if (!char.IsLetter(letraEscolhida[0]))
                {
                    Console.WriteLine("⚠️ Apenas letras são permitidas!");
                    continue;
                }

                // se passou em tudo → sai do loop
                letraEscolhida = letraEscolhida.ToUpper();
                break;
            }

            bool letraEncontrada = false;
            for (int i = 0; i < tamanhoPalavra; i++)
            {
                string letraAtual = palavraEscolhida[i].ToString();
                if (letraAtual == letraEscolhida)
                {
                    letrasIdentificadas[i] = letraAtual;
                    letraEncontrada = true;
                }
            }

            if (letraEncontrada)
            {

                bool todasLetrasIdentificadas = true;
                for (int i = 0; i < letrasIdentificadas.Length; i++)
                {
                    string letraAtual = letrasIdentificadas[i];
                    if (letraAtual == null)
                    {
                        todasLetrasIdentificadas = false;
                    }
                }

                if (todasLetrasIdentificadas)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Parabens, {namePlayer2} voce adivinhou a palavra: " + palavraEscolhida);
                    Console.WriteLine();
                    Console.WriteLine($"Reinicie o sistema e agora desafie o {namePlayer1} a acertar sua palavra");
                    JogoAndamento = false;
                }
            }
            else
            {
                // jogador errou a letra
                quantityErrors++;

                Console.WriteLine();
                Console.WriteLine("A letra (" + letraEscolhida + (") nao esta correta"));
                Console.WriteLine();
                Console.WriteLine("Aperte qualquer tecla para prosseguir");
                Console.ReadKey();
            }
        } while (JogoAndamento);
    }

    static void TeamColor(string time)
    {
        Console.ResetColor();

        switch (time)
        {
            case "Corinthians":
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                break;

            case "CAP":
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;
                break;

            case "Coxa":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.White;
                break;
        }
    }
}

//palavras com acentos letras
//essa letra ja foi - mostrar letras q ja foram
//comentar codigo




//                          +    *                          
//                         =*     *                         
//                          *     *                         
//                           ****                           
//      ***                 ******.                =***     
//    ******=            +************            +******   
//  +*********           ++++++++++++            *********  
//    +***++***              ***+*             =***+****=   
//      +***=****             --.             +**=+****     
//       :***==+*        =--=+++=+=:-        *+=-****       
//         =**--*    --+**#*#-%#-#@+**+=:    *--+**         
//               - -=**-+#:+:-*-+:*=-:%++++  +              
//               --*#=#%-@*#++===++%=*+==@%++               
//              =+#+:+-%+:          .=++%@#=*-              
//             -**+-+#=     :--***=   :*%+==-%=:            
//            -*===+#%= .----++====+**==:+%=+=#=            
//           ==#+=+#.#%++=#%%-*+--===*#*- =%:+@*=           
//           -%-%-%.  *=*+..+-++###*==+*=  *===%-:          
//          ==@*=**   .-=+*=--=+**+*+--=*. :*==**+          
//         ::==##==    #===*#*=----=##+---  %==+#:::        
//         --+%++%=    :%==-=*#*+=++-=##+=..%*@@#--=        
//          +:@@@#*     =-#*==+**++#*==*%#=-#==*++          
//           -#+@+#:    .=-**==+##*+*@*=-+*@-=-#=:          
//           --*+=*#.    +#=*+-==*%#=-*#=.+###**=           
//   =        ==@@%=#:   .@+   *+--+#+: .*+*=-#=         *  
//  ***        ==%+-=%*.  :-   .:==:   =#+--%*-:       *+*  
//  .*=+*       -=*+@@@@*=:+-      .-+%%%%***-       **=**  
//   *=.=*       --+@@*.#@%*%++***#*+@%:*@#==        *.:**  
//   * -:*        =.-+#%@@%:%--*+-*=-%@%*==          == *   
//      :-*           =-++*#%*+%@+@*+*==     -      ==      
//        -*              ==:==-.*::               ==       
//         -+*                --.               **-+        
//         *+-*               ##               *=-*         
//        +   ==+*           +***            *=-+           
//              +==***     -**++***     ***+==+      -      
//                =====******+.+*******+===+                
//                    *+====-  +***+===+-                   
//                         **+.+***-                        
//                           **+*                           
//                             *                            




//                   +-----======----=                   
//               +--=+#+++%++*=%+-*%#*=--+               
//             --+#=+#*+%*+-#%-%*+%%%#=+++--+            
//          -:-#%%%*-*#=++*#++*%+#%%%=+++%#+=:+          
//         --#+=+#%%+#%#*=========+##++=*++=%#=:         
//       *:++#%=++*%*=-==+#%%%%%%+==--+#*#-#*=#*:+       
//      +:*=#=++*#+-==: :=:+-#-+:-- :==-=#*=*%%#*--      
//     =:*#*-*+*+:+-  .=: =: * .+ .=.  -+-=*+*++#%=-     
//    +:*#+++*#-=*.  :+. :=  +  :-  =-   ++:#-#%%%%-=    
//   #.*-+*%##:+%#: :+   *   +   +.  =- :*%*:#*%%%%#:*   
//   -=*#%#+#-+%%%%##:  -=   +   :=  .#*%%%%*:##+++=*.   
//  #.#*+++#+-%%%%%#*##+#=:::*:::-#+*#**#%%%%+-*+#%=#:+  
//  +-++=++%:#%%%*. : .*%%%#****%%%%= .. -#%%%.#***+*+-  
//  -+=+-*##:%%%#..#%# .%%%* ---%%%= -%%= =%%%-+=*##%*.# 
//  :*%*+*#+-%%%+ -%%%**%%%* ==*%%%. *%%#*#%%%+=**#### % 
//  :*=*#*++-%%%+ -%%%##%%%* =+*%%%. *%%%#%%%%+=++***# % 
//  -+++++**:%%%# .#%#..#%%* #%%%%%= =%%+ =%%%=+#+****.# 
//  =-%*%*+#.#%%%*..:..*%%%%%%%%%%%#- .: -#%%%.#=+=+#+-  
//  #.#=%#+*+-%%%%%****+#=:..*:.:-#+*#**#%%%%+-#=*+*+:+  
//   -=*++#%%:+%%%%##:  -=   +   :+  .**%%%%#:#%##*+*.:  
//   #.#%%%%%#:*%#: :+   +   +   +.  == .*%#:*%%%%%%:+   
//    +:#%%%%%#-=*.  :+. :=  *  :=  =-   =+:#%%%%%%--    
//     =-%%%*+%%+:+=  .=: =: * .+ .=.  -+-=#%=*%%%=:     
//      =:#%*+%%%#=-+=: :=:+-#-+:-- :=+--#%%%=*%%=-      
//       +:*%%%%%%*++--=+*#%%%%%%*++--++*%%%%%%#:=       
//         --#%%%#-#=+++==-=====-=+++*-#+*%%%#=:-        
//          *:=##=#=*:*#*-++*+++*==+#-*:#*+#+:+          
//            ---+++=+#*+====*#++-#:+#%#=+-:+            
//               +--=++*+##-#=*+=*++##+--=               
//                   =----==++====---=                   


//                                                  *.
//                                                ***.
//                                              *****.
//                                            *******.
//                                          ********* 
//      %      %%       %%                *********   
//          -   %    -   %              +********     
//         %%   %   %%   %            =********     %-
//   #     %%   %   %%   %          .********     *%%-
//   %     %%   %   %%             ********-    =%%%%-
//   %     %%#  %   %%:          ********+     %%%%%%-
//   %     %    %   +          *********     %%%%%%%%-
//   %          %+           *********     %%%%%%%%   
//    %%        %   -      *********     %%%%%%%%     
//                       *********     %%%%%%%%=      
//                     *********     %%%%%%%%*        
//                   *********     %%%%%%%%%          
//                 *********     %%%%%%%%%     *      
//               *********     %%%%%%%%%     ***      
//             +********     %%%%%%%%%     *****      
//           -********     #%%%%%%%%     *******      
//          ********.    +%%%%%%%%     *********      
//        ********=    :%%%%%%%%     *********        
//      *********     %%%%%%%%     *********          
//    *********     %%%%%%%%     *********            
//   ********     %%%%%%%%     *********              
//   ******     %%%%%%%%:    =********                
//   ****     %%%%%%%%+    .********     %%           
//   **     %%%%%%%%#     ********     %%%%           
//        %%%%%%%%%     ********     %%%%%%           
//      %%%%%%%%%     ********     #%%%%%%%           
//    %%%%%%%%%     ********     *%%%%%%%%            
//     .%%%%%     ********-    -%%%%%%%%              
//       =%     ********+     %%%%%%%%=               
//            *********     %%%%%%%%*                 
//           ********     %%%%%%%%%                   
//             ****     %%%%%%%%%                     
//                    %%%%%%%%%                       
//                  %%%%%%%%%                         
//                   %%%%%%                           
//                     %%                             

