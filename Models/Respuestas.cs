public class Respuestas {
    public int IdRespuestas { set;  get;}
    public int IdPregunta { set;  get;}
    public int Opcion { set;  get;}
    public string Contenido { set;  get;}
    public bool Correcta { set;  get;}
    public string Foto { set;  get;}
    public Respuestas(int idRespuestas, int idPregunta, int opcion, string contenido, bool correcta, string foto ) {
        IdRespuestas = idRespuestas;
        IdPregunta = idPregunta;
        Opcion = opcion;
        Contenido = contenido;
        Correcta = correcta;
        Foto = foto;
    }
}