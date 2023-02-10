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
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\n\n\t       MODIFICAR PRODUCTE\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        ModificarProducte(ref productesBotiga);
                        break;
                    case "5":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\n\n\t        ORDENAR PRODUCTES\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        OrdenarProductes(ref productesBotiga, ref preusProductes, ref nProductes);
                        break;
                    case "6":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\n\n\t        ORDENAR PREUS\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("\n\tPreus ordenats correctament!");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("Preus ordenats:");
                        OrdenaPreus(preusProductes, nProductes);
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
                //Crida al mètode 'BarraDeCarrega' per obrir la barra de càrrega que s'executará després de finalitzar una opció.
                BarraDeCarrega();

                //Tornar al menú.
                Menu();
                opcio = Console.ReadLine();
                Console.Clear();
            }
        }
        static void BarraDeCarrega()
        {
            Console.Title = "Agenda Alumnes";
            Console.WriteLine("\n\n\t      Carregant menú...");

            for (int a = 1; a < 13; a++)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("        ");
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
        static void ModificarProducte(ref string[] productesBotiga)
        {
            Console.WriteLine("Nom del producte a modificar: ");
            string producteModificar = Console.ReadLine();

            for (int i = 0; i < productesBotiga.Length; i++)
            {
                if (productesBotiga[i] == producteModificar)
                {
                    Console.WriteLine("Nou nom: ");
                    string nouNom = Console.ReadLine();
                    productesBotiga[i] = nouNom;

                    Console.WriteLine($"S'ha modificat el nom de {producteModificar} a {nouNom}.");
                }
            }
        }
        //Opció 5:
        public static void OrdenarProductes(ref string[] productesBotiga, ref double[] preusProductes, ref int nProductes)
        {
            string aux;
            double aux2;

            for (int i = 1; i < nProductes; i++)
            {
                for (int j = 0; j < nProductes - i; j++)
                {
                    if (productesBotiga[j].CompareTo(productesBotiga[j + 1]) > 0)
                    {
                        aux = productesBotiga[j];
                        aux2 = preusProductes[j];
                        preusProductes[j] = preusProductes[j + 1];
                        productesBotiga[j] = productesBotiga[j + 1];
                        productesBotiga[j + 1] = aux;
                        preusProductes[j + 1] = aux2;
                    }
                }
            }
            Console.WriteLine("\nProductes ordenats:\n");

            for (int i = 0; i < productesBotiga.Length; i++)
            {
                Console.WriteLine($"Nom: {productesBotiga[i]}\tPreu: {preusProductes[i]}$");
            }
        }
        //Opció 6:
        static void OrdenaPreus(double[] preusProductes, int nProductes)
        {
            int menor;
            for (int numVolta = 0; numVolta < nProductes - 1; numVolta++)
            {
                menor = numVolta;

                for (int i = numVolta + 1; i < nProductes; i++)
                {
                    if (preusProductes[menor] > preusProductes[i])
                    {
                        menor = i;
                    }
                }
                if (menor != numVolta)
                {
                    double aux = preusProductes[menor];
                    preusProductes[menor] = preusProductes[numVolta];
                    preusProductes[numVolta] = aux;
                }
            }
            for (int i = 0; i < nProductes; i++)
            {
                Console.WriteLine("\t· " + preusProductes[i]);
            }
        }
        //Opció 7:
        static void MostrarProductes(string[] productesBotiga, double[] preusProductes, int nProductes)
        {
            for (int i = 0; i < nProductes; i++)
            {
                Console.WriteLine("Nom producte: " + productesBotiga[i]);
                Console.WriteLine("Preu producte: " + preusProductes[i] + "$" + "\n");
            }
            Console.WriteLine("Productes totals: " + nProductes);
            Console.WriteLine("Encara podem afegir: " + (preusProductes.Length - nProductes) + " productes.");
        }
    }
}


