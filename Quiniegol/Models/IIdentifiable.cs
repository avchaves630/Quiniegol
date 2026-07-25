namespace Quiniegol.Models
{
    /// <summary>
    /// Contrato para identificar de forma única una entidad del sistema.
    /// </summary>
    public interface IIdentifiable
    {
        /// <summary>
        /// Retorna el identificador único de la entidad.
        /// </summary>
        string GetId();
    }
}
