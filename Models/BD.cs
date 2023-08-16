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
            string sql = "exec [ObtenerRespuestas] @idpregunta";
            return db.Query<Pregunta>(sql, new{idpregunta = IdPregunta});
        }
    }
      public static Pregunta obtenerCategorias(int IdCtegoria)
    {
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "exec [obtenerCategorias] @idcategoria";
            return db.Query<Pregunta>(sql, new{idctegoria = IdCtegoria});
        }
    }
      public static Pregunta obtenerDificultades(int IdDificultad)
    {
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "exec [obtenerDificultades] @idcategoria";
            return db.Query<Pregunta>(sql, new{iddificultad = IdDificultad});
        }
    }
}
