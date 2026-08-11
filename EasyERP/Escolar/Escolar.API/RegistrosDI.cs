using Escolar.Repositorio;
using Escolar.Servicos;

public static class RegistrosDI
{
    public static IServiceCollection InjecaoServicos(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<ITurmaServicos, TurmaServicos>();
        services.AddScoped<IPessoaServicos, PessoaServicos>();

        return services;
    }

    public static IServiceCollection InjecaoRepositorios(this IServiceCollection services)
    {
        services.AddScoped(typeof(ICRUDGenerico<>), typeof(CRUDGenerico<>));
        return services;
    }
}