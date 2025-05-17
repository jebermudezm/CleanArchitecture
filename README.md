# CleanArchitecture

Este repositorio contiene un ejemplo de implementación de la arquitectura limpia (**Clean Architecture**) utilizando **.NET**. Su propósito es servir como base para aplicaciones escalables, mantenibles y fáciles de probar, separando las responsabilidades en capas bien definidas.

---

## 🧱 Estructura del Proyecto
```text
CleanArchitecture/
├── Application/       # Lógica de negocio (casos de uso)
├── Domain/            # Entidades del dominio y reglas de negocio
├── Infrastructure/    # Acceso a datos, servicios externos, implementación de interfaces
├── WebApi/            # Capa de presentación (API REST)
└── README.md


---

## 🚀 Tecnologías Usadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- AutoMapper
- MediatR
- SQL Server
- Swagger

---

## 📌 Principios Aplicados

- Separación de responsabilidades
- Inversión de dependencias
- Programación orientada a interfaces
- Inyección de dependencias
- Patrón CQRS con MediatR

---

## 🛠️ Cómo Ejecutar el Proyecto

1. Clona el repositorio:

   ```bash
   git clone https://github.com/jebermudezm/cleanarchitecture.git
Abre la solución en Visual Studio o Visual Studio Code.

Configura la cadena de conexión en WebApi/appsettings.json.

Aplica las migraciones (si estás usando EF Core):

bash
Copiar
Editar
dotnet ef database update
Ejecuta el proyecto. La API estará disponible en:

bash
Copiar
Editar
https://localhost:{puerto}/swagger
📚 Recursos Recomendados
Clean Architecture - Robert C. Martin

Documentación oficial de MediatR

Entity Framework Core

🙋 Autor
Joaquín Bermúdez Medina
Software Engineer | Cloud & Architecture Enthusiast
LinkedIn (opcional)
