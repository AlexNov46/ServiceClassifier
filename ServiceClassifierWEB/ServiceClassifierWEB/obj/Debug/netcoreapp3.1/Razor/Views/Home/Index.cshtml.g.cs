#pragma checksum "C:\Users\ProBookG6\Documents\GitHub\ServiceClassifier\ServiceClassifierWEB\ServiceClassifierWEB\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "451cb64ba3c0b1ab98daca1efcc837b0ef3a66c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\ProBookG6\Documents\GitHub\ServiceClassifier\ServiceClassifierWEB\ServiceClassifierWEB\Views\_ViewImports.cshtml"
using ServiceClassifierWEB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ProBookG6\Documents\GitHub\ServiceClassifier\ServiceClassifierWEB\ServiceClassifierWEB\Views\_ViewImports.cshtml"
using ServiceClassifierWEB.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"451cb64ba3c0b1ab98daca1efcc837b0ef3a66c9", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38924e168008b6d70849b4fec8d2003017653aae", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\ProBookG6\Documents\GitHub\ServiceClassifier\ServiceClassifierWEB\ServiceClassifierWEB\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Сервис для классификации обращений</h1>
    <br />
    <p>
        <textarea class=""inputbox"" id=""Input"" cols=""45"" placeholder=""Введите ваше обращение""></textarea>
    </p>
    <button class=""button"" id=""Start"">
        <span>
            Отправить запрос
        </span>
    </button>
    <br />
    <br />
    <p class=""output"" id=""Output"" >
        Здесь будет ответ
    </p>
</div>
");
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
