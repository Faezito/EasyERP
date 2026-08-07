using Admin.Repositorio;
using Admin.Servicos;

public static class RegistrosDI
{
    public static IServiceCollection InjecaoServicos(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<IApiExternaServicos, ApiExternaServicos>();

        return services;
    }

    public static IServiceCollection InjecaoRepositorios(this IServiceCollection services)
    {
        services.AddScoped(typeof(ICRUDGenerico<>), typeof(CRUDGenerico<>));
        return services;
    }
}