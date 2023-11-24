CREATE TABLE [dbo].[Aziende](
	[IdAzienda] [int] IDENTITY(1,1) NOT NULL,
	[RagioneSociale] [varchar](100) NOT NULL,
	[Citta] [varchar](100) NOT NULL,
	[Cap] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Aziende] PRIMARY KEY CLUSTERED 
(
	[IdAzienda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dipendenti]    Script Date: 24/11/2023 09:56:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dipendenti](
	[IdDipendente] [int] NOT NULL,
	[IdAzienda] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Cognome] [varchar](100) NOT NULL,
	[DataNascita] [date] NOT NULL,
 CONSTRAINT [PK_Dipendenti] PRIMARY KEY CLUSTERED 
(
	[IdDipendente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Dipendenti]  WITH CHECK ADD  CONSTRAINT [FK_Dipendenti_Aziende] FOREIGN KEY([IdAzienda])
REFERENCES [dbo].[Aziende] ([IdAzienda])
GO
ALTER TABLE [dbo].[Dipendenti] CHECK CONSTRAINT [FK_Dipendenti_Aziende]
GO
USE [master]
GO