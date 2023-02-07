namespace Botiga01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(44, 28);

            string opcio;
            string[] productesBotiga = new string[10];
            double[] preusProdutes = new double[10];
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

                        AfegirProducte(productesBotiga, preusProductes, ref nProductes);
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\n\n\t       MOSTRAR PRODUCTES\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\n\n\t       MODIFICAR USUARI\n");
                        Console.ForegroundColor = ConsoleColor.White;
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
        static void AfegirProducte(string[] productesBotiga, double[] preusProductes, ref int nProductes)
        {
            if (nProductes > productesBotiga.Length)
            {
                Console.WriteLine("NAO NAO");
                Menu();
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
        static void MostrarProductes(string[] productesBotiga, double[] preusProductes, int nProductes)
        {
            for (int i = 0; i < nProductes; i++)
            {
                Console.WriteLine(productesBotiga[i] + " - " + preusProductes[i] + "$");
            }
        }
        static void MostrarDades(string linia)
        {
            //Nom
            string nom = linia.Substring(0, linia.IndexOf(";"));
            Console.WriteLine("\n     Nom: " + nom);
            linia = linia.Substring(linia.IndexOf(";") + 1);

            //Cognom
            string cognom = linia.Substring(0, linia.IndexOf(";"));
            Console.WriteLine("     Cognom: " + cognom);
            linia = linia.Substring(linia.IndexOf(";") + 1);

            //DNI
            string dni = linia.Substring(0, linia.IndexOf(";"));
            Console.WriteLine("     DNI: " + dni);
            linia = linia.Substring(linia.IndexOf(";") + 1);

            //Telefon
            string telefon = linia.Substring(0, linia.IndexOf(";"));
            Console.WriteLine("     Telèfon: " + telefon);
            linia = linia.Substring(linia.IndexOf(";") + 1);

            //dataNaixement
            string dataNaixement = linia.Substring(0, linia.IndexOf(";"));
            Console.WriteLine("     Data de naixement: " + dataNaixement);
            linia = linia.Substring(linia.IndexOf(";") + 1);

            //Correu
            Console.WriteLine("     Correu: " + linia);
        }

        static void MostrarAgenda(string FITXER_USUARIS)
        {
            OrdenarAgenda(FITXER_USUARIS);

            using (var arxiuR = new StreamReader(FITXER_USUARIS))
            {
                string linia;

                while ((linia = arxiuR.ReadLine()) != null)
                {
                    //Nom
                    string nom = linia.Substring(0, linia.IndexOf(";"));
                    linia = linia.Substring(linia.IndexOf(";") + 1);

                    //Cognom
                    string cognom = linia.Substring(0, linia.IndexOf(";"));
                    linia = linia.Substring(linia.IndexOf(";") + 1);

                    //Telefon
                    string telefon = linia.Substring(linia.IndexOf(";") + 1).Substring(0, linia.IndexOf(";"));

                    Console.WriteLine($"\n  Nom: {nom} {cognom} - Telèfon: {telefon}");
                }
            }
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
        //Validacions de dades
    }
}
