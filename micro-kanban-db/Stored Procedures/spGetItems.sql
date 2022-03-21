CREATE PROCEDURE [dbo].[spGetItems]
AS
BEGIN
    IF (SELECT COUNT(1) FROM [microkanban].[dbo].[Items]) = 0
    BEGIN
        -- Dummy Data if none exists
        SELECT 1 as Id, '🌭 Eat Hotdogs!' as Content
        UNION
        SELECT 2, '😊 Be Happy'
    END
    ELSE
    BEGIN
        SELECT Id, Content FROM [microkanban].[dbo].[Items]
    END
END