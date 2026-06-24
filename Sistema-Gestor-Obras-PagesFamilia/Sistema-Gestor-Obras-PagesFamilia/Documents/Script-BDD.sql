--  Sistema de Gestion de Obras "Pages & Familia".
--  Script de creacion de BDD.
--  Integrantes: Alex Roth, Juan Meny, Facundo Villalba.

-- CREATE DATABASE pages_familia;
-- USE pages_familia;

CREATE TABLE rol (
    id_rol INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50)  UNIQUE NOT NULL,
    descripcion VARCHAR(255) NULL
);

CREATE TABLE oficio (
    id_oficio INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(60) UNIQUE NOT NULL
);

CREATE TABLE estado_obra (
    id_estado INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(40) UNIQUE NOT NULL,
    orden INT NULL
);

CREATE TABLE categoria_mov (
    id_categoria INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(60) UNIQUE NOT NULL,
    tipo VARCHAR(10) NOT NULL CHECK (tipo IN ('INGRESO','EGRESO'))
);

CREATE TABLE empleado (
    id_empleado INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(120) NOT NULL,
    documento VARCHAR(20) UNIQUE NULL,
    telefono VARCHAR(30) NULL,
    tipo VARCHAR(15) NOT NULL CHECK (tipo IN ('FIJO','SUBCONTRATISTA')),
    id_oficio INT NULL,
    activo BOOLEAN NOT NULL DEFAULT TRUE,
    fecha_baja DATE NULL,
    FOREIGN KEY (id_oficio) REFERENCES oficio (id_oficio)
);

CREATE TABLE usuario (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    email VARCHAR(120) UNIQUE NOT NULL,
    contrasenia VARCHAR(255) NOT NULL,
    id_empleado INT UNIQUE NULL,
    activo BOOLEAN NOT NULL DEFAULT TRUE,
    fecha_creacion DATETIME NULL,
    FOREIGN KEY (id_empleado) REFERENCES empleado (id_empleado)
);

CREATE TABLE usuario_rol (
    id_usuario INT NOT NULL,
    id_rol INT NOT NULL,
    PRIMARY KEY (id_usuario, id_rol),
    FOREIGN KEY (id_usuario) REFERENCES usuario (id_usuario),
    FOREIGN KEY (id_rol) REFERENCES rol (id_rol)
);

CREATE TABLE cliente (
    id_cliente INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(120) NOT NULL,
    telefono VARCHAR(30)  NULL,
    email VARCHAR(120) NULL,
    activo BOOLEAN NOT NULL DEFAULT TRUE
);

CREATE TABLE obra (
    id_obra INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(150) NOT NULL,
    direccion VARCHAR(200) NULL,
    descripcion VARCHAR(500) NULL,
    fecha_inicio DATE NULL,
    fecha_fin_estimada DATE NULL,
    id_cliente INT NOT NULL,
    id_estado INT NOT NULL,
    activo BOOLEAN NOT NULL DEFAULT TRUE,
    fecha_baja DATE NULL,
    creado_por INT NULL,
    fecha_creacion DATETIME NULL,
    FOREIGN KEY (id_cliente) REFERENCES cliente (id_cliente),
    FOREIGN KEY (id_estado) REFERENCES estado_obra (id_estado),
    FOREIGN KEY (creado_por) REFERENCES usuario (id_usuario)
);

CREATE TABLE asignacion (
    id_asignacion INT AUTO_INCREMENT PRIMARY KEY,
    id_empleado INT NOT NULL,
    id_obra INT NOT NULL,
    tarea VARCHAR(150) NULL,
    fecha_inicio DATE NOT NULL,
    fecha_fin DATE NULL,
    creado_por INT NULL,
    fecha_creacion DATETIME NULL,
    CHECK (fecha_fin IS NULL OR fecha_fin >= fecha_inicio),
    FOREIGN KEY (id_empleado) REFERENCES empleado (id_empleado),
    FOREIGN KEY (id_obra) REFERENCES obra (id_obra),
    FOREIGN KEY (creado_por) REFERENCES usuario (id_usuario)
);

