namespace BibliotecaApp
{
    public class BibliotecaConsole
    {
        private static Biblioteca biblioteca = new Biblioteca();

        public static bool Run()
        {
            int option = IndexLoop();
            switch (option)
            {
                case 1: // Add book
                    return AddBookLoop();
                    break;
                case 2: // Register user
                    return RegisterUserLoop();
                    break;
                case 3: // Lend book
                    return LendBookLoop();
                    break;
                case 4: // Return book
                    return ReturnBookLoop();
                    break;
                case 5: // See books state
                    return SeeBooksStateLoop();
                    break;
                case 6: // See lent book to a user
                    return SeeLentBooksOfUserLoop();
                    break;
                case 7: // quit
                    return false;
                    break;
            }
            return false;
        }
        private static int IndexLoop()
        {
            int input = -1;
            while (input < 1 || input > 7)
            {
                Console.WriteLine("\nBienvenido a la Biblioteca");
                Console.WriteLine("1. Agregar Libro");
                Console.WriteLine("2. Registrar Usuario");
                Console.WriteLine("3. Prestar Libro");
                Console.WriteLine("4. Devolver Libro");
                Console.WriteLine("5. Ver estado de todos los libros");
                Console.WriteLine("6. Ver libros prestados de un usuario");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");
                // Try to get input
                input = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            return input;
        }
        private static bool AddBookLoop()
        {
            string titulo, autor, isbn;
            while (true)
            {

                Console.Write("Ingrese el titulo del libro: ");
                titulo = Console.ReadLine();
                if (titulo == "")
                {
                    Console.WriteLine("El titulo no puede estar vacio");
                    continue;
                }
                titulo = titulo.Trim();
                break;
            }
            while (true)
            {
                Console.Write("Ingrese el autor del libro: ");
                autor = Console.ReadLine();
                if (autor == "")
                {
                    Console.WriteLine("El autor no puede estar vacio");
                    continue;
                }
                autor = autor.Trim();
                break;
            }
            while (true)
            {
                Console.Write("Ingrese el ISBN (solo numeros) del libro: ");
                isbn = Console.ReadLine();
                if (isbn == "")
                {
                    Console.WriteLine("El ISBN no puede estar vacio");
                    continue;
                }
                if (isbn.All(char.IsDigit) == false)
                {
                    Console.WriteLine("El ISBN debe ser un número");
                    continue;
                }
                isbn = isbn.Trim();
                break;
            }
            Console.WriteLine();
            bool added = biblioteca.AddBook(titulo, autor, isbn);
            if (added)
            {
                Console.WriteLine("Libro agregado exitosamente");

            }
            else
            {
                Console.WriteLine("Error al agregar el libro, intente nuevamente");
            }
            return added;
        }
        private static bool RegisterUserLoop()
        {
            string nombre = "";
            int id = -1;
            while (true)
            {
                Console.Write("Ingrese el nombre del usuario: ");
                nombre = Console.ReadLine();
                if (nombre == "")
                {
                    Console.WriteLine("El titulo no puede estar vacio");
                    continue;
                }
                nombre = nombre.Trim();
                break;
            }
            while (true)
            {
                Console.Write("Ingrese el id del usuario: ");
                id = int.Parse(Console.ReadLine());
                if (id < 0)
                {
                    Console.WriteLine("El id debe ser positivo");
                    continue;
                }
                break;
            }
            Console.WriteLine();
            bool added = biblioteca.RegisterUser(id, nombre);
            if (added)
            {
                Console.WriteLine("Usuario agregado exitosamente");

            }
            else
            {
                Console.WriteLine("Error al agregar el usuario, intente nuevamente");
            }
            return added;
        }
        private static bool LendBookLoop()
        {
            string isbn = "";
            int userId = -1;
            while (true)
            {
                Console.Write("Ingrese el ISBN del libro a prestar: ");
                isbn = Console.ReadLine();
                if (isbn == "")
                {
                    Console.WriteLine("El ISBN no puede estar vacio");
                    continue;
                }
                if (isbn.All(char.IsDigit) == false)
                {
                    Console.WriteLine("El ISBN debe ser un número");
                    continue;
                }
                isbn = isbn.Trim();
                break;
            }
            while (true)
            {
                Console.Write("Ingrese el id del usuario a prestar: ");
                userId = int.Parse(Console.ReadLine());
                if (userId < 0)
                {
                    Console.WriteLine("El id debe ser positivo");
                    continue;
                }
                break;
            }
            Console.WriteLine();
            bool added = biblioteca.LendBook(userId, isbn);
            if (added)
            {
                Console.WriteLine($"Libro {isbn} prestado al usuario {userId}");

            }
            else
            {
                Console.WriteLine("Error al agregar al prestar el libro, intente nuevamente");
            }
            return added;
        }
        private static bool ReturnBookLoop()
        {
            string isbn = "";
            int userId = -1;
            while (true)
            {
                Console.Write("Ingrese el ISBN del libro a devolver: ");
                isbn = Console.ReadLine();
                if (isbn == "")
                {
                    Console.WriteLine("El ISBN no puede estar vacio");
                    continue;
                }
                if (isbn.All(char.IsDigit) == false)
                {
                    Console.WriteLine("El ISBN debe ser un número");
                    continue;
                }
                isbn = isbn.Trim();
                break;
            }
            while (true)
            {
                Console.Write("Ingrese el id del usuario que devuelve: ");
                userId = int.Parse(Console.ReadLine());
                if (userId < 0)
                {
                    Console.WriteLine("El id debe ser positivo");
                    continue;
                }
                break;
            }
            Console.WriteLine();
            bool added = biblioteca.ReturnBook(userId, isbn);
            if (added)
            {
                Console.WriteLine($"Libro {isbn} devuelto por el usuario {userId}");

            }
            else
            {
                Console.WriteLine("Error al agregar al prestar el libro, intente nuevamente");
            }
            return added;
        }
        private static bool SeeBooksStateLoop()
        {
            string state = biblioteca.GetBooksState();
            Console.WriteLine(state);
            Console.WriteLine();
            return true;
        }

        private static bool SeeLentBooksOfUserLoop()
        {
            int userId;
            while (true)
            {
                Console.Write("Ingrese el id del usuario: ");
                userId = int.Parse(Console.ReadLine());
                if (userId < 0)
                {
                    Console.WriteLine("El id debe ser positivo");
                    continue;
                }

                break;
            }
            Console.WriteLine();
            biblioteca.GetLentBooksOfUser(userId);

            return true;
        }

    }
}
