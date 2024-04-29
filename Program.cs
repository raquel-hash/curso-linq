// See https://aka.ms/new-console-template for more information
LinqQueries queries = new LinqQueries();
PrintValues(queries.getAll());


void PrintValues(IEnumerable<Book> ListBooks)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. Paginas", "Fecha de Publicacion");
    foreach (var book in ListBooks)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
}
