﻿#pragma checksum "C:\Users\Solving Team\Source\Repos\MyFacialRecognition\FacialRecognitionDoor\UserProfilePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A9369B51494B7D67DE46FAA7A7AD065C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FacialRecognitionDoor
{
    partial class UserProfilePage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.VisitorNameBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 2:
                {
                    this.UserNameGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3:
                {
                    this.PhotoGrid = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    #line 43 "..\..\..\UserProfilePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.GridView)this.PhotoGrid).Loaded += this.PhotoGrid_Loaded;
                    #line default
                }
                break;
            case 4:
                {
                    this.UserNameBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.ConfirmButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 6:
                {
                    this.CancelButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 7:
                {
                    this.WebcamFeed = (global::Windows.UI.Xaml.Controls.CaptureElement)(target);
                }
                break;
            case 8:
                {
                    this.IdPhotoControl = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 9:
                {
                    this.AddButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 47 "..\..\..\UserProfilePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.AddButton).Tapped += this.AddButton_Tapped;
                    #line default
                }
                break;
            case 10:
                {
                    this.DeleteButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 48 "..\..\..\UserProfilePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.DeleteButton).Tapped += this.DeleteButton_Tapped;
                    #line default
                }
                break;
            case 11:
                {
                    this.HomeButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 49 "..\..\..\UserProfilePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.HomeButton).Tapped += this.HomeButton_Tapped;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

