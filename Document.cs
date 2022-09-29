// See https://aka.ms/new-console-template for more information
class Document
{
    public string Code { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public string Sector { get; set; }
    public bool Avaible { get; set; }
    public string Position { get; set; }
    public string Author { get; set; }

    public Document(string code, string title, int year, string sector, bool avaible, string position, string author)
    {
        Code = code;
        Title = title;
        Year = year;
        Sector = sector;
        Avaible = avaible;
        Position = position;
        Author = author;
    }


}