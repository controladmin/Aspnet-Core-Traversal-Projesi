#pragma checksum "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Shared\Components\_CommentList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2eed5ed42756cbf35d26ef7e0853bdf4d64b159"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components__CommentList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/_CommentList/Default.cshtml")]
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
#line 3 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\_ViewImports.cshtml"
using EntityLayer.Concreate;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2eed5ed42756cbf35d26ef7e0853bdf4d64b159", @"/Views/Shared/Components/_CommentList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"482fb87065e3ce3f5ae1a007d021543e69790139", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components__CommentList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Comment>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!--Burayı DestinationsDetails içinden kesip buraya taşıdık-->\r\n<div class=\"comments mt-5\">\r\n    <h4 class=\"side-title \">Yorumlar (");
#nullable restore
#line 5 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Shared\Components\_CommentList\Default.cshtml"
                                 Write(ViewBag.commentCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</h4>\r\n");
#nullable restore
#line 6 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Shared\Components\_CommentList\Default.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"media mt-4\">\r\n            <div class=\"img-circle\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 317, "\"", 344, 1);
#nullable restore
#line 10 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Shared\Components\_CommentList\Default.cshtml"
WriteAttributeValue("", 323, item.AppUser.ImageUr, 323, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\" alt=\"...\">\r\n            </div>\r\n            <div class=\"media-body\">\r\n\r\n                <ul class=\"time-rply mb-2\">\r\n                    <li>\r\n                        <a href=\"#URL\" class=\"name mt-0 mb-2 d-block\">");
#nullable restore
#line 16 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Shared\Components\_CommentList\Default.cshtml"
                                                                 Write(item.AppUser.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 16 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Shared\Components\_CommentList\Default.cshtml"
                                                                                    Write(item.AppUser.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        ");
#nullable restore
#line 17 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Shared\Components\_CommentList\Default.cshtml"
                    Write(((DateTime)item.CommentDate).ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                    </li>
                    <li class=""reply-last"">
                        <a href=""#reply"" class=""reply"">
                            Yanıtla
                        </a>
                    </li>
                </ul>
                <p>
                  ");
#nullable restore
#line 27 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Shared\Components\_CommentList\Default.cshtml"
             Write(item.CommentContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 31 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Shared\Components\_CommentList\Default.cshtml"
     }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Comment>> Html { get; private set; }
    }
}
#pragma warning restore 1591
