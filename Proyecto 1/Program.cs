using System;
using System.Collections.Generic;

// Clase base Persona para aplicar herencia
public abstract class Persona
{
    public int Id { get; private set; }
    public string Nombre { get; private set; }

    public Persona(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }
}

// Clase Profesor, derivada de Persona
public class Profesor : Persona
{
    public decimal Salario { get; private set; }
    private List<Curso> cursos;

    public Profesor(int id, string nombre, decimal salario)
        : base(id, nombre)
    {
        Salario = salario;
        cursos = new List<Curso>();
    }

    public void AsignarCurso(Curso curso)
    {
        cursos.Add(curso);
    }

    public void MostrarCursos()
    {
        Console.WriteLine($"Cursos impartidos por {Nombre}:");
        foreach (var curso in cursos)
        {
            Console.WriteLine($"- {curso.Nombre}");
        }
    }
}

// Clase Estudiante, derivada de Persona
public class Estudiante : Persona
{
    public string Direccion { get; private set; }
    private List<Curso> cursosInscritos;

    public Estudiante(int id, string nombre, string direccion)
        : base(id, nombre)
    {
        Direccion = direccion;
        cursosInscritos = new List<Curso>();
    }

    public void InscribirCurso(Curso curso)
    {
        cursosInscritos.Add(curso);
    }

    public void MostrarCursosInscritos()
    {
        Console.WriteLine($"Cursos inscritos por {Nombre}:");
        foreach (var curso in cursosInscritos)
        {
            Console.WriteLine($"- {curso.Nombre}");
        }
    }
}

// Clase Curso
public class Curso
{
    public string Codigo { get; private set; }
    public string Nombre { get; private set; }
    public string Departamento { get; private set; }

    public Curso(string codigo, string nombre, string departamento)
    {
        Codigo = codigo;
        Nombre = nombre;
        Departamento = departamento;
    }
}

// Clase Escuela con agregación de profesores y composición de cursos
public class Escuela
{
    public string Nombre { get; private set; }
    private List<Profesor> profesores;
    private List<Curso> cursos;

    public Escuela(string nombre)
    {
        Nombre = nombre;
        profesores = new List<Profesor>();
        cursos = new List<Curso>();
    }

    public void AgregarProfesor(Profesor profesor)
    {
        profesores.Add(profesor);
    }

    public void AgregarCurso(Curso curso)
    {
        cursos.Add(curso);
    }

    public void MostrarProfesores()
    {
        Console.WriteLine($"Profesores en la escuela {Nombre}:");
        foreach (var profesor in profesores)
        {
            Console.WriteLine($"- {profesor.Nombre}");
        }
    }

    public void MostrarCursos()
    {
        Console.WriteLine($"Cursos en la escuela {Nombre}:");
        foreach (var curso in cursos)
        {
            Console.WriteLine($"- {curso.Nombre}");
        }
    }
}

// Clase Universidad que gestiona todas las entidades
public class Universidad
{
    private List<Escuela> escuelas;
    private List<Profesor> profesores;
    private List<Estudiante> estudiantes;

    public Universidad()
    {
        escuelas = new List<Escuela>();
        profesores = new List<Profesor>();
        estudiantes = new List<Estudiante>();
    }

    public void AgregarEscuela(Escuela escuela)
    {
        escuelas.Add(escuela);
    }

    public void RegistrarProfesor(Profesor profesor)
    {
        profesores.Add(profesor);
    }

    public void RegistrarEstudiante(Estudiante estudiante)
    {
        estudiantes.Add(estudiante);
    }

    public void MostrarEscuelas()
    {
        Console.WriteLine("Escuelas en la universidad:");
        foreach (var escuela in escuelas)
        {
            Console.WriteLine($"- {escuela.Nombre}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Crear universidad
        Universidad universidad = new Universidad();

        // Crear algunas escuelas
        Escuela escuelaIngenieria = new Escuela("Ingeniería");
        Escuela escuelaMedicina = new Escuela("Medicina");

        // Crear algunos profesores y cursos
        Profesor prof1 = new Profesor(1, "Dr. Juan", 50000);
        Profesor prof2 = new Profesor(2, "Dra. Ana", 55000);

        Curso curso1 = new Curso("C001", "Física", "Ingeniería");
        Curso curso2 = new Curso("C002", "Química", "Ingeniería");

        // Asignar cursos a los profesores
        prof1.AsignarCurso(curso1);
        prof2.AsignarCurso(curso2);

        // Agregar profesores y cursos a la escuela de Ingeniería
        escuelaIngenieria.AgregarProfesor(prof1);
        escuelaIngenieria.AgregarProfesor(prof2);
        escuelaIngenieria.AgregarCurso(curso1);
        escuelaIngenieria.AgregarCurso(curso2);

        // Registrar escuelas en la universidad
        universidad.AgregarEscuela(escuelaIngenieria);
        universidad.AgregarEscuela(escuelaMedicina);

        // Crear y registrar estudiantes
        Estudiante est1 = new Estudiante(101, "Carlos", "Calle Falsa 123");
        Estudiante est2 = new Estudiante(102, "María", "Av. Siempre Viva 456");

        est1.InscribirCurso(curso1);
        est2.InscribirCurso(curso2);

        universidad.RegistrarEstudiante(est1);
        universidad.RegistrarEstudiante(est2);

        // Mostrar información
        universidad.MostrarEscuelas();
        escuelaIngenieria.MostrarProfesores();
        escuelaIngenieria.MostrarCursos();
        prof1.MostrarCursos();
        est1.MostrarCursosInscritos();
    }
}

