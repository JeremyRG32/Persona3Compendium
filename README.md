# Persona 3 Compendium

Aplicación web que funciona como un compendio/enciclopedia de **Persona 3 Reload**, permitiendo consultar información del juego (Personas, fusiones, etc.) desde una interfaz web construida con ASP.NET Core.

🔗 **Demo en vivo:** [persona3reloadcompendium.onrender.com](https://persona3reloadcompendium.onrender.com)

> ⚠️ Nota: al estar desplegado en el plan gratuito de Render, es posible que la primera carga tarde unos segundos mientras el servidor "despierta".

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![Docker](https://img.shields.io/badge/Docker-ready-2496ED?logo=docker)
![License](https://img.shields.io/badge/license-MIT-green)

---

## 📖 Tabla de contenido

- [Sobre el proyecto](#-sobre-el-proyecto)
- [Tecnologías utilizadas](#-tecnologías-utilizadas)
- [Estructura del proyecto](#-estructura-del-proyecto)
- [Instalación y ejecución local](#-instalación-y-ejecución-local)
- [Despliegue](#-despliegue)
- [Créditos](#-créditos)
- [Licencia](#-licencia)

## 📌 Sobre el proyecto

Persona 3 Compendium nace como un proyecto personal para practicar el desarrollo de aplicaciones web full-stack con **ASP.NET Core** y **Entity Framework Core**, usando como caso práctico la información del videojuego *Persona 3 Reload*.

La aplicación consulta una base de datos (SQLite) precargada con la información del juego y la expone a través de una interfaz web sencilla, permitiendo explorar y buscar contenido de forma rápida.

**Funcionalidades principales:**
- 🔍 Listado y búsqueda de Personas del juego.
- 📋 Vista de detalle con estadísticas, arcanos y resistencias.
- ⚡ Consulta rápida sin necesidad de instalar nada (versión web).

## 🛠️ Tecnologías utilizadas

- **Backend:** ASP.NET Core 8 (C#)
- **Base de datos:** SQLite + Entity Framework Core
- **Frontend:** HTML, CSS (Razor Views)
- **Contenedores:** Docker
- **Hosting:** [Render](https://render.com)

## 📂 Estructura del proyecto

```
Persona3Compendium/
├── ConsoleApp1/                 # Utilitario de consola (carga/seed de datos, scripts, etc.)
├── Persona3Compendium.Web/      # Aplicación web ASP.NET Core (proyecto principal)
├── Dockerfile                   # Imagen Docker usada para el despliegue en Render
├── Persona3Compendium.sln       # Solución de Visual Studio
└── LICENSE
```

## 🚀 Instalación y ejecución local

### Requisitos previos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- (Opcional) [Docker](https://www.docker.com/) si prefieres correrlo en contenedor

### Clonar el repositorio

```bash
git clone https://github.com/JeremyRG32/Persona3Compendium.git
cd Persona3Compendium
```

### Ejecutar con .NET

```bash
cd Persona3Compendium.Web
dotnet restore
dotnet run
```

La aplicación quedará disponible en `https://localhost:5001` (o el puerto que indique la consola).

### Ejecutar con Docker

```bash
docker build -t persona3-compendium .
docker run -p 8080:8080 -e PORT=8080 persona3-compendium
```

## ☁️ Despliegue

El proyecto está desplegado en **Render** usando el `Dockerfile` incluido en el repositorio, junto con la base de datos SQLite (`Persona.db`) empaquetada en la imagen.

🔗 Puedes ver la versión en producción aquí: **https://persona3reloadcompendium.onrender.com**

## 🙏 Créditos

Este proyecto es un trabajo hecho con fines educativos y de portafolio personal. Todo el contenido relacionado a Persona 3 Reload (personajes, Personas, arte, nombres, etc.) es propiedad de **Atlus Co., Ltd.** No se reclama ninguna propiedad sobre dicho material.

Desarrollado por **[JeremyRG32](https://github.com/JeremyRG32)**.

## 📄 Licencia

Este proyecto está bajo la licencia MIT. Consulta el archivo [LICENSE](./LICENSE) para más información.
