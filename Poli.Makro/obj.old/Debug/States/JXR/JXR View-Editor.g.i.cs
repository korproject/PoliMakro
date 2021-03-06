﻿#pragma checksum "..\..\..\..\States\JXR\JXR View-Editor.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72DC9D106F16A3DB994A7F133D8AF346F3C08D1E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.AvalonEdit.Search;
using Newtonsoft.Json.Linq;
using Poli.Makro.Converters;
using Poli.Makro.Converters.JSON;
using Poli.Makro.TemplateSelectors;
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
using System.Xml;


namespace Poli.Makro.States.JSONXMLXAMLRSS {
    
    
    /// <summary>
    /// JXXR_View_Editor
    /// </summary>
    public partial class JXXR_View_Editor : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 282 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl TabControl;
        
        #line default
        #line hidden
        
        
        #line 358 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView jsonTree;
        
        #line default
        #line hidden
        
        
        #line 372 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox jsonRich;
        
        #line default
        #line hidden
        
        
        #line 380 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ICSharpCode.AvalonEdit.TextEditor AvalonJSONEditor;
        
        #line default
        #line hidden
        
        
        #line 474 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView xmlTree;
        
        #line default
        #line hidden
        
        
        #line 488 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox xmlRich;
        
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
            System.Uri resourceLocater = new System.Uri("/Poli.Makro;component/states/jxr/jxr%20view-editor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            case 3:
            this.TabControl = ((System.Windows.Controls.TabControl)(target));
            
            #line 282 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            this.TabControl.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TabControl_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 306 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReadJSONFromFile);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 312 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReadJSONfromClipboard);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 318 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReadJSONfromWeb);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 326 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveJSONfilefromRichTb);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 332 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CopyJSONfilefromRichTb);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 340 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RefrmatJSONString);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 346 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Click += new System.Windows.RoutedEventHandler(this.ExpCollapseButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 348 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ClearJSONContainers);
            
            #line default
            #line hidden
            return;
            case 12:
            this.jsonTree = ((System.Windows.Controls.TreeView)(target));
            return;
            case 13:
            this.jsonRich = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 14:
            this.AvalonJSONEditor = ((ICSharpCode.AvalonEdit.TextEditor)(target));
            return;
            case 15:
            
            #line 422 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReadXMLFromFile);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 428 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReadXMLfromClipboard);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 434 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReadXMLfromWeb);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 442 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveXMLfilefromRichTb);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 448 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CopyXMLfilefromRichTb);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 456 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RefrmatXMLString);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 462 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Click += new System.Windows.RoutedEventHandler(this.ExpCollapseButton_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 464 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ClearXMLContainers);
            
            #line default
            #line hidden
            return;
            case 23:
            this.xmlTree = ((System.Windows.Controls.TreeView)(target));
            return;
            case 24:
            this.xmlRich = ((System.Windows.Controls.RichTextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 237 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.JValue_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            case 2:
            
            #line 263 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.JValue_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

