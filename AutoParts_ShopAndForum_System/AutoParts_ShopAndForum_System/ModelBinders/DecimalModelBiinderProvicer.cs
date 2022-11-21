using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AutoParts_ShopAndForum_System.ModelBinders
{
    public class DecimalModelBiinderProvicer : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(Decimal) || context.Metadata.ModelType == typeof(Decimal?))
            {
                return new DecimalModelBinder();
            }

            return null;
        }
    }
}
