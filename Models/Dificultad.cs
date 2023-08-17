public class Dificultad {
    public int IdDificultad { set;  get;}
    public string Nombre { set;  get;}
   
    public Dificultad(int idDificultad, string nombre) {
        IdDificultad = idDificultad;
        Nombre = nombre;
    }
}