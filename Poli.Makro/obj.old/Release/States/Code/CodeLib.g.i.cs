﻿#pragma checksum "..\..\..\..\States\Code\CodeLib.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8C3AA60A3F9E9F76F94AAD816D997CAF972403E6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AurelienRibon.Ui.SyntaxHighlightBox;
using Loaders;
using Poli.Makro.Converters;
using Poli.Makro.Core.Helpers.RichTextBox;
using Poli.Makro.States.Code;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace Poli.Makro.States.Code {
    
    
    /// <summary>
    /// CodeLib
    /// </summary>
    public partial class CodeLib : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 129 "..\..\..\..\States\Code\CodeLib.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl TabControl;
        
        #line default
        #line hidden
        
        
        #line 214 "..\..\..\..\States\Code\CodeLib.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddCodeTitle;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\..\States\Code\CodeLib.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.RichTextBox AddCodeDescRichTBox;
        
        #line default
        #line hidden
        
        
        #line 292 "..\..\..\..\States\Code\CodeLib.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddGroupTitle;
        
        #line default
        #line hidden
        
        
        #line 317 "..\..\..\..\States\Code\CodeLib.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.RichTextBox AddGroupRichTBox;
        
        #line default
        #line hidden
        
        
        #line 370 "..\..\..\..\States\Code\CodeLib.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddLangTitle;
        
        #line default
        #line hidden
        
        
        #line 395 "..\..\..\..\States\Code\CodeLib.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.RichTextBox AddLangRichTBox;
        
        #line default
        #line hidden
        
        
        #line 424 "..\..\..\..\States\Code\CodeLib.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AurelienRibon.Ui.SyntaxHighlightBox.SyntaxHighlightBox HighlightedCodeBase;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Poli.Makro;component/states/code/codelib.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\States\Code\CodeLib.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TabControl = ((System.Windows.Controls.TabControl)(target));
            return;
            case 2:
            
            #line 199 "..\..\..\..\States\Code\CodeLib.xaml"
            ((System.Windows.Controls.Expander)(target)).Expanded += new System.Windows.RoutedEventHandler(this.SidebarMenuItemExpanded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddCodeTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.AddCodeDescRichTBox = ((Xceed.Wpf.Toolkit.RichTextBox)(target));
            return;
            case 5:
            
            #line 264 "..\..\..\..\States\Code\CodeLib.xaml"
            ((System.Windows.Controls.Expander)(target)).Expanded += new System.Windows.RoutedEventHandler(this.SidebarMenuItemExpanded);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AddGroupTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.AddGroupRichTBox = ((Xceed.Wpf.Toolkit.RichTextBox)(target));
            return;
            case 8:
            
            #line 342 "..\..\..\..\States\Code\CodeLib.xaml"
            ((System.Windows.Controls.Expander)(target)).Expanded += new System.Windows.RoutedEventHandler(this.SidebarMenuItemExpanded);
            
            #line default
            #line hidden
            return;
            case 9:
            this.AddLangTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.AddLangRichTBox = ((Xceed.Wpf.Toolkit.RichTextBox)(target));
            return;
            case 11:
            this.HighlightedCodeBase = ((AurelienRibon.Ui.SyntaxHighlightBox.SyntaxHighlightBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

