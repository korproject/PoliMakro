   M S B A M L   `   `   `  ����  
Poli.Makro*    $Poli.Makro.NotifyIcon.WelcomeBalloon   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5          >�Name$  me��5
      $	��130��5      $	��283��5       � 	Resources 5         FadeInAndOut g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value��%y  &	        �� 5   
   .��5      U� $ 00:00:00X�5      $
 grid��5      $ (UIElement.Opacity)�5      .\�5      �� $ 00:00:00��5      $ 0Q�5      �� 5      $ 00:00:01��5      $ 0.895Q�5      �� 5      $ 00:00:10��5      $ 0.895Q�5      �� 5      $ 00:00:11.6000000��5      $ 0Q�5      5      5      5        � Triggers 5!      :� 5"   
    :� RoutedEvent$# tb:TaskbarIcon.BalloonShowing��5#      .[�5$      �� -   5        	 ��Name$"	 FadeInAndOut_BeginStoryboard��5&      #��[  5%      5&      5'      .��5)      �� -   5        
 ��Name$

 grid��5)       �� CornerRadius$ 5��6     ThemeColor1#��[ 6,   ._�5*   
   �  � RowDefinitions 5+      �� 5,      $
��Auto �6    �� 5-      $��* �6    .+�50      �� $��5q�6   $��14(�51      $
��Bold"�52      $
��Wrap=�53      $!��Poli Makro Çalışıyor...��54        BlueGrey200#��[ 55      $��Center=�56      $��Center=�62   �� 58      $��5q�6   $��1��6#   $��13(�59      $
��Wrap=�5:      $����Poli Makro arkaplanda belirlediğin ayarlarla çalışıyor, özel bir işlem yapmadığın sürece sadece komutlarını dinler. İşlemler için bildirim ikonuna bak.��5;      #��[ 5<      $��Center=�5=      $��Center=�62   5?      5@      5A      