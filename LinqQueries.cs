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

    public IEnumerable<Book> LibrosPython() {
        return librosCollections.Where(p => p.Categories.Contains("Python"));
    }
}
