// See https://aka.ms/new-console-template for more information
class Dvd : Document
{
    public int Time { get; set; }

    public Dvd(int time, string code, string title, int year, string sector, bool avaible, string position, string author) : base(code, title, year, sector, avaible, position, author)
    {
        Time = time;
    }

    public Dvd SearchForName(Dvd[] dvds)
    {
    SearchForName:
        Console.WriteLine("Inserisci il nome del Dvd da ricercare");
        string input = Console.ReadLine();

        foreach (Dvd dvd in dvds)
        {

            if (input.ToLower() == dvd.Title.ToLower())
            {
                Dvd d = dvd;
                return d;
            }
            Console.WriteLine("Nome non valido riprova");
        }
        goto SearchForName;
    }

}