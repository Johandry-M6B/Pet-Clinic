# 🐾 Tareas de la Semana 1: Registro de Pacientes y Mascotas

---

## 🎯 Objetivo
Registrar y consultar pacientes desde la consola para tener un control inicial de la información básica.

---

## ⚙️ Configuración del Entorno
- [x] Descargar e instalar el **.NET SDK** compatible con C#.
- [x] Configurar el editor recomendado (**Visual Studio** o **VS Code**).
- [x] Crear un primer programa de consola para verificar que el entorno funcione.

---

## 🏗️ Creación del Proyecto
- [x] Crear un proyecto de consola llamado `ClinicaSalud`.
- [x] Organizar la estructura de carpetas (crear carpeta `Models`).
- [x] Configurar `Program.cs` como punto de entrada del programa.

---

## 👤 Gestión de Pacientes
- [ ] Crear la clase `Paciente` en `Models` con propiedades:
  - `Id` (int)
  - `Nombre` (string)
  - `Edad` (int)
  - `Sintoma` (string)
- [ ] Probar la creación de objetos `Paciente` en `Program.cs`.
- [ ] Declarar lista de pacientes en `Program.cs`.
- [ ] Crear clase `PacienteService` para separar responsabilidades.
- [ ] Desarrollar método **RegistrarPaciente**.
- [ ] Desarrollar método **ListarPacientes**.
- [ ] Desarrollar método **BuscarPacientePorNombre**.

---

## 📋 Menú Principal
- [ ] Diseñar menú con opciones:  
  1️⃣ Registrar paciente  
  2️⃣ Listar pacientes  
  3️⃣ Buscar paciente  
  4️⃣ Salir
- [ ] Implementar bucle `while` para repetir el menú hasta salir.
- [ ] Implementar navegación entre opciones con `switch-case`.

---

## ⚠️ Manejo de Errores
- [ ] Implementar manejo básico de errores con `try-catch`.
- [ ] Validar que la edad ingresada sea un número entero.
- [ ] Capturar excepciones al convertir datos.
- [ ] Mostrar mensajes amigables al usuario si la entrada es incorrecta.

---

> ✅ Puedes marcar las tareas completadas agregando `x` dentro de los corchetes `[x]`.