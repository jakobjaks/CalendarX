#pragma checksum "C:\Users\ADMIN\Desktop\CalendarProject\CalendarX\WebApp\Views\EventInLocation\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f319cf18ec01138704ec1ad4ac7aa7ecc342922a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EventInLocation_Create), @"mvc.1.0.view", @"/Views/EventInLocation/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f319cf18ec01138704ec1ad4ac7aa7ecc342922a", @"/Views/EventInLocation/Create.cshtml")]
    public class Views_EventInLocation_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Domain.EventInLocation>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ADMIN\Desktop\CalendarProject\CalendarX\WebApp\Views\EventInLocation\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Create</h1>

<h4>EventInLocation</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Create"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""EventId"" class=""control-label""></label>
                <select asp-for=""EventId"" class =""form-control"" asp-items=""ViewBag.EventId""></select>
            </div>
            <div class=""form-group"">
                <label asp-for=""LocationId"" class=""control-label""></label>
                <select asp-for=""LocationId"" class =""form-control"" asp-items=""ViewBag.LocationId""></select>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Create"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 35 "C:\Users\ADMIN\Desktop\CalendarProject\CalendarX\WebApp\Views\EventInLocation\Create.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Domain.EventInLocation> Html { get; private set; }
    }
}
#pragma warning restore 1591
