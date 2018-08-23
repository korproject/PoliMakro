﻿#pragma checksum "..\..\..\..\States\Settings\Settings.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "817801CBD410F2D833B8F2298FCED4F2BE92415E"
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


namespace Poli.Makro.States.Settings {
    
    
    /// <summary>
    /// Settings
    /// </summary>
    public partial class Settings : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 112 "..\..\..\..\States\Settings\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView SettingsListView;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\States\Settings\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl TabControl;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\..\States\Settings\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton LogOutUserTGB;
        
        #line default
        #line hidden
        
        
        #line 235 "..\..\..\..\States\Settings\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LanguageName;
        
        #line default
        #line hidden
        
        
        #line 250 "..\..\..\..\States\Settings\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ICSharpCode.AvalonEdit.TextEditor FeedbackEditor;
        
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
            System.Uri resourceLocater = new System.Uri("/Poli.Makro;component/states/settings/settings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\States\Settings\Settings.xaml"
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
            this.SettingsListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.TabControl = ((System.Windows.Controls.TabControl)(target));
            return;
            case 3:
            this.LogOutUserTGB = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 188 "..\..\..\..\States\Settings\Settings.xaml"
            this.LogOutUserTGB.Click += new System.Windows.RoutedEventHandler(this.LogOutUserTGB_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LanguageName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.FeedbackEditor = ((ICSharpCode.AvalonEdit.TextEditor)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

