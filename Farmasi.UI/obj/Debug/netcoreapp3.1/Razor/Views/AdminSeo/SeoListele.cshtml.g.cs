#pragma checksum "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "643766995c71bb96bf9bcb3ddb8b527c0d02c02f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Farmasi.UI.Pages.AdminSeo.Views_AdminSeo_SeoListele), @"mvc.1.0.view", @"/Views/AdminSeo/SeoListele.cshtml")]
namespace Farmasi.UI.Pages.AdminSeo
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
#line 1 "D:\Projeler\Farmasi\Farmasi.UI\Views\_ViewImports.cshtml"
using Farmasi.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projeler\Farmasi\Farmasi.UI\Views\_ViewImports.cshtml"
using Farmasi.Entities.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"643766995c71bb96bf9bcb3ddb8b527c0d02c02f", @"/Views/AdminSeo/SeoListele.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de46d58a290f41a17b8894f86b99fd2334381bad", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_AdminSeo_SeoListele : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Seo>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SeoGuncelle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AdminSeo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
  
    Layout = "_AdminLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div style=\"width:100%\">\r\n");
            WriteLiteral("\r\n</div>\r\n<br />\r\n");
#nullable restore
#line 10 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
 if (TempData["Ekleme"] != null)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert success\" id=mainAlertMessage>\r\n        <span class=\"closebtn\" onclick=\"this.parentElement.style.display=\'none\';\">&times;</span>\r\n        ");
#nullable restore
#line 15 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
   Write(TempData["Ekleme"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 17 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 19 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
 if (TempData["Guncellendi"] != null)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert info\" id=mainAlertMessage>\r\n        <span class=\"closebtn\" onclick=\"this.parentElement.style.display=\'none\';\">&times;</span>\r\n        ");
#nullable restore
#line 24 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
   Write(TempData["Guncellendi"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 26 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 28 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
 if (TempData["Silindi"] != null)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert warning\" id=mainAlertMessage>\r\n        <span class=\"closebtn\" onclick=\"this.parentElement.style.display=\'none\';\">&times;</span>\r\n        ");
#nullable restore
#line 33 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
   Write(TempData["Silindi"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 35 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<table id=""example"" class=""display nowrap"" style=""width:100%"">
    <thead>
        <tr>
            <th>İşlemler</th>
            <th>Seo Kodu</th>
            <th>Resim</th>
            <th>Ad</th>
            <th>Aciklama</th>
            <th>Fiyat</th>



        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 51 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n");
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "643766995c71bb96bf9bcb3ddb8b527c0d02c02f7374", async() => {
                WriteLiteral("Guncelle");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 56 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
                                                                                                 WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("<br />\r\n\r\n                </td>\r\n                <td>");
#nullable restore
#line 59 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
               Write(item.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td width=\"100\" height=\"100\" align=\"center\"><img");
            BeginWriteAttribute("src", " src=\"", 1775, "\"", 1799, 2);
            WriteAttributeValue("", 1781, "/images/", 1781, 8, true);
#nullable restore
#line 60 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
WriteAttributeValue("", 1789, item.icon, 1789, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"100\" width=\"100\"></td>\r\n                <td>");
#nullable restore
#line 61 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
               Write(item.author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 62 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
               Write(item.keywords);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 63 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
               Write(item.description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n            </tr>\r\n");
#nullable restore
#line 67 "D:\Projeler\Farmasi\Farmasi.UI\Views\AdminSeo\SeoListele.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Seo>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
