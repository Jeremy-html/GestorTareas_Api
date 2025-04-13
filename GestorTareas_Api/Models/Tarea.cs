using System.ComponentModel.DataAnnotations.Schema;

namespace GestorTareas_Api.Models
{

    public class Tarea
    {
        public int ID_Tarea { get; set; }

        
        public int UsuarioID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime? Fecha_Entrega { get; set; }
        public string Estado { get; set; }
        //nuevo cambio
 

        public Usuario Usuario { get; set; }
        public ICollection<TareaCategoria> TareasCategorias { get; set; }
    }
}
