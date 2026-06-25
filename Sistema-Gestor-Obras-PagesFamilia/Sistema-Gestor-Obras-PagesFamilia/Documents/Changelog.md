# Changelog — Sistema de Gestión de Obras (Pages & Familia)

Registro cronológico de cambios del proyecto, sincronizado con el [Plan de iteraciones](./Plan_de_Iteraciones.md) y la [Documentación de Ingeniería de Software](./Documentacion_Ing_Software.md).

---

## [v1.2] — 2026-06-24

**Iteración 2 — Módulo Personal**

### Added
- **Empleados:** ABM completo (`Personal/Index`, `Create`, `Edit`, `Details`, `Delete` con baja lógica). Campos: nombre, tipo (FIJO/SUBCONTRATISTA), oficio, documento (único), teléfono.
- **Asignaciones:** alta y baja de asignaciones empleado→obra (`Personal/Asignaciones/Create`, `Delete`). Validación de fechas (`fecha_fin >= fecha_inicio`). Protección contra eliminación si existen registros de horas.
- **Repositories:** `IOficioRepository`, `OficioRepository`, `IEmpleadoRepository`, `EmpleadoRepository`, `IAsignacionRepository`, `AsignacionRepository`.
- **Services:** `IOficioService`, `OficioService`, `IEmpleadoService`, `EmpleadoService`, `IAsignacionService`, `AsignacionService`.
- **ViewModels:** `EmpleadoFormViewModel`, `AsignacionFormViewModel`.

### Changed
- **`_Layout.cshtml`:** link Personal habilitado (`asp-page="/Personal/Index"`).
- **`Obras/Details`:** nueva sección "Personal asignado" con tabla de asignaciones y botón "Asignar empleado" (solo Admin/Capataz sobre obras activas).
- **`Pages/Index.cshtml.cs` (Dashboard):** contador de empleados migrado de `IRepository<Empleado>` a `IEmpleadoService.ContarActivosAsync()`.
- **`Program.cs`:** registro de los 3 nuevos repositorios y 3 nuevos services en el contenedor DI.

### Permisos por rol (Iteración 2)

| Acción | Administrador | Capataz | Consulta |
|--------|---------------|---------|----------|
| Ver listado de empleados | Sí (todos) | Sí (activos) | Sí (activos) |
| Crear/editar empleados | Sí | Sí | No |
| Dar de baja empleados | Sí | Sí | No |
| Crear/eliminar asignaciones | Sí | Sí | No |

---

## [v1.1] — 2026-06-24

**Ajustes post-MVP — Login split-screen + pulido UI**

### Changed
- **Login:** nuevo layout de dos columnas. Izquierda: formulario de acceso. Derecha: panel de bienvenida con descripción del sistema y lista de features.
- **Role-cards:** selector de roles convertido a disposición horizontal (`role-cards--horizontal`) con tarjetas compactas (ícono + nombre, sin descripción visible).
- **Role-cards fix:** corregida deformación de texto (`text-transform` eliminado, `flex` con `min-width`/`max-width`, `word-break`). Ícono de Capataz corregido de `bi-hard-hat` → `bi-hammer`.
- **Dashboard:** subtítulo de bienvenida ("Bienvenido, email · rol") mejorado de `rgba(255,255,255,0.38)` a `rgba(255,255,255,0.62)` para mayor legibilidad.
- **CSS:** sección LOGIN rediseñada. Nuevas clases: `.login-split-container`, `.login-left`, `.login-right`, `.login-welcome`, `.login-feature`, `.role-cards--horizontal`, `.role-card-inner--compact`. Responsive: en pantallas ≤900 px se oculta la columna derecha y el panel se apila.

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
| fundamentos | 0 | Completado |
| `v1.0` | 1 — MVP | Completado |
| `v1.1` | Post-MVP (UI polish) | Completado |
| `v1.2` | 2 — Personal | Pendiente |
| `v1.3` | 3 — Materiales | Pendiente |
| `v1.4` | 4 — Finanzas + Panel completo | Pendiente |

---

*Mantenido por el equipo de desarrollo.*
