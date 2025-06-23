Create database TrabajadoresPrueba;
go
use trabajadoresPrueba;
go

INSERT INTO dbo.Trabajadores
    (TipoDocumento, NumeroDocumento, Nombres, Sexo, IdDepartamento, IdProvincia, IdDistrito)
VALUES
    ('DNI', '12345678', N'Juan Pérez',   'M', 15, 101, 1857),
    ('DNI', '87654321', N'Ana González',  'F', 15, 101, 1858),
    ('PAS', 'X1234567', N'Carlos Ramírez','M',  4,  42,  1859),
    ('DNI', '11223344', N'Lucía Torres',  'F', 10,  85,  1860),
    ('DNI', '55667788', N'María López',   'F', 20, 187, 1861);
GO

IF OBJECT_ID('dbo.usp_ListarTrabajadores', 'P') IS NOT NULL
  DROP PROCEDURE dbo.usp_ListarTrabajadores;
GO

CREATE PROCEDURE dbo.usp_ListarTrabajadores
AS
BEGIN
  SET NOCOUNT ON;
  SELECT 
    t.Id,
    t.TipoDocumento,
    t.NumeroDocumento,
    t.Nombres,
    t.Sexo,
    d.NombreDepartamento,
    p.NombreProvincia,
    di.NombreDistrito
  FROM dbo.Trabajadores t
  INNER JOIN dbo.Departamento d ON d.Id = t.IdDepartamento
  INNER JOIN dbo.Provincia p    ON p.Id = t.IdProvincia
  INNER JOIN dbo.Distrito di    ON di.Id = t.IdDistrito;
END
GO


Exec usp_ListarTrabajadores;
Exec usp_GetProvinciasPorDepartamento 1;
Exec usp_GetDistritosPorProvincia 1;