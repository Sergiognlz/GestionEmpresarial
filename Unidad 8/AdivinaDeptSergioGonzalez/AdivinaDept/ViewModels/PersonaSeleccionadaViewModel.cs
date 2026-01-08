public class PersonaSeleccionadaViewModel
{
    public int PersonaId { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;

    // Nullable para que no falle si el usuario no selecciona ningún departamento
    public int? DepartamentoSeleccionado { get; set; }

    // Color para la fila (pista, acierto/fallo)
    public string? ColorDepartamento { get; set; }
}
