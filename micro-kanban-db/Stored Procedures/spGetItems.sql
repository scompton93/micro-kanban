CREATE PROCEDURE [dbo].[spGetItems]
AS
BEGIN
    SELECT Id, Content FROM [microkanban].[dbo].[Items]
END