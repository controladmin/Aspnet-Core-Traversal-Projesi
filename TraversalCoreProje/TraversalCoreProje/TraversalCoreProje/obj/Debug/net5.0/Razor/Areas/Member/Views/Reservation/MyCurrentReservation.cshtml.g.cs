#pragma checksum "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Areas\Member\Views\Reservation\MyCurrentReservation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f328f950cb164717059b4ce5dc66c257c9901bde"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Member_Views_Reservation_MyCurrentReservation), @"mvc.1.0.view", @"/Areas/Member/Views/Reservation/MyCurrentReservation.cshtml")]
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
#line 1 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Areas\Member\Views\_ViewImports.cshtml"
using TraversalCoreProje;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Areas\Member\Views\_ViewImports.cshtml"
using TraversalCoreProje.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Areas\Member\Views\Reservation\MyCurrentReservation.cshtml"
using EntityLayer.Concreate;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f328f950cb164717059b4ce5dc66c257c9901bde", @"/Areas/Member/Views/Reservation/MyCurrentReservation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"482fb87065e3ce3f5ae1a007d021543e69790139", @"/Areas/Member/Views/_ViewImports.cshtml")]
    public class Areas_Member_Views_Reservation_MyCurrentReservation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Reservation>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Areas\Member\Views\Reservation\MyCurrentReservation.cshtml"
  
    ViewData["Title"] = "MyCurrentReservation";
    Layout = "~/Views/Shared/_MemberLayout.cshtml";
    int sayac = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<style>\r\n    tr:nth-child(odd) {\r\n        background: #f5f5f5;\r\n    }\r\n\r\n    tr:nth-child(even) {\r\n        background: #c0c0c0;\r\n    }\r\n\r\n    .table thead tr th {\r\n        background: #708090;\r\n        color: white !important;\r\n    }\r\n</style>\r\n\r\n");
#nullable restore
#line 25 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Areas\Member\Views\Reservation\MyCurrentReservation.cshtml"
 if (!Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4 style=\"color:red;\">Aktif Rezervasyon Bulunmamaktadır</h4>\r\n");
#nullable restore
#line 28 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Areas\Member\Views\Reservation\MyCurrentReservation.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Areas\Member\Views\Reservation\MyCurrentReservation.cshtml"
   




else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h4 class=""card-title"">Aktif Rezarvasyonlar</h4>
                <a class=""heading-elements-toggle""><i class=""la la-ellipsis-v font-medium-3""></i></a>
                <div class=""heading-elements"">
                    <ul class=""list-inline mb-0"">
                        <li><a data-action=""collapse""><i class=""ft-minus""></i></a></li>
                        <li><a data-action=""reload""><i class=""ft-rotate-cw""></i></a></li>
                        <li><a data-action=""expand""><i class=""ft-maximize""></i></a></li>
                        <li><a data-action=""close""><i class=""ft-x""></i></a></li>
                    </ul>
                </div>
            </div>
            <div class=""card-content collapse show"">
                <div class=""card-body"">
                    <p class=""card-text"">Web sitemiz traversal üzerinde yapmış olduğunuz aktif rezarvasyon listenize aşağıdan ");
            WriteLiteral(@"ulaşabilirsiniz </p>
                    <div class=""table-responsive"">
                        <table class=""table"">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Lokasyon</th>
                                    <th>Kişi Sayısı</th>
                                    <th>Rezervasyon Tarihi</th>
                                    <th>Durum</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 92 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Areas\Member\Views\Reservation\MyCurrentReservation.cshtml"
                                 foreach (var item in Model)
                                {
                                    sayac++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 96 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Areas\Member\Views\Reservation\MyCurrentReservation.cshtml"
                                       Write(sayac);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 97 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Areas\Member\Views\Reservation\MyCurrentReservation.cshtml"
                                       Write(item.Destination.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 98 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Areas\Member\Views\Reservation\MyCurrentReservation.cshtml"
                                       Write(item.PersonCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 99 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Areas\Member\Views\Reservation\MyCurrentReservation.cshtml"
                                       Write(item.ReservationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 100 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Areas\Member\Views\Reservation\MyCurrentReservation.cshtml"
                                       Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 102 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Areas\Member\Views\Reservation\MyCurrentReservation.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 111 "C:\Users\ali kahya\OneDrive\Masaüstü\C Sharp Projeler\TraversalCoreProje\TraversalCoreProje\TraversalCoreProje\Areas\Member\Views\Reservation\MyCurrentReservation.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Reservation>> Html { get; private set; }
    }
}
#pragma warning restore 1591
