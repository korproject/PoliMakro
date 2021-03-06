﻿#pragma checksum "..\..\..\..\States\Color\Color.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BCFC90C61B306CE5B790A8DB86789072030F5E93BB681B42CAC9525E7C976E02"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Loaders;
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


namespace Poli.Makro.States.Color {
    
    
    /// <summary>
    /// Color
    /// </summary>
    public partial class Color : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 166 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl TabControl;
        
        #line default
        #line hidden
        
        
        #line 177 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ColorPickerGrid;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border MouseOverColorBorder;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MousePositions;
        
        #line default
        #line hidden
        
        
        #line 206 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.ColorCanvas MouseColorPicker;
        
        #line default
        #line hidden
        
        
        #line 331 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView PickedColorsListView;
        
        #line default
        #line hidden
        
        
        #line 357 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid PickedGroupSaveGrid;
        
        #line default
        #line hidden
        
        
        #line 381 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PickedColorsGroupName;
        
        #line default
        #line hidden
        
        
        #line 433 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton ColorPickerMiniTB;
        
        #line default
        #line hidden
        
        
        #line 465 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ColorLibGrid;
        
        #line default
        #line hidden
        
        
        #line 466 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid CodeLibListSelectGrid;
        
        #line default
        #line hidden
        
        
        #line 472 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ColorGroupsListView;
        
        #line default
        #line hidden
        
        
        #line 484 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ColorsListView;
        
        #line default
        #line hidden
        
        
        #line 497 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AddNewColorGrid;
        
        #line default
        #line hidden
        
        
        #line 528 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddColorTitle;
        
        #line default
        #line hidden
        
        
        #line 547 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddColorString;
        
        #line default
        #line hidden
        
        
        #line 577 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.ColorCanvas _colorPicker;
        
        #line default
        #line hidden
        
        
        #line 630 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AddNewGroupGrid;
        
        #line default
        #line hidden
        
        
        #line 661 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddGroupTitle;
        
        #line default
        #line hidden
        
        
        #line 727 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton AddNewColorTB;
        
        #line default
        #line hidden
        
        
        #line 739 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton AddNewGroupTb;
        
        #line default
        #line hidden
        
        
        #line 760 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid DominantColorsGrid;
        
        #line default
        #line hidden
        
        
        #line 783 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView DominantColorsListView;
        
        #line default
        #line hidden
        
        
        #line 806 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid DominantColorsGroupSaveGrid;
        
        #line default
        #line hidden
        
        
        #line 830 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DominantColorsGroupName;
        
