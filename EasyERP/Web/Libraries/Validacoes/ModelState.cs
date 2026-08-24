
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BOPE.Libraries.Validacoes
{
    public static class ModelStateHelper
    {

        //ModelStateHelper.ValidarModelState(ModelState);
        public static void ValidarModelState(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                var mensagens = string.Join("<br />", modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                throw new Exception(mensagens);
            }
        }
    }
}
