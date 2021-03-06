Print 'Updating [spGetTransactions]'
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[spGetTransactions] 
AS

BEGIN
/*select pca.pcaDT as DateTime, pca.pcaAmount as Amount,
case when aut.autKey='Cs' then 'what was spent' else 'cash added' end as Category,
'who spent/added cash' as Person
from tblPettyCashAudit pca
inner join tblAccount acc on pca.pcaAccount=acc.accId
inner join tblAuditType aut on pca.pcaAuditType=aut.autId
order by pca.pcaDt desc*/

select pca.pcaDT as DateTime, pca.pcaAmount as Amount, pcc.ppcName as Category, a.accUserName as Person
from tblPettyCashAudit pca
inner join tblPettyCashCategory pcc on pcc.pccId = pca.pcaCategory
inner join tblAccount a on a.accId = pca.pcaAccount
order by pca.pcaAccount
END 
GO

Print 'Finished Updating [spGetTransactions]'
GO


Print 'Creating [spGetLoginTimesByAccountId]'
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetLoginTimesByAccountId] (
@AccountId nvarchar(50)
)
AS

BEGIN

SELECT aa.acaDT AS EventTime, audTyp.autName AS EventType 
FROM tblAccountAudit aa
INNER JOIN tblAuditType audTyp on audTyp.autId = aa.acaAuditType
WHERE aa.acaAccount = @AccountId

END
GO

Print 'Finished Creating [spGetLoginTimesByAccountId]'
GO
