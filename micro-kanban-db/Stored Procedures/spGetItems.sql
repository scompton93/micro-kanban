CREATE PROCEDURE [dbo].[spGetItems]
AS
BEGIN
    IF (SELECT COUNT(1) FROM [microkanban].[dbo].[Items]) = 0
    BEGIN
        -- Dummy Data if none exists
        SELECT 1 as Id, 1 as [Column], '🌭 Eat Hotdogs!' as Content
        UNION
        SELECT 2, 1, '😊 Be Happy'
		        UNION
        SELECT 3, 3, '😊 I''m Completed!'
    END
    ELSE
    BEGIN
        SELECT [Id], [Column], [Content] FROM [microkanban].[dbo].[Items] ORDER BY [Column]
    END
END