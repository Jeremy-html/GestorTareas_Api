﻿namespace GestorTareas_Api.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public bool Estado { get; set; } // Activo/Inactivo
        public ICollection<Tarea> Tareas { get; set; }
    }
}
