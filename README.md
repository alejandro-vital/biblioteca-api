# BibliotecaApi

Una API REST desarrollada en .NET 9 para gestionar una biblioteca de libros, implementando una arquitectura limpia con Entity Framework Core y SQL Server.

## 🚀 Características

- **API REST completa** para gestión de libros (CRUD)
- **Arquitectura Clean Architecture** con capas bien definidas
- **Entity Framework Core** como ORM
- **SQL Server** como base de datos
- **AutoMapper** para mapeo de objetos
- **Swagger UI** para documentación interactiva
- **Inyección de dependencias** nativa de .NET

## 📋 Prerrequisitos

Antes de ejecutar el proyecto, asegúrate de tener instalado:

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (LocalDB, Express o completo)
- [Git](https://git-scm.com/)

## 🛠️ Instalación y Configuración

### 1. Clonar el repositorio

```bash
git clone https://github.com/alejandro-vital/biblioteca-api.git
cd BibliotecaApi
```

### 2. Configurar la base de datos

#### SQL Server local
Edita el archivo `BibliotecaApi/appsettings.json` y actualiza la cadena de conexión:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=DbBiblioteca;User Id=sa;Password=TU_PASSWORD;TrustServerCertificate=True"
  }
}
```

### 3. Restaurar paquetes NuGet

```bash
cd BibliotecaApi
dotnet restore
```

### 4. Aplicar migraciones de base de datos

```bash
dotnet ef database update
```

Si no tienes instalado Entity Framework CLI, instálalo primero:

```bash
dotnet tool install --global dotnet-ef
```

## ▶️ Ejecutar el proyecto

### Desde la línea de comandos

```bash
cd BibliotecaApi
dotnet run
```

### Desde Visual Studio

1. Abrir `BibliotecaApi.sln`
2. Establecer `BibliotecaApi` como proyecto de inicio
3. Presionar `F5` o hacer clic en "Iniciar"

## 🌐 Acceso a la aplicación

Una vez iniciada la aplicación:

- **API Base URL**: `https://localhost:7157` o `http://localhost:5194`
- **Swagger UI**: `https://localhost:7157/swagger` o `http://localhost:5194/swagger`

## 📚 Endpoints de la API

### Libros

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/Book` | Obtener todos los libros |
| GET | `/api/Book/{id}` | Obtener libro por ID |
| POST | `/api/Book` | Crear nuevo libro |
| PUT | `/api/Book/{id}` | Actualizar libro existente |
| DELETE | `/api/Book/{id}` | Eliminar libro |

### Ejemplo de objeto Book

```json
{
  "id": 1,
  "title": "El Quijote",
  "author": "Miguel de Cervantes",
  "isbn": "978-84-376-0494-7",
  "publicationYear": 1605,
  "genre": "Novela",
  "description": "Las aventuras del ingenioso hidalgo Don Quijote de La Mancha"
}
```

## 🏗️ Estructura del Proyecto

```
BibliotecaApi/
├── API/
│   └── Controllers/          # Controladores de la API
├── Application/
│   ├── DTOs/                # Data Transfer Objects
│   └── Mapping/             # Perfiles de AutoMapper
├── Domain/
│   ├── Entities/            # Entidades del dominio
│   └── Interfaces/          # Interfaces del repositorio
├── Infrastructure/
│   ├── Data/                # Contexto de Entity Framework
│   └── Repositories/        # Implementación de repositorios
├── Migrations/              # Migraciones de Entity Framework
├── Program.cs               # Punto de entrada de la aplicación
└── appsettings.json         # Configuración de la aplicación
```

## 🧪 Probar la API

### Usando Swagger UI

1. Navega a `https://localhost:7157/swagger`
2. Explora y prueba los endpoints directamente desde la interfaz

### Usando el archivo .http

El proyecto incluye un archivo `BibliotecaApi.http` con ejemplos de requests que puedes usar con:
- Visual Studio Code (con extensión REST Client)
- Visual Studio
- JetBrains IDEs

### Usando curl

```bash
# Obtener todos los libros
curl -X GET "https://localhost:7157/api/Book" -H "accept: application/json"

# Crear un nuevo libro
curl -X POST "https://localhost:7157/api/Book" \
  -H "accept: application/json" \
  -H "Content-Type: application/json" \
  -d '{
    "title": "Nuevo Libro",
    "author": "Autor Ejemplo",
    "isbn": "978-84-376-0494-8",
    "publicationYear": 2024,
    "genre": "Ficción",
    "description": "Descripción del libro"
  }'
```

## 🔧 Configuración adicional

### Problemas con migraciones

Para recrear la base de datos desde cero:

```bash
dotnet ef database drop
dotnet ef database update
```