#pragma checksum "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Shared\Components\_SubAbout\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62f9b3e2d7c0c5eb61997fe1a2345a165869403b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components__SubAbout_Default), @"mvc.1.0.view", @"/Views/Shared/Components/_SubAbout/Default.cshtml")]
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
#line 1 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\_ViewImports.cshtml"
using TraversalCoreProje;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\_ViewImports.cshtml"
using TraversalCoreProje.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Shared\Components\_SubAbout\Default.cshtml"
using EntityLayer.Concreate;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62f9b3e2d7c0c5eb61997fe1a2345a165869403b", @"/Views/Shared/Components/_SubAbout/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"482fb87065e3ce3f5ae1a007d021543e69790139", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components__SubAbout_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SubAbout>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"<!--burayı index.cshmtl alanından kesip aldık index.cshtml alanına partial olarak ekleyeceğiz burayı-->

<section class=""w3l-bottom py-5"">
    <div class=""container py-md-4 py-3 text-center"">
        <div class=""row my-lg-4 mt-4"">
            <div class=""col-lg-9 col-md-10 ml-auto"">
                <div class=""bottom-info ml-auto"">
                    <div class=""header-section text-left"">
");
#nullable restore
#line 12 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Shared\Components\_SubAbout\Default.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h3 class=\"hny-title two\">");
#nullable restore
#line 14 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Shared\Components\_SubAbout\Default.cshtml"
                                                 Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            <p class=\"mt-3 pr-lg-5\">\r\n                                ");
#nullable restore
#line 16 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Shared\Components\_SubAbout\Default.cshtml"
                           Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n");
#nullable restore
#line 18 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Shared\Components\_SubAbout\Default.cshtml"
                         }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a href=\"about.html\" class=\"btn btn-style btn-secondary mt-5\">Daha Fazla</a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SubAbout>> Html { get; private set; }
    }
}
#pragma warning restore 1591
