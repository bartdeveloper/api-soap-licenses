USE [API_License]
GO
/****** Object:  Table [dbo].[companies]    Script Date: 2018-12-10 18:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[companies](
	[cmp_id] [int] IDENTITY(1,1) NOT NULL,
	[cmp_name] [varchar](50) NOT NULL,
	[cmp_nip] [varchar](20) NOT NULL,
 CONSTRAINT [PK_companies] PRIMARY KEY CLUSTERED 
(
	[cmp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[licenses]    Script Date: 2018-12-10 18:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[licenses](
	[lic_id] [int] IDENTITY(1,1) NOT NULL,
	[lic_cmpid] [int] NOT NULL,
	[lic_valid] [bit] NOT NULL,
 CONSTRAINT [PK_licenses] PRIMARY KEY CLUSTERED 
(
	[lic_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[versions]    Script Date: 2018-12-10 18:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[versions](
	[ver_id] [int] IDENTITY(1,1) NOT NULL,
	[ver_name] [varchar](50) NOT NULL,
	[ver_version] [varchar](10) NOT NULL,
 CONSTRAINT [PK_versions] PRIMARY KEY CLUSTERED 
(
	[ver_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[licenses]  WITH CHECK ADD  CONSTRAINT [FK_licenses_companies] FOREIGN KEY([lic_cmpid])
REFERENCES [dbo].[companies] ([cmp_id])
GO
ALTER TABLE [dbo].[licenses] CHECK CONSTRAINT [FK_licenses_companies]
GO
