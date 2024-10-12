Proyecto CRUD con Blazor y .NET
Este proyecto implementa un CRUD completo para las tablas tipo_producto, termino_clave y proyecto, utilizando Blazor en el frontend y una API en .NET en el backend.

Requisitos
.NET 8
SQL Server
Visual Studio Code o Visual Studio
Postman (opcional para pruebas de API)
SQL Server Management Studio (para gestión de la base de datos)

Configuración Inicial
Backend
El backend se conecta a una base de datos ya existente. Las siguientes operaciones se realizan en las tablas tipo_producto, termino_clave y proyecto:

GET: Obtener todos los registros.
POST: Crear un nuevo registro.
PUT: Actualizar un registro existente.
DELETE: Eliminar un registro.
Configuración de CORS
Para permitir que el frontend interactúe correctamente con el backend, configuramos CORS en Program.cs para habilitar solicitudes desde el cliente Blazor. Esta configuración es esencial para que la API acepte peticiones desde el frontend hospedado en otro origen:

csharp
services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
Esta política se aplica en los controladores del backend para permitir el acceso desde el frontend en Blazor.

Swagger
Implementamos Swagger en el backend para documentar y probar las API de forma interactiva. Swagger facilita la visualización de las rutas disponibles y las operaciones CRUD implementadas.

Soluciones a Problemas de Foreign Keys
Durante la implementación del proyecto, surgieron problemas al intentar eliminar registros en las tablas que estaban referenciadas por claves foráneas en otras tablas. Para solucionar esto, fue necesario modificar las relaciones entre las tablas en la base de datos.

Realizamos los siguientes cambios:

Eliminar restricciones de claves foráneas: Se eliminó la restricción de las claves foráneas que no permitían eliminar un registro de una tabla porque estaba referenciado en otra tabla.

Pruebas con Postman
Se realizaron pruebas exhaustivas de las operaciones CRUD utilizando Postman para asegurar que las peticiones a las API fueran correctas.

Por ejemplo, para probar la creación de un nuevo proyecto, utilizamos la siguiente solicitud:

Método: POST
URL: http://localhost:5155/api/proyecto
Body (JSON):
json
Copiar código
{
  "titulo": "Nuevo Proyecto",
  "resumen": "Descripción del nuevo proyecto",
  "presupuesto": 10000.00,
  "tipo_financiacion": "Pública",
  "tipo_fondos": "Nacionales",
  "fecha_inicio": "2024-01-01",
  "fecha_fin": null
}
Cómo Ejecutar el Proyecto
Clonar el repositorio.
Restaurar las dependencias de .NET.
Configurar la cadena de conexión a SQL Server en appsettings.json.
Ejecutar el backend.
Ejecutar el frontend Blazor.
Notas Adicionales
Durante el desarrollo se presentaron desafíos con las relaciones de claves foráneas en la base de datos, los cuales fueron resueltos mediante ajustes en las restricciones de las tablas. En las tablas donde las claves foráneas impedían eliminaciones, se aplicó la política de ON DELETE SET NULL para evitar la eliminación de registros dependientes.

