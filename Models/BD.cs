using System.Data.SqlClient;
using Dapper;

public static class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=PreguntadOrt; Trusted_Connection=True;";
     
    public static List<Preguntas> ObtenerPreguntas(int IdCategoria, int IdDificultad)
    {
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "exec [obtenerPreguntas] @idcategoria, @iddificultad";
            return db.Query<Preguntas>(sql, new{idcategoria = IdCategoria, iddificultad = IdDificultad}).ToList();
        }
    }
    
    public static List<Respuestas> ObtenerRespuestas(List<Preguntas> preguntas)
    {
        List<Respuestas> lista = new List<Respuestas>();
        foreach(Preguntas pregunta in preguntas){
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Respuestas WHERE IdPregunta = @id";
                lista.AddRange(db.Query<Respuestas>(sql, new{id = pregunta.IdPregunta}).ToList());
            }
        }
        return null;
    }
      public static List<Categoria> ObtenerCategorias()
    {
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Categorias";
            return db.Query<Categoria>(sql).ToList();
        }
    }
      public static List<Dificultad> ObtenerDificultades()
    {
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Dificultades";
            return db.Query<Dificultad>(sql).ToList();
        }
    }
}
