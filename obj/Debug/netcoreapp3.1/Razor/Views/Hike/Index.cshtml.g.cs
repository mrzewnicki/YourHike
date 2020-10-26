#pragma checksum "C:\Users\mateu\source\repos\YourHike\Views\Hike\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1fb27b04843dde19953893fc583baf7880727a0a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hike_Index), @"mvc.1.0.view", @"/Views/Hike/Index.cshtml")]
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
#line 1 "C:\Users\mateu\source\repos\YourHike\Views\_ViewImports.cshtml"
using YourHike;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mateu\source\repos\YourHike\Views\_ViewImports.cshtml"
using YourHike.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fb27b04843dde19953893fc583baf7880727a0a", @"/Views/Hike/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a18a329a042579e762409980cc8c3cbcb1f02c1f", @"/Views/_ViewImports.cshtml")]
    public class Views_Hike_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<YourHike.Models.ViewModel.HikeVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\mateu\source\repos\YourHike\Views\Hike\Index.cshtml"
  
    ViewData["Title"] = "Wędrówki";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4 text-primary\">Twoje wędrówki</h1>\r\n</div>\r\n\r\n");
#nullable restore
#line 11 "C:\Users\mateu\source\repos\YourHike\Views\Hike\Index.cshtml"
 if(TempData["DeleteResult"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <span class=\"text-success\">");
#nullable restore
#line 14 "C:\Users\mateu\source\repos\YourHike\Views\Hike\Index.cshtml"
                              Write(TempData["DeleteResult"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </div>\r\n");
#nullable restore
#line 16 "C:\Users\mateu\source\repos\YourHike\Views\Hike\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 18 "C:\Users\mateu\source\repos\YourHike\Views\Hike\Index.cshtml"
 if(TempData["EditResult"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <span class=\"text-success\">");
#nullable restore
#line 21 "C:\Users\mateu\source\repos\YourHike\Views\Hike\Index.cshtml"
                              Write(TempData["EditResult"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </div>\r\n");
#nullable restore
#line 23 "C:\Users\mateu\source\repos\YourHike\Views\Hike\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table class=""table table-striped table-dark"">
    <thead class=""thead-dark"">
        <tr>
            <th scope=""col"">Title</th>
            <th scope=""col"">Start Date</th>
            <th scope=""col"">End Date</th>
            <th scope=""col"">Start Place</th>
            <th scope=""col"">End Place</th>
            <th scope=""col"">Distance</th>
            <th scope=""col""></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 38 "C:\Users\mateu\source\repos\YourHike\Views\Hike\Index.cshtml"
          
            foreach (var item in @Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 42 "C:\Users\mateu\source\repos\YourHike\Views\Hike\Index.cshtml"
                   Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 43 "C:\Users\mateu\source\repos\YourHike\Views\Hike\Index.cshtml"
                   Write(item.StartDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 44 "C:\Users\mateu\source\repos\YourHike\Views\Hike\Index.cshtml"
                   Write(item.EndDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 45 "C:\Users\mateu\source\repos\YourHike\Views\Hike\Index.cshtml"
                   Write(item.StartPlace);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 46 "C:\Users\mateu\source\repos\YourHike\Views\Hike\Index.cshtml"
                   Write(item.EndPlace);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 47 "C:\Users\mateu\source\repos\YourHike\Views\Hike\Index.cshtml"
                   Write(item.Distance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 1284, "\"", 1313, 2);
            WriteAttributeValue("", 1291, "/Hike/Details/", 1291, 14, true);
#nullable restore
#line 48 "C:\Users\mateu\source\repos\YourHike\Views\Hike\Index.cshtml"
WriteAttributeValue("", 1305, item.Id, 1305, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info\">Szczegóły</a></td>\r\n                </tr>\r\n");
#nullable restore
#line 50 "C:\Users\mateu\source\repos\YourHike\Views\Hike\Index.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<YourHike.Models.ViewModel.HikeVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591