﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Nemont.WPF.Service;

namespace Nemont.WPF.Controls
{
    public class TabButton : RadioButton
    {
        public static SolidColorBrush SelectedBackground { get; set; } = SystemColors.HighlightBrush;

        [Category("Brushes")]
        public Brush SelectedForeground { get { return (Brush)GetValue(SelectedForegroundProperty); } set { SetValue(SelectedForegroundProperty, value); } }
        public static DependencyProperty SelectedForegroundProperty =
            DependencyProperty.Register(nameof(SelectedForeground), typeof(Brush), typeof(TabButton), new PropertyMetadata(SystemColors.HighlightTextBrush));

        static TabButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TabButton), new FrameworkPropertyMetadata(typeof(TabButton)));
        }

        protected override void OnChecked(RoutedEventArgs e)
        {
            base.OnChecked(e);

            var parent = VisualDependencyObject.FindParent<TabGroupBox>(this as DependencyObject);
            if (parent == null) {
                return;
            }

            var backBtnToggle = (Border)parent.Template.FindName("Bd_Btn_Toggle", parent);

            backBtnToggle.Visibility = Visibility.Visible;
        }

        protected override void OnUnchecked(RoutedEventArgs e)
        {
            base.OnUnchecked(e);

            var parent = VisualDependencyObject.FindParent<TabGroupBox>(this as DependencyObject);
            if (parent == null) {
                return;
            }

            var backBtnToggle = (Border)parent.Template.FindName("Bd_Btn_Toggle", parent);

            backBtnToggle.Visibility = Visibility.Hidden;
        }
    }
}