CREATE TABLE registro_horas (
    id_registro INT AUTO_INCREMENT PRIMARY KEY,
    id_asignacion INT NOT NULL,
    fecha DATE NOT NULL,
    horas DECIMAL(5,2) NOT NULL CHECK (horas > 0 AND horas <= 24),
    fecha_creacion DATETIME NULL,
    FOREIGN KEY (id_asignacion) REFERENCES asignacion (id_asignacion)
);

CREATE TABLE material (
    id_material INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(120) UNIQUE NOT NULL,
    unidad VARCHAR(20) NOT NULL,
    activo BOOLEAN NOT NULL DEFAULT TRUE
);

CREATE TABLE obra_material (
    id_obra_material  INT AUTO_INCREMENT PRIMARY KEY,
    id_obra INT NOT NULL,
    id_material INT NOT NULL,
    cant_requerida DECIMAL(12,2) NOT NULL DEFAULT 0 CHECK (cant_requerida >= 0),
    UNIQUE (id_obra, id_material),
    FOREIGN KEY (id_obra) REFERENCES obra (id_obra),
    FOREIGN KEY (id_material) REFERENCES material (id_material)
);

CREATE TABLE movimiento_fin (
    id_movimiento INT AUTO_INCREMENT PRIMARY KEY,
    id_obra INT NOT NULL,
    id_categoria INT NOT NULL,
    monto DECIMAL(14,2) NOT NULL CHECK (monto > 0),
    fecha DATE NOT NULL,
    descripcion VARCHAR(255) NULL,
    creado_por INT NULL,
    fecha_creacion DATETIME NULL,
    FOREIGN KEY (id_obra) REFERENCES obra (id_obra),
    FOREIGN KEY (id_categoria) REFERENCES categoria_mov (id_categoria),
    FOREIGN KEY (creado_por) REFERENCES usuario (id_usuario)
);

CREATE TABLE compra (
    id_compra INT AUTO_INCREMENT PRIMARY KEY,
    id_obra_material INT NOT NULL,
    id_movimiento INT UNIQUE NOT NULL,
    cantidad DECIMAL(12,2) NOT NULL CHECK (cantidad > 0),
    costo_unitario DECIMAL(14,2) NOT NULL CHECK (costo_unitario >= 0),
    fecha DATE NOT NULL,
    creado_por INT NULL,
    fecha_creacion DATETIME NULL,
    FOREIGN KEY (id_obra_material) REFERENCES obra_material (id_obra_material),
    FOREIGN KEY (id_movimiento) REFERENCES movimiento_fin (id_movimiento),
    FOREIGN KEY (creado_por) REFERENCES usuario (id_usuario)
);

--  Datos iniciales
INSERT INTO rol (nombre, descripcion) VALUES
    ('Administrador', 'Acceso total'),
    ('Capataz', 'Carga de horas y avance de obra'),
    ('Consulta', 'Solo lectura de informacion');

INSERT INTO estado_obra (nombre, orden) VALUES
    ('Planificada', 1),
    ('En curso', 2),
    ('Pausada', 3),
    ('Finalizada', 4),
    ('Cancelada', 5);

INSERT INTO oficio (nombre) VALUES
    ('Albanil'),
    ('Electricista'),
    ('Sanitario'),
    ('Pintor'),
    ('Carpintero'),
    ('Herrero');

INSERT INTO categoria_mov (nombre, tipo) VALUES
    ('Cobro a cliente', 'INGRESO'),
    ('Anticipo', 'INGRESO'),
    ('Compra de material', 'EGRESO'),
    ('Pago de personal', 'EGRESO'),
    ('Gasto general', 'EGRESO');

-- Usuario administrador inicial (contraseña en texto plano — entorno académico)
INSERT INTO usuario (email, contrasenia, activo, fecha_creacion) VALUES
    ('admin@pages.com', 'admin123', TRUE, NOW());

INSERT INTO usuario_rol (id_usuario, id_rol) VALUES
    (1, 1);

-- Clientes de ejemplo para pruebas del MVP
INSERT INTO cliente (nombre, telefono, email, activo) VALUES
    ('García, Juan', '341-5551234', 'juan.garcia@email.com', TRUE),
    ('Constructora Sur SRL', '341-5559876', 'contacto@consursrl.com', TRUE);
