/****** Object:  Table [dbo].[Networks]    Script Date: 11/18/2009 15:13:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Networks]') AND type in (N'U'))
DROP TABLE [dbo].[Networks]
GO
/****** Object:  Table [dbo].[Episodes]    Script Date: 11/18/2009 15:13:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Episodes]') AND type in (N'U'))
DROP TABLE [dbo].[Episodes]
GO
/****** Object:  Table [dbo].[Programs]    Script Date: 11/18/2009 15:13:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Programs]') AND type in (N'U'))
DROP TABLE [dbo].[Programs]
GO
/****** Object:  Table [dbo].[Dayparts]    Script Date: 11/18/2009 15:13:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dayparts]') AND type in (N'U'))
DROP TABLE [dbo].[Dayparts]
GO
/****** Object:  Table [dbo].[EpisodeTweets]    Script Date: 11/18/2009 15:13:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EpisodeTweets]') AND type in (N'U'))
DROP TABLE [dbo].[EpisodeTweets]
GO
/****** Object:  Table [dbo].[Seasons]    Script Date: 11/18/2009 15:13:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Seasons]') AND type in (N'U'))
DROP TABLE [dbo].[Seasons]
GO
/****** Object:  Table [dbo].[Seasons]    Script Date: 11/18/2009 15:13:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Seasons]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Seasons](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SeasonNumber] [float] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Program_id] [int] NULL,
	[Created_at] [datetime] NULL,
	[Updated_at] [datetime] NULL,
 CONSTRAINT [PK_Seasons] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[EpisodeTweets]    Script Date: 11/18/2009 15:13:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EpisodeTweets]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EpisodeTweets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TweetText] [nvarchar](145) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Episode_id] [int] NULL,
	[Created_at] [datetime] NULL,
	[Updated_at] [datetime] NULL,
 CONSTRAINT [PK_EpisodeTweets] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Dayparts]    Script Date: 11/18/2009 15:13:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dayparts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Dayparts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DaypartName] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Created_at] [datetime] NULL,
	[Updated_at] [datetime] NULL,
 CONSTRAINT [PK_Dayparts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Programs]    Script Date: 11/18/2009 15:13:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Programs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Programs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProgramName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Network_id] [int] NULL,
	[Daypart_id] [int] NULL,
	[Created_at] [datetime] NULL,
	[Updated_at] [datetime] NULL,
 CONSTRAINT [PK_Programs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Episodes]    Script Date: 11/18/2009 15:13:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Episodes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Episodes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EpisodeName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AirDate] [datetime] NULL,
	[StartTime] [datetime] NULL,
	[Duration] [float] NULL,
	[HHLD_Proj] [float] NULL,
	[Season_id] [int] NULL,
	[Created_at] [datetime] NULL,
	[Updated_at] [datetime] NULL,
 CONSTRAINT [PK_Episodes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Networks]    Script Date: 11/18/2009 15:13:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Networks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Networks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NetworkName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NetworkInitials] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Created_at] [datetime] NULL,
	[Updated_at] [datetime] NULL,
 CONSTRAINT [PK_Networks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
