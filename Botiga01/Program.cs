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

                        AfegirProducte(productesBotiga, preusProductes,ref nProductes);
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\n\n\t       RECUPERAR USUARI\n");
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
                        //Console.WriteLine("\n\n\t        ORDENAR AGENDA\n");
                        //Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("\n\tAgenda ordenada correctament!");
                        //Console.ForegroundColor = ConsoleColor.White;
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
        static void AfegirProducte(string[] productesBotiga, double[] preusProductes,ref int nProductes)
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
        static string RecuperarUsuari(string FITXER_USUARIS)
        {
            Console.Write("\n\t  Nom de l'usuari: ");
            string nomRecuperar = Console.ReadLine();

            StreamReader arxiuR = new StreamReader(FITXER_USUARIS);
            string linia = arxiuR.ReadLine();

            bool usuariTrobat = false;

            while (linia != null && usuariTrobat == false)
            {
                if (nomRecuperar == linia.Substring(0, linia.IndexOf(";")))
                {
                    usuariTrobat = true;
                    MostrarDades(linia);
                }
                linia = arxiuR.ReadLine();
            }

            if (!usuariTrobat)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"\n      No existeix cap usuari '{nomRecuperar}'.");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\tTornar a provar? (s/n): ");
                string resposta = Console.ReadLine();

                while (resposta != "n" && resposta != "s")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("\n\t     Opció no vàlida.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\tTornar a provar? (s/n): ");
                    resposta = Console.ReadLine();
                }
                if (resposta == "s")
                {
                    RecuperarUsuari(FITXER_USUARIS);
                }
            }
            arxiuR.Close();
            return linia;
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
        //Opció 3:
        //static void ModificarUsuari(string FITXER_USUARIS)
        //{
        //    string liniaUsuariModificar = RecuperarUsuari(FITXER_USUARIS);

        //    Console.Write("\n  Dada a modificar ('q' per sortir): ");
        //    string dadaModificar = Console.ReadLine().ToLower();

        //    //Si la línia és diferent de la que volem eliminar l'escriu a l'arxiu temporal. En canvi, si és igual, la guarda i la modifica.
        //    using (var arxiuR = new StreamReader(FITXER_USUARIS))
        //    using (var arxiuW = new StreamWriter("arxiuTemp.txt"))
        //    {
        //        string linia = arxiuR.ReadLine();

        //        while (linia != null)
        //        {
        //            if (linia == liniaUsuariModificar)
        //            {
        //                Console.Write($"\n\t     Nou '{dadaModificar}': ");
        //                switch (dadaModificar)
        //                {
        //                    case "nom":
        //                        string nouNom = ValidarNomCognom(Console.ReadLine());

        //                        linia = linia.Replace(linia.Substring(0, linia.IndexOf(";")), nouNom);
        //                        break;
        //                    case "cognom":
        //                        string nouCognom = ValidarNomCognom(Console.ReadLine());

        //                        int iniciCognom = linia.IndexOf(";") + 1;
        //                        int finalCognom = linia.IndexOf(";", iniciCognom);
        //                        string cognom = linia.Substring(iniciCognom, finalCognom - iniciCognom);
        //                        linia = linia.Replace(cognom, nouCognom);
        //                        break;
        //                    case "dni":
        //                        string nouDni = ValidarDNI(Console.ReadLine());

        //                        int iniciDNI = linia.IndexOf(";", linia.IndexOf(";") + 1) + 1;
        //                        int finalDNI = linia.IndexOf(";", iniciDNI);
        //                        string dni = linia.Substring(iniciDNI, finalDNI - iniciDNI);
        //                        linia = linia.Replace(dni, nouDni);
        //                        break;
        //                    case "telefon":
        //                        string nouTelefon = ValidarTelefon(Console.ReadLine());

        //                        int iniciTelefon = linia.LastIndexOf(";") + 1;
        //                        int longitudTelefon = linia.Length - iniciTelefon;
        //                        string telefon = linia.Substring(iniciTelefon, longitudTelefon);
        //                        linia = linia.Replace(telefon, nouTelefon);
        //                        break;
        //                    case "data":
        //                        string nouData = Console.ReadLine();
        //                        DateTime dataN;

        //                        while (!DateTime.TryParse(nouData, out dataN))
        //                        {
        //                            Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("Data no vàlida!");
        //                            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Torna a provar: ");
        //                            nouData = Console.ReadLine();
        //                        }
        //                        //Convertirm la data en format (dd/mm/aaaa).
        //                        nouData = dataN.ToString("d");

        //                        string data = linia.Substring(linia.LastIndexOf(";") + 1);
        //                        linia = linia.Replace(data, nouData);
        //                        break;
        //                    case "correu":
        //                        string nouCorreu = ValidarCorreu(Console.ReadLine());

        //                        int finalCorreu = linia.LastIndexOf(";");
        //                        int iniciCorreu = linia.LastIndexOf(";", finalCorreu - 1) + 1;
        //                        string correu = linia.Substring(iniciCorreu, finalCorreu - iniciCorreu);
        //                        linia = linia.Replace(correu, nouCorreu);
        //                        break;
        //                    case "q":
        //                        Menu();
        //                        break;
        //                    default:
        //                        Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("Dada no vàlida!");
        //                        Console.ForegroundColor = ConsoleColor.White;
        //                        break;
        //                }
        //                arxiuW.WriteLine(linia);
        //            }
        //            else
        //                arxiuW.WriteLine(linia);
        //            linia = arxiuR.ReadLine();
        //        }
        //    }
        //    //Elimina l'arxiu original.
        //    File.Delete(FITXER_USUARIS);

        //    //Mou l'arxiu amb l'usuari esborrat a un arxiu igual que l'original.
        //    File.Move("arxiuTemp.txt", FITXER_USUARIS);
        //}
        //Opció 4:
        static void EliminarUsuari(string FITXER_USUARIS)
        {
            string liniaEliminar = RecuperarUsuari(FITXER_USUARIS);

            //Si la línia és diferent de la que volem eliminar l'escriu a l'arxiu temporal. En canvi, si és igual, no l'escriu, i per tant l'esborra.
            using (var arxiuR = new StreamReader(FITXER_USUARIS))
            using (var arxiuW = new StreamWriter("arxiuTemp.txt"))
            {
                string linia;

                while ((linia = arxiuR.ReadLine()) != null)
                {
                    if (linia != liniaEliminar)
                    {
                        arxiuW.WriteLine(linia);
                    }
                }
            }
            //Elimina l'arxiu original.
            File.Delete(FITXER_USUARIS);

            //Mou l'arxiu amb l'usuari esborrat a un arxiu igual que l'original.
            File.Move("arxiuTemp.txt", FITXER_USUARIS);

        }
        //Opció 5:
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

        static void Mostrar()
        {

        }
        //Validacions de dades
        }
}