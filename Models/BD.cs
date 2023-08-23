using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Dapper;
public static class BD {
    private static string _connectionString = @"Server=localhost;DataBase=PreguntadOrt;Trusted_Connection=True;";
    public static List<Categoria> ObtenerCategorias() {
        List<Categoria> categorias = null;
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sp = "ObtenerCategorias";
            categorias = db.Query<Categoria>(sp, new {}, commandType: CommandType.StoredProcedure).ToList();
        }
        return categorias;
    }
    public static List<Dificultad> ObtenerDificultades(){
        List<Dificultad> dificultades = null;
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sp = "ObtenerDificultades";
            dificultades = db.Query<Dificultad>(sp, new {}, commandType: CommandType.StoredProcedure).ToList();
        }
        return dificultades;

    }
    public static List<Pregunta> ObtenerTodasLasPreguntas() {
        List<Pregunta> preguntas = null;
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sp = "ObtenerTodasLasPreguntas";
            preguntas = db.Query<Pregunta>(sp, new {}, commandType: CommandType.StoredProcedure).ToList();
        }
        return preguntas;
    }
    public static List<Pregunta> ObtenerPreguntas(int dificultad, int categoria) {
        List<Pregunta> preguntas = null;
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sp = "ObtenerPreguntas";
            preguntas = db.Query<Pregunta>(sp, new {idDificultad  = dificultad, idCategoria  = categoria}, commandType: CommandType.StoredProcedure).ToList();
        }
        return preguntas;
    }
    public static List<Respuesta> ObtenerRespuestas(List<Pregunta> preguntas) {
        List<Respuesta> respuestas = new List<Respuesta>();
        foreach(var item in preguntas) {
            int id = item.IdPregunta;
            using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sp = "ObtenerRespuestas";
            var resultados = db.Query<Respuesta>(sp, new {IdPregunta = id}, commandType: CommandType.StoredProcedure).ToList();
            respuestas.AddRange(resultados);
        }
        }

        return respuestas;
    }
}