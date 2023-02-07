namespace Botiga01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(44, 28);

            string opcio;
            string[] productesBotiga = new string[2];
            double[] preusProdutes = new double[2];
            int nProductes = 0;

            Menu();

            opcio = Console.ReadLine().ToLower();

            //Neteja la pantalla.
            Console.Clear();

            SwitchOpcio(opcio, productesBotiga, preusProdutes, nProductes);
        }
        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\n\n\n\t\tBOTIGA ALUMNES");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\t1. AFEGIR PRODUCTE.\n\t2. AMPLIAR BOTIGA.\n\t3. MODIFICAR PREU.\n\t4. MODIFICAR PRODUCTE.\n\t5. ORDENAR PRODUCTE.\n\t6. ORDENAR PREUS.\n\t7. MOSTRAR PRODUCTES\n\n\t'Q'. Exit!.");
            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write("\n\n   Introdueix l'opció a realitzar: ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void SwitchOpcio(string opcio, string[] productesBotiga, double[] preusProductes, int nProductes)
        {
            while (opcio != "q")
            {
                switch (opcio)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\n\n\t    AFEGIR PRODUCTE\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        AfegirProducte(ref productesBotiga, ref preusProductes, ref nProductes);
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\n\n\t       AMPLIAR BOTIGA\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        AmpliarBotiga(ref productesBotiga, ref preusProductes);
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\n\n\t       MODIFICAR PREU\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        ModificarPreu(ref productesBotiga, ref preusProductes);
                        break;
                    case "4":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\n\n\t       ELIMINAR USUARI\n");
                        break;
                    case "5":
                        Console.WriteLine("\n\n\t       MOSTRAR AGENDA\n");
                        break;
                    case "6":
                        Console.WriteLine("\n\n\t        ORDENAR AGENDA\n");
                        Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("\n\tAgenda ordenada correctament!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "7":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\n\n\t       MOSTRAR PRODUCTES\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        MostrarProductes(productesBotiga, preusProductes, nProductes);
                        break;
                    case "q":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("\n\n\t Aquesta opció no és vàlida!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                //Crida al mètode 'BarraDeCarrega' per obrir la barra de càrrega que s'executará després de resoldre un problema.
                BarraDeCarrega();

                //Tornar al menú
                Menu();
                opcio = Console.ReadLine();
                Console.Clear();
            }
        }
        static void BarraDeCarrega()
        {
            Console.Title = "Agenda Alumnes";
            Console.WriteLine("\n\n\t      Carregant menú...");

            for (int a = 1; a < 20; a++)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("     ");
                Thread.Sleep(400);
                a++;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            //Mostra un missatge després de carregar el menú per continuar i pasar de pantalla.
            Console.WriteLine("\n    Prem qualsevol tecla per contiuar...");
            Console.ReadKey(true);
            Console.Clear();
        }
        //Opció 1:
        static void AfegirProducte(ref string[] productesBotiga, ref double[] preusProductes, ref int nProductes)
        {
            if (nProductes >= productesBotiga.Length)
            {
                Console.WriteLine("La mida de la botiga permet " + productesBotiga.Length + " productes.");
                Console.Write("Vols ampliar la botiga? (s/n) ");
                char respostaAmpliarBotiga = Convert.ToChar(Console.ReadLine());

                if (respostaAmpliarBotiga == 's' || respostaAmpliarBotiga == 'S')
                {
                    AmpliarBotiga(ref productesBotiga, ref preusProductes);
                    Console.Clear();
                    Menu();
                }
                else if (respostaAmpliarBotiga == 'n' || respostaAmpliarBotiga == 'N')
                {
                    Thread.Sleep(1000);
                    Console.Clear();
                    Menu();
                }
                else
                    Console.WriteLine("Resposta no vàlida!");
            }
            else
            {
                Console.Write("Nom del producte: ");
                string producteAfegir = Console.ReadLine();
                productesBotiga[nProductes] = producteAfegir;
                Console.WriteLine();

                Console.Write("Preu del producte: ");
                double preuProducteAfegir = Convert.ToDouble(Console.ReadLine());
                preusProductes[nProductes] = preuProducteAfegir;

                nProductes++;
            }
        }
        //Opció 2:
        static void AmpliarBotiga(ref string[] productesBotiga, ref double[] preusProductes)
        {
            Console.WriteLine("Mida actual de la botiga: " + productesBotiga.Length + " productes");
            Console.Write("Ingresa la nova mida: ");
            int nouSizeBotiga = Convert.ToInt32(Console.ReadLine());

            Array.Resize(ref productesBotiga, nouSizeBotiga);
            Array.Resize(ref preusProductes, nouSizeBotiga);

            Console.WriteLine("Nova mida de la botiga: " + productesBotiga.Length + " productes.");
        }
        //Opció 3:
        static void ModificarPreu(ref string[] productesBotiga, ref double[] preusProductes)
        {
            Console.WriteLine("Nom del producte per modificar el preu: ");
            string producteModificar = Console.ReadLine();

            for (int i = 0; i < productesBotiga.Length; i++)
            {
                if (productesBotiga[i] == producteModificar)
                {
                    Console.WriteLine("Nou preu: ");
                    double nouPreu = Convert.ToDouble(Console.ReadLine());
                    preusProductes[i] = nouPreu;

                    Console.WriteLine($"S'ha modificat el preu de {producteModificar} a {nouPreu}$.");
                }
            }
        }
        //Opció 4:
        static void ModificarProduce(ref string[] productesBotiga, ref double[] preusProductes)
        {

        }
        static void MostrarProductes(string[] productesBotiga, double[] preusProductes, int nProductes)
        {
            for (int i = 0; i < nProductes; i++)
            {
                Console.WriteLine("Nom producte:" + productesBotiga[i]);
                Console.WriteLine("Preu producte: " + preusProductes[i] + "$" + "\n");
            }
            Console.WriteLine("Productes totals: " + nProductes);
            Console.WriteLine("Encara podem afegir: " + (preusProductes.Length - nProductes) + " productes.");
        }
        //Opció 6:
        static void OrdenarAgenda(string FITXER_USUARIS)
        {
            //Llegeix totes les línies de l'arxiu
            var linies = File.ReadAllLines(FITXER_USUARIS);

            //Ordena les línies alfabèticament
            for (int i = 0; i < linies.Length - 1; i++)
            {
                for (int j = i + 1; j < linies.Length; j++)
                {
                    if (String.Compare(linies[i], linies[j]) > 0)
                    {
                        string k = linies[i];
                        linies[i] = linies[j];
                        linies[j] = k;
                    }
                }
            }
            //Escriu les línies ordenades de tornada a l'arxiu original 'alumnes.txt'.
            File.WriteAllLines(FITXER_USUARIS, linies);
        }
    }
}


