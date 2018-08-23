﻿#pragma checksum "..\..\..\..\States\JXR\JXR View-Editor.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83FF4ED2A7401639424CEDC9AECA3F9EE15A8E2A"
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
using Poli.Makro.Core.Helpers.Avalon;
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
using System.Windows.Interactivity;
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


namespace Poli.Makro.States.JXR {
    
    
    /// <summary>
    /// JXR_Editor
    /// </summary>
    public partial class JXR_Editor : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 206 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl TabControl;
        
        #line default
        #line hidden
        
        
        #line 214 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid JsonEditorGrid;
        
        #line default
        #line hidden
        
        
        #line 357 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView JsonTree;
        
        #line default
        #line hidden
        
        
        #line 371 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox HighlightingComboBox;
        
        #line default
        #line hidden
        
        
        #line 378 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ICSharpCode.AvalonEdit.TextEditor AvalonJsonEditor;
        
        #line default
        #line hidden
        
        
        #line 393 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GetFromWebGrid;
        
        #line default
        #line hidden
        
        
        #line 404 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border SaveRecords;
        
        #line default
        #line hidden
        
        
        #line 417 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GetJsonURL;
        
        #line default
        #line hidden
        
        
        #line 500 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid XmlEditorGrid;
        
        #line default
        #line hidden
        
        
        #line 624 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView XmlTree;
        
        #line default
        #line hidden
        
        
        #line 639 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox HighlightingComboBoxXml;
        
        #line default
        #line hidden
        
        
        #line 646 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ICSharpCode.AvalonEdit.TextEditor AvalonXmlEditor;
        
        #line default
        #line hidden
        
        
        #line 661 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GetFromWebGridXml;
        
        #line default
        #line hidden
        
        
        #line 685 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GetXmlURL;
        
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
            case 1:
            
            #line 15 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((Poli.Makro.States.JXR.JXR_Editor)(target)).Loaded += new System.Windows.RoutedEventHandler(this.JXR_Editor_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TabControl = ((System.Windows.Controls.TabControl)(target));
            
            #line 206 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            this.TabControl.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TabControl_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.JsonEditorGrid = ((System.Windows.Controls.Grid)(target));
            
            #line 214 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            this.JsonEditorGrid.Drop += new System.Windows.DragEventHandler(this.JsonEditorGrid_OnDrop);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 264 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.GetFromWebChecked);
            
            #line default
            #line hidden
            
            #line 264 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.GetJsonFromWebClose);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 313 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.JsonTreeExpandCollapse);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 342 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.JsontoXmlConvert);
            
            #line default
            #line hidden
            return;
            case 9:
            this.JsonTree = ((System.Windows.Controls.TreeView)(target));
            return;
            case 10:
            this.HighlightingComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.AvalonJsonEditor = ((ICSharpCode.AvalonEdit.TextEditor)(target));
            return;
            case 12:
            this.GetFromWebGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 13:
            
            #line 394 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GetJsonFromWebClose);
            
            #line default
            #line hidden
            return;
            case 14:
            this.SaveRecords = ((System.Windows.Controls.Border)(target));
            return;
            case 15:
            this.GetJsonURL = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            
            #line 435 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.JsonGetFromWeb);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 446 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GetJsonFromWebClose);
            
            #line default
            #line hidden
            return;
            case 18:
            this.XmlEditorGrid = ((System.Windows.Controls.Grid)(target));
            
            #line 500 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            this.XmlEditorGrid.Drop += new System.Windows.DragEventHandler(this.XmlEditorGrid_OnDrop);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 518 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.XmlLoadFromFile);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 532 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoadXmlFromClipboard);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 548 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.GetFromWebXmlChecked);
            
            #line default
            #line hidden
            
            #line 548 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.GetXmlFromWebClose);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 564 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BindXmlTree);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 579 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReFormatXmlString);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 595 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.XmlTreeExpandCollapse);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 609 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ClearXmlData);
            
            #line default
            #line hidden
            return;
            case 26:
            this.XmlTree = ((System.Windows.Controls.TreeView)(target));
            return;
            case 27:
            this.HighlightingComboBoxXml = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 28:
            this.AvalonXmlEditor = ((ICSharpCode.AvalonEdit.TextEditor)(target));
            return;
            case 29:
            this.GetFromWebGridXml = ((System.Windows.Controls.Grid)(target));
            return;
            case 30:
            
            #line 662 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GetXmlFromWebClose);
            
            #line default
            #line hidden
            return;
            case 31:
            this.GetXmlURL = ((System.Windows.Controls.TextBox)(target));
            return;
            case 32:
            
            #line 703 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GetXmlFromWeb);
            
            #line default
            #line hidden
            return;
            case 33:
            
            #line 714 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GetXmlFromWebClose);
            
            #line default
            #line hidden
            return;
            case 34:
            
            #line 739 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveAsXmlString);
            
            #line default
            #line hidden
            return;
            case 35:
            
            #line 748 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Click += new System.Windows.RoutedEventHandler(this.CopyToClipboardXml);
            
            #line default
            #line hidden
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
            case 2:
            
            #line 154 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.JValue_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 188 "..\..\..\..\States\JXR\JXR View-Editor.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.JValue_OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
