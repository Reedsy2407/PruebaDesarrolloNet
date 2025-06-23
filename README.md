# Mantenimiento Web de Trabajadores

Este repositorio contiene tres componentes:

1. **TrabajadoresBiblioteca** (Class Library): Modelos, `DbContext`, repositorios y servicios.
2. **TrabajadoresApi** (ASP.NET Core Web API): Endpoints REST para CRUD y lookups.
3. **TrabajadoresWeb** (ASP.NET Core MVC): UI con Bootstrap, modales para crear/editar y listado dinámico.

---

#### Prerrequisitos

- [.NET 6.0 SDK (o .NET 5.0)](https://dotnet.microsoft.com/download)
- SQL Server (p. ej. **SQLEXPRESS**)
- Git
- Visual Studio 2022 o superior con el workload de ASP.NET y desarrollo web

---

#### Configurar la base de datos

1. Abre **SQL Server Management Studio** y conéctate a tu instancia local.
2. Ejecuta el script `Script Trabajadores.sql` en la raíz del repositorio.
   - Crea la base **TrabajadoresPrueba**, tablas (`Departamento`, `Provincia`, `Distrito`, `Trabajadores`), datos de ejemplo y el SP `usp_ListarTrabajadores`.
3. Verifica con:
   ```sql
   USE TrabajadoresPrueba;
   GO
   EXEC dbo.usp_ListarTrabajadores;
   ```

---

#### Cadena de conexión

En ambos proyectos (`TrabajadoresApi` y `TrabajadoresWeb`), abre `appsettings.json` y establece:

```jsonc
{
  "ConnectionStrings": {
    "cn": "Server=.;Database=TrabajadoresPrueba;uid=sa;pwd=sql;TrustServerCertificate=True;"
  }
}
```

---

#### Cómo ejecutar la solución

1. Clona el repositorio y compila:
   ```bash
   git clone https://github.com/<tuUsuario>/TrabajadoresPrueba.git
   cd TrabajadoresPrueba
   dotnet build
   ```
1. Abre `TrabajadoresPruebaSolution.sln` en Visual Studio.
2. Configura **Multiple startup projects**:
   - Clic derecho en la solución → **Properties** → **Startup Project** → **Multiple startup projects**.
   - Marca **Start** para **TrabajadoresApi** y **TrabajadoresWeb**, en ese orden.
3. Ejecuta (F5 o ▶️).
   - La API arrancará en `https://localhost:<puerto>/swagger`
   - La Web en `https://localhost:<puerto>/Trabajadores`

---

#### Uso y flujo de prueba

- El listado inicial utiliza el SP `usp_ListarTrabajadores`.
- **Crear**:
  1. Selecciona un **Departamento** → se cargan **Provincias**.
  2. Selecciona una **Provincia** → se cargan **Distritos**.
  3. Guarda → modal cierra → tabla recarga.
- **Editar** o **Eliminar** registros desde la tabla.
- Puedes probar la API en Swagger o Postman.

---