        #line default
        #line hidden
        
        
        #line 884 "..\..\..\..\States\Color\Color.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton SaveDominantColorsGroupTB;
        
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
            System.Uri resourceLocater = new System.Uri("/Poli.Makro;component/states/color/color.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\States\Color\Color.xaml"
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
            
            #line 170 "..\..\..\..\States\Color\Color.xaml"
            this.TabControl.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TabControl_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ColorPickerGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.MouseOverColorBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.MousePositions = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.MouseColorPicker = ((Xceed.Wpf.Toolkit.ColorCanvas)(target));
            return;
            case 6:
            
            #line 220 "..\..\..\..\States\Color\Color.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.ColorWatcher_Checked);
            
            #line default
            #line hidden
            
            #line 220 "..\..\..\..\States\Color\Color.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.ColorWatcher_Unchecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.PickedColorsListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.PickedGroupSaveGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            
            #line 358 "..\..\..\..\States\Color\Color.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PickedGroupSave_Close);
            
            #line default
            #line hidden
            return;
            case 10:
            this.PickedColorsGroupName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            
            #line 399 "..\..\..\..\States\Color\Color.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SavePickedColors);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 410 "..\..\..\..\States\Color\Color.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PickedGroupSave_Close);
            
            #line default
            #line hidden
            return;
            case 13:
            this.ColorPickerMiniTB = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 436 "..\..\..\..\States\Color\Color.xaml"
            this.ColorPickerMiniTB.Checked += new System.Windows.RoutedEventHandler(this.ColorPickerMini_Checked);
            
            #line default
            #line hidden
            
            #line 436 "..\..\..\..\States\Color\Color.xaml"
            this.ColorPickerMiniTB.Unchecked += new System.Windows.RoutedEventHandler(this.ColorPickerMini_Close);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 447 "..\..\..\..\States\Color\Color.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.SaveAsPickedColors_Checked);
            
            #line default
            #line hidden
            
            #line 447 "..\..\..\..\States\Color\Color.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.PickedGroupSave_Close);
            
            #line default
            #line hidden
            return;
            case 15:
            this.ColorLibGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 16:
            this.CodeLibListSelectGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 17:
            this.ColorGroupsListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 18:
            this.ColorsListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 19:
            this.AddNewColorGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 20:
            
            #line 498 "..\..\..\..\States\Color\Color.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddNewColor_Close);
            
            #line default
            #line hidden
            return;
            case 21:
            this.AddColorTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 22:
            this.AddColorString = ((System.Windows.Controls.TextBox)(target));
            return;
            case 23:
            this._colorPicker = ((Xceed.Wpf.Toolkit.ColorCanvas)(target));
            return;
            case 24:
            
            #line 604 "..\..\..\..\States\Color\Color.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveColor);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 615 "..\..\..\..\States\Color\Color.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddNewColor_Close);
            
            #line default
            #line hidden
            return;
            case 26:
            this.AddNewGroupGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 27:
            
            #line 631 "..\..\..\..\States\Color\Color.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddNewGroup_Close);
            
            #line default
            #line hidden
            return;
            case 28:
            this.AddGroupTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 29:
            
            #line 693 "..\..\..\..\States\Color\Color.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveGroup);
            
            #line default
            #line hidden
            return;
            case 30:
            
            #line 704 "..\..\..\..\States\Color\Color.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddNewGroup_Close);
            
            #line default
            #line hidden
            return;
            case 31:
            this.AddNewColorTB = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 730 "..\..\..\..\States\Color\Color.xaml"
            this.AddNewColorTB.Checked += new System.Windows.RoutedEventHandler(this.AddNewColor_Checked);
            
            #line default
            #line hidden
            
            #line 730 "..\..\..\..\States\Color\Color.xaml"
            this.AddNewColorTB.Unchecked += new System.Windows.RoutedEventHandler(this.AddNewColor_Close);
            
            #line default
            #line hidden
            return;
            case 32:
            this.AddNewGroupTb = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 742 "..\..\..\..\States\Color\Color.xaml"
            this.AddNewGroupTb.Checked += new System.Windows.RoutedEventHandler(this.AddNewGroup_Checked);
            
            #line default
            #line hidden
            
            #line 742 "..\..\..\..\States\Color\Color.xaml"
            this.AddNewGroupTb.Unchecked += new System.Windows.RoutedEventHandler(this.AddNewGroup_Close);
            
            #line default
            #line hidden
            return;
            case 33:
            this.DominantColorsGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 34:
            this.DominantColorsListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 35:
            this.DominantColorsGroupSaveGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 36:
            
            #line 807 "..\..\..\..\States\Color\Color.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DominantColorsGroupSave_Close);
            
            #line default
            #line hidden
            return;
            case 37:
            this.DominantColorsGroupName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 38:
            
            #line 848 "..\..\..\..\States\Color\Color.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveDominantColors);
            
            #line default
            #line hidden
            return;
            case 39:
            
            #line 859 "..\..\..\..\States\Color\Color.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DominantColorsGroupSave_Close);
            
            #line default
            #line hidden
            return;
            case 40:
            this.SaveDominantColorsGroupTB = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 887 "..\..\..\..\States\Color\Color.xaml"
            this.SaveDominantColorsGroupTB.Checked += new System.Windows.RoutedEventHandler(this.SaveDominantColorsGroup_Checked);
            
            #line default
            #line hidden
            
            #line 887 "..\..\..\..\States\Color\Color.xaml"
            this.SaveDominantColorsGroupTB.Unchecked += new System.Windows.RoutedEventHandler(this.DominantColorsGroupSave_Close);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

