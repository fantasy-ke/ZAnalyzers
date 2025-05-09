using Microsoft.AspNetCore.Authorization;

namespace ZAnalyzers.Test.Attr
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TestAuthorizeAttribute : AuthorizeAttribute
    {
        public string[] AuthorizeName { get; set; }
        public TestAuthorizeAttribute(params string[] policyNames)
        {
            AuthorizeName = policyNames;
            Policy = AuthorizeName.Length > 0 ? string.Join(",", AuthorizeName) : null;
        }
    }
}
