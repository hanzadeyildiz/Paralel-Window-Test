﻿#pragma checksum "..\..\..\WallWindowChrome.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9F1B9BBA1FC3380BFC3B9BA4980A371B86CA85AE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ParalelWindowTest;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ParalelWindowTest {
    
    
    /// <summary>
    /// WallWindowChrome
    /// </summary>
    public partial class WallWindowChrome : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\WallWindowChrome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ParalelWindowTest.WallWindowChrome window;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\WallWindowChrome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush bgImage;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\WallWindowChrome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel ChromeDock;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\WallWindowChrome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock zIndexTextBlock;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ParalelWindowTest;V1.0.0.0;component/wallwindowchrome.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WallWindowChrome.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.window = ((ParalelWindowTest.WallWindowChrome)(target));
            
            #line 16 "..\..\..\WallWindowChrome.xaml"
            this.window.Closing += new System.ComponentModel.CancelEventHandler(this.window_Closing);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\WallWindowChrome.xaml"
            this.window.MouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.window_MouseRightButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bgImage = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 3:
            this.ChromeDock = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 4:
            this.zIndexTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
