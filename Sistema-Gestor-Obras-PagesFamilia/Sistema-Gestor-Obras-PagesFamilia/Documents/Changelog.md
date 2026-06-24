# Changelog — Sistema de Gestión de Obras (Pages & Familia)

Registro cronológico de cambios del proyecto, sincronizado con el [Plan de iteraciones](./Plan_de_Iteraciones.md) y la [Documentación de Ingeniería de Software](./Documentacion_Ing_Software.md).

---

## [Unreleased]

### Added
- *(ninguno)*

---

## [v0.1-mvp] — 2026-06-24

**Iteración 1 — MVP (entrega inicial usable)**

### Added
- **Diseño UI:** sistema glassmorphism (estilo iOS/Apple) sobre base negro/blanco, tipografía Inter, paneles con `backdrop-filter`, bordes translúcidos y gradientes ambientales.
- **Autenticación:** `Account/Login` con email/contraseña en texto plano (académico) y selector de rol (Administrador, Capataz, Consulta).
- **Sesión:** `Account/Logout`, claves en `Helpers/SessionKeys.cs`, permisos en `Helpers/Roles.cs`.
- **Capa de datos:** Repositories (`IRepository`, Obra, Cliente, EstadoObra, Usuario, Rol) y Services (Auth, Obra, Cliente, EstadoObra, Usuario).
- **ViewModels:** Dashboard, Login, Obra, Cliente, Usuario.
- **Dashboard:** panel con stats (obras, empleados, clientes) y obras recientes.
- **Obras:** ABM completo (`Index`, `Create`, `Edit`, `Details`, `Delete` con baja lógica).
- **Clientes:** ABM (solo Administrador puede crear/editar/dar de baja; todos ven listado).
- **Usuarios:** ABM con asignación de roles (solo Administrador).
- **Base de autorización:** `AuthenticatedPageModel` con redirección por rol.
- **Seed en `Script-BDD.sql`:** usuario `admin@pages.com` / `admin123`, rol Administrador, clientes de ejemplo.

### Changed
- `PagesFamiliaContext`: conexión exclusiva vía `appsettings.json` (sin string hardcodeado).
- `_Layout.cshtml`: navegación por módulos, badge de rol, alertas TempData, fuente Inter.
- `site.css`: migrado a variables glassmorphism; componentes reutilizables (`.glass-panel`, `.glass-input`, `.role-cards`).
- `Program.cs`: registro de `IUsuarioService`.

### Permisos por rol (Iteración 1)

| Acción | Administrador | Capataz | Consulta |
|--------|---------------|---------|----------|
| Ver panel y obras | Sí | Sí | Sí |
| Crear/editar obras | Sí | Sí | No |
| Ver obras inactivas | Sí | No | No |
| ABM clientes | Sí | No | No |
| ABM usuarios | Sí | No | No |

### Fixed
- Compilación: propiedades de `AuthenticatedPageModel` expuestas como `public` para vistas Razor.

---

## [v0.0-fundamentos] — 2026-03 / 2026-06

**Iteración 0 — Fundamentos**

### Added
- Documentación IDS: `Documentacion_Ing_Software.md`.
- Scaffolding EF Core (15 entidades) + `PagesFamiliaContext`.
- Proyecto ASP.NET Core Razor Pages (`net10.0`) + MySQL Pomelo.
- `Plan_de_Iteraciones.md`, `Changelog.md`, `Script-BDD.sql`.

---

## Historial planificado

| Versión | Iteración | Estado |
|---------|-----------|--------|
| `v0.0-fundamentos` | 0 | Completado |
| `v0.1-mvp` | 1 | Completado |
| `v0.2-personal` | 2 | Pendiente |
| `v0.3-materiales` | 3 | Pendiente |
| `v1.0` | 4 | Pendiente |

---

*Mantenido por el equipo de desarrollo.*
