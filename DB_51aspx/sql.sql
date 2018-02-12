USE [supermarketdb]
GO
/****** Object:  User [renzhenhua]    Script Date: 05/12/2017 16:36:26 ******/
CREATE USER [renzhenhua] FOR LOGIN [renzhenhua] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[supplierInfo]    Script Date: 05/12/2017 16:36:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[supplierInfo](
	[supplierName] [nvarchar](50) NOT NULL,
	[supplierLawyer] [nvarchar](4) NULL,
	[supplierTelephone] [varchar](11) NULL,
	[supplierAddress] [nvarchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sellInfo]    Script Date: 05/12/2017 16:36:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sellInfo](
	[sellInfoId] [int] IDENTITY(1,1) NOT NULL,
	[sellNo] [varchar](30) NOT NULL,
	[goodNo] [varchar](20) NULL,
	[price] [float] NULL,
	[number] [int] NULL,
	[totalPrice] [float] NULL,
	[sellTime] [datetime] NULL,
	[employeeNo] [varchar](20) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sellBackInfo]    Script Date: 05/12/2017 16:36:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sellBackInfo](
	[sellBackId] [int] IDENTITY(1,1) NOT NULL,
	[sellNo] [varchar](20) NULL,
	[goodNo] [varchar](20) NULL,
	[price] [float] NULL,
	[number] [int] NULL,
	[totalPrice] [float] NULL,
	[sellBackReason] [text] NULL,
	[sellBackTime] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[goodStockInfo]    Script Date: 05/12/2017 16:36:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[goodStockInfo](
	[goodNo] [varchar](50) NOT NULL,
	[goodCount] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[goodInfo]    Script Date: 05/12/2017 16:36:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[goodInfo](
	[goodNo] [varchar](20) NOT NULL,
	[goodClassId] [int] NULL,
	[goodName] [nvarchar](30) NOT NULL,
	[goodUnit] [nvarchar](2) NULL,
	[goodModel] [nvarchar](20) NULL,
	[goodSpecs] [nvarchar](20) NULL,
	[goodPrice] [float] NULL,
	[goodPlace] [nvarchar](50) NULL,
	[goodMemo] [char](10) NULL,
	[goodAddTime] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[goodClassInfo]    Script Date: 05/12/2017 16:36:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[goodClassInfo](
	[goodClassId] [int] IDENTITY(1,1) NOT NULL,
	[goodClassName] [nvarchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[goodCartInfo]    Script Date: 05/12/2017 16:36:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[goodCartInfo](
	[goodCartId] [int] IDENTITY(1,1) NOT NULL,
	[employeeNo] [varchar](20) NULL,
	[goodNo] [varchar](20) NULL,
	[goodCount] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[employeeSellResult]    Script Date: 05/12/2017 16:36:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[employeeSellResult](
	[employeeNo] [varchar](20) NOT NULL,
	[employeeName] [nvarchar](20) NULL,
	[employeeSellMoney] [float] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[employeeInfo]    Script Date: 05/12/2017 16:36:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[employeeInfo](
	[employeeNo] [varchar](20) NOT NULL,
	[employeeName] [nvarchar](20) NULL,
	[employeePassword] [varchar](30) NULL,
	[employeeSex] [nchar](1) NULL,
	[employeeBirthday] [datetime] NULL,
	[employeeEducationId] [int] NULL,
	[employeeHomeTel] [varchar](20) NULL,
	[employeeMobile] [varchar](20) NULL,
	[employeeCard] [varchar](20) NULL,
	[employeeEmail] [varchar](30) NULL,
	[employeeAddress] [nvarchar](80) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[educationInfo]    Script Date: 05/12/2017 16:36:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[educationInfo](
	[educationId] [int] IDENTITY(1,1) NOT NULL,
	[educationName] [nvarchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[buyInfo]    Script Date: 05/12/2017 16:36:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[buyInfo](
	[buyId] [int] IDENTITY(1,1) NOT NULL,
	[goodNo] [varchar](20) NULL,
	[supplierName] [nvarchar](50) NULL,
	[price] [float] NULL,
	[number] [int] NULL,
	[totalPrice] [float] NULL,
	[buyDate] [datetime] NULL,
	[addTime] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[buyBackInfo]    Script Date: 05/12/2017 16:36:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[buyBackInfo](
	[buyBackId] [int] IDENTITY(1,1) NOT NULL,
	[goodNo] [varchar](20) NULL,
	[supplierName] [varchar](50) NULL,
	[price] [float] NULL,
	[number] [int] NULL,
	[totalPrice] [float] NULL,
	[buyBackDate] [datetime] NULL,
	[buyBackReason] [text] NULL,
	[buyBackAddTime] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[admin]    Script Date: 05/12/2017 16:36:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[admin](
	[adminUsername] [varchar](20) NOT NULL,
	[adminPassword] [varchar](32) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[admin] ([adminUsername], [adminPassword]) VALUES (N'admin', N'admin')
