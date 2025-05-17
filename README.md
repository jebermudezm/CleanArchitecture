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
```

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
   ```

2. Abre la solución en Visual Studio o Visual Studio Code.

3. Configura la cadena de conexión en `WebApi/appsettings.json`.

4. Aplica las migraciones (si estás usando EF Core):

   ```bash
   dotnet ef database update
   ```

5. Ejecuta el proyecto. La API estará disponible en:

   ```
   https://localhost:{puerto}/swagger
   ```

---

## 📚 Recursos Recomendados

- [Clean Architecture - Robert C. Martin](https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164)
- [Documentación oficial de MediatR](https://github.com/jbogard/MediatR)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)

---

## 🙋 Autor

**Joaquín Bermúdez Medina**  
Software Engineer | Cloud & Architecture Enthusiast  
[LinkedIn](https://www.linkedin.com/in/tuusuario/) <!-- opcional -->

---

> Este proyecto es solo un ejemplo educativo y puede adaptarse a las necesidades de cada aplicación real.
