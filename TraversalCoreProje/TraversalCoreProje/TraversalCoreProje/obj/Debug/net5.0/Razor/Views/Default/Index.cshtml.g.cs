#pragma checksum "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Default\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47163595e7e2638690094621546e1ebd0c73bb13"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Default_Index), @"mvc.1.0.view", @"/Views/Default/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47163595e7e2638690094621546e1ebd0c73bb13", @"/Views/Default/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"482fb87065e3ce3f5ae1a007d021543e69790139", @"/Views/_ViewImports.cshtml")]
    public class Views_Default_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Default\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_UILayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!--\r\n    Sayfa: Manin Dafault index\r\n-->\r\n<h1>Index</h1>\r\n\r\n\r\n<!--shared altındaki _SliderPartial klasörüdür çünkü onun altında Default.cshtml var burdaki kodları oraya taşıdık-->\r\n");
#nullable restore
#line 14 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Default\Index.cshtml"
Write(await Component.InvokeAsync("_SliderPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<!--shared altındaki _PopularDestinations klasörüdür çünkü onun altında Default.cshtml var burdaki kodları oraya taşıdık-->\r\n");
#nullable restore
#line 17 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Default\Index.cshtml"
Write(await Component.InvokeAsync("_PopularDestinations"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<!--shared altındaki _Statistic klasörüdür çünkü onun altında Default.cshtml var burdaki kodları oraya taşıdık-->\r\n");
#nullable restore
#line 21 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Default\Index.cshtml"
Write(await Component.InvokeAsync("_Statistic"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<!--shared altındaki _Feature klasörüdür çünkü onun altında Default.cshtml var burdaki kodları oraya taşıdık-->\r\n");
#nullable restore
#line 24 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Default\Index.cshtml"
Write(await Component.InvokeAsync("_Feature"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<!--shared altındaki _SubAbout klasörüdür çünkü onun altında Default.cshtml var burdaki kodları oraya taşıdık-->\r\n");
#nullable restore
#line 27 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Default\Index.cshtml"
Write(await Component.InvokeAsync("_SubAbout"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<!--shared altındaki _Testimonial klasörüdür çünkü onun altında Default.cshtml var burdaki kodları oraya taşıdık-->\r\n");
#nullable restore
#line 30 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Views\Default\Index.cshtml"
Write(await Component.InvokeAsync("_Testimonial"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
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
