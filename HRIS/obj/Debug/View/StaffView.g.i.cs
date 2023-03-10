#pragma checksum "..\..\..\View\StaffView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "633A8651D2D968E515841E40E9AF9FBA00872E87BC4C811E79B55C7E7921D704"
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
    /// StaffView
    /// </summary>
    public partial class StaffView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\View\StaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid StaffDetails;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\View\StaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid User_Options;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\View\StaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameFilterBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\View\StaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CategoryFilterBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\View\StaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox StaffList;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\View\StaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StaffDetailsOutput;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\View\StaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StaffDetailsInfo;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\View\StaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AvailabilityTextBox;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\View\StaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image StaffPhoto;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\View\StaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox StaffConsultationHours;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\View\StaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox StaffTaughtUnits;
        
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
            System.Uri resourceLocater = new System.Uri("/HRIS;component/view/staffview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\StaffView.xaml"
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
            this.StaffDetails = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.User_Options = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.NameFilterBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\..\View\StaffView.xaml"
            this.NameFilterBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NameFilterTextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CategoryFilterBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\..\View\StaffView.xaml"
            this.CategoryFilterBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CategoryFilterSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.StaffList = ((System.Windows.Controls.ListBox)(target));
            
            #line 37 "..\..\..\View\StaffView.xaml"
            this.StaffList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.StaffMemberSelected);
            
            #line default
            #line hidden
            return;
            case 6:
            this.StaffDetailsOutput = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.StaffDetailsInfo = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.AvailabilityTextBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.StaffPhoto = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            this.StaffConsultationHours = ((System.Windows.Controls.ListBox)(target));
            
            #line 113 "..\..\..\View\StaffView.xaml"
            this.StaffConsultationHours.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.StaffConsultationHours_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.StaffTaughtUnits = ((System.Windows.Controls.ListBox)(target));
            
            #line 132 "..\..\..\View\StaffView.xaml"
            this.StaffTaughtUnits.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TaughtUnitSelected);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 151 "..\..\..\View\StaffView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ConsultationTable);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

