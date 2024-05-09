// See https://aka.ms/new-console-template for more information
LinqQueries queries = new LinqQueries();
//toda la coleccion
// PrintValues(queries.getAll());

//libros despues del 200
// PrintValues(queries.LibrosDespues2000());

//libros que tienen mas 250 pag y tienen en el titulo la palabra "In Action"
// PrintValues(queries.LibrosMas250PagConPalabrasInAction());

//Todos los libros tienen status ?
// Console.WriteLine($"Todos los libros tienen status ?: {queries.TodosLibrosTienenStatus()}");

//Algun libro publicado en 2005?
// Console.WriteLine($"Algun libro publicado en 2005?: {queries.AlgunLibroPublicado2005()}");
//Libros de python
// PrintValues(queries.LibrosPython());

//Libros de Java ordenados por Nombre
// PrintValues(queries.LibrosJavaOrdenarPorNombre());

//Libros con mas 450 paginas y ordenados descendente por num de pagina
// PrintValues(queries.LibrosMasPag450OrdenarNumPagDesc());
// 3 libros de java publicados recientemente
// PrintValues(queries.LibrosJavaPublciacionRecientemente());

//Tercer y cuarto libro con mas de 400 pag
// PrintValues(queries.TecerCuartoLibroMas400Pag());
//Tres primeros libros filtrados con select
// PrintValues(queries.TresPrimerosLibrosColeccion());

//Numero de libros que tienen entre 200 a 500 paginas
// Console.WriteLine($"Cantidad de libros que tienen entre 200 a 500 paginas: {queries.NumeroLibrosPag200A500Pag()}");

//Fecha de publicacion minimo
// Console.WriteLine($"Fecha de publicacion minimo: {queries.FechaPublicacionMenor()}");

//Libro con mas paginas
// Console.WriteLine($"Libro con mas paginas: {queries.LibroMasPag()} paginas");

//Libro con menor numero de paginas
// var libroMenorPag = queries.LibroMenorNumPag();
// Console.WriteLine($"{libroMenorPag.Title} - {libroMenorPag.PageCount}");

//Libro con fecha de publicacion reciente
// var libroPublicacionReciente = queries.LibroFechaPublicacionReciente();
// Console.WriteLine($"{libroPublicacionReciente.Title} - {libroPublicacionReciente.PublishedDate}");

//Suma de paginas de libros entre 0 a 500
// Console.WriteLine($"Suma total de paginas: {queries.SumaPag0A500()} paginas");

//Titulos de libros con fecha de publicacion mayor a 2015
// Console.WriteLine($"Titulos de libros con fecha de publicacion mayor a 2015: {queries.TitulosFechaPublicMayor2015()}");

//Promedio de caracteres del titulo de los libros
// Console.WriteLine($"Promedio de caracteres titulo: {queries.PromedioCaracteresTitulo()}");

//Libros publicadoos a partir del 2000 agrupados por anio
// PrintGroup(queries.LibrosDespues2000AgrupadosPorAnio());

//Diccionario de libros por letra
var diccionarioLookup = queries.DiccionarioLibrosPorLetra();
printDictionary(diccionarioLookup, 'S');

void PrintValues(IEnumerable<Book> ListBooks)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. Paginas", "Fecha de Publicacion");
    foreach (var book in ListBooks)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
}

void PrintGroup(IEnumerable<IGrouping<int, Book>> ListadeLibros)
{
    foreach (var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
        }
    }
}

void printDictionary(ILookup<char, Book> listBooks, char letter)
{
    char letterUpper = Char.ToUpper(letter);
    if (listBooks[letterUpper].Count() == 0)
    {
        Console.WriteLine($"No hay libros que inicien con la letra '{letterUpper}'");
    }
    else
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Título", "Nro. Páginas", "Fecha de Publicación");
        foreach (var book in listBooks[letterUpper])
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
        }
    }
}
