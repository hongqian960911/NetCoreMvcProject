--------------------------------SQL升级脚本---------------------------------
--                                                                        --
-- 1.脚本创建：蒋新敏/2020-04-01                                          --
-- 2.脚本内容：                                                           --
--      ALERT TABLE billmanage add splitguid nvarchar(50)                 --
--                                                                        --
--                                                                        --
----------------------------------------------------------------------------


--创建人：张曼曼 创建时间：2020-04-02 16:30
ALTER TABLE billmanage ADD splitguid NVARCHAR(50) NULL

--创建人：蒋新敏 创建时间：2020-04-16 13:30
alter table summary add modelstatus nvarchar(50)

--创建人：张曼曼 创建时间：2020-04-17 11:57
alter table billmanage add splitno nvarchar(50)

--创建人：洪仟 创建时间：2020-04-21 14:38
alter table scwarehousedetail alter column initialqty decimal(18,2)
alter table scwarehousedetail add summaryguid nvarchar(50)
alter table scfactorydetail add summaryguid nvarchar(50)
GO
CREATE TABLE [dbo].[scfactorysummary](
	[guid] [nchar](50) NOT NULL,
	[sceneguid] [nchar](50) NULL,
	[plantid] [nchar](50) NULL,
	[fixedcost] [decimal](18, 2) NULL,
	[productioncost] [decimal](18, 2) NULL,
	[opencost] [decimal](18, 2) NULL,
	[closecost] [decimal](18, 2) NULL,
	[createuser] [nchar](50) NULL,
	[createdate] [nchar](50) NULL,
 CONSTRAINT [PK_scfactorysummary] PRIMARY KEY CLUSTERED 
(
	[guid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[scwarehousesummary](
	[guid] [nchar](50) NOT NULL,
	[sceneguid] [nchar](50) NULL,
	[warehouseid] [nchar](50) NULL,
	[fixedcost] [decimal](18, 2) NULL,
	[opencost] [decimal](18, 2) NULL,
	[closecost] [decimal](18, 2) NULL,
	[inboundcost] [decimal](18, 2) NULL,
	[outboundcost] [decimal](18, 2) NULL,
	[invholdingcost] [decimal](18, 2) NULL,
	[createuser] [nchar](50) NULL,
	[createdate] [nchar](50) NULL,
 CONSTRAINT [PK_scwarehousesummary] PRIMARY KEY CLUSTERED 
(
	[guid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


--创建人：张曼曼 创建时间：2020-04-29 13:51
alter table billmanage add timetype nvarchar(50)

--创建人：洪仟 创建时间：2020-05-06 14:10
alter table scscene add unitdemandpenalty nvarchar(50)

--创建人：张曼曼 创建时间：2020-05-06 9：49

CREATE TABLE [dbo].[importlog](
	[guid] [nvarchar](50) NOT NULL,
	[createuser] [nvarchar](50) NOT NULL,
	[createdate] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[count] [int] NOT NULL,
 CONSTRAINT [PK_importlog] PRIMARY KEY CLUSTERED 
(
	[guid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]