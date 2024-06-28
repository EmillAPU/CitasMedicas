CREATE DATABASE CitasMedicas
USE CitasMedicas

-- Insertar datos en la tabla Paciente
INSERT INTO Pacientes (Nombre, Apellido, FechaNacimiento, Email, Telefono) VALUES
('Juan', 'Perez', '1985-06-15', 'juan.perez@example.com', '555-1234'),
('Maria', 'Gonzalez', '1990-12-22', 'maria.gonzalez@example.com', '555-5678'),
('Carlos', 'Ramirez', '1978-03-30', 'carlos.ramirez@example.com', '555-8765'),
('Ana', 'Lopez', '1982-07-18', 'ana.lopez@example.com', '555-4321');

-- Insertar datos en la tabla Especialidad
INSERT INTO Especialidads (Nombre) VALUES
('Cardiología'),
('Dermatología'),
('Neurología'),
('Pediatría');

-- Insertar datos en la tabla Medico
INSERT INTO Medicos (Nombre, Apellido, EspecialidadId) VALUES
('Laura', 'Martinez', 1),
('Roberto', 'Gomez', 2),
('Andrea', 'Fernandez', 3),
('David', 'Sanchez', 4);

-- Insertar datos en la tabla Cita
INSERT INTO Citas(PacienteId, MedicoId, FechaCita, Motivo) VALUES
(1, 1, '2024-07-01 10:00:00', 'Consulta de cardiología'),
(2, 2, '2024-07-02 11:30:00', 'Consulta de dermatología'),
(3, 3, '2024-07-03 09:00:00', 'Consulta de neurología'),
(4, 4, '2024-07-04 14:00:00', 'Consulta de pediatría'),
(1, 2, '2024-07-05 16:00:00', 'Revisión dermatológica');
