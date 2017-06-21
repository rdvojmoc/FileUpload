using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FileUpload
{
    public class AssetBinder : IModelBinder
    {
        protected readonly IHostingEnvironment _hosting;

        protected readonly FormFileOptions _fileOptions;
		

        public AssetBinder(IHostingEnvironment hosting, IOptions<FormFileOptions> fileOptions)
        {
            _hosting = hosting;
			
            _fileOptions = fileOptions.Value;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            bindingContext.ModelState.TryAddModelError("test", "test error message");
            
            return TaskCache.CompletedTask;
        }
    }

    public class AssetBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(Asset))
            {
                return new BinderTypeModelBinder(typeof(AssetBinder));
            }

            return null;
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class DisableFormValueModelBindingAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var formValueProviderFactory = context.ValueProviderFactories
                .OfType<FormValueProviderFactory>()
                .FirstOrDefault();
            if (formValueProviderFactory != null)
            {
                context.ValueProviderFactories.Remove(formValueProviderFactory);
            }

            var jqueryFormValueProviderFactory = context.ValueProviderFactories
                .OfType<JQueryFormValueProviderFactory>()
                .FirstOrDefault();
            if (jqueryFormValueProviderFactory != null)
            {
                context.ValueProviderFactories.Remove(jqueryFormValueProviderFactory);
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
