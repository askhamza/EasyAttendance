#pragma checksum "C:\Users\ASKOUR\Desktop\Projet\EasyAttendance\Assiduite\Pages\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "deac2eb3eeb8760036b43b99841b01dd776113e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Assiduite.Pages.Pages_Login), @"mvc.1.0.razor-page", @"/Pages/Login.cshtml")]
namespace Assiduite.Pages
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
#line 1 "C:\Users\ASKOUR\Desktop\Projet\EasyAttendance\Assiduite\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASKOUR\Desktop\Projet\EasyAttendance\Assiduite\Pages\_ViewImports.cshtml"
using Assiduite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASKOUR\Desktop\Projet\EasyAttendance\Assiduite\Pages\_ViewImports.cshtml"
using Assiduite.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"deac2eb3eeb8760036b43b99841b01dd776113e6", @"/Pages/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffed88bc61be11305d3033c456e554e12c881dd6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Login : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\ASKOUR\Desktop\Projet\EasyAttendance\Assiduite\Pages\Login.cshtml"
  
    Layout = "../Pages/Shared/_LayoutMaster";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""content"">
    <div class=""row"">
        <div class=""col-md-3""></div>
        <div class=""col-md-4"">
            <div class=""card card-user"">
                <div class=""card-body"">
                    <p class=""card-text"">
                        <div class=""author"">
                            <div class=""block block-one""></div>
                            <div class=""block block-two""></div>
                            <div class=""block block-three""></div>
                            <div class=""block block-four""></div>
                            <a href=""javascript:void(0)"">
                                <img class=""avatar"" src=""../assets/img/emilyz.jpg"" alt=""..."">
                                
                            </a>
                    <p class=""description"">
                        Se Connecter
                    </p>
                </div>
                </p>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "deac2eb3eeb8760036b43b99841b01dd776113e65212", async() => {
                WriteLiteral(@"
                    <div class=""form-group"">
                        <label>Matricule</label>
                        <input type=""text"" class=""form-control"" placeholder=""Matricule"">
                    </div>
                    <div class=""form-group"">
                        <label>Mot de passe</label>
                        <input type=""password"" class=""form-control"" placeholder=""Password"">
                    </div>
                    <div style=""text-align:center"">
                        <button type=""submit"" class=""btn btn-fill btn-primary"">Connexion</button>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""card-footer"">
                <h5 class=""title"" style=""text-align:center"" >Easy Attendance</h5>
                <!--<div class=""button-container"">
        <button href=""javascript:void(0)"" class=""btn btn-icon btn-round btn-facebook"">
            <i class=""fab fa-facebook""></i>
        </button>
        <button href=""javascript:void(0)"" class=""btn btn-icon btn-round btn-twitter"">
            <i class=""fab fa-twitter""></i>
        </button>
        <button href=""javascript:void(0)"" class=""btn btn-icon btn-round btn-google"">
            <i class=""fab fa-google-plus""></i>
        </button>
    </div>-->
            </div>
        </div>
    </div>
</div>
        </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Assiduite.Pages.LoginModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Assiduite.Pages.LoginModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Assiduite.Pages.LoginModel>)PageContext?.ViewData;
        public Assiduite.Pages.LoginModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
