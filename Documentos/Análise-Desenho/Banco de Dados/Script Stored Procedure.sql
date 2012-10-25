USE [CRMOnlineDB]
GO
/****** Object:  StoredProcedure [dbo].[atividade_Buscar]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[atividade_Buscar]
(
  @busca varchar(8000)
) 
AS
	SELECT DISTINCT codAti, desAti, tipAti, datAti, horAti, durAti FROM Atividade
		WHERE desAti LIKE CONCAT('%',@busca,'%') OR tipAti LIKE CONCAT('%',@busca,'%')
RETURN
GO
/****** Object:  StoredProcedure [dbo].[atividade_Inserir]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[atividade_Inserir]
(
  @desAti varchar(100),
  @tipAti varchar(50),
  @datAti varchar(10),
  @horAti varchar(8),
  @durAti int
)
AS
  INSERT INTO Atividade VALUES (@desAti, @tipAti, @datAti, @horAti, @durAti)
GO
/****** Object:  StoredProcedure [dbo].[atividade_Obter]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[atividade_Obter]
(
  @codAti int
) 
AS
	SELECT DISTINCT codAti, desAti, tipAti, datAti, horAti, durAti FROM Atividade
		WHERE codAti = @codAti
RETURN
GO
/****** Object:  StoredProcedure [dbo].[atividade_ObterTodos]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[atividade_ObterTodos]
AS
	SELECT DISTINCT codAti, desAti, tipAti, datAti, horAti, durAti FROM Atividade
RETURN
GO
/****** Object:  StoredProcedure [dbo].[atividade_Remover]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[atividade_Remover]
(
@codAti int
) 
AS
Delete from Atividade where codAti = @codAti
GO
/****** Object:  StoredProcedure [dbo].[atualizar_Atualizar]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[atualizar_Atualizar]
(
  @codAti int,
  @desAti varchar(100),
  @tipAti varchar(50),
  @datAti varchar(10),
  @horAti varchar(8),
  @durAti int
) 
AS
  update Atividade set desAti=@desAti,
  							 tipAti=@tipAti,
							 datAti=@datAti,
                             horAti=@horAti,
                             durAti=@durAti
where codAti=@codAti
GO
/****** Object:  StoredProcedure [dbo].[cliente_Atualizar]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cliente_Atualizar]
(
  @codCli int,
  @nomCli varchar(50),
  @endCli varchar(100),
  @cidCli varchar(50),
  @ufCli varchar(2),
  @cnpjEmp varchar(14)
) 
AS
  update Cliente set nomCli=@nomCli,
                             endCli=@endCli,
                             cidCli=@cidCli,
							 ufCli=@ufCli,
							 cnpjEmp=@cnpjEmp
where codCli=@codCli
GO
/****** Object:  StoredProcedure [dbo].[cliente_Buscar]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cliente_Buscar]
(
  @busca varchar(8000)
) 
AS
	SELECT DISTINCT codCli, nomCli, endCli, cidCli, ufCli, Cliente.cnpjEmp, nomEmp FROM Cliente JOIN Empresa ON Cliente.cnpjEmp = Empresa.cnpjEmp
		WHERE nomCli LIKE CONCAT('%',@busca,'%') OR nomEmp LIKE CONCAT('%',@busca,'%')
RETURN
GO
/****** Object:  StoredProcedure [dbo].[cliente_Inserir]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cliente_Inserir]
(
  @nomCli varchar(50),
  @endCli varchar(100),
  @cidCli varchar(50),
  @ufCli varchar(2),
  @cnpjEmp varchar(14)
) 
AS
  INSERT INTO Cliente VALUES (@nomCli, @endCli, @cidCli, @ufCli, @cnpjEmp)
GO
/****** Object:  StoredProcedure [dbo].[cliente_Obter]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cliente_Obter]
(
  @codCli int
) 
AS
	SELECT DISTINCT codCli, nomCli, endCli, cidCli, ufCli, Cliente.cnpjEmp, nomEmp FROM Cliente JOIN Empresa ON Cliente.cnpjEmp = Empresa.cnpjEmp
		WHERE codCli = @codCli
RETURN
GO
/****** Object:  StoredProcedure [dbo].[cliente_ObterTodos]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cliente_ObterTodos]
AS
	SELECT DISTINCT codCli, nomCli, endCli, cidCli, ufCli, Cliente.cnpjEmp, nomEmp FROM Cliente JOIN Empresa ON Cliente.cnpjEmp = Empresa.cnpjEmp
RETURN
GO
/****** Object:  StoredProcedure [dbo].[cliente_Remover]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cliente_Remover]
(
@codCli int
) 
AS
Delete from Cliente where codCli = @codCli
GO
/****** Object:  StoredProcedure [dbo].[empresa_Atualizar]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[empresa_Atualizar]
(
  @cnpjEmp varchar(14),
  @razEmp varchar(50),
  @nomEmp varchar(50),
  @endEmp varchar(100),
  @cidEmp varchar(50),
  @ufEmp varchar(2),
  @telEmp varchar(10)
) 
AS
  update Empresa set cnpjEmp=@cnpjEmp,
  							 razEmp=@razEmp,
							 nomEmp=@nomEmp,
                             endEmp=@endEmp,
                             cidEmp=@cidEmp,
							 ufEmp=@ufEmp,
							 telEmp=@telEmp
where cnpjEmp=@cnpjEmp
GO
/****** Object:  StoredProcedure [dbo].[empresa_Buscar]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[empresa_Buscar]
(
  @busca varchar(8000)
) 
AS
	SELECT DISTINCT cnpjEmp, razEmp, nomEmp, endEmp, cidEmp, ufEmp, telEmp FROM Empresa
		WHERE razEmp LIKE CONCAT('%',@busca,'%') OR nomEmp LIKE CONCAT('%',@busca,'%')
RETURN
GO
/****** Object:  StoredProcedure [dbo].[empresa_Inserir]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[empresa_Inserir]
(
  @cnpjEmp varchar(14),
  @razEmp varchar(50),
  @nomEmp varchar(50),
  @endEmp varchar(100),
  @cidEmp varchar(50),
  @ufEmp varchar(2),
  @telEmp varchar(10)
) 
AS
  INSERT INTO Empresa VALUES (@cnpjEmp, @razEmp, @nomEmp, @endEmp, @cidEmp, @ufEmp, @telEmp)
GO
/****** Object:  StoredProcedure [dbo].[empresa_Obter]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[empresa_Obter]
(
  @cnpjEmp varchar(14)
) 
AS
	SELECT DISTINCT cnpjEmp, razEmp, nomEmp, endEmp, cidEmp, ufEmp, telEmp FROM Empresa
		WHERE cnpjEmp = @cnpjEmp
RETURN
GO
/****** Object:  StoredProcedure [dbo].[empresa_ObterTodos]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[empresa_ObterTodos]
AS
	SELECT DISTINCT cnpjEmp, razEmp, nomEmp, endEmp, cidEmp, ufEmp, telEmp FROM Empresa
RETURN
GO
/****** Object:  StoredProcedure [dbo].[empresa_Remover]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[empresa_Remover]
(
@cnpjEmp varchar(14)
) 
AS
Delete from Empresa where cnpjEmp = @cnpjEmp
GO
/****** Object:  StoredProcedure [dbo].[graduacao_ObterTodos]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[graduacao_ObterTodos]
AS
	SELECT DISTINCT codGra, nomGra FROM Graduacao
		ORDER BY nomGra
RETURN
GO
/****** Object:  StoredProcedure [dbo].[usuario_Atualizar]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usuario_Atualizar]
(
  @cpfUsu varchar(11),
  @nomUsu varchar(50),
  @sexUsu varchar(1),
  @endUsu varchar(100),
  @cidUsu varchar(50),
  @ufUsu varchar(2),
  @telUsu varchar(10),
  @emaUsu varchar(50),
  @tipUsu varchar(1),
  @senUsu varchar(10),
  @codGra int
) 
AS
  update Usuario set nomUsu=@nomUsu,
							 sexUsu=@sexUsu,
                             endUsu=@endUsu,
                             cidUsu=@cidUsu,
							 ufUsu=@ufUsu,
							 telUsu=@telUsu,
							 emaUsu=@emaUsu,
							 tipUsu=@tipUsu,
							 senUsu=@senUsu,
							 codGra=@codGra
where cpfUsu=@cpfUsu
GO
/****** Object:  StoredProcedure [dbo].[usuario_AtualizarPermissao]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usuario_AtualizarPermissao]
(
  @cpfUsu varchar(11),
  @tipUsu varchar(1)	
) 
AS
  update Usuario set tipUsu=@tipUsu
where cpfUsu=@cpfUsu
GO
/****** Object:  StoredProcedure [dbo].[usuario_Buscar]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usuario_Buscar]
(
  @busca varchar(8000)
) 
AS
	SELECT DISTINCT cpfUsu, nomUsu, sexUsu, endUsu, cidUsu, ufUsu, telUsu, emaUsu, tipUsu, senUsu, Usuario.codGra, nomGra FROM Usuario JOIN Graduacao ON Usuario.codGra = Graduacao.codGra
		WHERE nomUsu LIKE CONCAT('%',@busca,'%') OR nomGra LIKE CONCAT('%',@busca,'%')
RETURN
GO
/****** Object:  StoredProcedure [dbo].[usuario_Inserir]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usuario_Inserir]
(
  @cpfUsu varchar(11),
  @nomUsu varchar(50),
  @sexUsu varchar(1),
  @endUsu varchar(100),
  @cidUsu varchar(50),
  @ufUsu varchar(2),
  @telUsu varchar(10),
  @emaUsu varchar(50),
  @tipUsu varchar(1),
  @senUsu varchar(10),
  @codGra int
) 
AS
  INSERT INTO Usuario VALUES (@cpfUsu, @nomUsu, @sexUsu, @endUsu, @cidUsu, @ufUsu, @telUsu, @emaUsu, @tipUsu, @senUsu, @codGra)
GO
/****** Object:  StoredProcedure [dbo].[usuario_Obter]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usuario_Obter]
(
  @cpfUsu varchar(11)
) 
AS
	SELECT DISTINCT cpfUsu, nomUsu, sexUsu, endUsu, cidUsu, ufUsu, telUsu, emaUsu, tipUsu, senUsu, Usuario.codGra, nomGra FROM Usuario JOIN Graduacao ON Usuario.codGra = Graduacao.codGra
		WHERE cpfUsu = @cpfUsu
RETURN
GO
/****** Object:  StoredProcedure [dbo].[usuario_ObterTodos]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usuario_ObterTodos]
AS
	SELECT DISTINCT cpfUsu, nomUsu, sexUsu, endUsu, cidUsu, ufUsu, telUsu, emaUsu, tipUsu, senUsu, Usuario.codGra, nomGra FROM Usuario JOIN Graduacao ON Usuario.codGra = Graduacao.codGra
RETURN
GO
/****** Object:  StoredProcedure [dbo].[usuario_Remover]    Script Date: 15/10/2012 17:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usuario_Remover]
(
@cpfUsu varchar(11)
) 
AS
Delete from Usuario WHERE cpfUsu = @cpfUsu
GO
CREATE PROCEDURE [dbo].[usuario_Validar]
(
	@emaUsu varchar(50),
	@senUsu varchar(10)
) 
AS
	SELECT DISTINCT cpfUsu, nomUsu, tipUsu FROM Usuario
		WHERE emaUsu = @emaUsu AND senUsu = @senUsu
GO
