#region CREAZIONE TABELLE
//CREATE TABLE[dbo].[document] (
//[id]  BIGINT PRIMARY KEY  IDENTITY  NOT NULL,
//[code] VARCHAR (255) NOT NULL,
//[title] VARCHAR (255) NOT NULL,
//[year] INT NOT NULL,
//[sector] VARCHAR (50) NOT NULL,
//[available] TINYINT NOT NULL,
//[position] VARCHAR (3) NOT NULL,
//[author] VARCHAR (100) NOT NULL,
//[created_at]   DATETIME      DEFAULT (NULL) NULL,
//[updated_at] DATETIME DEFAULT(NULL) NULL,
//);



//CREATE TABLE[dbo].[rents] (
//    [id]            INT IDENTITY NOT NULL,
//    [start_period]    DATETIME DEFAULT (NULL) NULL,
//    [end_period] DATETIME DEFAULT(NULL) NULL,
//    [user_id] BIGINT NOT NULL,
//    [document_id]  BIGINT   NOT NULL,
//    CONSTRAINT[PK_rents_id] PRIMARY KEY CLUSTERED ([id] ASC),
//    CONSTRAINT[rents$rents_user_id_foreign] FOREIGN KEY([user_id]) REFERENCES[dbo].[users]([id]),
//    CONSTRAINT[rents$rents_document_id_foreign] FOREIGN KEY([document_id]) REFERENCES[dbo].[documents]([id])
//);

//CREATE TABLE[dbo].[dvds] (
//    [document_id] int NOT NULL,

//    [time] INT NOT NULL,
//    [created_at] DATETIME DEFAULT (NULL) NULL,
//    [updated_at] DATETIME DEFAULT(NULL) NULL,
//    PRIMARY KEY CLUSTERED ([id] ASC)
//); 
#endregion
using System.Data.SqlClient;


bool exit = false;

while (!exit)
{
    Console.WriteLine("\n\n");
    ShowMenu();
    int choice = Convert.ToInt32(StringInput("Cosa vuoi fare?"));

    switch (choice)
    {
        case 1:

            string code = StringInput("\nInserisci il codice:");
            string title = StringInput("\nInserisci il titolo:");
            int year = Convert.ToInt32(StringInput("\nInserisci l'anno:"));
            string sector = StringInput("\nInserisci il genere:");
            int available = StringInput("\nInserisci se è disponibile:") == "si" ? 1 : 0;
            string position = StringInput("\nInserisci il  :");
            string author = StringInput("\nInserisci il  :");
            string type = StringInput("\nInserisci il  :");
            int timeOrPages;
            if (type == "libro" || type == "Libro")
            {
                timeOrPages = Convert.ToInt32(StringInput("\nInserisci il numero di pagine:"));
            }
            else
            {
                timeOrPages = Convert.ToInt32(StringInput("\nInserisci la durata:"));
            }

            AddDocument(code, title, year, sector, available, position, author, type, timeOrPages);

            break;

        case 2:

            string docToSearch = StringInput("\nInserisci il titolo da cercare");
            Console.WriteLine("Risultato ricerca:\n\n");
            PrintDocument(docToSearch);


                break;

        default:

            exit = true;

            break;
    }
}

static void ShowMenu()
{
    Console.WriteLine("1-Aggiungi\n2-Verifica disponibilità");
}

static string StringInput(string message)
{
    Console.WriteLine(message);
    return Console.ReadLine();
}

static void AddDocument(string dato1, string dato2, int dato3, string dato4, int dato5, string dato6, string dato7, string dato8, int dato9)
{
    string conn = "Data Source=localhost;Initial Catalog=db-biblioteca;Integrated Security=True";
    SqlConnection connToDb = new SqlConnection(conn);



    try
    {
        connToDb.Open();

        string query = "";
        if(dato8 == "libro")
        {
             query = "INSERT INTO documents (code, title, year, sector, available, position, author, type, total_pages ) VALUES (@code, @title, @year, @sector, @available, @position, @author, @type, @total_pages);";
        }
        else
        {
            query = "INSERT INTO documents (code, title, year, sector, available, position, author, type, time ) VALUES (@code, @title, @year, @sector, @available, @position, @author, @type, @time);";
        }
 

        SqlCommand cmd = new SqlCommand(query, connToDb);
        cmd.Parameters.Add(new SqlParameter("@code", dato1));
        cmd.Parameters.Add(new SqlParameter("@title", dato2));
        cmd.Parameters.Add(new SqlParameter("@year", dato3));
        cmd.Parameters.Add(new SqlParameter("@sector", dato4));
        cmd.Parameters.Add(new SqlParameter("@available", dato5));
        cmd.Parameters.Add(new SqlParameter("@position", dato6));
        cmd.Parameters.Add(new SqlParameter("@author", dato7));
        cmd.Parameters.Add(new SqlParameter("@type", dato8));
        if (dato8 == "libro")
        {
            cmd.Parameters.Add(new SqlParameter("@total_pages", dato9));

        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@time", dato9));

        }

        int affectedRows = cmd.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        connToDb.Close();
    }
}


static void PrintDocument(string name)
{

    string conn = "Data Source=localhost;Initial Catalog=db-biblioteca;Integrated Security=True";
    SqlConnection connToDb = new SqlConnection(conn);

    try
    {
        connToDb.Open();
        string query = "SELECT * FROM documents where title = @name;";

        SqlCommand cmd = new SqlCommand(query, connToDb);
        cmd.Parameters.Add(new SqlParameter("@name", name));
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            string title = reader.GetString(2);
            int disponibility = reader.GetByte(5);
            Console.WriteLine($"#{id} - {title} - Disponibile: {(disponibility == 1 ? "si": "no" )}" );
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
    finally
    {
        connToDb.Close();
    }
}