namespace Quiniegol.Models
{
    /// <summary>
    /// Contrato para serializar y deserializar entidades en formato CSV.
    /// </summary>
    public interface ICSVSerializable
    {
        /// <summary>
        /// Convierte la entidad a una línea de texto CSV.
        /// </summary>
        string ToCSVLine();

        /// <summary>
        /// Retorna el encabezado de columnas correspondiente al CSV.
        /// </summary>
        string GetHeader();
    }
}
