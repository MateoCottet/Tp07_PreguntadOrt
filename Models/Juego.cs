public static class Juego{
    public static string  _username{get; set;}
    public static int  _PuntajeActual{get; set;}
    public static int  _CantidadPreguntasCorrectas{get; set;}
    public static int _CantidadPreguntas {get; set;}
    public static List<Preguntas> _preguntas{get; set;} = new List<Preguntas>();
    public static List<Respuestas> _respuestas{get; set;} = new List<Respuestas>();

    public static void InicializarJuego(){
        _username = "";
        _PuntajeActual = 0;
        _CantidadPreguntas = 0;
        _CantidadPreguntasCorrectas = 0;
    }
    public static List<Categoria> ObtenerCategorias(){
        return BD.ObtenerCategorias();
    }
      public static List<Dificultad> ObtenerDificultades(){
        return BD.ObtenerDificultades();
    }
    public static void CargarPartida(string username, int dificultad, int categoria){
        _username = username;
        _preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        _respuestas = BD.ObtenerRespuestas(_preguntas);
    }
    public static Preguntas ObtenerProximaPregunta(){
        if(_preguntas.Count != 0){
            int numAleatorio = 0;
            // FALTA HACER NUMERO ALEATORIO BIEN, EL RANDOM ESTABA MAL HECHO
            return _preguntas[numAleatorio];
        }
        else{
            return null;
        }
    }

    public static List<Respuestas> ObtenerProximasRespuestas(int idPregunta){
        List<Respuestas> resp = new List<Respuestas>();
        foreach(Respuestas item in _respuestas)
        {
            if(item.IdPregunta == idPregunta){
                resp.Add(item);
            }
        }
        return resp;

    }
    
    public static bool VerificarRespuesta(int idPregunta, int idRespuesta){
        Preguntas pregunta = new Preguntas();
        foreach(var item in _preguntas)
        {
            if(item.IdPregunta == idPregunta){
                pregunta = item;
            }
        }
        foreach(var item in _respuestas)
        {
            if(item.IdPregunta == idPregunta){
                if(item.Opcion == idRespuesta && item.Correcta == true){
                    _PuntajeActual+=5;
                    _CantidadPreguntasCorrectas+=1;
                    _preguntas.Remove(pregunta);
                    _respuestas.Remove(item);
                    return true;
                }
            }
        }
        return false;
    }

}