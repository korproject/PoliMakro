﻿#pragma checksum "..\..\..\..\..\States\Code\CodeLibDialogs\ShowCode.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6944907D994D750B3A4129DE495B2C739A766362"
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
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.AvalonEdit.Search;
using Poli.Makro.Converters;
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


namespace Poli.Makro.States.Code.CodeLibDialogs {
    
    
    /// <summary>
    /// ShowCode
    /// </summary>
    public partial class ShowCode : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\..\..\..\States\Code\CodeLibDialogs\ShowCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CodeTitle;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\States\Code\CodeLibDialogs\ShowCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UpdateCodeText;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\..\States\Code\CodeLibDialogs\ShowCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid CodeViewGrid;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\..\States\Code\CodeLibDialogs\ShowCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ICSharpCode.AvalonEdit.TextEditor CodeView;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\..\States\Code\CodeLibDialogs\ShowCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.RichTextBox CodeDescView;
        
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
            System.Uri resourceLocater = new System.Uri("/Poli.Makro;component/states/code/codelibdialogs/showcode.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\States\Code\CodeLibDialogs\ShowCode.xaml"
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
            
            #line 43 "..\..\..\..\..\States\Code\CodeLibDialogs\ShowCode.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_FareSolTıkBasıldığında);
            
            #line default
            #line hidden
            
            #line 44 "..\..\..\..\..\States\Code\CodeLibDialogs\ShowCode.xaml"
            ((System.Windows.Controls.Border)(target)).PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Border_ÖnizlemeFareSolTıkKalktığında);
            
            #line default
            #line hidden
            
            #line 45 "..\..\..\..\..\States\Code\CodeLibDialogs\ShowCode.xaml"
            ((System.Windows.Controls.Border)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_ÖnizlemeFareSolTıkBastığında);
            
            #line default
            #line hidden
            
            #line 46 "..\..\..\..\..\States\Code\CodeLibDialogs\ShowCode.xaml"
            ((System.Windows.Controls.Border)(target)).PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.Border_ÖnizlemeFareyleTaşıma);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CodeTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.UpdateCodeText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            
            #line 80 "..\..\..\..\..\States\Code\CodeLibDialogs\ShowCode.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Close);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CodeViewGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.CodeView = ((ICSharpCode.AvalonEdit.TextEditor)(target));
            return;
            case 7:
            this.CodeDescView = ((Xceed.Wpf.Toolkit.RichTextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
