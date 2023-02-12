﻿#pragma checksum "..\..\..\View\UnitView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B471096B2098A482945C404E1F2B3FE31721531796CABB34319CC1B739E7C0AB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HRIS.Controller;
using HRIS.View;
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


namespace HRIS.View {
    
    
    /// <summary>
    /// UnitView
    /// </summary>
    public partial class UnitView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\View\UnitView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid UnitDetails;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\View\UnitView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid User_Options;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\View\UnitView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UnitNameFilterBox;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\View\UnitView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CampusFilteredBox;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\View\UnitView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox UnitList;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\View\UnitView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView UnitDayandTime;
        
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
            System.Uri resourceLocater = new System.Uri("/HRIS;component/view/unitview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\UnitView.xaml"
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
            this.UnitDetails = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.User_Options = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.UnitNameFilterBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 42 "..\..\..\View\UnitView.xaml"
            this.UnitNameFilterBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NameFilterTextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CampusFilteredBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 80 "..\..\..\View\UnitView.xaml"
            this.CampusFilteredBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CampusFilterSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.UnitList = ((System.Windows.Controls.ListBox)(target));
            
            #line 91 "..\..\..\View\UnitView.xaml"
            this.UnitList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.UnitListSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.UnitDayandTime = ((System.Windows.Controls.ListView)(target));
            
            #line 125 "..\..\..\View\UnitView.xaml"
            this.UnitDayandTime.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.UnitCoordinatorSelected);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

