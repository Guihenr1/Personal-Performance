USE [master]
GO
/****** Object:  Database [personal]    Script Date: 19/05/2021 22:23:57 ******/
CREATE DATABASE [personal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'personal', FILENAME = N'/var/opt/mssql/data/personal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'personal_log', FILENAME = N'/var/opt/mssql/data/personal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [personal] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [personal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [personal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [personal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [personal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [personal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [personal] SET ARITHABORT OFF 
GO
ALTER DATABASE [personal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [personal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [personal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [personal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [personal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [personal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [personal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [personal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [personal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [personal] SET  ENABLE_BROKER 
GO
ALTER DATABASE [personal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [personal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [personal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [personal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [personal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [personal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [personal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [personal] SET RECOVERY FULL 
GO
ALTER DATABASE [personal] SET  MULTI_USER 
GO
ALTER DATABASE [personal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [personal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [personal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [personal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [personal] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'personal', N'ON'
GO
ALTER DATABASE [personal] SET QUERY_STORE = OFF
GO
USE [personal]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aluno]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aluno](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Email] [varchar](254) NULL,
	[DataNascimento] [datetime] NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
	[DataExcluido] [datetime] NULL,
	[Excluido] [bit] NOT NULL,
	[ProfessorId] [uniqueidentifier] NOT NULL,
	[EnderecoId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Aluno] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnamnesePergunta]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnamnesePergunta](
	[Id] [uniqueidentifier] NOT NULL,
	[Pergunta] [varchar](250) NOT NULL,
 CONSTRAINT [PK_AnamnesePergunta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnamneseResposta]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnamneseResposta](
	[Id] [uniqueidentifier] NOT NULL,
	[Resposta] [varchar](250) NOT NULL,
	[AnamnesePerguntaId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AnamneseResposta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[UserType] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Biometria]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Biometria](
	[Id] [uniqueidentifier] NOT NULL,
	[Peso] [int] NOT NULL,
	[Altura] [decimal](3, 2) NOT NULL,
	[BracoDireito] [decimal](5, 2) NOT NULL,
	[BracoEsquerdo] [decimal](5, 2) NOT NULL,
	[Torax] [decimal](5, 2) NOT NULL,
	[Cintura] [decimal](5, 2) NOT NULL,
	[Quadril] [decimal](5, 2) NOT NULL,
	[CoxaDireita] [decimal](5, 2) NOT NULL,
	[CoxaEsquerda] [decimal](5, 2) NOT NULL,
	[GemeoDireito] [decimal](5, 2) NOT NULL,
	[GemeoEsquerdo] [decimal](5, 2) NOT NULL,
	[AnteBracoDireito] [decimal](5, 2) NOT NULL,
	[AnteBracoEsquerdo] [decimal](5, 2) NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
	[DataExcluido] [datetime] NULL,
	[Excluido] [bit] NOT NULL,
	[AlunoId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Biometria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Endereco]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Endereco](
	[Id] [uniqueidentifier] NOT NULL,
	[Cep] [varchar](8) NOT NULL,
	[Logradouro] [varchar](100) NOT NULL,
	[Numero] [int] NOT NULL,
	[Bairro] [varchar](50) NOT NULL,
	[Complemento] [varchar](40) NOT NULL,
	[Cidade] [varchar](50) NOT NULL,
	[AlunoId] [uniqueidentifier] NOT NULL,
	[EstadoId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Sigla] [varchar](2) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exercicio]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exercicio](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](100) NULL,
	[Descricao] [varchar](100) NULL,
 CONSTRAINT [PK_Exercicio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExercicioCarga]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExercicioCarga](
	[Id] [uniqueidentifier] NOT NULL,
	[Carga] [int] NOT NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[ExercicioTreinoId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ExercicioCarga] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExercicioTreino]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExercicioTreino](
	[Id] [uniqueidentifier] NOT NULL,
	[ExercicioId] [uniqueidentifier] NOT NULL,
	[TreinoId] [uniqueidentifier] NOT NULL,
	[RepeticaoId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ExercicioTreino] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ficha]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ficha](
	[Id] [uniqueidentifier] NOT NULL,
	[Objetivo] [varchar](100) NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
	[AlunoId] [uniqueidentifier] NOT NULL,
	[AnamneseRespostaId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Ficha] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissao]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissao](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](100) NULL,
	[TipoId] [uniqueidentifier] NOT NULL,
	[TipoUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Permissao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professor]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[CREF] [int] NOT NULL,
	[Email] [varchar](254) NULL,
	[DataCadastro] [datetime] NOT NULL,
	[DataExcluido] [datetime] NULL,
	[Excluido] [bit] NOT NULL,
 CONSTRAINT [PK_Professor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefreshTokens]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefreshTokens](
	[Id] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Token] [uniqueidentifier] NOT NULL,
	[ExpirationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_RefreshTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Repeticao]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Repeticao](
	[Id] [uniqueidentifier] NOT NULL,
	[Descricao] [varchar](100) NULL,
 CONSTRAINT [PK_Repeticao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SecurityKeys]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityKeys](
	[Id] [uniqueidentifier] NOT NULL,
	[Parameters] [nvarchar](max) NULL,
	[KeyId] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[Algorithm] [nvarchar](max) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_SecurityKeys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo](
	[Id] [uniqueidentifier] NOT NULL,
	[Descricao] [varchar](100) NULL,
 CONSTRAINT [PK_Tipo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Treino]    Script Date: 19/05/2021 22:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treino](
	[Id] [uniqueidentifier] NOT NULL,
	[AlunoId] [uniqueidentifier] NOT NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[Nome] [varchar](100) NULL,
 CONSTRAINT [PK_Treino] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210420000251_Treino', N'3.1.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210427003622_Atualizacao', N'3.1.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210505183725_Initial', N'3.1.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210505202035_configuration', N'3.1.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210505212455_initial', N'3.1.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210512184706_UserActive1', N'3.1.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210512214424_UpdateRelatinament', N'3.1.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210513171221_IsStudent', N'3.1.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210514010759_user-type', N'3.1.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210517171736_ExercicioCarga', N'3.1.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210518015658_NomeTreino', N'3.1.7')
GO
INSERT [dbo].[Aluno] ([Id], [Nome], [Email], [DataNascimento], [DataCadastro], [DataExcluido], [Excluido], [ProfessorId], [EnderecoId]) VALUES (N'd7ccdbf1-bcfe-40c0-a0f0-60e00c07b9ef', N'Mariane Isabelle Flávia', N'mariana.isabelle@gmail.com', CAST(N'2001-05-17T00:00:00.000' AS DateTime), CAST(N'2021-05-17T21:11:12.343' AS DateTime), NULL, 0, N'8e1f0a33-9ac6-4eea-877e-28394a8bb1c0', N'55baff28-ea12-40b0-b86f-153f8364d4fe')
GO
INSERT [dbo].[Aluno] ([Id], [Nome], [Email], [DataNascimento], [DataCadastro], [DataExcluido], [Excluido], [ProfessorId], [EnderecoId]) VALUES (N'2f413a30-e378-404c-8309-850572ac03da', N'Nathan Felipe Santos', N'nathan.felipe@gmail.com', CAST(N'2002-05-17T00:00:00.000' AS DateTime), CAST(N'2021-05-17T21:03:01.990' AS DateTime), NULL, 0, N'0d53b274-cad7-416c-9a5f-99a2b632a2ed', N'b6d06674-46ab-4f9c-b3c1-6fddce06fbea')
GO
INSERT [dbo].[Aluno] ([Id], [Nome], [Email], [DataNascimento], [DataCadastro], [DataExcluido], [Excluido], [ProfessorId], [EnderecoId]) VALUES (N'c2843637-52ae-40b4-961f-c0ca4be1422f', N'Emanuelly Mariane Sara Jesus', N'emanu@gmail.com', CAST(N'1990-05-19T00:32:00.743' AS DateTime), CAST(N'2021-05-18T21:34:45.490' AS DateTime), NULL, 0, N'8e1f0a33-9ac6-4eea-877e-28394a8bb1c0', N'7e28ad93-ac1f-4bf4-9ce8-b629ad1b7025')
GO
INSERT [dbo].[Aluno] ([Id], [Nome], [Email], [DataNascimento], [DataCadastro], [DataExcluido], [Excluido], [ProfessorId], [EnderecoId]) VALUES (N'0d07621e-9c18-4277-b68f-f5c4125551ef', N'Aurora Caroline da Conceição', N'aurora.caroline@gmail.com', CAST(N'2000-05-17T00:00:00.000' AS DateTime), CAST(N'2021-05-17T20:59:36.247' AS DateTime), NULL, 0, N'0d53b274-cad7-416c-9a5f-99a2b632a2ed', N'0e8f4e96-cb5c-4646-b5ee-db4ec9074861')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsActive], [UserType]) VALUES (N'0d07621e-9c18-4277-b68f-f5c4125551ef', N'aurora.caroline@gmail.com', N'AURORA.CAROLINE@GMAIL.COM', N'aurora.caroline@gmail.com', N'AURORA.CAROLINE@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAENH7zumtf+W0wVDTD32FQ6ojWKI1WmCl+oI+o4dwQsLWoyn1ol2pCPTrEnjVqo4Q3Q==', N'ABD6UFDFIQZPJDLZTDHNTGTLNTWGVGZM', N'7b60e560-950e-4091-bfe9-5390f63de7a3', NULL, 0, 0, NULL, 1, 0, 1, 2)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsActive], [UserType]) VALUES (N'0d53b274-cad7-416c-9a5f-99a2b632a2ed', N'eduardo.amaral@gmail.com', N'EDUARDO.AMARAL@GMAIL.COM', N'eduardo.amaral@gmail.com', N'EDUARDO.AMARAL@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEDBxwVfmV7vwDygsWjQDsUjGcZrSpRQU22/W+Z2q2t3JKeUlMBQ2SBkcTpKaKV1oEg==', N'U2XDJTWTH2T2RQJNQRWTLVI4QF7GMRLQ', N'f1cda994-a8e1-487f-adb8-489a0e26e13b', NULL, 0, 0, NULL, 1, 0, 1, 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsActive], [UserType]) VALUES (N'2f413a30-e378-404c-8309-850572ac03da', N'nathan.felipe@gmail.com', N'NATHAN.FELIPE@GMAIL.COM', N'nathan.felipe@gmail.com', N'NATHAN.FELIPE@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEE71vnp7YT49YtsU8rE5LmDh/XvgiXVBPhEIz7pQuiiGsr615RBBoPjsheZsRXHe8A==', N'4RQJQDIYH6Y55OISOV7BEKW4N3JR6X2G', N'8310d82d-0782-425d-8ac8-2eb9ad0fd6b0', NULL, 0, 0, NULL, 1, 0, 1, 2)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsActive], [UserType]) VALUES (N'8e1f0a33-9ac6-4eea-877e-28394a8bb1c0', N'marcos.amaral@gmail.com', N'MARCOS.AMARAL@GMAIL.COM', N'marcos.amaral@gmail.com', N'MARCOS.AMARAL@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEJafGKgLBYWaGx4ZDIFJ4QyA2cyyBqqfEl1+isw5CjxZLS9hMKAkXnRfSeleb6Mcag==', N'X7ZX2NON4CHGJRUS57ZGNRJCILNJ7TVZ', N'e731dc77-0c1d-4c0e-b2fd-0ae999071f0d', NULL, 0, 0, NULL, 1, 0, 1, 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsActive], [UserType]) VALUES (N'c2843637-52ae-40b4-961f-c0ca4be1422f', N'emanu@gmail.com', N'EMANU@GMAIL.COM', N'emanu@gmail.com', N'EMANU@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEOq8Rdq5jcUlG22yq1b5CsrE/4OJzaQYcVDBA8erdsc+bxIvEJA0/u+H8Oiiq3GbCg==', N'LN65IOSTYBXVGOFR2CJQQU563HEB4L5P', N'74390256-c26d-492d-ad8c-6b5e8deebb2f', NULL, 0, 0, NULL, 1, 0, 1, 2)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsActive], [UserType]) VALUES (N'd7ccdbf1-bcfe-40c0-a0f0-60e00c07b9ef', N'mariana.isabelle@gmail.com', N'MARIANA.ISABELLE@GMAIL.COM', N'mariana.isabelle@gmail.com', N'MARIANA.ISABELLE@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEFSrvNFGlcSYp7AtW2i2yV/GHIOkre+14sJiZDb4GSk1YHlN2VlB/JKM8EtiPpEecA==', N'MR4QBF5MC4VHU3DXHFJ2CTOPZ4E3IZWH', N'4a45a83a-77ca-41c9-8d91-36eeefd3568a', NULL, 0, 0, NULL, 1, 0, 1, 2)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsActive], [UserType]) VALUES (N'fdd1ef89-acc7-4d9e-bb48-691d719f8473', N'guilherme.pomp@gmail.com', N'GUILHERME.POMP@GMAIL.COM', N'guilherme.pomp@gmail.com', N'GUILHERME.POMP@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEAiLGKiHyfG//ZLcw91Cgc1/ZDnflZPxPyoekz0spMmPCGY/8CVlwBlHYb0g9kqTZQ==', N'3AN5LUEGLLA63DZ3JM4IUNJBUDW5FUUD', N'fab289a9-1fab-4f22-9b84-9dc18d149c38', NULL, 0, 0, NULL, 1, 0, 1, 3)
GO
INSERT [dbo].[Endereco] ([Id], [Cep], [Logradouro], [Numero], [Bairro], [Complemento], [Cidade], [AlunoId], [EstadoId]) VALUES (N'55baff28-ea12-40b0-b86f-153f8364d4fe', N'74640035', N'Avenida Vereador Germino Alves', 45, N'Setor Leste Vila Nova', N'Casa', N'Goiânia', N'd7ccdbf1-bcfe-40c0-a0f0-60e00c07b9ef', N'df0b7049-617c-446f-a8a3-a042378784e5')
GO
INSERT [dbo].[Endereco] ([Id], [Cep], [Logradouro], [Numero], [Bairro], [Complemento], [Cidade], [AlunoId], [EstadoId]) VALUES (N'b6d06674-46ab-4f9c-b3c1-6fddce06fbea', N'74640035', N'Avenida Vereador Germino Alves', 45, N'Setor Leste Vila Nova', N'Casa', N'Goiânia', N'2f413a30-e378-404c-8309-850572ac03da', N'df0b7049-617c-446f-a8a3-a042378784e5')
GO
INSERT [dbo].[Endereco] ([Id], [Cep], [Logradouro], [Numero], [Bairro], [Complemento], [Cidade], [AlunoId], [EstadoId]) VALUES (N'7e28ad93-ac1f-4bf4-9ce8-b629ad1b7025', N'52081518', N'2ª Travessa Antônio Pinto Lapa', 43, N'Alto José Bonifácio', N'Casa', N'Recife', N'c2843637-52ae-40b4-961f-c0ca4be1422f', N'df0b7049-617c-446f-a8a3-a042378784e5')
GO
INSERT [dbo].[Endereco] ([Id], [Cep], [Logradouro], [Numero], [Bairro], [Complemento], [Cidade], [AlunoId], [EstadoId]) VALUES (N'0e8f4e96-cb5c-4646-b5ee-db4ec9074861', N'74640035', N'Avenida Vereador Germino Alves', 525, N'Setor Leste Vila Nova', N'Casa', N'Goiânia', N'0d07621e-9c18-4277-b68f-f5c4125551ef', N'df0b7049-617c-446f-a8a3-a042378784e5')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'24031933-d6e0-4922-8f3e-0b3c30324593', N'Rondônia', N'RO')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'28bab9e4-ed5f-4325-b9a2-10c3cc242fc2', N'Amazonas', N'AM')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'349160b8-b41d-4e6a-80fe-1ab627485f4e', N'Distrito Federal', N'DF')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'c2acedc2-a3cf-4695-a8f1-2a7a93d94e1a', N'Bahia', N'BA')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'ef74f3f6-ef3b-4ef2-9453-396d73b0891b', N'Mato Grosso do Sul', N'MS')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'640970ce-e1f1-4314-a9df-47c76a2d67fe', N'Amapá', N'AP')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'3b74bede-7aa4-4292-9746-4b580440594e', N'Pernambuco', N'PE')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'78d792d2-3e1f-4cce-849f-5f9bf91f53c6', N'Paraíba', N'PB')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'cdfd6952-c90d-4f15-886f-611b89b6685a', N'Mato Grosso', N'MT')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'3a4a0780-4eae-4b1a-b107-685f3aa8a13f', N'Minas Gerais', N'MG')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'e5c4b9bd-812d-480f-b1ff-70fbcb0925ed', N'Tocantins', N'TO')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'ccbd97ae-6612-4d4c-9f04-7b96f5fce185', N'Piauí', N'PI')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'11b40f14-51d5-4da3-a295-7db3d129ac20', N'Maranhão', N'MA')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'defc1b08-de90-4ab5-ae61-7e519d8fcdf3', N'Acre', N'AC')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'ff3df197-252c-424a-83ac-7fa5e059f2cc', N'Sergipe', N'SE')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'99db698a-7f61-4f10-9451-80904aa5cce2', N'Rio de Janeiro', N'RJ')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'78564eb0-68e2-4e45-86bc-99915c383afc', N'Paraná', N'PR')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'df0b7049-617c-446f-a8a3-a042378784e5', N'Goiás', N'GO')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'6734eec6-6ab0-4542-b4c0-a2ae82b3681e', N'Roraima', N'RR')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'274200e1-9a6a-44f4-9388-a2ec36b331bb', N'Alagoas', N'AL')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'33e807cb-419d-4115-9988-b2aa187495fc', N'São Paulo', N'SP')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'9abe7da8-d0c8-4d27-b434-b3f10b03e1df', N'Santa Catarina', N'SC')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'351834e9-b5f4-4185-bc1c-ba8b23161ded', N'Rio Grande do Norte', N'RN')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'da74e75c-b523-46c2-bc69-bc3576cc1830', N'Rio Grande do Sul', N'RS')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'e92357f8-6e1c-4ead-807d-e3eebffed9c0', N'Pará', N'PA')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'ff6ee140-ece6-455b-8b52-f75ce5824a96', N'Espírito Santo', N'ES')
GO
INSERT [dbo].[Estado] ([Id], [Nome], [Sigla]) VALUES (N'cc9a0907-716a-46b4-8ae8-fa26c03091d9', N'Ceará', N'CE')
GO
INSERT [dbo].[Exercicio] ([Id], [Nome], [Descricao]) VALUES (N'7ef1f17f-9a7b-4c6f-a6ea-295557a33c03', N'Crucifixo', N'')
GO
INSERT [dbo].[Exercicio] ([Id], [Nome], [Descricao]) VALUES (N'a147d41d-2f3b-4661-947b-b759260c56dc', N'Supino Reto', N'')
GO
INSERT [dbo].[Exercicio] ([Id], [Nome], [Descricao]) VALUES (N'ae7132ea-19b3-4d07-948c-d27b2ea7510a', N'Agachamento', N'')
GO
INSERT [dbo].[ExercicioCarga] ([Id], [Carga], [DataCadastro], [ExercicioTreinoId]) VALUES (N'9304587a-89dc-4b2f-9491-06a13214f09d', 30, CAST(N'2021-05-18T17:56:13.3200000' AS DateTime2), N'9528c9f7-6c61-461c-ad6c-16b1624fe6d5')
GO
INSERT [dbo].[ExercicioTreino] ([Id], [ExercicioId], [TreinoId], [RepeticaoId]) VALUES (N'daf46ac5-7630-43f7-b5b3-1069301043ed', N'7ef1f17f-9a7b-4c6f-a6ea-295557a33c03', N'2c81eef3-060d-4f4b-8f0b-d3bce7a4e6e7', N'700d2191-d903-4e52-8ece-484879cb75bb')
GO
INSERT [dbo].[ExercicioTreino] ([Id], [ExercicioId], [TreinoId], [RepeticaoId]) VALUES (N'9528c9f7-6c61-461c-ad6c-16b1624fe6d5', N'a147d41d-2f3b-4661-947b-b759260c56dc', N'adae4528-acd7-4438-ac2a-ef67eed2fd39', N'700d2191-d903-4e52-8ece-484879cb75bb')
GO
INSERT [dbo].[ExercicioTreino] ([Id], [ExercicioId], [TreinoId], [RepeticaoId]) VALUES (N'f5287570-49bb-4284-b28a-35de5bf669d0', N'7ef1f17f-9a7b-4c6f-a6ea-295557a33c03', N'e75f0c50-aa37-40f6-a661-261ee9542027', N'700d2191-d903-4e52-8ece-484879cb75bb')
GO
INSERT [dbo].[ExercicioTreino] ([Id], [ExercicioId], [TreinoId], [RepeticaoId]) VALUES (N'cc11e9f9-dd01-4d11-a23f-3858dc17fedc', N'7ef1f17f-9a7b-4c6f-a6ea-295557a33c03', N'92f1e34e-867d-4a5e-89f0-a714b1e5341d', N'700d2191-d903-4e52-8ece-484879cb75bb')
GO
INSERT [dbo].[ExercicioTreino] ([Id], [ExercicioId], [TreinoId], [RepeticaoId]) VALUES (N'32d173ca-a34f-42f8-bcc0-5453a73c3bec', N'7ef1f17f-9a7b-4c6f-a6ea-295557a33c03', N'1fa441e9-77c9-4554-bcfb-101e2b599c18', N'700d2191-d903-4e52-8ece-484879cb75bb')
GO
INSERT [dbo].[ExercicioTreino] ([Id], [ExercicioId], [TreinoId], [RepeticaoId]) VALUES (N'a192377b-04c1-4102-a86a-593a86deecfd', N'7ef1f17f-9a7b-4c6f-a6ea-295557a33c03', N'c0ab88bc-a366-4ee6-a47d-100841cb1e38', N'700d2191-d903-4e52-8ece-484879cb75bb')
GO
INSERT [dbo].[ExercicioTreino] ([Id], [ExercicioId], [TreinoId], [RepeticaoId]) VALUES (N'0edbdafc-757c-4463-baed-598005edcece', N'7ef1f17f-9a7b-4c6f-a6ea-295557a33c03', N'db156209-0a33-4e2a-ad05-35ff16ce269c', N'700d2191-d903-4e52-8ece-484879cb75bb')
GO
INSERT [dbo].[ExercicioTreino] ([Id], [ExercicioId], [TreinoId], [RepeticaoId]) VALUES (N'6968d7a8-d7d3-43c4-98a6-7e5c5e46c376', N'7ef1f17f-9a7b-4c6f-a6ea-295557a33c03', N'4f55a44a-cbb5-4605-bbec-3beb79537c6e', N'700d2191-d903-4e52-8ece-484879cb75bb')
GO
INSERT [dbo].[ExercicioTreino] ([Id], [ExercicioId], [TreinoId], [RepeticaoId]) VALUES (N'59fab0df-fc1b-408f-adf5-822eec2f43f7', N'7ef1f17f-9a7b-4c6f-a6ea-295557a33c03', N'0cbe25f6-0ecd-4296-a102-f8ef62de749e', N'700d2191-d903-4e52-8ece-484879cb75bb')
GO
INSERT [dbo].[ExercicioTreino] ([Id], [ExercicioId], [TreinoId], [RepeticaoId]) VALUES (N'7617cdf4-24d5-4d1c-a025-887b9d3934c1', N'7ef1f17f-9a7b-4c6f-a6ea-295557a33c03', N'adae4528-acd7-4438-ac2a-ef67eed2fd39', N'e99a9f94-2008-4035-8058-f423b276f1bb')
GO
INSERT [dbo].[ExercicioTreino] ([Id], [ExercicioId], [TreinoId], [RepeticaoId]) VALUES (N'a85667af-e49b-4d33-a473-88decd8d9737', N'7ef1f17f-9a7b-4c6f-a6ea-295557a33c03', N'bf02f944-ed5c-4c6f-90c9-98df6ce13d38', N'700d2191-d903-4e52-8ece-484879cb75bb')
GO
INSERT [dbo].[ExercicioTreino] ([Id], [ExercicioId], [TreinoId], [RepeticaoId]) VALUES (N'fb777fce-527a-41c0-9db0-ddc2c6c32511', N'7ef1f17f-9a7b-4c6f-a6ea-295557a33c03', N'71fe196a-afd8-4b93-9504-c4b7aa2045bb', N'700d2191-d903-4e52-8ece-484879cb75bb')
GO
INSERT [dbo].[ExercicioTreino] ([Id], [ExercicioId], [TreinoId], [RepeticaoId]) VALUES (N'e335029a-feb4-4cd0-a2d4-f24f8acbefaa', N'a147d41d-2f3b-4661-947b-b759260c56dc', N'db156209-0a33-4e2a-ad05-35ff16ce269c', N'e99a9f94-2008-4035-8058-f423b276f1bb')
GO
INSERT [dbo].[Professor] ([Id], [Nome], [CREF], [Email], [DataCadastro], [DataExcluido], [Excluido]) VALUES (N'8e1f0a33-9ac6-4eea-877e-28394a8bb1c0', N'Marcos Paulo', 1234, N'marcos.amaral@gmail.com', CAST(N'2021-05-17T20:56:14.940' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Professor] ([Id], [Nome], [CREF], [Email], [DataCadastro], [DataExcluido], [Excluido]) VALUES (N'0d53b274-cad7-416c-9a5f-99a2b632a2ed', N'Eduardo', 2344, N'eduardo.amaral@gmail.com', CAST(N'2021-05-17T20:55:52.873' AS DateTime), NULL, 0)
GO
INSERT [dbo].[RefreshTokens] ([Id], [Username], [Token], [ExpirationDate]) VALUES (N'd6f7fcb9-a9ca-4dd8-b12c-13fd5ab42dfb', N'emanu@gmail.com', N'ba4c3281-37eb-4856-b2ea-7638ec317e1c', CAST(N'2021-05-19T08:35:36.2853186' AS DateTime2))
GO
INSERT [dbo].[RefreshTokens] ([Id], [Username], [Token], [ExpirationDate]) VALUES (N'cb727e33-cddf-4802-90f0-3f04373de3c5', N'mariana.isabelle@gmail.com', N'2fb2fa6a-965f-4a61-bb2f-3af7ad3a8b63', CAST(N'2021-05-19T04:56:00.8631086' AS DateTime2))
GO
INSERT [dbo].[RefreshTokens] ([Id], [Username], [Token], [ExpirationDate]) VALUES (N'9cfb255b-b3c8-49ec-9375-5f34a6875e8d', N'nathan.felipe@gmail.com', N'523a2435-d114-4875-93b4-3227a3f2442c', CAST(N'2021-05-19T02:42:22.4003664' AS DateTime2))
GO
INSERT [dbo].[RefreshTokens] ([Id], [Username], [Token], [ExpirationDate]) VALUES (N'8d097f9c-13c8-4b31-8393-6ca213b7bc71', N'eduardo.amaral@gmail.com', N'30db3c27-eb41-4c1c-908d-ca21f36f6c2e', CAST(N'2021-05-19T04:51:30.4866140' AS DateTime2))
GO
INSERT [dbo].[RefreshTokens] ([Id], [Username], [Token], [ExpirationDate]) VALUES (N'9610d1d6-1745-4296-bf67-dfe3d19a582e', N'guilherme.pomp@gmail.com', N'ac802f23-efd6-4322-8f4b-a9275132e30a', CAST(N'2021-05-19T05:32:42.5814999' AS DateTime2))
GO
INSERT [dbo].[RefreshTokens] ([Id], [Username], [Token], [ExpirationDate]) VALUES (N'c044fbdb-143d-4db5-9a11-ecc1afdee16f', N'marcos.amaral@gmail.com', N'696893c4-bb7e-4ed7-8455-22874e549f5d', CAST(N'2021-05-19T08:40:49.4669770' AS DateTime2))
GO
INSERT [dbo].[Repeticao] ([Id], [Descricao]) VALUES (N'700d2191-d903-4e52-8ece-484879cb75bb', N'4x12')
GO
INSERT [dbo].[Repeticao] ([Id], [Descricao]) VALUES (N'241cd730-7ba4-4ded-8839-7e8543f0ea54', N'3x12')
GO
INSERT [dbo].[Repeticao] ([Id], [Descricao]) VALUES (N'e99a9f94-2008-4035-8058-f423b276f1bb', N'3x10')
GO
INSERT [dbo].[SecurityKeys] ([Id], [Parameters], [KeyId], [Type], [Algorithm], [CreationDate]) VALUES (N'a6dd498e-f3e6-4a70-94b2-9dd453de1b15', N'{"AdditionalData":{},"Alg":"ES256","Crv":"P-256","D":"jNOUG-a76p37qpQCuXHemgug0-o6aUGIJ73mZazxIVY","KeyId":"TJIa9shzFZbsRfro3NJaag","KeyOps":[],"Kid":"TJIa9shzFZbsRfro3NJaag","Kty":"EC","Use":"sig","X":"6qOsChqvi8BQFvxNqahvPwbRtSkZr31Y1BKI_ppYQFM","X5c":[],"Y":"J_KOzrhWHs5QT18cpuzAyjxvgFZck7zjiu3apSb64SU","KeySize":256,"HasPrivateKey":true,"CryptoProviderFactory":{"CryptoProviderCache":{},"CacheSignatureProviders":true}}', N'TJIa9shzFZbsRfro3NJaag', N'EC', N'ES256', CAST(N'2021-05-17T20:54:39.8614613' AS DateTime2))
GO
INSERT [dbo].[Tipo] ([Id], [Descricao]) VALUES (N'ab4c848b-5e7c-4290-8867-0535ed4f8154', N'Menu')
GO
INSERT [dbo].[Tipo] ([Id], [Descricao]) VALUES (N'7fc734e9-266f-4b25-96d2-9371e0f7b2db', N'Sub Menu')
GO
INSERT [dbo].[Treino] ([Id], [AlunoId], [DataCadastro], [Nome]) VALUES (N'c0ab88bc-a366-4ee6-a47d-100841cb1e38', N'2f413a30-e378-404c-8309-850572ac03da', CAST(N'2021-05-18T15:41:39.5033333' AS DateTime2), N'Treino de Força')
GO
INSERT [dbo].[Treino] ([Id], [AlunoId], [DataCadastro], [Nome]) VALUES (N'1fa441e9-77c9-4554-bcfb-101e2b599c18', N'2f413a30-e378-404c-8309-850572ac03da', CAST(N'2021-05-18T15:41:57.5733333' AS DateTime2), N'Treino da PF 1')
GO
INSERT [dbo].[Treino] ([Id], [AlunoId], [DataCadastro], [Nome]) VALUES (N'e75f0c50-aa37-40f6-a661-261ee9542027', N'2f413a30-e378-404c-8309-850572ac03da', CAST(N'2021-05-18T15:41:35.2500000' AS DateTime2), N'Treino de Emagrecimento')
GO
INSERT [dbo].[Treino] ([Id], [AlunoId], [DataCadastro], [Nome]) VALUES (N'db156209-0a33-4e2a-ad05-35ff16ce269c', N'2f413a30-e378-404c-8309-850572ac03da', CAST(N'2021-05-17T21:23:51.7066667' AS DateTime2), NULL)
GO
INSERT [dbo].[Treino] ([Id], [AlunoId], [DataCadastro], [Nome]) VALUES (N'4f55a44a-cbb5-4605-bbec-3beb79537c6e', N'2f413a30-e378-404c-8309-850572ac03da', CAST(N'2021-05-18T15:42:03.5933333' AS DateTime2), N'Treino da PF 3')
GO
INSERT [dbo].[Treino] ([Id], [AlunoId], [DataCadastro], [Nome]) VALUES (N'bf02f944-ed5c-4c6f-90c9-98df6ce13d38', N'2f413a30-e378-404c-8309-850572ac03da', CAST(N'2021-05-18T15:41:23.1866667' AS DateTime2), N'Treino de Hipertrofia')
GO
INSERT [dbo].[Treino] ([Id], [AlunoId], [DataCadastro], [Nome]) VALUES (N'92f1e34e-867d-4a5e-89f0-a714b1e5341d', N'2f413a30-e378-404c-8309-850572ac03da', CAST(N'2021-05-18T15:41:48.0466667' AS DateTime2), N'Treino da PF')
GO
INSERT [dbo].[Treino] ([Id], [AlunoId], [DataCadastro], [Nome]) VALUES (N'71fe196a-afd8-4b93-9504-c4b7aa2045bb', N'2f413a30-e378-404c-8309-850572ac03da', CAST(N'2021-05-18T15:39:45.1966667' AS DateTime2), NULL)
GO
INSERT [dbo].[Treino] ([Id], [AlunoId], [DataCadastro], [Nome]) VALUES (N'2c81eef3-060d-4f4b-8f0b-d3bce7a4e6e7', N'2f413a30-e378-404c-8309-850572ac03da', CAST(N'2021-05-18T15:42:00.8866667' AS DateTime2), N'Treino da PF 2')
GO
INSERT [dbo].[Treino] ([Id], [AlunoId], [DataCadastro], [Nome]) VALUES (N'adae4528-acd7-4438-ac2a-ef67eed2fd39', N'd7ccdbf1-bcfe-40c0-a0f0-60e00c07b9ef', CAST(N'2021-05-18T17:52:01.4700000' AS DateTime2), N'Treino atualizardo')
GO
INSERT [dbo].[Treino] ([Id], [AlunoId], [DataCadastro], [Nome]) VALUES (N'0cbe25f6-0ecd-4296-a102-f8ef62de749e', N'2f413a30-e378-404c-8309-850572ac03da', CAST(N'2021-05-18T15:41:44.1733333' AS DateTime2), N'Treino de Aman')
GO
/****** Object:  Index [IX_Aluno_EnderecoId]    Script Date: 19/05/2021 22:24:02 ******/
CREATE NONCLUSTERED INDEX [IX_Aluno_EnderecoId] ON [dbo].[Aluno]
(
	[EnderecoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Aluno_ProfessorId]    Script Date: 19/05/2021 22:24:02 ******/
CREATE NONCLUSTERED INDEX [IX_Aluno_ProfessorId] ON [dbo].[Aluno]
(
	[ProfessorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AnamneseResposta_AnamnesePerguntaId]    Script Date: 19/05/2021 22:24:02 ******/
CREATE NONCLUSTERED INDEX [IX_AnamneseResposta_AnamnesePerguntaId] ON [dbo].[AnamneseResposta]
(
	[AnamnesePerguntaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 19/05/2021 22:24:02 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 19/05/2021 22:24:02 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 19/05/2021 22:24:02 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 19/05/2021 22:24:02 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 19/05/2021 22:24:02 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 19/05/2021 22:24:02 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 19/05/2021 22:24:02 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Biometria_AlunoId]    Script Date: 19/05/2021 22:24:02 ******/
CREATE NONCLUSTERED INDEX [IX_Biometria_AlunoId] ON [dbo].[Biometria]
(
	[AlunoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Endereco_EstadoId]    Script Date: 19/05/2021 22:24:02 ******/
CREATE NONCLUSTERED INDEX [IX_Endereco_EstadoId] ON [dbo].[Endereco]
(
	[EstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ExercicioCarga_ExercicioTreinoId]    Script Date: 19/05/2021 22:24:02 ******/
CREATE NONCLUSTERED INDEX [IX_ExercicioCarga_ExercicioTreinoId] ON [dbo].[ExercicioCarga]
(
	[ExercicioTreinoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IDX_Treino]    Script Date: 19/05/2021 22:24:02 ******/
CREATE NONCLUSTERED INDEX [IDX_Treino] ON [dbo].[ExercicioTreino]
(
	[TreinoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ExercicioTreino_ExercicioId]    Script Date: 19/05/2021 22:24:02 ******/
CREATE NONCLUSTERED INDEX [IX_ExercicioTreino_ExercicioId] ON [dbo].[ExercicioTreino]
(
	[ExercicioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ExercicioTreino_RepeticaoId]    Script Date: 19/05/2021 22:24:02 ******/
CREATE NONCLUSTERED INDEX [IX_ExercicioTreino_RepeticaoId] ON [dbo].[ExercicioTreino]
(
	[RepeticaoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Ficha_AlunoId]    Script Date: 19/05/2021 22:24:02 ******/
CREATE NONCLUSTERED INDEX [IX_Ficha_AlunoId] ON [dbo].[Ficha]
(
	[AlunoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Ficha_AnamneseRespostaId]    Script Date: 19/05/2021 22:24:02 ******/
CREATE NONCLUSTERED INDEX [IX_Ficha_AnamneseRespostaId] ON [dbo].[Ficha]
(
	[AnamneseRespostaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IDX_Tipo]    Script Date: 19/05/2021 22:24:02 ******/
CREATE NONCLUSTERED INDEX [IDX_Tipo] ON [dbo].[Permissao]
(
	[TipoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsActive]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ((0)) FOR [UserType]
GO
ALTER TABLE [dbo].[Aluno]  WITH CHECK ADD  CONSTRAINT [FK_Aluno_Endereco_EnderecoId] FOREIGN KEY([EnderecoId])
REFERENCES [dbo].[Endereco] ([Id])
GO
ALTER TABLE [dbo].[Aluno] CHECK CONSTRAINT [FK_Aluno_Endereco_EnderecoId]
GO
ALTER TABLE [dbo].[Aluno]  WITH CHECK ADD  CONSTRAINT [FK_Aluno_Professor_ProfessorId] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([Id])
GO
ALTER TABLE [dbo].[Aluno] CHECK CONSTRAINT [FK_Aluno_Professor_ProfessorId]
GO
ALTER TABLE [dbo].[AnamneseResposta]  WITH CHECK ADD  CONSTRAINT [FK_AnamneseResposta_AnamnesePergunta_AnamnesePerguntaId] FOREIGN KEY([AnamnesePerguntaId])
REFERENCES [dbo].[AnamnesePergunta] ([Id])
GO
ALTER TABLE [dbo].[AnamneseResposta] CHECK CONSTRAINT [FK_AnamneseResposta_AnamnesePergunta_AnamnesePerguntaId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Biometria]  WITH CHECK ADD  CONSTRAINT [FK_Biometria_Aluno_AlunoId] FOREIGN KEY([AlunoId])
REFERENCES [dbo].[Aluno] ([Id])
GO
ALTER TABLE [dbo].[Biometria] CHECK CONSTRAINT [FK_Biometria_Aluno_AlunoId]
GO
ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD  CONSTRAINT [FK_Endereco_Estado_EstadoId] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estado] ([Id])
GO
ALTER TABLE [dbo].[Endereco] CHECK CONSTRAINT [FK_Endereco_Estado_EstadoId]
GO
ALTER TABLE [dbo].[ExercicioCarga]  WITH CHECK ADD  CONSTRAINT [FK_ExercicioCarga_ExercicioTreino_ExercicioTreinoId] FOREIGN KEY([ExercicioTreinoId])
REFERENCES [dbo].[ExercicioTreino] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExercicioCarga] CHECK CONSTRAINT [FK_ExercicioCarga_ExercicioTreino_ExercicioTreinoId]
GO
ALTER TABLE [dbo].[ExercicioTreino]  WITH CHECK ADD  CONSTRAINT [FK_ExercicioTreino_Exercicio_ExercicioId] FOREIGN KEY([ExercicioId])
REFERENCES [dbo].[Exercicio] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExercicioTreino] CHECK CONSTRAINT [FK_ExercicioTreino_Exercicio_ExercicioId]
GO
ALTER TABLE [dbo].[ExercicioTreino]  WITH CHECK ADD  CONSTRAINT [FK_ExercicioTreino_Repeticao_RepeticaoId] FOREIGN KEY([RepeticaoId])
REFERENCES [dbo].[Repeticao] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExercicioTreino] CHECK CONSTRAINT [FK_ExercicioTreino_Repeticao_RepeticaoId]
GO
ALTER TABLE [dbo].[ExercicioTreino]  WITH CHECK ADD  CONSTRAINT [FK_ExercicioTreino_Treino_TreinoId] FOREIGN KEY([TreinoId])
REFERENCES [dbo].[Treino] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExercicioTreino] CHECK CONSTRAINT [FK_ExercicioTreino_Treino_TreinoId]
GO
ALTER TABLE [dbo].[Ficha]  WITH CHECK ADD  CONSTRAINT [FK_Ficha_Aluno_AlunoId] FOREIGN KEY([AlunoId])
REFERENCES [dbo].[Aluno] ([Id])
GO
ALTER TABLE [dbo].[Ficha] CHECK CONSTRAINT [FK_Ficha_Aluno_AlunoId]
GO
ALTER TABLE [dbo].[Ficha]  WITH CHECK ADD  CONSTRAINT [FK_Ficha_AnamneseResposta_AnamneseRespostaId] FOREIGN KEY([AnamneseRespostaId])
REFERENCES [dbo].[AnamneseResposta] ([Id])
GO
ALTER TABLE [dbo].[Ficha] CHECK CONSTRAINT [FK_Ficha_AnamneseResposta_AnamneseRespostaId]
GO
ALTER TABLE [dbo].[Permissao]  WITH CHECK ADD  CONSTRAINT [FK_Permissao_Tipo_TipoId] FOREIGN KEY([TipoId])
REFERENCES [dbo].[Tipo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Permissao] CHECK CONSTRAINT [FK_Permissao_Tipo_TipoId]
GO
USE [master]
GO
ALTER DATABASE [personal] SET  READ_WRITE 
GO
