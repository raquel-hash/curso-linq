public class LinqQueries
{
    private List<Book> librosCollections = new List<Book>();
    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollections = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }

    public IEnumerable<Book> getAll()
    {
        return librosCollections;
    }

    public IEnumerable<Book> LibrosDespues2000()
    {
        //extension method
        // return librosCollections.Where(p => p.PublishedDate.Year > 2000);

        //query expresion
        return from l in librosCollections where l.PublishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> LibrosMas250PagConPalabrasInAction()
    {
        //extension method
        // return librosCollections.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));
        //query expresion
        return from l in librosCollections where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

    public bool TodosLibrosTienenStatus()
    {
        return librosCollections.All(p => p.Status != string.Empty);
    }

    public bool AlgunLibroPublicado2005()
    {
        return librosCollections.Any(p => p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> LibrosPython()
    {
        return librosCollections.Where(p => p.Categories.Contains("Python"));
    }

    public IEnumerable<Book> LibrosJavaOrdenarPorNombre()
    {
        return librosCollections.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
    }

    public IEnumerable<Book> LibrosMasPag450OrdenarNumPagDesc()
    {
        return librosCollections.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
    }

    public IEnumerable<Book> LibrosJavaPublciacionRecientemente()
    {
        return librosCollections
        .Where(p => p.Categories.Contains("Java"))
        .OrderByDescending(p => p.PublishedDate)
        .Take(3);
    }
    public IEnumerable<Book> TecerCuartoLibroMas400Pag()
    {
        return librosCollections.Where(p => p.PageCount > 400)
        .Take(4)
        .Skip(2);
    }

    public IEnumerable<Book> TresPrimerosLibrosColeccion()
    {
        return librosCollections.Take(3)
        .Select(p => new Book()
        {
            Title = p.Title,
            PageCount = p.PageCount
        });
    }

    public long NumeroLibrosPag200A500Pag()
    {
        // return librosCollections.Where(p => p.PageCount >= 200 && p.PageCount <= 500).LongCount();//Mala Practica
        return librosCollections.Count(p => p.PageCount >= 200 && p.PageCount <= 500);
    }

    public DateTime FechaPublicacionMenor()
    {
        return librosCollections.Min(p => p.PublishedDate);
    }

    public int LibroMasPag()
    {
        return librosCollections.Max(p => p.PageCount);
    }

    public Book LibroMenorNumPag()
    {
        return librosCollections.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
    }

    public Book LibroFechaPublicacionReciente()
    {
        return librosCollections.MaxBy(p => p.PublishedDate);
    }

    public int SumaPag0A500()
    {
        return librosCollections.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);
    }

    public string TitulosFechaPublicMayor2015()
    {
        return librosCollections.Where(p => p.PublishedDate.Year > 2015)
        .Aggregate("", (TitulosLibros, next) =>
        {
            if (TitulosLibros != string.Empty)
                TitulosLibros += " - " + next.Title;
            else
                TitulosLibros += next.Title;

            return TitulosLibros;
        });
    }

    public double PromedioCaracteresTitulo()
    {
        return librosCollections.Average(p => p.Title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> LibrosDespues2000AgrupadosPorAnio()
    {
        return librosCollections.Where(p => p.PublishedDate.Year >= 2000)
        .GroupBy(p => p.PublishedDate.Year);
    }

    public ILookup<char, Book> DiccionarioLibrosPorLetra()
    {
        return librosCollections.ToLookup(p => p.Title[0], p => p);
    }
}
