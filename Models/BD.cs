using System.Data.SqlClient;
using Dapper;

public static class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=PreguntadOrt; Trusted_Connection=True;";
     
    public static Pregunta obtenerPreguntas(int IdCategoria, int IdDificultad)
    {
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "exec [obtenerPreguntas] @idcategoria, @iddificultad";
            return db.Query<Pregunta>(sql, new{idcategoria = IdCategoria, iddificultad = IdDificultad});
        }
    }
     public static Pregunta obtenerRespuestas(int IdCPregunta)
    {
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "exec [ObtenerRespuestas] @idPregunta";
            return db.Query<Pregunta>(sql, new{idpregunta = IdPregunta});
        }
    }
}
