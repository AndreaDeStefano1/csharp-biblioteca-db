

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