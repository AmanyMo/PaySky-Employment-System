USE [Test]
GO
/****** Object:  Table [dbo].[Applicant_Vacancy]    Script Date: 2/15/2025 10:59:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applicant_Vacancy](
	[UserId] [int] NOT NULL,
	[VacancyId] [int] NOT NULL,
	[AppliedDate] [date] NOT NULL,
 CONSTRAINT [PK_Applicant_Vacancy] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[VacancyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2/15/2025 10:59:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/15/2025 10:59:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[HashPassword] [nvarchar](max) NOT NULL,
	[CreatedAt] [date] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vacancies]    Script Date: 2/15/2025 10:59:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vacancies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[ExpiryDate] [date] NOT NULL,
	[MaxApplicant] [int] NOT NULL,
	[EmployerId] [int] NULL,
 CONSTRAINT [PK_Vacancies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Applicant_Vacancy]  WITH CHECK ADD  CONSTRAINT [FK_Applicant_Vacancy_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Applicant_Vacancy] CHECK CONSTRAINT [FK_Applicant_Vacancy_Users]
GO
ALTER TABLE [dbo].[Applicant_Vacancy]  WITH CHECK ADD  CONSTRAINT [FK_Applicant_Vacancy_Vacancies] FOREIGN KEY([VacancyId])
REFERENCES [dbo].[Vacancies] ([Id])
GO
ALTER TABLE [dbo].[Applicant_Vacancy] CHECK CONSTRAINT [FK_Applicant_Vacancy_Vacancies]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
ALTER TABLE [dbo].[Vacancies]  WITH CHECK ADD  CONSTRAINT [FK_Vacancies_Users] FOREIGN KEY([EmployerId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Vacancies] CHECK CONSTRAINT [FK_Vacancies_Users]
GO
