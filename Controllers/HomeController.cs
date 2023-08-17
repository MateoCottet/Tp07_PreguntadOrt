using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PreguntadOrt.Models;

namespace PreguntadOrt.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult ConfigurarJuego() {
        Juego.InicializarJuego();
        return View();
    }
    public IActionResult CambiarConfig(string _username, int dificultad, int categoria) {
        Juego.CargarPartida(_username,dificultad,categoria);
        return View("Index");
    }
    public IActionResult Jugar() {
        Preguntas preg = Juego.ObtenerProximaPregunta();
        if(preg == null) {
            return View("Fin");
        }
        ViewBag.Pregunta = preg;
        ViewBag.Respuestas = Juego.ObtenerProximasRespuestas(preg.IdPregunta);
        return View("Jugar");
    }
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta,string enunciado, string respuesta) {
        ViewBag.Correcta = Juego.VerificarRespuesta(idPregunta,idRespuesta);
        ViewBag.IdPregunta = idPregunta;
        ViewBag.Pregunta = enunciado;
        ViewBag.Respuesta = respuesta;
        ViewBag.Progreso = Juego._CantidadPreguntasCorrectas;
        ViewBag.Maximo = Juego._CantidadPreguntas;
        return View("Respuesta");
    }
        public IActionResult Reiniciar(int idPregunta) {
        List<Preguntas> pregs = BD.ObtenerPreguntas(1,1); // FALTA HACER QUE SE PIDAN LAS PREGUNTAS POR CATEGORIA Y DIFICULTAD
        Preguntas preg = new Preguntas();
        foreach(var i in pregs) {
            if (i.IdPregunta == idPregunta) {
                preg = i;
            }
        }
        ViewBag.Pregunta = preg;
        ViewBag.Respuestas = Juego.ObtenerProximasRespuestas(preg.IdPregunta);
        return View("Jugar");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
