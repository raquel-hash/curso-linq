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
Console.WriteLine($"Algun libro publicado en 2005?: {queries.AlgunLibroPublicado2005()}");

void PrintValues(IEnumerable<Book> ListBooks)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. Paginas", "Fecha de Publicacion");
    foreach (var book in ListBooks)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
}
