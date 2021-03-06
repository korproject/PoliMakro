﻿#pragma checksum "..\..\..\Main\Base.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3C852CF4AFE52CDDF548524CBD5B4D93375D6F5D5E90CBB06FE8C43EF7C6F500"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Hardcodet.Wpf.TaskbarNotification;
using KOR.Converters;
using Poli.Makro.Converters;
using Poli.Makro.Core.ViewModel.Color;
using Poli.Makro.States.Clipboard;
using Poli.Makro.States.Code;
using Poli.Makro.States.Color;
using Poli.Makro.States.JXR;
using Poli.Makro.States.Settings;
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


namespace Poli.Makro.Main {
    
    
    /// <summary>
    /// Base
    /// </summary>
    public partial class Base : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\Main\Base.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shell.TaskbarItemInfo TaskbarItemInfo;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Main\Base.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Hardcodet.Wpf.TaskbarNotification.TaskbarIcon MyNotifyIcon;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\Main\Base.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Path Path1;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\Main\Base.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Path Path2;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\Main\Base.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl SideBarTabControl;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\..\Main\Base.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl TabControl;
        
        #line default
        #line hidden
        
        
        #line 224 "..\..\..\Main\Base.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Title;
        
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
            System.Uri resourceLocater = new System.Uri("/Poli.Makro;component/main/base.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Main\Base.xaml"
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
            
            #line 17 "..\..\..\Main\Base.xaml"
            ((Poli.Makro.Main.Base)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_OnLoaded);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\Main\Base.xaml"
            ((Poli.Makro.Main.Base)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\Main\Base.xaml"
            ((Poli.Makro.Main.Base)(target)).SourceInitialized += new System.EventHandler(this.Window_SourceInitialized);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TaskbarItemInfo = ((System.Windows.Shell.TaskbarItemInfo)(target));
            return;
            case 3:
            this.MyNotifyIcon = ((Hardcodet.Wpf.TaskbarNotification.TaskbarIcon)(target));
            return;
            case 4:
            
            #line 84 "..\..\..\Main\Base.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ColorPickerMini_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Path1 = ((System.Windows.Shapes.Path)(target));
            return;
            case 6:
            this.Path2 = ((System.Windows.Shapes.Path)(target));
            return;
            case 7:
            this.SideBarTabControl = ((System.Windows.Controls.TabControl)(target));
            
            #line 153 "..\..\..\Main\Base.xaml"
            this.SideBarTabControl.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SideBarTabControl_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TabControl = ((System.Windows.Controls.TabControl)(target));
            return;
            case 9:
            this.Title = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            
            #line 229 "..\..\..\Main\Base.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.MoveLayer_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 230 "..\..\..\Main\Base.xaml"
            ((System.Windows.Controls.Border)(target)).PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.MoveLayer_PreviewMouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 231 "..\..\..\Main\Base.xaml"
            ((System.Windows.Controls.Border)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.MoveLayer_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 232 "..\..\..\Main\Base.xaml"
            ((System.Windows.Controls.Border)(target)).PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.MoveLayer_PreviewMouseMove);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 235 "..\..\..\Main\Base.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenCommandConsole);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 276 "..\..\..\Main\Base.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DisposeSomethings);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 279 "..\..\..\Main\Base.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DisposeSomethings);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

