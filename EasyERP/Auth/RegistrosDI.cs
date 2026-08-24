using Auth.Repositorio;
using Auth.Servicos;

public static class RegistrosDI
{
    public static IServiceCollection InjecaoServicos(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<IUsuarioServicos, UsuarioServicos>();
        services.AddScoped<IPessoaFisicaServicos, PessoaFisicaServicos>();
        services.AddScoped<IPessoaJuridicaServicos, PessoaJuridicaServicos>();
        services.AddScoped<IEnderecoServicos, EnderecoServicos>();
        services.AddScoped<IAcessoServicos, AcessoServicos>();
        services.AddScoped<IModuloServicos, ModuloServicos>();

        return services;
    }

    public static IServiceCollection InjecaoRepositorios(this IServiceCollection services)
    {
        services.AddScoped(typeof(ICRUDGenerico<>), typeof(CRUDGenerico<>));
        return services;
    }
}