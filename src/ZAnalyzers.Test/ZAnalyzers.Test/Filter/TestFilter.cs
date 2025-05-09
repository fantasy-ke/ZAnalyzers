namespace ZAnalyzers.Test.Filter
{
    public class TestFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            return await next(context);
        }
    }
    public class Test1Filter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            return await next(context);
        }
    }

}
