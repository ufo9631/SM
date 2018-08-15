using Castle.DynamicProxy;
using SM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.WebSite.Models
{
    public class AopInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            string paramStr = $"你正在调用方法 \"{invocation.Method.Name}\"... 参数是 {string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray())} ";
            LogUtils.Debug(paramStr);
            //在被拦截的方法执行完毕后 继续执行    
            invocation.Proceed();
            string returnStr = $"方法执行完毕，返回结果:{invocation.ReturnValue}";
            LogUtils.Debug(returnStr);
        }
    }
}
