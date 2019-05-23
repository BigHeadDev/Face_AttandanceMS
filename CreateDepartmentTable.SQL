USE [Face_AttendanceDB]
GO

/****** Object:  Table [dbo].[DepartmentTable]    Script Date: 2019/5/23 星期四 20:16:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DepartmentTable](
	[Did] [int] NOT NULL,
	[Dname] [nvarchar](50) NOT NULL,
	[Dintroduce] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DepartmentTable] PRIMARY KEY CLUSTERED 
(
	[Did] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

