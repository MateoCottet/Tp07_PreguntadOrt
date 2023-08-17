public class Preguntas
{
    public int IdPregunta {get; private set;}
    public int IdCategoria {get; private set;}
    public int IdDificultad {get; private set;}
    public string Enunciado {get; private set;}
    public string Foto {get; private set;}
    
    public Preguntas(){}

    public Preguntas(int idPregunta, int idCategoria, int idDificultad, string enunciado, string foto) {
        IdPregunta = idPregunta;
        IdCategoria = idCategoria;
        IdDificultad = idDificultad;
        Enunciado = enunciado;
        Foto = foto;
    }
}