CREATE PROCEDURE [dbo].[spInsertItem]
    @ColumnId int,
    @Content varchar(512)
AS
BEGIN
    INSERT INTO dbo.Items ([Column],Content,[Order],Created_UTC) VALUES (@ColumnId,@Content,1,GETUTCDATE())
END
