using Usuarios.Repositorio;
using Usuarios.Servicos;

public static class RegistrosDI
{
    public static IServiceCollection InjecaoServicos(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<IUsuarioServicos, UsuarioServicos>();
        services.AddScoped<IPessoaFisicaServicos, PessoaFisicaServicos>();
        services.AddScoped<IPessoaJuridicaServicos, PessoaJuridicaServicos>();
        services.AddScoped<IEnderecoServicos, EnderecoServicos>();

        return services;
    }

    public static IServiceCollection InjecaoRepositorios(this IServiceCollection services)
    {
        services.AddScoped(typeof(ICRUDGenerico<>), typeof(CRUDGenerico<>));
        return services;
    }
}