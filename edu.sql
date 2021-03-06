USE [educate]
GO
/****** Object:  Table [dbo].[course_teacher_relation]    Script Date: 2021/3/18 17:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[course_teacher_relation](
	[course_id] [int] NOT NULL,
	[teacher_id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[courses]    Script Date: 2021/3/18 17:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[courses](
	[course_id] [int] NOT NULL,
	[course_name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](300) NULL,
	[is_publish] [tinyint] NOT NULL,
	[course_cover] [nvarchar](50) NOT NULL,
	[course_url] [varchar](100) NULL,
 CONSTRAINT [PK_courses] PRIMARY KEY CLUSTERED 
(
	[course_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[platforms]    Script Date: 2021/3/18 17:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[platforms](
	[platform_id] [int] NOT NULL,
	[platform_name] [nvarchar](100) NOT NULL,
	[is_validation] [tinyint] NOT NULL,
 CONSTRAINT [PK_platforms] PRIMARY KEY CLUSTERED 
(
	[platform_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[play_record]    Script Date: 2021/3/18 17:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[play_record](
	[course_id] [int] NOT NULL,
	[platform_id] [int] NOT NULL,
	[play_count] [tinyint] NOT NULL,
	[is_raised] [tinyint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 2021/3/18 17:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] NOT NULL,
	[user_name] [nvarchar](100) NOT NULL,
	[real_name] [nvarchar](100) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[is_validation] [tinyint] NOT NULL,
	[is_can_login] [tinyint] NOT NULL,
	[is_teacher] [tinyint] NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[course_teacher_relation]  WITH CHECK ADD  CONSTRAINT [FK_course_teacher_relation_courses] FOREIGN KEY([course_id])
REFERENCES [dbo].[courses] ([course_id])
GO
ALTER TABLE [dbo].[course_teacher_relation] CHECK CONSTRAINT [FK_course_teacher_relation_courses]
GO
ALTER TABLE [dbo].[course_teacher_relation]  WITH CHECK ADD  CONSTRAINT [FK_course_teacher_relation_users] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[course_teacher_relation] CHECK CONSTRAINT [FK_course_teacher_relation_users]
GO
ALTER TABLE [dbo].[play_record]  WITH CHECK ADD  CONSTRAINT [FK_play_record_courses] FOREIGN KEY([course_id])
REFERENCES [dbo].[courses] ([course_id])
GO
ALTER TABLE [dbo].[play_record] CHECK CONSTRAINT [FK_play_record_courses]
GO
