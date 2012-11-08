if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Atividade') and o.name = 'FK_ATIVIDAD_REFERENCE_CLIENTE')
alter table Atividade
   drop constraint FK_ATIVIDAD_REFERENCE_CLIENTE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Cliente') and o.name = 'FK_EMPRESA_REFERENCE_CLIENTE')
alter table Cliente
   drop constraint FK_EMPRESA_REFERENCE_CLIENTE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Cliente') and o.name = 'FK_CLIENTE_REFERENCE_EMPRESA')
alter table Cliente
   drop constraint FK_CLIENTE_REFERENCE_EMPRESA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Contrato') and o.name = 'FK_CONTRATO_REFERENCE_USUARIO')
alter table Contrato
   drop constraint FK_CONTRATO_REFERENCE_USUARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Contrato') and o.name = 'FK_CONTRATO_REFERENCE_EMPRESA')
alter table Contrato
   drop constraint FK_CONTRATO_REFERENCE_EMPRESA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Contrato') and o.name = 'FK_CONTRATO_REFERENCE_CARGO')
alter table Contrato
   drop constraint FK_CONTRATO_REFERENCE_CARGO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Lembrete') and o.name = 'FK_LEMBRETE_REFERENCE_PARTICIP')
alter table Lembrete
   drop constraint FK_LEMBRETE_REFERENCE_PARTICIP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Participante') and o.name = 'FK_PARTICIP_REFERENCE_USUARIO')
alter table Participante
   drop constraint FK_PARTICIP_REFERENCE_USUARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Participante') and o.name = 'FK_PARTICIP_REFERENCE_ATIVIDAD')
alter table Participante
   drop constraint FK_PARTICIP_REFERENCE_ATIVIDAD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Usuario') and o.name = 'FK_USUARIO_REFERENCE_GRADUACA')
alter table Usuario
   drop constraint FK_USUARIO_REFERENCE_GRADUACA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Vendedor') and o.name = 'FK_VENDEDOR_REFERENCE_USUARIO')
alter table Vendedor
   drop constraint FK_VENDEDOR_REFERENCE_USUARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Vendedor') and o.name = 'FK_VENDEDOR_REFERENCE_CLIENTE')
alter table Vendedor
   drop constraint FK_VENDEDOR_REFERENCE_CLIENTE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Atividade')
            and   type = 'U')
   drop table Atividade
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Cargo')
            and   type = 'U')
   drop table Cargo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Cliente')
            and   type = 'U')
   drop table Cliente
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Contrato')
            and   type = 'U')
   drop table Contrato
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Empresa')
            and   type = 'U')
   drop table Empresa
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Graduacao')
            and   type = 'U')
   drop table Graduacao
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Lembrete')
            and   type = 'U')
   drop table Lembrete
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Participante')
            and   type = 'U')
   drop table Participante
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Usuario')
            and   type = 'U')
   drop table Usuario
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Vendedor')
            and   type = 'U')
   drop table Vendedor
go

/*==============================================================*/
/* Table: Atividade                                             */
/*==============================================================*/
create table Atividade (
   codAti               integer              identity,
   codCli               integer              not null,
   desAti               varchar(200)         not null,
   tipAti               varchar(50)          not null,
   datAti               date                 not null,
   horAti               time                 not null,
   constraint PK_ATIVIDADE primary key (codAti)
)
go

/*==============================================================*/
/* Table: Cargo                                                 */
/*==============================================================*/
create table Cargo (
   codCar               integer              identity,
   nomCar               varchar(30)          not null,
   constraint PK_CARGO primary key (codCar)
)
go

/*==============================================================*/
/* Table: Cliente                                               */
/*==============================================================*/
create table Cliente (
   codCli               integer              identity,
   cnpjEmp              varchar(18)          not null,
   cnpjCli              varchar(18)          not null,
   constraint PK_CLIENTE primary key (codCli)
)
go

/*==============================================================*/
/* Table: Contrato                                              */
/*==============================================================*/
create table Contrato (
   codCtr               integer              identity,
   cpfUsu               varchar(14)          not null,
   cnpjEmp              varchar(18)          not null,
   codCar               integer              not null,
   iniCtr               date                 not null,
   fimCtr               date                 not null,
   constraint PK_CONTRATO primary key (codCtr)
)
go

