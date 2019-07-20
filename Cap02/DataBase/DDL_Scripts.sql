create procedure usp_GetArtist
@Nombre NVARCHAR(100)
as
BEGIN
	SELECT *
	FROM Artist
	WHERE @Nombre = '' OR Name like @Nombre

END

--exec usp_GetArtist ''
--exec usp_GetArtist 'aero%'