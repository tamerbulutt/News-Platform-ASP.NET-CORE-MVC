#pragma checksum "C:\Users\tamer\source\repos\NewsTK\NewsTK\Views\User\AccessDenied.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "780248ba8134a5bb8da6ec2146150dc8f3bf593b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_AccessDenied), @"mvc.1.0.view", @"/Views/User/AccessDenied.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\tamer\source\repos\NewsTK\NewsTK\Views\_ViewImports.cshtml"
using NewsTK;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tamer\source\repos\NewsTK\NewsTK\Views\_ViewImports.cshtml"
using NewsTK.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\tamer\source\repos\NewsTK\NewsTK\Views\_ViewImports.cshtml"
using NewsTK.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"780248ba8134a5bb8da6ec2146150dc8f3bf593b", @"/Views/User/AccessDenied.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe320eef26f0eab6056febf8c1b2fd49254f4d77", @"/Views/_ViewImports.cshtml")]
    public class Views_User_AccessDenied : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div class=\"alert alert-danger\" role=\"alert\">\r\n    You are not authorized to access this page.\r\n    <a href=\"/Home/Index\" class=\"alert-link\">Click</a> to return to the main page\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
