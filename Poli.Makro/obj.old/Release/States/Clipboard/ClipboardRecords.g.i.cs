﻿#pragma checksum "..\..\..\..\States\Clipboard\ClipboardRecords.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77BD31081705E07588FE19079B03C8BCFF449376"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Poli.Makro.Converters;
using System;
using System.Data;
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


namespace Poli.Makro.States.Clipboard {
    
    
    /// <summary>
    /// ClipboardRecords
    /// </summary>
    public partial class ClipboardRecords : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 115 "..\..\..\..\States\Clipboard\ClipboardRecords.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl TabControl;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\States\Clipboard\ClipboardRecords.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Records;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\..\States\Clipboard\ClipboardRecords.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox HistoryComboBox;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\..\States\Clipboard\ClipboardRecords.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView HistoryofRecords;
        
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
            System.Uri resourceLocater = new System.Uri("/Poli.Makro;component/states/clipboard/clipboardrecords.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\States\Clipboard\ClipboardRecords.xaml"
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
            this.Records = ((System.Windows.Controls.ListView)(target));
            
            #line 138 "..\..\..\..\States\Clipboard\ClipboardRecords.xaml"
            this.Records.SizeChanged += new System.Windows.SizeChangedEventHandler(this.Records_OnSizeChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.HistoryComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.HistoryofRecords = ((System.Windows.Controls.ListView)(target));
            
            #line 165 "..\..\..\..\States\Clipboard\ClipboardRecords.xaml"
            this.HistoryofRecords.SizeChanged += new System.Windows.SizeChangedEventHandler(this.Records_OnSizeChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

