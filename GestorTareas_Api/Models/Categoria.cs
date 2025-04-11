namespace GestorTareas_Api.Models
{
    public class Categoria
    {
        public int ID_Categoria { get; set; }
        public string Nombre { get; set; }
        public ICollection<TareaCategoria> TareasCategorias { get; set; }
    }
}
