using AplicativoSeguridad.Models;
using Microsoft.Data.SqlClient;

namespace AplicativoSeguridad.Controllers
{
    public class SQLController
    {
        public SQLController() { }

        public List<Activo> GetDataAct()
        {
            List<Activo> activos = new List<Activo>();

            // Retrieve the "Activo" data from the SQL Server or other data source
            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-G6T119Q;Database=AplicativoSeguridad;Trusted_Connection=True;MultipleActiveResultSets=true"))
            //using (SqlConnection connection = new SqlConnection("Server=BlackDragon;Database=AplicativoSeguridad;Trusted_Connection=True;MultipleActiveResultSets=true"))
            //using (SqlConnection connection = new SqlConnection("Server=MSI\\SQLEXPRESS;Database=AplicativoSeguridad;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Identificador, Criticidad FROM Activo", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Activo activo = new Activo();
                    activo.Identificador = reader.GetString(0);
                    activo.Criticidad = reader.GetInt32(1);

                    activos.Add(activo);
                }

                reader.Close();
            }

            return activos;
        }

        public List<Control> GetDataContr()
        {
            List<Control> controles = new List<Control>();

            // Retrieve the "Activo" data from the SQL Server or other data source
            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-G6T119Q;Database=AplicativoSeguridad;Trusted_Connection=True;MultipleActiveResultSets=true"))
            //using (SqlConnection connection = new SqlConnection("Server=BlackDragon;Database=AplicativoSeguridad;Trusted_Connection=True;MultipleActiveResultSets=true"))
            //using (SqlConnection connection = new SqlConnection("Server=MSI\\SQLEXPRESS;Database=AplicativoSeguridad;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Codigo, Eficiencia FROM Control", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Control control = new Control();
                    control.Codigo = reader.GetString(0);
                    control.Eficiencia = reader.GetInt32(1);

                    controles.Add(control);
                }

                reader.Close();
            }

            return controles;
        }

        public List<Vulnerabilidad> GetDataVul()
        {
            List<Vulnerabilidad> vulnerabilidades = new List<Vulnerabilidad>();

            // Retrieve the "Activo" data from the SQL Server or other data source
            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-G6T119Q;Database=AplicativoSeguridad;Trusted_Connection=True;MultipleActiveResultSets=true"))
            //using (SqlConnection connection = new SqlConnection("Server=BlackDragon;Database=AplicativoSeguridad;Trusted_Connection=True;MultipleActiveResultSets=true"))
            //using (SqlConnection connection = new SqlConnection("Server=MSI\\SQLEXPRESS;Database=AplicativoSeguridad;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Codigo, NivAmenaza, NivVulnerabilidad FROM Vulnerabilidad", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Vulnerabilidad vulnerabilidad = new Vulnerabilidad();
                    vulnerabilidad.Codigo = reader.GetString(0);
                    vulnerabilidad.NivAmenaza = reader.GetInt32(1);
                    vulnerabilidad.NivVulnerabilidad = reader.GetInt32(2);

                    vulnerabilidades.Add(vulnerabilidad);
                }

                reader.Close();
            }

            return vulnerabilidades;
        }
    }
}
