USE [ADb]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 16-Mar-23 4:28:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[first_name] [varchar](100) NULL,
	[last_name] [varchar](100) NULL,
	[dob] [date] NOT NULL,
	[address] [varchar](500) NULL,
	[gender] [char](1) NULL,
	[emp_id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[emp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


