# Changelog — Sistema de Gestión de Obras (Pages & Familia)

Registro cronológico de cambios del proyecto, sincronizado con el [Plan de iteraciones](./Plan_de_Iteraciones.md) y la [Documentación de Ingeniería de Software](./Documentacion_Ing_Software.md).

---

## [v1.3] — 2026-06-26

**Iteración 4 — Módulo Finanzas + Panel completo**

### Added
- **Módulo Finanzas:** ABM de movimientos financieros manuales (`Finanzas/Index`, `Create`, `Delete`). Campos: obra, categoría, monto, fecha, descripción opcional.
- **Toast de error:** soporte para `TempData["Error"]` en `_Layout.cshtml` con estilo rojo consistente con el sistema de toasts existente.
- **IMovimientoFinRepository / MovimientoFinRepository:** métodos `GetAllWithDetailsAsync`, `GetByObraIdAsync`, `GetByIdWithDetailsAsync` con includes (obra, categoría, usuario, compra).
- **IMovimientoFinService / MovimientoFinService:** CRUD manual + protección contra eliminación de movimientos generados por compras + cálculo de resúmenes (ingresos vs egresos).
- **MovimientoFinFormViewModel:** validaciones de rango para IdObra, IdCategoria y Monto.
- **CSS:** clases `.badge-ingreso`, `.badge-egreso`, `.badge-manual`, `.badge-compra`, `.fin-num-ingreso/egreso`, `.fin-resumen-grid`, `.toast-error`.

### Changed
- **`_Layout.cshtml`:** link Finanzas habilitado (`asp-page="/Finanzas/Index"`). Agregado toast de error.
- **Dashboard (`Index.cshtml.cs` + `Index.cshtml`):** inyección de `IMovimientoFinService`. Dos nuevas stat-cards: Total Ingresos y Total Egresos globales.
- **`Obras/Details.cshtml.cs`:** inyección de `IMovimientoFinService`; carga de `Movimientos`, `TotalIngresosObra`, `TotalEgresosObra`, `BalanceObra` en `OnGetAsync`.
- **`Obras/Details.cshtml`:** nueva sección "Resumen Financiero" con tarjetas de totales + tabla de movimientos por obra (tipo, categoría, monto, origen manual/compra).
- **`Program.cs`:** registro de `IMovimientoFinRepository` y `IMovimientoFinService` en el contenedor DI.

### Permisos por rol (Iteración 4)

| Acción | Administrador | Capataz | Consulta |
|--------|---------------|---------|----------|
| Ver módulo Finanzas | Sí | Sí | Sí |
| Registrar movimiento manual | Sí | Sí | No |
| Eliminar movimiento manual | Sí | No | No |
| Ver resumen financiero en obra | Sí | Sí | Sí |

---

## [v1.2.1] — 2026-06-25

**Favicon**

### Added
- **Favicon:** tag `<link rel="icon">` explícito con `asp-append-version="true"` en `_Layout.cshtml` para cache-busting automático.

---

## [v1.2] — 2026-06-25

**Iteración 3 — Módulo Materiales**

### Added
- **Materiales:** ABM completo (`Materiales/Index`, `Create`, `Edit`, `Delete` con baja lógica). Campos: nombre, unidad, activo.
- **ObraMateriales:** agregar/quitar material de obra con cantidad requerida (`Materiales/ObraMateriales/Create`, `Delete`). Validación de unicidad por par (obra + material). Protección contra eliminación si existen compras.
- **Compras:** alta y baja de compras por ObraMaterial (`Materiales/Compras/Create`, `Delete`). Campos: cantidad, costo unitario, fecha, descripción opcional.
- **MovimientoFin automático:** al registrar una compra se genera un egreso en `movimiento_fin` con categoría "Compra de material". Al eliminar la compra se elimina el movimiento asociado.
- **Repositories:** `IMaterialRepository`, `MaterialRepository`, `IObraMaterialRepository`, `ObraMaterialRepository`, `ICompraRepository`, `CompraRepository`.
- **Services:** `IMaterialService`, `MaterialService`, `IObraMaterialService`, `ObraMaterialService`, `ICompraService`, `CompraService`.
- **ViewModels:** `MaterialFormViewModel`, `ObraMaterialFormViewModel`, `CompraFormViewModel`.
- **CSS:** estilos `.compra-sub-row` y `.compra-sub-indent` para sub-filas de compras en tabla.

### Changed
- **`_Layout.cshtml`:** link Materiales habilitado (`asp-page="/Materiales/Index"`).
- **`Obras/Details`:** nueva sección "Materiales" con tabla de ObraMateriales + sub-filas de compras inline (fecha, cantidad, costo, total), botones "Agregar material" y "Registrar compra".
- **`Obras/Details.cshtml.cs`:** inyección de `IObraMaterialService`, carga de `ObraMateriales` en `OnGetAsync`.
- **`Program.cs`:** registro de 3 nuevos repositorios y 3 nuevos services en el contenedor DI.

### Permisos por rol (Iteración 3)

| Acción | Administrador | Capataz | Consulta |
|--------|---------------|---------|----------|
| Ver catálogo de materiales | Sí (todos) | Sí (activos) | Sí (activos) |
| Crear/editar materiales | Sí | Sí | No |
| Dar de baja materiales | Sí | Sí | No |
| Agregar/quitar material de obra | Sí | Sí | No |
| Registrar/eliminar compras | Sí | Sí | No |

---

## [v1.1.1] — 2026-06-25

**Fixes y mejoras de UX**

### Added
- **Toast notifications:** mensajes de éxito convertidos a popup flotante (top-right, glassmorphism, auto-dismiss 4s, botón ×). Bootstrap `.text-muted` sobrescrito con `!important` para contraste correcto.
- **Page loader:** overlay circular animado de 1.5s en cada cambio de página (fade-in al cargar, fade-out al salir).
- **Login spinner:** botón "Ingresar" muestra spinner inline al enviar el formulario. Ancho cambiado de `w-100` a `min-width: 160px` centrado.

### Changed
- **`site.css`:** variable `--text-muted` de `0.38` → `0.55` de opacidad. Nuevas clases: `.toast-notification`, `.toast-success`, `.toast-icon`, `.toast-message`, `.toast-close`, `.page-loader`, `.loader-spinner`, `.btn-spinner`. Animaciones `@keyframes toastSlideIn`, `toastFadeOut`, `spin`.
- **`site.js`:** función global `dismissToast()`. Lógica de auto-hide del toast (4s). Lógica del page loader (muestra en carga 1.5s + en clicks de links). Lógica del spinner de login (verifica ausencia de errores de validación antes de activar).
- **`Login.cshtml`:** botón submit: removido `w-100`, agregado `id="loginBtn"`.

---

## [v1.1] — 2026-06-24

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

## [v1.0.1] — 2026-06-24

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

## [v1.0] — 2026-06-24

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
| `v1.0.1` | Post-MVP (UI polish) | Completado |
| `v1.1` | 2 — Personal | Completado |
| `v1.1.1` | UX fixes | Completado |
| `v1.2` | 3 — Materiales | Completado |
| `v1.2.1` | Favicon | Completado |
| `v1.3` | 4 — Finanzas + Panel completo | Completado |

---

*Mantenido por el equipo de desarrollo.*
