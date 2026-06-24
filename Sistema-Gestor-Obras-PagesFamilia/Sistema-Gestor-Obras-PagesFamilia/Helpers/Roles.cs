namespace Sistema_Gestor_Obras_PagesFamilia.Helpers;

public static class Roles
{
    public const string Administrador = "Administrador";
    public const string Capataz = "Capataz";
    public const string Consulta = "Consulta";

    public static bool PuedeEscribir(string? rolNombre) =>
        rolNombre is Administrador or Capataz;

    public static bool EsAdministrador(string? rolNombre) =>
        rolNombre == Administrador;

    public static bool EsSoloLectura(string? rolNombre) =>
        rolNombre == Consulta;
}
