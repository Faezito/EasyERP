using Newtonsoft.Json;

namespace Bibliotecas;

public static class ObjectExt
{
    //
    // Summary:
    //     Clona o objeto.
    //
    // Parameters:
    //   source:
    //     O objeto a ser clonado.
    //
    // Type parameters:
    //   T:
    //     Tipo do objeto.
    //
    // Returns:
    //     Nova instância do objeto clonado.
    public static T Clonar<T>(this T source)
    {
        return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
    }
}
