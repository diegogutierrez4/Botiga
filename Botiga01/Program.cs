using System.Xml.Linq;

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
            double cartera = 104.23;
            int espaiCistella = 4;

            Menu();

            opcio = Console.ReadLine().ToLower();

            //Neteja la pantalla.
            Console.Clear();

            SwitchOpcio(opcio, productesBotiga, preusProdutes, nProductes, espaiCistella, cartera);
        }
        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\n\n\n\t\tBOTIGA ALUMNES");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\t1. AFEGIR PRODUCTE.\n\t2. AMPLIAR BOTIGA.\n\t3. MODIFICAR PREU.\n\t4. MODIFICAR PRODUCTE.\n\t5. ORDENAR PRODUCTE.\n\t6. ORDENAR PREUS.\n\t7. MOSTRAR PRODUCTES\n\n\t'C'. CISTELLA\n\t'Q'. Exit!.");
            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write("\n\n   Introdueix l'opció a realitzar: ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void SwitchOpcio(string opcio, string[] productesBotiga, double[] preusProductes, int nProductes, int espaiCistella, double cartera)
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

                        AmpliarBotiga(ref productesBotiga, ref preusProductes, nProductes);
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

                        Console.WriteLine("\nPreus ordenats:\n");
                        OrdenaPreus(preusProductes, nProductes);
                        break;
                    case "7":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\n\n\t       MOSTRAR PRODUCTES\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        MostrarProductes(productesBotiga, preusProductes, nProductes);
                        break;
                    case "c":
                        Cistella(productesBotiga, preusProductes, nProductes, espaiCistella, cartera);
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
                opcio = Console.ReadLine().ToLower();
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
                    AmpliarBotiga(ref productesBotiga, ref preusProductes, nProductes);
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
                producteAfegir = producteAfegir.Substring(0,1).ToUpper() + producteAfegir.Substring(1).ToLower();
                productesBotiga[nProductes] = producteAfegir;
                Console.WriteLine();

                Console.Write("Preu del producte: ");
                double preuProducteAfegir = Convert.ToDouble(Console.ReadLine());
                preusProductes[nProductes] = preuProducteAfegir;

                nProductes++;
            }
        }
        //Opció 2:
        static void AmpliarBotiga(ref string[] productesBotiga, ref double[] preusProductes, int nProductes)
        {
            Console.WriteLine("Mida actual de la botiga: " + productesBotiga.Length + " productes");
            Console.Write("Ingresa la nova mida: ");
            int nouSizeBotiga = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            while (nouSizeBotiga < nProductes)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("Mida inferior a la quantitat de productes.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Ingresa la nova mida: ");
                nouSizeBotiga = Convert.ToInt32(Console.ReadLine());
            }
            Array.Resize(ref productesBotiga, nouSizeBotiga);
            Array.Resize(ref preusProductes, nouSizeBotiga);
            Console.WriteLine("Nova mida de la botiga: " + productesBotiga.Length + " productes.");
        }
        //Opció 3:
        static void ModificarPreu(ref string[] productesBotiga, ref double[] preusProductes)
        {
            Console.Write("Nom del producte a modificar: ");
            string producteModificar = Console.ReadLine();
            producteModificar = producteModificar.Substring(0, 1).ToUpper() + producteModificar.Substring(1).ToLower();

            for (int i = 0; i < productesBotiga.Length; i++)
            {
                if (productesBotiga[i] == producteModificar)
                {
                    Console.Write("Nou preu: ");
                    double nouPreu = Convert.ToDouble(Console.ReadLine());
                    preusProductes[i] = nouPreu;

                    Console.WriteLine($"\nS'ha modificat el preu de '{producteModificar}' a {nouPreu}$.");
                }
            }
        }
        //Opció 4:
        static void ModificarProducte(ref string[] productesBotiga)
        {
            Console.Write("Nom del producte a modificar: ");
            string producteModificar = Console.ReadLine();
            producteModificar = producteModificar.Substring(0, 1).ToUpper() + producteModificar.Substring(1).ToLower();

            for (int i = 0; i < productesBotiga.Length; i++)
            {
                if (productesBotiga[i] == producteModificar)
                {
                    Console.Write("Nou nom: ");
                    string nouNom = Console.ReadLine();
                    productesBotiga[i] = nouNom;

                    Console.WriteLine($"\nS'ha modificat el nom de '{producteModificar}' a {nouNom}.");
                }
            }
        }
        //Opció 5:
        static void OrdenarProductes(ref string[] productesBotiga, ref double[] preusProductes, ref int nProductes)
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

            for (int i = 0; i < nProductes; i++)
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

        //CISTELLA
        static void Cistella(string[] productesBotiga, double[] preusProductes, int nProductes, int espaiCistella, double cartera)
        {
            string[] productesCistella = new string[espaiCistella];
            int[] quantitats = new int[espaiCistella];

            MenuCistella();
            string opcio = Console.ReadLine().ToLower();

            //Neteja la pantalla.
            Console.Clear();

            SwitchOpcioCistella(opcio, productesBotiga, nProductes, preusProductes, espaiCistella, cartera, productesCistella, quantitats);
        }
        static void MenuCistella()
        {
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\n\n\n\t\t   CISTELLA");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\t1. COMPRAR PRODUCTES.\n\t2. ORDENAR CISTELLA.\n\t3. MOSTRAR TICKET.\n\n\t'Q'. Exit!.");
            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write("\n\n   Introdueix l'opció a realitzar: ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void SwitchOpcioCistella(string opcio, string[] productesBotiga, int nProductes, double[] preusProductes, int espaiCistella, double cartera, string[] productesCistella, int[] quantitats)
        {
            while (opcio != "q")
            {
                switch (opcio)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\n\n\t    COMPRAR PRODUCTES");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("\nEspai de la cistella: " + espaiCistella)
                        if(nProductes < 1)
                        {
                            Console.Write("\n      Botiga buida, afegeix productes!");
                            Thread.Sleep(2222);
                            Console.Clear();
                        }
                        else
                            Comprar(productesBotiga, preusProductes, nProductes, ref espaiCistella, ref cartera, productesCistella, quantitats);
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\n\n\t       ORDENAR CISTELLA\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        //PENDENT
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\n\n\t       MOSTRAR TICKET\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        MostrarTicket(productesCistella, quantitats, productesBotiga, preusProductes);
                        break;
                    case "q":
                        Menu();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("\n\n\t Aquesta opció no és vàlida!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                //Crida al mètode 'BarraDeCarrega' per obrir la barra de càrrega que s'executará després de finalitzar una opció.
                BarraDeCarrega();

                //Tornar al menú.
                MenuCistella();
                opcio = Console.ReadLine().ToLower();
                Console.Clear();
            }
        }
        static void SeleccionarProducte(string[] productesBotiga, double[] preusProductes, int nProductes)
        {
            Console.WriteLine("Llistat de productes: " + "\n");
            for (int i = 0; i < nProductes; i++)
            {
                Console.WriteLine(productesBotiga[i] + " -> " + preusProductes[i] + "$");
            }
    }
        static void Comprar(string[] productesBotiga, double[] preusProductes, int nProductes, ref int espaiCistella, ref double cartera, string[] productesCistella, int[] quantitats)
        {
            string sortir = "";
            int nProductesCistella = 0;
            for (int i = 0; sortir != "s"; i++)
            {
                Console.WriteLine("Selecciona un producte de la botiga:\n");

                for (int j = 0; j < nProductes; j++)
                {
                    Console.WriteLine("\t" + (j + 1) + ") " + productesBotiga[j] + " - " + preusProductes[j] + "$");
                }
                Console.Write("\nNº producte: ");
                int opcio = Convert.ToInt32(Console.ReadLine());
                string producteSeleccionat = productesBotiga[opcio - 1];
                double preuSeleccionat = preusProductes[opcio - 1];

                Console.Write($"Quantitat de '{producteSeleccionat}': ");
                int quantitat = Convert.ToInt32(Console.ReadLine());

                if (cartera >= preuSeleccionat * quantitat)
                {
                    if (nProductesCistella + quantitat <= espaiCistella)
                    {
                        productesCistella[i] = producteSeleccionat;
                        quantitats[i] = quantitat;
                        cartera -= preuSeleccionat * quantitat;
                        nProductesCistella += quantitat;
                        Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("       Producte afegit correctament!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("    No hi ha prou espai a la cistella!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("\n\t  No tens prou diners!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("Espai disponible a la cistella: " + (espaiCistella - nProductesCistella));
                Console.WriteLine($"Cartera: {cartera}$");
                Console.Write("Sortir (s/n)? ");
                sortir = Console.ReadLine().ToLower();
                Console.WriteLine();
            }
        }
        static void MostrarTicket(string[] productesCistella, int[] quantitats, string[] productesBotiga, double[] preusProductes)
        {
            Console.WriteLine("Ticket de compra:\n");
            double preuTotal = 0;

            for (int i = 0; i < productesCistella.Length; i++)
            {
                if (productesCistella[i] != null)
                {
                    int index = Array.IndexOf(productesBotiga, productesCistella[i]);
                    double preuUnitari = preusProductes[index];
                    double preu = preuUnitari * quantitats[i];
                    Console.WriteLine("\t" + productesCistella[i] + " - " + quantitats[i] + " x " + preuUnitari + "$ = " + preu + "$");
                    preuTotal += preu;
                }
            }
            Console.WriteLine("\nPreu total: " + preuTotal + "$");
        }
    }
}