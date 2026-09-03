using Bibliotecas.Http;
using Web.Areas.Escolar.Services;
using Web.Services;

public static class RegistrosDI
{
    public static IServiceCollection InjecaoServicos(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<IAcessoServices, AcessoServices>();
        services.AddScoped<IPessoaServices, PessoaServices>();
        services.AddScoped<IAlunoServices, AlunoServices>();
        services.AddScoped<IModuloServices, ModuloServices>();
        services.AddScoped<IModuloServices, ModuloServices>();
        services.AddScoped<ITurmaServices, TurmaServices>();
        services.AddScoped<IUsuarioServices, UsuarioServices>();
        services.AddScoped<IDisciplinaServices, DisciplinaServices>();

        services.AddScoped<IClientFactory, ClientFactory>();

        return services;
    }
}