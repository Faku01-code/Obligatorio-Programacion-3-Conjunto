# Changelog — Sistema de Gestión de Obras (Pages & Familia)

Registro cronológico de cambios del proyecto, sincronizado con el [Plan de iteraciones](./Plan_de_Iteraciones.md) y la [Documentación de Ingeniería de Software](./Documentacion_Ing_Software.md).

El formato se inspira en [Keep a Changelog](https://keepachangelog.com/es-ES/1.0.0/).  
Las versiones siguen las etiquetas SCM planificadas por iteración (`v0.1-mvp`, `v0.2-personal`, etc.).

---

## [Unreleased]

Cambios en curso que aún no tienen tag de versión.

### Added
- `Documents/Plan_de_Iteraciones.md` — plan operativo de iteraciones 0–5 con tareas técnicas, entidades y criterios de done.
- `Documents/Changelog.md` — registro de cambios del proyecto.

### Changed
- *(ninguno)*

### Fixed
- *(ninguno)*

### Removed
- *(ninguno)*

---

## [v0.0-fundamentos] — 2026-03 / 2026-06 (en progreso)

**Iteración 0 — Fundamentos**

### Added
- Documentación IDS completa: `Documents/Documentacion_Ing_Software.md` (relevamiento, RF/RNF, incrementos, cronograma, SQA, SCM, testing).
- Proyecto ASP.NET Core Razor Pages (`net10.0`) con EF Core 9 y Pomelo MySQL.
- Scaffolding de 15 entidades desde BD MySQL `pages_familia`:
  - `Asignacion`, `CategoriaMov`, `Cliente`, `Compra`, `Empleado`, `EstadoObra`, `Material`, `MovimientoFin`, `Obra`, `ObraMaterial`, `Oficio`, `RegistroHora`, `Rol`, `Usuario`.
- `Data/PagesFamiliaContext.cs` — DbContext con mapeo completo de relaciones e índices.
- `Data/AppDbContext.cs` — contexto auxiliar (placeholder).
- Configuración de inyección de dependencias en `Program.cs`:
  - `PagesFamiliaContext` vía connection string.
  - Registro planificado de Repositories y Services.
  - Sesión HTTP (timeout 30 min).
- Vista parcial de Dashboard en `Pages/Index` (estructura UI con stats y tabla de obras recientes).
- Layout con navegación por módulos (`Panel`, `Obras`, `Personal`, `Materiales`, `Finanzas`, `Reportes`); módulos 2–5 deshabilitados hasta sus iteraciones.
- Estilos base en `wwwroot/css/site.css`.
- Connection string en `appsettings.json` / `appsettings.Development.json`.

### Changed
- *(pendiente)* Migrar connection string hardcodeada en `PagesFamiliaContext.OnConfiguring` a configuración exclusiva vía DI.

### Fixed
- *(ninguno registrado)*

### Removed
- *(ninguno)*

### Known gaps (deuda técnica documentada)
- Carpetas `Repositories/`, `Services/`, `ViewModels/` referenciadas en código pero **no presentes** en el repositorio.
- Páginas `Account/Login`, `Account/Logout`, `Obras/*` referenciadas pero **no implementadas**.
- Autenticación y hash de contraseñas pendientes.
- Pruebas unitarias pendientes.
- Diseño UI definitivo pendiente de especificación del equipo.

---

## Plantilla para entradas futuras

Copiar y completar al cerrar cada iteración o al mergear features relevantes:

```markdown
## [v0.X-nombre] — YYYY-MM-DD

**Iteración N — Nombre**

### Added
- Descripción del cambio ([#PR](url) / commit `hash`)

### Changed
- ...

### Fixed
- ...

### Removed
- ...
```

---

## Historial planificado (referencia)

| Versión | Iteración | Estado |
|---------|-----------|--------|
| `v0.0-fundamentos` | 0 | En progreso |
| `v0.1-mvp` | 1 | Pendiente |
| `v0.2-personal` | 2 | Pendiente |
| `v0.3-materiales` | 3 | Pendiente |
| `v1.0` | 4 | Pendiente |
| `v1.0-final` | 5 (cierre) | Pendiente |

---

*Mantenido por el equipo de desarrollo. Actualizar este archivo en el mismo PR o commit que introduzca el cambio.*
