#pragma checksum "C:\Users\ASKOUR\Desktop\Projet\EasyAttendance\Assiduite\Pages\Shared\_LayoutMaster.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b945e2cfb0f220c6ad124ed79389a3f3f1efd5b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Assiduite.Pages.Shared.Pages_Shared__LayoutMaster), @"mvc.1.0.view", @"/Pages/Shared/_LayoutMaster.cshtml")]
namespace Assiduite.Pages.Shared
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b945e2cfb0f220c6ad124ed79389a3f3f1efd5b", @"/Pages/Shared/_LayoutMaster.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffed88bc61be11305d3033c456e554e12c881dd6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__LayoutMaster : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/css/nucleo-icons.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/css/black-dashboard.css?v=1.0.0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/demo/demo.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!--
=========================================================
* * Black Dashboard - v1.0.1
=========================================================

* Product Page: https://www.creative-tim.com/product/black-dashboard
* Copyright 2019 Creative Tim (https://www.creative-tim.com)


* Coded by Creative Tim

=========================================================

* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
-->
<!DOCTYPE html>
<html lang=""en"">

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b945e2cfb0f220c6ad124ed79389a3f3f1efd5b5990", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"">
    <link rel=""apple-touch-icon"" sizes=""76x76"" href=""../assets/img/apple-icon.png"">
    <link rel=""icon"" type=""image/png"" href=""../assets/img/favicon.png"">
    <title>
        Black Dashboard by Creative Tim
    </title>
    <!--     Fonts and icons     -->
    <link href=""https://fonts.googleapis.com/css?family=Poppins:200,300,400,600,700,800"" rel=""stylesheet"" />
    <link href=""https://use.fontawesome.com/releases/v5.0.6/css/all.css"" rel=""stylesheet"">
    <!-- Nucleo Icons -->
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2b945e2cfb0f220c6ad124ed79389a3f3f1efd5b6892", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <!-- CSS Files -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2b945e2cfb0f220c6ad124ed79389a3f3f1efd5b8096", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <!-- CSS Just for demo purpose, don\'t include it in your project -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2b945e2cfb0f220c6ad124ed79389a3f3f1efd5b9351", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b945e2cfb0f220c6ad124ed79389a3f3f1efd5b11233", async() => {
                WriteLiteral(@"
    <div class=""wrapper"">
        <div class=""main-panel"">
            <!-- Navbar -->
            <nav class=""navbar navbar-expand-lg navbar-absolute navbar-transparent"">
                <div class=""container-fluid"">
                    <div class=""navbar-wrapper"">
                        <div class=""navbar-toggle d-inline"">
                            <button type=""button"" class=""navbar-toggler"">
                                <span class=""navbar-toggler-bar bar1""></span>
                                <span class=""navbar-toggler-bar bar2""></span>
                                <span class=""navbar-toggler-bar bar3""></span>
                            </button>
                        </div>
                        <a class=""navbar-brand"" href=""javascript:void(0)"">Easy Attendance</a>
                    </div>
                    <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#navigation"" aria-expanded=""false"" aria-label=""Toggle navigation"">
            ");
                WriteLiteral(@"            <span class=""navbar-toggler-bar navbar-kebab""></span>
                        <span class=""navbar-toggler-bar navbar-kebab""></span>
                        <span class=""navbar-toggler-bar navbar-kebab""></span>
                    </button>
                    <div class=""collapse navbar-collapse"" id=""navigation"">
                        <ul class=""navbar-nav ml-auto"">
                            <li class=""search-bar input-group"">
                                <button class=""btn btn-link"" id=""search-button"" data-toggle=""modal"" data-target=""#searchModal"">
                                    <i class=""tim-icons icon-zoom-split""></i>
                                    <span class=""d-lg-none d-md-block"">Search</span>
                                </button>
                            </li>
                            <li class=""dropdown nav-item"">
                                <a href=""javascript:void(0)"" class=""dropdown-toggle nav-link"" data-toggle=""dropdown"">
                   ");
                WriteLiteral(@"                 <div class=""notification d-none d-lg-block d-xl-block""></div>
                                    <i class=""tim-icons icon-sound-wave""></i>
                                    <p class=""d-lg-none"">
                                        Notifications
                                    </p>
                                </a>
                                <ul class=""dropdown-menu dropdown-menu-right dropdown-navbar"">
                                    <li class=""nav-link""><a href=""#"" class=""nav-item dropdown-item"">Mike John responded to your email</a></li>
                                    <li class=""nav-link""><a href=""javascript:void(0)"" class=""nav-item dropdown-item"">You have 5 more tasks</a></li>
                                    <li class=""nav-link""><a href=""javascript:void(0)"" class=""nav-item dropdown-item"">Your friend Michael is in town</a></li>
                                    <li class=""nav-link""><a href=""javascript:void(0)"" class=""nav-item dropdown-item"">Another");
                WriteLiteral(@" notification</a></li>
                                    <li class=""nav-link""><a href=""javascript:void(0)"" class=""nav-item dropdown-item"">Another one</a></li>
                                </ul>
                            </li>
                            <li class=""dropdown nav-item"">
                                <a href=""#"" class=""dropdown-toggle nav-link"" data-toggle=""dropdown"">
                                    <div class=""photo"">
                                        <img src=""../assets/img/anime3.png"" alt=""Profile Photo"">
                                    </div>
                                    <b class=""caret d-none d-lg-block d-xl-block""></b>
                                    <p class=""d-lg-none"">
                                        Log out
                                    </p>
                                </a>
                                <ul class=""dropdown-menu dropdown-navbar"">
                                    <li class=""nav-link""><a href=""javascri");
                WriteLiteral(@"pt:void(0)"" class=""nav-item dropdown-item"">Profile</a></li>
                                    <li class=""nav-link""><a href=""javascript:void(0)"" class=""nav-item dropdown-item"">Settings</a></li>
                                    <li class=""dropdown-divider""></li>
                                    <li class=""nav-link""><a href=""javascript:void(0)"" class=""nav-item dropdown-item"">Log out</a></li>
                                </ul>
                            </li>
                            <li class=""separator d-lg-none""></li>
                        </ul>
                    </div>
                </div>
            </nav>
            <div class=""modal modal-search fade"" id=""searchModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""searchModal"" aria-hidden=""true"">
                <div class=""modal-dialog"" role=""document"">
                    <div class=""modal-content"">
                        <div class=""modal-header"">
                            <input type=""text"" class=""form-control"" id");
                WriteLiteral(@"=""inlineFormInputGroup"" placeholder=""SEARCH"">
                            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                <i class=""tim-icons icon-simple-remove""></i>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End Navbar -->
            ");
#nullable restore
#line 117 "C:\Users\ASKOUR\Desktop\Projet\EasyAttendance\Assiduite\Pages\Shared\_LayoutMaster.cshtml"
       Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            <footer class=""footer"">
                <div class=""container-fluid"">
                    <!-- <ul class=""nav"">
                        <li class=""nav-item"">
                            <a href=""javascript:void(0)"" class=""nav-link"">
                                Creative Tim
                            </a>
                        </li>
                        <li class=""nav-item"">
        <a href=""javascript:void(0)"" class=""nav-link"">
            About Us
        </a>
    </li>
    <li class=""nav-item"">
        <a href=""javascript:void(0)"" class=""nav-link"">
            Blog
        </a>
    </li>
                    </ul>-->
                    <div class=""copyright"">
                        © HILALI *** ASKOUR 
                        <script>
                            document.write(new Date().getFullYear())
                        </script><i class=""tim-icons icon-heart-2""></i>
                        <a");
                BeginWriteAttribute("href", " href=\"", 8020, "\"", 8027, 0);
                EndWriteAttribute();
                WriteLiteral(@">Easy Attendance</a>  .
                    </div>
                </div>
            </footer>
        </div>
    </div>

    <!--   Core JS Files   -->
                    <script src=""../assets/js/core/jquery.min.js""></script>
                    <script src=""../assets/js/core/popper.min.js""></script>
                    <script src=""../assets/js/core/bootstrap.min.js""></script>
                    <script src=""../assets/js/plugins/perfect-scrollbar.jquery.min.js""></script>
                    <!--  Google Maps Plugin    -->
                    <!-- Place this tag in your head or just before your close body tag. -->
                    <script src=""https://maps.googleapis.com/maps/api/js?key=YOUR_KEY_HERE""></script>
                    <!-- Chart JS -->
                    <script src=""../assets/js/plugins/chartjs.min.js""></script>
                    <!--  Notifications Plugin    -->
                    <script src=""../assets/js/plugins/bootstrap-notify.js""></script>
                   ");
                WriteLiteral(@" <!-- Control Center for Black Dashboard: parallax effects, scripts for the example pages etc -->
                    <script src=""../assets/js/black-dashboard.min.js?v=1.0.0""></script><!-- Black Dashboard DEMO methods, don't include it in your project! -->
                    <script src=""../assets/demo/demo.js""></script>
                    <script>
                        $(document).ready(function () {
                            $().ready(function () {
                                $sidebar = $('.sidebar');
                                $navbar = $('.navbar');
                                $main_panel = $('.main-panel');

                                $full_page = $('.full-page');

                                $sidebar_responsive = $('body > .navbar-collapse');
                                sidebar_mini_active = true;
                                white_color = false;

                                window_width = $(window).width();

                                fixed");
                WriteLiteral(@"_plugin_open = $('.sidebar .sidebar-wrapper .nav li.active a p').html();



                                $('.fixed-plugin a').click(function (event) {
                                    if ($(this).hasClass('switch-trigger')) {
                                        if (event.stopPropagation) {
                                            event.stopPropagation();
                                        } else if (window.event) {
                                            window.event.cancelBubble = true;
                                        }
                                    }
                                });

                                $('.fixed-plugin .background-color span').click(function () {
                                    $(this).siblings().removeClass('active');
                                    $(this).addClass('active');

                                    var new_color = $(this).data('color');

                                    if ($sidebar.length != ");
                WriteLiteral(@"0) {
                                        $sidebar.attr('data', new_color);
                                    }

                                    if ($main_panel.length != 0) {
                                        $main_panel.attr('data', new_color);
                                    }

                                    if ($full_page.length != 0) {
                                        $full_page.attr('filter-color', new_color);
                                    }

                                    if ($sidebar_responsive.length != 0) {
                                        $sidebar_responsive.attr('data', new_color);
                                    }
                                });

                                $('.switch-sidebar-mini input').on(""switchChange.bootstrapSwitch"", function () {
                                    var $btn = $(this);

                                    if (sidebar_mini_active == true) {
                                     ");
                WriteLiteral(@"   $('body').removeClass('sidebar-mini');
                                        sidebar_mini_active = false;
                                        blackDashboard.showSidebarMessage('Sidebar mini deactivated...');
                                    } else {
                                        $('body').addClass('sidebar-mini');
                                        sidebar_mini_active = true;
                                        blackDashboard.showSidebarMessage('Sidebar mini activated...');
                                    }

                                    // we simulate the window Resize so the charts will get updated in realtime.
                                    var simulateWindowResize = setInterval(function () {
                                        window.dispatchEvent(new Event('resize'));
                                    }, 180);

                                    // we stop the simulation of Window Resize after the animations are completed
               ");
                WriteLiteral(@"                     setTimeout(function () {
                                        clearInterval(simulateWindowResize);
                                    }, 1000);
                                });

                                $('.switch-change-color input').on(""switchChange.bootstrapSwitch"", function () {
                                    var $btn = $(this);

                                    if (white_color == true) {

                                        $('body').addClass('change-background');
                                        setTimeout(function () {
                                            $('body').removeClass('change-background');
                                            $('body').removeClass('white-content');
                                        }, 900);
                                        white_color = false;
                                    } else {

                                        $('body').addClass('change-background');
          ");
                WriteLiteral(@"                              setTimeout(function () {
                                            $('body').removeClass('change-background');
                                            $('body').addClass('white-content');
                                        }, 900);

                                        white_color = true;
                                    }


                                });

                                $('.light-badge').click(function () {
                                    $('body').addClass('white-content');
                                });

                                $('.dark-badge').click(function () {
                                    $('body').removeClass('white-content');
                                });
                            });
                        });
                    </script>
                    <script src=""https://cdn.trackjs.com/agent/v3/latest/t.js""></script>
                    <script>
                     ");
                WriteLiteral(@"   window.TrackJS &&
                            TrackJS.install({
                                token: ""ee6fab19c5a04ac1a32a645abde4613a"",
                                application: ""black-dashboard-free""
                            });
                    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
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
