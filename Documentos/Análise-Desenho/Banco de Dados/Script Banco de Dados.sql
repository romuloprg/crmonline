USE [CRMOnlineDB]
GO
/****** Object:  Table [dbo].[Atividade]    Script Date: 25/10/2012 14:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Atividade](
	[codAti] [int] IDENTITY(1,1) NOT NULL,
	[desAti] [varchar](200) NOT NULL,
	[tipAti] [varchar](50) NOT NULL,
	[datAti] [date] NOT NULL,
	[horAti] [time](7) NOT NULL,
	[durAti] [int] NOT NULL,
 CONSTRAINT [PK_Atividade] PRIMARY KEY CLUSTERED 
(
	[codAti] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 25/10/2012 14:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cargo](
	[codCar] [int] IDENTITY(1,1) NOT NULL,
	[nomCar] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
(
	[codCar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 25/10/2012 14:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[codCli] [int] IDENTITY(1,1) NOT NULL,
	[nomCli] [varchar](50) NOT NULL,
	[endCli] [varchar](100) NULL,
	[cidCli] [varchar](50) NULL,
	[ufCli] [varchar](2) NULL,
	[cnpjEmp] [varchar](18) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[codCli] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contato]    Script Date: 25/10/2012 14:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contato](
	[codCon] [int] IDENTITY(1,1) NOT NULL,
	[nomCon] [varchar](50) NOT NULL,
	[telCon] [varchar](10) NULL,
	[emaCon] [varchar](50) NULL,
	[codCli] [int] NOT NULL,
 CONSTRAINT [PK_Contato] PRIMARY KEY CLUSTERED 
(
	[codCon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contrato]    Script Date: 25/10/2012 14:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contrato](
	[codCtr] [int] IDENTITY(1,1) NOT NULL,
	[iniCtr] [date] NOT NULL,
	[fimCtr] [date] NULL,
	[cpfUsu] [varchar](14) NOT NULL,
	[cnpjEmp] [varchar](18) NOT NULL,
	[codCar] [int] NOT NULL,
 CONSTRAINT [PK_Contrato] PRIMARY KEY CLUSTERED 
(
	[codCtr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 25/10/2012 14:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empresa](
	[cnpjEmp] [varchar](18) NOT NULL,
	[razEmp] [varchar](100) NOT NULL,
	[nomEmp] [varchar](50) NOT NULL,
	[endEmp] [varchar](100) NULL,
	[cidEmp] [varchar](50) NULL,
	[ufEmp] [varchar](2) NULL,
	[telEmp] [varchar](14) NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[cnpjEmp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Graduacao]    Script Date: 25/10/2012 14:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Graduacao](
	[codGra] [int] IDENTITY(1,1) NOT NULL,
	[nomGra] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Graduacao] PRIMARY KEY CLUSTERED 
(
	[codGra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Lembrete]    Script Date: 25/10/2012 14:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lembrete](
	[codLem] [int] IDENTITY(1,1) NOT NULL,
	[datLem] [date] NOT NULL,
	[horLem] [time](7) NOT NULL,
	[repLem] [varchar](1) NOT NULL,
	[cpfUsu] [varchar](14) NOT NULL,
	[codAti] [int] NOT NULL,
 CONSTRAINT [PK_Lembrete] PRIMARY KEY CLUSTERED 
(
	[codLem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Participante]    Script Date: 25/10/2012 14:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Participante](
	[codPar] [int] IDENTITY(1,1) NOT NULL,
	[cpfUsu] [varchar](14) NOT NULL,
	[codAti] [int] NOT NULL,
 CONSTRAINT [PK_Participante] PRIMARY KEY CLUSTERED 
(
	[codPar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 25/10/2012 14:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[cpfUsu] [varchar](14) NOT NULL,
	[nomUsu] [varchar](50) NOT NULL,
	[sexUsu] [varchar](1) NOT NULL,
	[endUsu] [varchar](100) NULL,
	[cidUsu] [varchar](50) NULL,
	[ufUsu] [varchar](2) NULL,
	[telUsu] [varchar](14) NULL,
	[emaUsu] [varchar](50) NOT NULL,
	[senUsu] [varchar](10) NOT NULL,
	[codGra] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[cpfUsu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vendedor]    Script Date: 25/10/2012 14:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendedor](
	[codVen] [int] IDENTITY(1,1) NOT NULL,
	[iniVen] [date] NOT NULL,
	[fimVen] [date] NULL,
	[cpfUsu] [varchar](14) NOT NULL,
	[codCli] [int] NOT NULL,
 CONSTRAINT [PK_Vendedor] PRIMARY KEY CLUSTERED 
(
	[codVen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Cliente] FOREIGN KEY([cnpjEmp])
REFERENCES [dbo].[Empresa] ([cnpjEmp])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Empresa_Cliente]
GO
ALTER TABLE [dbo].[Contato]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Contato] FOREIGN KEY([codCli])
REFERENCES [dbo].[Cliente] ([codCli])
GO
ALTER TABLE [dbo].[Contato] CHECK CONSTRAINT [FK_Cliente_Contato]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [FK_Cargo_Contrato] FOREIGN KEY([codCar])
REFERENCES [dbo].[Cargo] ([codCar])
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [FK_Cargo_Contrato]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Contrato] FOREIGN KEY([cnpjEmp])
REFERENCES [dbo].[Empresa] ([cnpjEmp])
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [FK_Empresa_Contrato]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Contrato] FOREIGN KEY([cpfUsu])
REFERENCES [dbo].[Usuario] ([cpfUsu])
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [FK_Usuario_Contrato]
GO
ALTER TABLE [dbo].[Lembrete]  WITH CHECK ADD  CONSTRAINT [FK_Atividade_Lembrete] FOREIGN KEY([codAti])
REFERENCES [dbo].[Atividade] ([codAti])
GO
ALTER TABLE [dbo].[Lembrete] CHECK CONSTRAINT [FK_Atividade_Lembrete]
GO
ALTER TABLE [dbo].[Lembrete]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Lembrete] FOREIGN KEY([cpfUsu])
REFERENCES [dbo].[Usuario] ([cpfUsu])
GO
ALTER TABLE [dbo].[Lembrete] CHECK CONSTRAINT [FK_Usuario_Lembrete]
GO
ALTER TABLE [dbo].[Participante]  WITH CHECK ADD  CONSTRAINT [FK_Atividade_Participante] FOREIGN KEY([codAti])
REFERENCES [dbo].[Atividade] ([codAti])
GO
ALTER TABLE [dbo].[Participante] CHECK CONSTRAINT [FK_Atividade_Participante]
GO
ALTER TABLE [dbo].[Participante]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Participante] FOREIGN KEY([cpfUsu])
REFERENCES [dbo].[Usuario] ([cpfUsu])
GO
ALTER TABLE [dbo].[Participante] CHECK CONSTRAINT [FK_Usuario_Participante]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Graduacao_Usuario] FOREIGN KEY([codGra])
REFERENCES [dbo].[Graduacao] ([codGra])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Graduacao_Usuario]
GO
ALTER TABLE [dbo].[Vendedor]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Vendedor] FOREIGN KEY([codCli])
REFERENCES [dbo].[Cliente] ([codCli])
GO
ALTER TABLE [dbo].[Vendedor] CHECK CONSTRAINT [FK_Cliente_Vendedor]
GO
ALTER TABLE [dbo].[Vendedor]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Vendedor] FOREIGN KEY([cpfUsu])
REFERENCES [dbo].[Usuario] ([cpfUsu])
GO
ALTER TABLE [dbo].[Vendedor] CHECK CONSTRAINT [FK_Usuario_Vendedor]
GO
