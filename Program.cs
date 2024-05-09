﻿// See https://aka.ms/new-console-template for more information
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
Console.WriteLine($"Libro con mas paginas: {queries.LibroMasPag()} paginas");

void PrintValues(IEnumerable<Book> ListBooks)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. Paginas", "Fecha de Publicacion");
    foreach (var book in ListBooks)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
}
