/*
use master
go
if exists (select * from master.dbo.sysdatabases where name='sitedb')
drop database sitedb
go*/
--create database sitedb
--go

use sitedb
go

-----------------------------------------------------------------------------------------
-- Schema

if exists (select * from sys.tables where name='tblAccount')
Drop TABLE [dbo].[tblAccount]
Go

if not exists (select * from sys.tables where name='tblAccount')
CREATE TABLE [dbo].[tblAccount](
	[accId] [uniqueidentifier] Not NULL,
	[accFirstName] [nvarchar](50) Not NULL,
	[accLastName] [nvarchar](50) Not NULL,
	[accUserName] [nvarchar](50) Not NULL,
	[accPwd] [nvarchar](50) Not NULL
) ON [PRIMARY]
GO

if  exists (select * from sys.tables where name='tblAccountType')
Drop TABLE [dbo].[tblAccountType]
Go

if not exists (select * from sys.tables where name='tblAccountType')
CREATE TABLE [dbo].[tblAccountType](
	[actId] [uniqueidentifier] NOT NULL,
	[actName] [nvarchar](50) NOT NULL,
	[actKey] [varchar](10) NOT NULL,
 CONSTRAINT [PK_tblAccountType] PRIMARY KEY CLUSTERED 
(
	[actId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

if  exists (select * from sys.tables where name='tblAccountTypeIndex')
Drop TABLE [dbo].[tblAccountTypeIndex]
Go

if not exists (select * from sys.tables where name='tblAccountTypeIndex')
CREATE TABLE [dbo].[tblAccountTypeIndex](
	[atiId] [int] identity (1,1) NOT NULL,
	[atiAccount] [uniqueidentifier] NOT NULL,
	[atiAccountType] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_tblAccountTypeIndex] PRIMARY KEY CLUSTERED 
(
	[atiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

if exists (select * from sys.objects where name='tblAuditType')
Drop TABLE [dbo].[tblAuditType]
Go

if not exists (select * from sys.objects where name='tblAuditType')
CREATE TABLE [dbo].[tblAuditType](
	[autId] [uniqueidentifier] NOT NULL,
	[autName] [nvarchar](50) NOT NULL,
	[autKey] [varchar](10) NOT NULL
) ON [PRIMARY]
GO


if exists (select * from sys.objects where name='tblAccountAudit')
Drop TABLE [dbo].[tblAccountAudit]
Go

if not exists (select * from sys.objects where name='tblAccountAudit')
CREATE TABLE [dbo].[tblAccountAudit](
	[acaId] [int] identity (1,1) NOT NULL,
	[acaDT] [datetime] NOT NULL,
	[acaAccount] [uniqueidentifier] NOT NULL,
	[acaAuditType] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_tblAccountAudit] PRIMARY KEY CLUSTERED 
(
	[acaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


if exists (select * from sys.objects where name='tblPettyCashCategory')
Drop TABLE [dbo].[tblPettyCashCategory]
Go

if not exists (select * from sys.objects where name='tblPettyCashCategory')
CREATE TABLE [dbo].[tblPettyCashCategory](
	[pccId] [uniqueidentifier] NOT NULL,
	[ppcName] [nvarchar](50) NOT NULL,
	[pccKey] [nchar](10) NOT NULL,
 CONSTRAINT [PK_tblPettyCashCategory] PRIMARY KEY CLUSTERED 
(
	[pccId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

if exists (select * from sys.tables where name='tblPettyCashAudit')
Drop TABLE [dbo].[tblPettyCashAudit]
Go

if not exists (select * from sys.tables where name='tblPettyCashAudit')
CREATE TABLE [dbo].[tblPettyCashAudit](
	[pcaId] [int] IDENTITY(1,1) NOT NULL,
	[pcaDT] [datetime] NOT NULL,
	[pcaAccount] [uniqueidentifier] NOT NULL,
	[pcaAuditType] [uniqueidentifier] NOT NULL,
	[pcaCategory] [uniqueidentifier] NOT NULL,
	[pcaAmount] [money] NOT NULL,
	[pcaAmountCurrent] [money] NOT NULL,
 CONSTRAINT [PK_tblPettyCashAudit] PRIMARY KEY CLUSTERED 
(
	[pcaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
-----------------------------------------------------------------------------------------
-- Stored Procedures
if exists (select * from sys.procedures where name = 'spGetAccountLoggedIn')
Drop PROCEDURE spGetAccountLoggedIn
Go
 
CREATE PROCEDURE spGetAccountLoggedIn 
AS

declare @acaAccount uniqueidentifier
declare @autKey varchar(10)
select top (1) @acaAccount=aa.acaAccount, @autkey=at.autkey from tblAccountAudit aa inner join tblAuditType at on aa.acaAuditType=at.autId
 order by aa.acaDT desc
if @autkey != 'Li'
set @acaAccount = (SELECT CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER))
select @acaAccount as acaAccount

GO

if exists (select * from sys.procedures where name = 'spAccountLogin')
Drop PROCEDURE spAccountLogin
Go

if exists (select * from sys.procedures where name = 'spAccountLoginOut')
Drop PROCEDURE spAccountLoginOut
Go
CREATE PROCEDURE spAccountLoginOut
	@accusername nvarchar(50),
	@accpwd nvarchar(50),
	@dt datetime,
	@inout varchar(10)
AS
declare @accid uniqueidentifier
declare @audid uniqueidentifier

set @audid = (select autId from tblAuditType where autKey=@inout)

set @accid = (select accId from tblAccount where accUserName=@accusername and accPwd=@accpwd)

if not @accid is null and (@inout = 'Li' or @inout='Lo')
INSERT INTO [dbo].[tblAccountAudit]
           ([acaDT]
           ,[acaAccount]
           ,[acaAuditType])
     VALUES
           (@dt
           ,@accid
           ,@audid
		   )
else
set  @accid =  (SELECT CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER))
select @accid as acaAccount

GO

if exists (select * from sys.procedures where name = 'spCashUpdate')
Drop PROCEDURE [dbo].[spCashUpdate]
Go

Create PROCEDURE [dbo].[spCashUpdate] 
	@dt datetime,
	@accid uniqueidentifier,
	@catid uniqueidentifier,
	@cash money,
	@addspend varchar(10)
AS
declare @audid uniqueidentifier
declare @cashtotal money

set @audid = (select top (1) autId from tblAuditType where autKey=@addspend)
set @cashtotal = isnull((select top (1) pcaAmountCurrent from tblPettyCashAudit order by pcaDT desc), 0.0)
if @addspend = 'Ca'
set @cashtotal = @cashtotal + @cash
if @addspend = 'Cs'
set @cashtotal = @cashtotal - @cash

if @addspend='Ca' or @addspend='Cs'
INSERT INTO [dbo].[tblPettyCashAudit]
           ([pcaDT]
           ,[pcaAccount]
           ,[pcaAuditType]
           ,[pcaCategory]
           ,[pcaAmount]
           ,[pcaAmountCurrent])
     VALUES
           (@dt
           ,@accid
           ,@audid
		   ,@catid
		  ,@cash
		  ,@cashtotal)

select @cashtotal as cashtotal

Go

if exists (select * from sys.procedures where name = 'spCashReadList')
Drop PROCEDURE [dbo].[spCashReadList]
Go
CREATE PROCEDURE spCashReadList

AS
 select * from tblPettyCashAudit pca inner join tblAccount acc on acc.accId=pca.pcaAccount inner join tblAuditType at on pca.pcaAuditType=at.autId order by pcaDT desc

GO

if exists (select * from sys.procedures where name = 'spAccountReadById')
Drop PROCEDURE [dbo].[spAccountReadById]
Go
CREATE PROCEDURE spAccountReadById 
	@accId uniqueidentifier
AS
	select top (1) acc.accId, acc.accFirstName, acc.accLastName, acc.accUserName, act.actKey, act.actName, adt.autKey, aud.acaDT from tblAccount acc
	 inner join tblAccountTypeIndex ati on acc.accId=ati.atiAccount
	 inner join tblAccountType act on act.actId=ati.atiAccountType
     inner join tblAccountAudit aud on aud.acaAccount = acc.accId
	 inner join tblAuditType adt on adt.autId=aud.acaAuditType
	where acc.accId = @accId
    order by aud.acaDT desc
GO

if exists (select * from sys.procedures where name = 'spCashSpendCategory')
Drop PROCEDURE [dbo].[spCashSpendCategory]
Go
CREATE PROCEDURE spCashSpendCategory 
AS
select * from tblPettyCashCategory where pccKey != 'PC_Nothing' order by ppcName asc
GO


if exists (select * from sys.procedures where name = 'spAuditInsert')
Drop PROCEDURE [dbo].[spAuditInsert]
Go
Create Procedure [dbo].[spAuditInsert]
@dt Datetime,
@username varchar(100),
@accType varchar(100),
@pcType varchar(100),
@debit decimal,
@sum decimal
As
INSERT INTO [dbo].[tblPettyCashAudit] ([pcaDT],[pcaAccount],[pcaAuditType],[pcaCategory],[pcaAmount],[pcaAmountCurrent]) VALUES(@dt,(select accId from tblAccount where accUserName=@username),(select actId from tblAccountType where actName=@accType),(select pccId from tblPettyCashCategory where pccKey=@pcType),@debit,@sum)
Go

if exists (select * from sys.procedures where name = 'spGetTransactions')
Drop PROCEDURE [dbo].[spGetTransactions]
Go
Create PROCEDURE [dbo].[spGetTransactions] 
AS
select pca.pcaDT as DateTime, pca.pcaAmount as Amount,
case when aut.autKey='Cs' then 'what was spent' else 'cash added' end as Category,
'who spent/added cash' as Person
from tblPettyCashAudit pca
inner join tblAccount acc on pca.pcaAccount=acc.accId
inner join tblAuditType aut on pca.pcaAuditType=aut.autId
order by pca.pcaDt desc
Go


if exists (select * from sys.procedures where name = 'spAuditTypeReadByKey')
Drop PROCEDURE [dbo].[spAuditTypeReadByKey]
Go
Create PROCEDURE [dbo].[spAuditTypeReadByKey] 
   @autkey as nvarchar(10)
AS
select autId,autKey,autName from tblAuditType aut where aut.autKey = @autkey
Go

-----------------------------------------------------------------------------------------
-- Data
declare @actkey varchar(10)

set @actkey = 'Emp'
if not exists (select * from tblAccountType where actKey=@actkey)
INSERT INTO [dbo].[tblAccountType]
           ([actId]
           ,[actName]
           ,[actKey])
     VALUES
           (NEWID(), 'Employee', @actkey)

set @actkey = 'Adm'

if not exists (select * from tblAccountType where actKey=@actkey)
INSERT INTO [dbo].[tblAccountType]
           ([actId]
           ,[actName]
           ,[actKey])
     VALUES
           (NEWID(), 'Admin', @actkey)

set @actkey = 'Dir'
if not exists (select * from tblAccountType where actKey=@actkey)
INSERT INTO [dbo].[tblAccountType]
           ([actId]
           ,[actName]
           ,[actKey])
     VALUES
           (NEWID(), 'Director', @actkey)

set @actkey = 'Man'
if not exists (select * from tblAccountType where actKey=@actkey)
INSERT INTO [dbo].[tblAccountType]
           ([actId]
           ,[actName]
           ,[actKey])
     VALUES
           (NEWID(), 'Manager', @actkey)




declare @uid uniqueidentifier
declare @accemp uniqueidentifier = (select actId from tblAccountType where actKey='Emp')
declare @accadm uniqueidentifier = (select actId from tblAccountType where actKey='Adm')
declare @accdir uniqueidentifier = (select actId from tblAccountType where actKey='Dir')
declare @accman uniqueidentifier = (select actId from tblAccountType where actKey='Man')

set @uid ='B781998C-485C-46C9-9059-895CF9077318'
if not exists (select * from tblAccount where accId=@uid)
INSERT INTO [dbo].[tblAccount]
           ([accId]
           ,[accFirstName]
           ,[accLastName]
		   ,[accUserName]
		   ,[accPwd]
		   )
     VALUES
           (@uid
           ,'John'
           ,'Kirkstone'
		   ,'jkirkstone'
		   ,'apple'
		   )
if not exists (select * from tblAccountTypeIndex where atiAccount=@uid and atiAccountType=@accemp)
	insert into tblAccountTypeIndex (atiAccount, atiAccountType) values (@uid, @accemp)


set @uid ='BA2CFA9B-05C8-4458-A28C-5057E5CC4757'
if not exists (select * from tblAccount where accId=@uid)
INSERT INTO [dbo].[tblAccount]
           ([accId]
           ,[accFirstName]
           ,[accLastName]
		   ,[accUserName]
		   ,[accPwd]
		   )
     VALUES
           (@uid
           ,'Janet'
           ,'Sherwood'
		   ,'jsherwood'
		   ,'pear'
		   )
if not exists (select * from tblAccountTypeIndex where atiAccount=@uid and atiAccountType=@accemp)
	insert into tblAccountTypeIndex (atiAccount, atiAccountType) values (@uid, @accemp)
if not exists (select * from tblAccountTypeIndex where atiAccount=@uid and atiAccountType=@accdir)
	insert into tblAccountTypeIndex (atiAccount, atiAccountType) values (@uid, @accadm)


set @uid ='201102BA-B7D8-4F16-8DCC-8EA8C302FF14'
if not exists (select * from tblAccount where accId=@uid)
INSERT INTO [dbo].[tblAccount]
           ([accId]
           ,[accFirstName]
           ,[accLastName]
		   ,[accUserName]
		   ,[accPwd]
		   )
     VALUES
           (@uid
           ,'Graham'
           ,'Norcross'
		   ,'gnorcross'
		   ,'banana'
		   )
if not exists (select * from tblAccountTypeIndex where atiAccount=@uid and atiAccountType=@accemp)
	insert into tblAccountTypeIndex (atiAccount, atiAccountType) values (@uid, @accemp)
if not exists (select * from tblAccountTypeIndex where atiAccount=@uid and atiAccountType=@accdir)
	insert into tblAccountTypeIndex (atiAccount, atiAccountType) values (@uid, @accman)


set @uid ='8F17D7C5-2593-424B-84C1-82B0CF3BA3B8'
if not exists (select * from tblAccount where accId=@uid)
INSERT INTO [dbo].[tblAccount]
           ([accId]
           ,[accFirstName]
           ,[accLastName]
		   ,[accUserName]
		   ,[accPwd]
		   )
     VALUES
           (@uid
           ,'Jennifer'
           ,'Green'
		   ,'jgreen'
		   ,'orange'
		   )

if not exists (select * from tblAccountTypeIndex where atiAccount=@uid and atiAccountType=@accemp)
	insert into tblAccountTypeIndex (atiAccount, atiAccountType) values (@uid, @accemp)
if not exists (select * from tblAccountTypeIndex where atiAccount=@uid and atiAccountType=@accadm)
	insert into tblAccountTypeIndex (atiAccount, atiAccountType) values (@uid, @accadm)


set @uid ='FA4BEB51-3BB2-402F-8298-96F5EFC9E133'
if not exists (select * from tblAccount where accId=@uid)

INSERT INTO [dbo].[tblAccount]
           ([accId]
           ,[accFirstName]
           ,[accLastName]
		   ,[accUserName]
		   ,[accPwd]
		   )
     VALUES
           (@uid
           ,'Karen'
           ,'Hide'
		   ,'khide'
		   ,'lemon'
		   )
if not exists (select * from tblAccountTypeIndex where atiAccount=@uid and atiAccountType=@accemp)
	insert into tblAccountTypeIndex (atiAccount, atiAccountType) values (@uid, @accemp)
if not exists (select * from tblAccountTypeIndex where atiAccount=@uid and atiAccountType=@accdir)
	insert into tblAccountTypeIndex (atiAccount, atiAccountType) values (@uid, @accdir)

 set @uid = '1D5C9B9B-CB37-4BA3-AAE7-2BE18F0ECCBA'
 if not exists (select * from tblAuditType where autId=@uid)
 insert into tblAuditType (autId, autName, autKey) values (@uid, 'Login', 'Li')

 set @uid = 'ED914DC9-A49A-4BCB-9B9D-118A268B7AAD'
  if not exists (select * from tblAuditType where autId=@uid)
 insert into tblAuditType (autId, autName, autKey) values (@uid, 'Logout', 'Lo')

  set @uid = '1F5EF812-A3A3-41EB-BBBF-A223533CFDAC'
  if not exists (select * from tblAuditType where autId=@uid)
 insert into tblAuditType (autId, autName, autKey) values (@uid, 'Petty Cash Added', 'Ca')
  
  set @uid = '0E251344-EB3F-4F02-9E46-D1A2928937FC'
  if not exists (select * from tblAuditType where autId=@uid)
 insert into tblAuditType (autId, autName, autKey) values (@uid, 'Petty Cash Spent', 'Cs')

 set @uid = 'CEFC5B5B-E640-47A2-A3AD-B76A9E771742'
if not exists (select * from tblPettyCashCategory where pccId=@uid)
 INSERT INTO [dbo].[tblPettyCashCategory]
           ([pccId],[ppcName],[pccKey]) VALUES (@uid,'Tea/Coffee/Sugar/Milk','PC_Tea')

set @uid = '6721CE21-9615-4EAD-8751-A0920FE10C87'
if not exists (select * from tblPettyCashCategory where pccId=@uid)
 INSERT INTO [dbo].[tblPettyCashCategory]
           ([pccId],[ppcName],[pccKey]) VALUES (@uid,'Stationary','PC_Stat')

set @uid = 'A5A05566-D935-4040-BFDA-D3AAFDCA849D'
if not exists (select * from tblPettyCashCategory where pccId=@uid)
 INSERT INTO [dbo].[tblPettyCashCategory]
           ([pccId],[ppcName],[pccKey]) VALUES (@uid,'Travel Expenses','PC_Travel')

set @uid = '1AE2822A-1EC5-4E29-9670-56101BED344C'
if not exists (select * from tblPettyCashCategory where pccId=@uid)
 INSERT INTO [dbo].[tblPettyCashCategory]
           ([pccId],[ppcName],[pccKey]) VALUES (@uid,'Cleaning','PC_Clean')


set @uid = '00000000-0000-0000-0000-000000000000'
if not exists (select * from tblPettyCashCategory where pccId=@uid)
 INSERT INTO [dbo].[tblPettyCashCategory]
           ([pccId],[ppcName],[pccKey]) VALUES (@uid,'Nothing','PC_Nothing')
Go


--select NEWID()
select acc.accFirstName, acc.accLastName, acc.accUserName, at.actName from tblAccount acc inner join tblAccountTypeIndex ati on acc.accId=ati.atiAccount inner join tblAccountType at on ati.atiAccountType=at.actId
select * from tblPettyCashCategory


