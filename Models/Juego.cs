public static class Juego{
    public static string  _username{get; private set;}
    public static int  _PuntajeActual{get; private set;}
    public static int  _CantidadPreguntasCorrectas{get; private set;}
    public static list<pregunta> preguntas{get; private set;} = new list<pregunta>();
    public static list<respuesta> respuestas{get; private set;} = new list<respuesta>();

    public static void inicializarJuego(){
        _username = "";
        dificultad = 1;
        categoria = 1;
        _puntajeActual = 0;
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
    public static pregunta ObtenerProximaPregunta8(){
        if(_preguntas.Count != 0){
            random random=new Random();
            int numAleatorio=random.Next(0, _preguntas.Count);
            return _preguntas[numAleatorio];
        }
        else{
            return null;
        }
    }

    public static List<Respuesta> ObtenerProximasRespuestas(int idPregunta){
        List<Respuesta> respuestas = BD.ObtenerRespuestas(_preguntas);
        List<Respuesta> respuestas = ne List<Respuesta>();
        foreach(var item in respuestas)
        {
            if(item.IdPregunta == idPregunta){
                respuesta.Add(item);
            }
        }
        return respuesta;

    }
    
    public static bool VerificarRespuesta(int idPregunta, int idRespuesta){
        Pregunta pregunta = null;
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
                    _puntajeActual+=5;
                    cantidadPreguntasCorrectas+=1;
                    _preguntas.Remove(pregunta);
                    _respuestas.Remove(item);
                    return true;
                }
            }
        }
        return false;
    }

}