/*==============================================================*/
/* Table: Empresa                                               */
/*==============================================================*/
create table Empresa (
   cnpjEmp              varchar(18)          not null,
   nomEmp               varchar(100)         not null,
   endEmp               varchar(100)         null,
   cidEmp               varchar(50)          null,
   ufEmp                varchar(2)           null,
   telEmp               varchar(14)          null,
   constraint PK_EMPRESA primary key (cnpjEmp)
)
go

/*==============================================================*/
/* Table: Graduacao                                             */
/*==============================================================*/
create table Graduacao (
   codGra               int                  identity,
   nomGra               varchar(30)          not null,
   constraint PK_GRADUACAO primary key (codGra)
)
go

/*==============================================================*/
/* Table: Lembrete                                              */
/*==============================================================*/
create table Lembrete (
   codLem               integer              identity,
   codPar               integer              not null,
   diaLem               integer              not null,
   horLem               integer              not null,
   repLem               integer              not null,
   constraint PK_LEMBRETE primary key (codLem)
)
go

/*==============================================================*/
/* Table: Participante                                          */
/*==============================================================*/
create table Participante (
   codPar               integer              identity,
   cpfUsu               varchar(14)          not null,
   codAti               integer              not null,
   constraint PK_PARTICIPANTE primary key (codPar)
)
go

/*==============================================================*/
/* Table: Usuario                                               */
/*==============================================================*/
create table Usuario (
   cpfUsu               varchar(14)          not null,
   codGra               int                  not null,
   nomUsu               varchar(50)          not null,
   sexUsu               varchar(1)           not null,
   endUsu               varchar(100)         null,
   cidUsu               varchar(50)          null,
   ufUsu                varchar(2)           null,
   telUsu               varchar(14)          null,
   emaUsu               varchar(50)          not null,
   senUsu               varchar(10)          not null,
   constraint PK_USUARIO primary key (cpfUsu)
)
go

/*==============================================================*/
/* Table: Vendedor                                              */
/*==============================================================*/
create table Vendedor (
   codVen               integer              identity,
   cpfUsu               varchar(14)          not null,
   codCli               integer              not null,
   iniVen               date                 not null,
   fimVen               date                 not null,
   constraint PK_VENDEDOR primary key (codVen)
)
go

alter table Atividade
   add constraint FK_ATIVIDAD_REFERENCE_CLIENTE foreign key (codCli)
      references Cliente (codCli)
go

alter table Cliente
   add constraint FK_EMPRESA_REFERENCE_CLIENTE foreign key (cnpjEmp)
      references Empresa (cnpjEmp)
go

alter table Cliente
   add constraint FK_CLIENTE_REFERENCE_EMPRESA foreign key (cnpjCli)
      references Empresa (cnpjEmp)
go

alter table Contrato
   add constraint FK_CONTRATO_REFERENCE_USUARIO foreign key (cpfUsu)
      references Usuario (cpfUsu)
go

alter table Contrato
   add constraint FK_CONTRATO_REFERENCE_EMPRESA foreign key (cnpjEmp)
      references Empresa (cnpjEmp)
go

alter table Contrato
   add constraint FK_CONTRATO_REFERENCE_CARGO foreign key (codCar)
      references Cargo (codCar)
go

alter table Lembrete
   add constraint FK_LEMBRETE_REFERENCE_PARTICIP foreign key (codPar)
      references Participante (codPar)
go

alter table Participante
   add constraint FK_PARTICIP_REFERENCE_USUARIO foreign key (cpfUsu)
      references Usuario (cpfUsu)
go

alter table Participante
   add constraint FK_PARTICIP_REFERENCE_ATIVIDAD foreign key (codAti)
      references Atividade (codAti)
go

alter table Usuario
   add constraint FK_USUARIO_REFERENCE_GRADUACA foreign key (codGra)
      references Graduacao (codGra)
go

alter table Vendedor
   add constraint FK_VENDEDOR_REFERENCE_USUARIO foreign key (cpfUsu)
      references Usuario (cpfUsu)
go

alter table Vendedor
   add constraint FK_VENDEDOR_REFERENCE_CLIENTE foreign key (codCli)
      references Cliente (codCli)
go
