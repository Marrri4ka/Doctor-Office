#pragma checksum "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f1293914c087791220036e1f47f6d4256bcc167"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Doctors_Show), @"mvc.1.0.view", @"/Views/Doctors/Show.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Doctors/Show.cshtml", typeof(AspNetCore.Views_Doctors_Show))]
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
#line 1 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Show.cshtml"
using DoctorOffice.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f1293914c087791220036e1f47f6d4256bcc167", @"/Views/Doctors/Show.cshtml")]
    public class Views_Doctors_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(28, 36, true);
            WriteLiteral("\n<h1>Doctor Office</h1>\n<h2>Doctor: ");
            EndContext();
            BeginContext(65, 25, false);
#line 4 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Show.cshtml"
       Write(Model["doctor"].GetName());

#line default
#line hidden
            EndContext();
            BeginContext(90, 14, true);
            WriteLiteral("</h2>\n<hr />\n\n");
            EndContext();
#line 7 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Show.cshtml"
 if (@Model["doctorPatients"].Count != 0)
{

#line default
#line hidden
            BeginContext(148, 46, true);
            WriteLiteral("<h4>Here are all doctor\'s patinets:</h4>\n<ul>\n");
            EndContext();
#line 11 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Show.cshtml"
   foreach (var patient in @Model["doctorPatients"])
  {

#line default
#line hidden
            BeginContext(251, 6, true);
            WriteLiteral("  <li>");
            EndContext();
            BeginContext(258, 17, false);
#line 13 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Show.cshtml"
 Write(patient.GetName());

#line default
#line hidden
            EndContext();
            BeginContext(275, 6, true);
            WriteLiteral("</li>\n");
            EndContext();
#line 14 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Show.cshtml"
  }

#line default
#line hidden
            BeginContext(285, 6, true);
            WriteLiteral("</ul>\n");
            EndContext();
#line 16 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Show.cshtml"
}

#line default
#line hidden
            BeginContext(293, 47, true);
            WriteLiteral("\n<h4>Add a patient for this doctor:</h4>\n\n<form");
            EndContext();
            BeginWriteAttribute("action", " action=\'", 340, "\'", 395, 3);
            WriteAttributeValue("", 349, "/doctors/", 349, 9, true);
#line 20 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Show.cshtml"
WriteAttributeValue("", 358, Model["doctor"].GetId(), 358, 24, false);

#line default
#line hidden
            WriteAttributeValue("", 382, "/patients/new", 382, 13, true);
            EndWriteAttribute();
            BeginContext(396, 122, true);
            WriteLiteral(" method=\'post\'>\n  <label for=\'patientId\'>Select a patient</label>\n  <select id=\'patientId\' name=\'patientId\' type=\'text\'>\n\n");
            EndContext();
#line 24 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Show.cshtml"
     foreach (var patient in @Model["allPatients"])
    {

#line default
#line hidden
            BeginContext(576, 11, true);
            WriteLiteral("    <option");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 587, "\'", 611, 1);
#line 26 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Show.cshtml"
WriteAttributeValue("", 595, patient.GetId(), 595, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(612, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(614, 17, false);
#line 26 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Show.cshtml"
                                Write(patient.GetName());

#line default
#line hidden
            EndContext();
            BeginContext(631, 10, true);
            WriteLiteral("</option>\n");
            EndContext();
#line 27 "/Users/mariiastashuk/Desktop/DoctorOffice.Solution/DoctorOffice/Views/Doctors/Show.cshtml"
    }

#line default
#line hidden
            BeginContext(647, 102, true);
            WriteLiteral("\n  </select>\n  <button type=\'submit\'>Add</button>\n</form>\n\n<p><a href=\"/\">Return to Main Page</a></p>\n");
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
