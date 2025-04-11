namespace GestorTareas_Api.Models
{
    public class TareaCategoria
    {
        public int IDTarea_Categoria { get; set; }
        public int ID_Tarea { get; set; }
        public int ID_Categoria { get; set; }

        public Tarea Tarea { get; set; }
        public Categoria Categoria { get; set; }
    }
}
