// See https://aka.ms/new-console-template for more information
class Book : Document
{
    public int TotalPages { get; set; }

    public Book(int totalPages, string code, string title, int year, string sector, bool avaible, string position, string author) : base(code, title, year, sector, avaible, position, author)
    {
        TotalPages = totalPages;
    }


}