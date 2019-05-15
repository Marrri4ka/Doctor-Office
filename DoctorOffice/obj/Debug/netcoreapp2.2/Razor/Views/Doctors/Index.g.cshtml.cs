#pragma checksum "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4fa530b84f69764171e4238863cc190852bad628"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Doctors_Index), @"mvc.1.0.view", @"/Views/Doctors/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Doctors/Index.cshtml", typeof(AspNetCore.Views_Doctors_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fa530b84f69764171e4238863cc190852bad628", @"/Views/Doctors/Index.cshtml")]
    public class Views_Doctors_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 7, true);
            WriteLiteral("<html>\n");
            EndContext();
            BeginContext(7, 15, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4fa530b84f69764171e4238863cc190852bad6282849", async() => {
                BeginContext(13, 2, true);
                WriteLiteral("\n\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(22, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(23, 540, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4fa530b84f69764171e4238863cc190852bad6284005", async() => {
                BeginContext(29, 19, true);
                WriteLiteral("\n<h1>Doctors</h1>\n\n");
                EndContext();
#line 8 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Index.cshtml"
 if (@Model.Count == 0)
{

#line default
#line hidden
                BeginContext(74, 40, true);
                WriteLiteral("<h3>No doctors in our clinic yet. </h3>\n");
                EndContext();
#line 11 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Index.cshtml"
}

#line default
#line hidden
                BeginContext(116, 1, true);
                WriteLiteral("\n");
                EndContext();
#line 13 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Index.cshtml"
 foreach (var doctor in Model)
{


#line default
#line hidden
                BeginContext(151, 20, true);
                WriteLiteral("<h5>Doctor</h5>\n  <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 171, "\'", 202, 2);
                WriteAttributeValue("", 178, "/doctors/", 178, 9, true);
#line 17 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Index.cshtml"
WriteAttributeValue("", 187, doctor.GetId(), 187, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(203, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(205, 16, false);
#line 17 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Index.cshtml"
                                Write(doctor.GetName());

#line default
#line hidden
                EndContext();
                BeginContext(221, 5, true);
                WriteLiteral("</a>\n");
                EndContext();
                BeginContext(228, 13, true);
                WriteLiteral("        <form");
                EndContext();
                BeginWriteAttribute("action", " action=\"", 241, "\"", 281, 3);
                WriteAttributeValue("", 250, "/doctors/", 250, 9, true);
#line 20 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Index.cshtml"
WriteAttributeValue("", 259, doctor.GetId(), 259, 15, false);

#line default
#line hidden
                WriteAttributeValue("", 274, "/delete", 274, 7, true);
                EndWriteAttribute();
                BeginContext(282, 112, true);
                WriteLiteral(" method=\"post\">\n          <button class=\"btn btn-sm\" type=\"submit\" name=\"button\">Clear</button>\n        </form>\n");
                EndContext();
                BeginContext(395, 6, true);
                WriteLiteral("    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 401, "\'", 439, 3);
                WriteAttributeValue("", 408, "/doctors/", 408, 9, true);
#line 24 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Index.cshtml"
WriteAttributeValue("", 417, doctor.GetId(), 417, 15, false);

#line default
#line hidden
                WriteAttributeValue("", 432, "/delete", 432, 7, true);
                EndWriteAttribute();
                BeginContext(440, 16, true);
                WriteLiteral(">Delete</a>\n  <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 456, "\'", 492, 3);
                WriteAttributeValue("", 463, "/doctors/", 463, 9, true);
#line 25 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Index.cshtml"
WriteAttributeValue("", 472, doctor.GetId(), 472, 15, false);

#line default
#line hidden
                WriteAttributeValue("", 487, "/edit", 487, 5, true);
                EndWriteAttribute();
                BeginContext(493, 10, true);
                WriteLiteral(">Edit</a>\n");
                EndContext();
#line 26 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Index.cshtml"




}

#line default
#line hidden
                BeginContext(509, 47, true);
                WriteLiteral("<a class=\"card-link\" href=\"/\">Back home</a>\n\n\n\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(563, 19, true);
            WriteLiteral("\n</center>\n</html>\n");
            EndContext();
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
