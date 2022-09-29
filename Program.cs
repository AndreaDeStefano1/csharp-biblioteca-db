

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


using System.Data.SqlClient;




int choice = Convert.ToInt32(StringInput("Cosa vuoi fare?"));


switch (choice)
{
    case 1:

        string code = StringInput("Inserisci il codice:");
        string title = StringInput("Inserisci il titolo:");
        int year = Convert.ToInt32(StringInput("Inserisci l'anno:"));
        string sector = StringInput("Inserisci il genere:");
        int available = StringInput("Inserisci se è disponibile:") == "si" ? 1 : 0;
        string position = StringInput("Inserisci il  :");
        string author = StringInput("Inserisci il  :");
        string type = StringInput("Inserisci il  :");
        int timeOrPages;
        if(type == "libro" || type == "Libro")
        {
            timeOrPages = Convert.ToInt32(StringInput("Inserisci il numero di pagine:"));
        }
        else
        {
            timeOrPages = Convert.ToInt32(StringInput("Inserisci la durata:"));
        }

        AddDocument(code, title, year, sector, available, position, author, type, varX);

        break;
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