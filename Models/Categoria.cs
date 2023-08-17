public class Categoria {
    public int IdCategoria { set;  get;}
    public string Nombre { set;  get;}
    public string Foto { set;  get;}
    public Categoria(int idCategoria, string nombre, string foto ) {
        IdCategoria = idCategoria;
        Nombre = nombre;
        Foto = foto;
    }
}