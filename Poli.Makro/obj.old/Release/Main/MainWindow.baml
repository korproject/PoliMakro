   M S B A M L   `   `   `  ���� E  APoli.Makro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Poli.Makro.States.ClipboardPoli.Makro.States.Clipboard  ?$clr-namespace:Poli.Makro.States.CodePoli.Makro.States.Code  S.clr-namespace:Poli.Makro.States.JSONXMLXAMLRSS Poli.Makro.States.JSONXMLXAMLRSS       Poli.Makro.Main.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ?	clipboard)clr-namespace:Poli.Makro.States.Clipboard     8codeLib$clr-namespace:Poli.Makro.States.Code     Ijsonxmlxamlrss.clr-namespace:Poli.Makro.States.JSONXMLXAMLRSS     -     � Title$  
Poli Makro��$
��1400��$	��700�� � WindowState$ Normal=� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanResizeWithGrip=� � Topmost . 
������ '  !System.Windows.Shell.WindowChrome   WindowChrome      CaptionHeight$ 0Q�   ResizeBorderThickness$ 5q� � 	Resources ��%    .���  	  White#��[  	 � RowDefinitions	 �� $��70 ��� $��* �
 � ColumnDefinitions
 �� $	��300 ��� $��* �.+�� $��2��$��2��.+��� $
��Fill=�$��0q�$F��@C:\Users\e9396\Pictures\Wallpapers\Dazzling\wallhaven-285274.jpg�� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$	 100Q�   
KernelType$ Gaussian=��� #��[   J� Opacity$ .9Q��� -    ��Name$ SideBarTabControl��$��1��$��0�� �� TabStripPlacement$
 Left=�$
��Left=�$��Stretch=�  BlueGrey800#��[  # PoliMakroTabControlBasedSideBar#���  .@��� $��Pano Yöneticisi��   PoliMakroTabItemBasedSideBar#��[ 
 � Tag ��   	Clipboard �� Source# [  �� Path$
 Data�.���� $��15q�$
��Auto=�$��Hidden=�  SidebarMenuScrollViewer#���  .����  �� Orientation$ Vertical=�.+���  �� Padding$ 10q� �� CornerRadius$ 3��  BlueGrey900#��[ ._��� $��Pano Yöneticisi��$��Center=�#��[  $��15(�$��Segoe UI Semibold)��� $
��Auto=�$��Hidden=�#���  .���� $ Vertical=�$��Stretch=���. .+�9� -   $��İzleme��#��[  $��0 20 0 0q�   PoliMakroSidebarMenuExpander#���  $��14(�$��Segoe UI Semibold)�.���� $ Vertical=�$��1��$��0 0 0 5q�.+�d� -   $��25�� $  PoliMakroSidebarMenuToggleButton#��[ $��Klavye - Fare��$
��Left=�$��13(�$��Segoe UI)�d� -   $��25��#��[ $��Pano Değişiklikleri��$
��Left=�$��13(�$��Segoe UI)�d� -   $��25��#��[ $ ��Fare ile Seçilen Metinler��$
��Left=�$��13(�$��Segoe UI)�9� -   $��Kayıt��#��[  $��0 20 0 0q�#���  $��14(�$��Segoe UI Semibold)�.���� $ Vertical=�$��1��$��0 0 0 5q�.+�d� -   $��25��#��[ $��Kayıt Seçenekleri��$
��Left=�$��13(�$��Segoe UI)��� $��JSON XML RSS��#��[  ��  	 	Hierarchy# [	 $
 Data�.���� $��15q�$
��Auto=�$��Hidden=�#���  .���� $ Vertical=�.+��� $ 10q�$ 3��#��[ ._��� $��JSON - XML -XAML - RSS��$��Center=�#��[  $��15(�$��Segoe UI Semibold)��� $
��Auto=�$��Hidden=�#���  .���� $ Vertical=�$��Stretch=���. .+�9� -	   $��JSON Araçları��#��[  $��0 20 0 0q�#���  $��14(�$��Segoe UI Semibold)� 9� 
IsExpanded . .���� $ Vertical=�$��1��$��0 0 0 5q�.+�d� -
   $��25��#��[ $��#Düzenleme ve Kaydetme��$
��Left=�$��13(�$��Segoe UI)�9� -   $��XML Araçları��#��[  $��0 20 0 0q�#���  $��14(�$��Segoe UI Semibold)�.���� $ Vertical=�$��1��$��0 0 0 5q�.+�d� -   $��25��#��[ $��#Düzenleme ve Kaydetme��$
��Left=�$��13(�$��Segoe UI)�9� -   $��XAML Araçları��#��[  $��0 20 0 0q�#���  $��14(�$��Segoe UI Semibold)�.���� $ Vertical=�$��1��$��0 0 0 5q�.+�d� -   $��25��#��[ $��#Düzenleme ve Kaydetme��$
��Left=�$��13(�$��Segoe UI)�9� -   $��RSS Araçları��#��[  $��0 20 0 0q�#���  $��14(�$��Segoe UI Semibold)�.���� $ Vertical=�$��1��$��0 0 0 5q�.+�d� -   $��25��#��[ $��#Düzenleme ve Kaydetme��$
��Left=�$��13(�$��Segoe UI)�9� -   $��Dönüştürme��#��[  $��0 20 0 0q�#���  $��14(�$��Segoe UI Semibold)�.���� $ Vertical=�$��1��$��0 0 0 5q�.+�d� -   $��25��#��[ $"��#JSON ve XML Dönüşümleri��$
��Left=�$��13(�$��Segoe UI)��� $��Renkler Kütüphanesi��#��[  ��  
 ColorPalette1em# [
 $
 Data��� $��Kodlar Kütüphanesi��#��[  ��   Code# [ $
 Data�.���� $��15q�$
��Auto=�$��Hidden=�#���  .���� $ Vertical=�.+��� $ 10q�$ 3��#��[ ._��� $��Kod Kütüphanesi��$��Center=�#��[  $��15(�$��Segoe UI Semibold)��� $
��Auto=�$��Hidden=�#���  .���� $ Vertical=�$��Stretch=���. .+�9� -   $��Kod Kütüphanesi��#��[  $��0 20 0 0q�#���  $��14(�$��Segoe UI Semibold)� . .���� $ Vertical=�$��1��$��0 0 0 5q�.+�d� -   $��25��#��[ $��#Kütüphane��$
��Left=�$��13(�$��Segoe UI)�d� -   $��25��#��[ $��#Kod veya Kod Grubu Ekle��$
��Left=�$��13(�$��Segoe UI)�d� -   $��25��#��[ $��	#Geçmiş��$
��Left=�$��13(�$��Segoe UI)�{�.  d� -   $��25��#��[ $��#Paylaştıklarım��$
��Left=�$��13(�$��Segoe UI)�{�.  �� {�.  #��[  ��   Setting# [ $
 Data��� $��0��$��2��#��[ �� $��1��$��1��  NoHeaderTabControl#��[  �� SelectedIndex ��  �� ElementName$ SideBarTabControl��$ SelectedIndex�.@��� .��2   ,Poli.Makro.States.Clipboard.ClipboardRecords  �� .��7   1Poli.Makro.States.JSONXMLXAMLRSS.JXXR_View_Editor  �� .���� �� .��$   Poli.Makro.States.Code.CodeLib  �� -     DefaultButtonStyle#��[ $
��Left=�.���� $ 
Horizontal=�.+�F� $��15�� �� Stretch$ Uniform=�  
BlueGrey50#��[ ����   HamburgerMenu# [ $
 Data��� -   $ .00001Q�$��2��#��[  