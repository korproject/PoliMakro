   M S B A M L   `   `   `  ���� ^  ZAurelienRibon.Ui.SyntaxHighlightBox, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null�^clr-namespace:AurelienRibon.Ui.SyntaxHighlightBox;assembly=AurelienRibon.Ui.SyntaxHighlightBox#AurelienRibon.Ui.SyntaxHighlightBox  J FMrMitch.Loaders, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null:.clr-namespace:Loaders;assembly=MrMitch.LoadersLoaders E APoli.Makro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Poli.Makro.States.CodePoli.Makro.States.Code =#clr-namespace:Poli.Makro.ConvertersPoli.Makro.Converters J FPoli.Makro.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullrJclr-namespace:Poli.Makro.Core.Helpers.RichTextBox;assembly=Poli.Makro.Core#Poli.Makro.Core.Helpers.RichTextBox $   Poli.Makro.States.Code.CodeLib   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     }syntaxHighlightBox^clr-namespace:AurelienRibon.Ui.SyntaxHighlightBox;assembly=AurelienRibon.Ui.SyntaxHighlightBox     Bloaders.clr-namespace:Loaders;assembly=MrMitch.Loaders     5code$clr-namespace:Poli.Makro.States.Code     :
converters#clr-namespace:Poli.Makro.Converters     brichTextBoxJclr-namespace:Poli.Makro.Core.Helpers.RichTextBox;assembly=Poli.Makro.Core     X TXceed.Wpf.Toolkit, Version=3.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � 	Resources  :  4Poli.Makro.Converters.Bool2ToggleVisibilityConverter "  Bool2ToggleVisibilityConverter4  .Poli.Makro.Converters.Bool2VisibilityConverter  Bool2VisibilityConverter6  0Poli.Makro.Converters.MultipleParameterConverter  MultipleParameterConverter< 6Poli.Makro.Converters.StringMaxLenghtTreeDotsConverter $  StringMaxLenghtTreeDotsConverter  DataTemplateforCodeGroups � ColumnDefinitions �� Stretch  BlueGrey400  Code �� Source �� Path  BlueGrey300 �� 	Converter � ToolTip  CustomTooltip 	 DataTemplateforCodeList  
 DataTemplateforAddGroupCombo  GroupofAtoms  DataTemplateforAddLangCombo  Translation��%�  &	        &	      &	 
     &	      &	      7  7  7  7  &		     7  7  7  7  &	
     7  7  7  7  &	     7  7  7  7          �� .R�� $��30�� �� $��40 ��� $��* �.+�F� $ Uniform=�$��15��8��  $��Center=����� 8  $
 Data��� $��1��8�� $��Center=�$��Segoe UI Semilight)�$��14(����� $ Title�8   _� #���  ���� $ Title��� .R�� $��30�� �� $��40 ��� $��* �.+�F� $ Uniform=�$��15��8��  $��Center=����� 8  $
 Data��� $��1��8�� $��Center=�$��Segoe UI Semilight)�$��14(����� $ Title�8   _� #���  ���� $ Title��� .R�� $��30�� �� $��40 ��� $��* �.+�F� $ Uniform=�$��15��8��  $��Center=����� 8  $
 Data��� $��1��8�� $��Center=�$��Segoe UI Semilight)�$��14(����� $ Title�8   _� #���  ���� $ Title��� .R�� $��30�� �� $��40 ��� $��* �.+�F� $ Uniform=�$��15��8��  $��Center=����� 8  $
 Data��� $��1��8�� $��Center=�$��Segoe UI Semilight)�$��14(����� $ Title�8   _� #���  ���� $ Title�.��� .+��� -    ��Name$ 
TabControl��  CustomTabControl#���  $��Stretch=�.@��� $��Kütüphane��  CustomTabItemStyle#��[ 
 � Tag ��   	Hierarchy# [ $
 Data�.���  �� $��* ��� $	��350 �	 � RowDefinitions	 �� $��* ��� $��* �.+��� $��2��$��10 15 10 15q�#��[   BlueGrey900#��[   CustomListView#��[ $R LKod grupları burada görüntülenir ancak henüz bir kod grubu eklenmemiş.������ $ 
CodeGroups��� $��2��$��1��$��10 15 10 15q�#��[	 #��[ #��[ $ Gösterilecek Kod Yok������ $ Codes��� $��Geçmiş��#��[  �� # [ $
 Data��� $��Kod / Grup Ekle��#��[ .���  �� $	��330 ��� $��* �	 �� $��50 ��� $��* �.+���   CustomButtonStyle#��[ $��10 0 0 0q�$��Temizle��$��Segoe UI Semilight)�$��18(�#��[ �� $��1��$��	15 0 15 0q�$��Segoe UI Semilight)�$��18(�#��[ ���� $ Status��� $��1��$��Hidden=�$��0 0 0 15q�$��Hidden=�  SidebarMenuScrollViewer#���  .���� 
 �� Orientation$
 Vertical=�$��Stretch=���. .+�9� -   $��Kod Ekle�� 	 White#��[ $��0 15 0 0q�   PoliMakroSidebarMenuExpander#���  $��14(�$��Segoe UI Semibold)�$	��Top=� 9� 
IsExpanded �� $ AddCodeExpanderIsExpanded�.���� $
 Vertical=�$��1��$��0 0 0 5q�{��� $ AddCodeIsEnabled�.+��� #��[ $��35��._��� $
 
Horizontal=�$��5 0 0 0q�.+�� .+�  Loaders.ChromeLoader  $��25��$��25��$��Center=�$��Center=�y���  �� ElementName$ EyeToggleButton��$ 	IsChecked�# [   �� FallbackValue$ Hidden������ $ AddCodeTitle��$
 Text�  SideMenuItemColorConverter# [ F� $ Uniform=�$��13��$��17��#��[ $��Center=����� # [ $
 Data��� -    ��Name$ AddCodeTitle��$	��240��$��35��$��Center=�$��Stretch=�$��Center=�$&  Kod Bloğu için Bir İsim Girin��$��Segoe UI Semilight)�#��[   BlueGrey200#��[  �� 
CaretBrush �� $ AddCodeTitle��$
 Text�# [  �� SelectionBrush �� $ AddCodeTitle��$
 Text�# [ .�� J� InputBindings �� 
 �� Key$ Enter�� �� Command �� $ AddCodeComm� �� CommandParameter �� $ AddCodeTitle��$
 Text�.�� _� #���  $j��dBoş bırakılırsa veritabanına kaydediliği satır numarası ile gösterilecektir/çağrılabilir��.��#  Xceed.Wpf.Toolkit.RichTextBox  -     Name$ AddCodeDescRichTBox��$	��150��$��0 10 0 0q�$��5q�$��0q�$��13(�#��[ #��[ $��Stretch=�$? 9Varsa küçük bir açıklama veya bağlantı eklenebilir��$
��Auto=�$��Segoe UI Semilight)�   Text �� $ AddCodeDesc�����  �� RelativeSource �� *FindAncestor+ �� AncestorType$ 
StackPanelL�$ ActualWidth�3  -Xceed.Wpf.Toolkit.RichTextBoxFormatBarManager   	FormatBar ,  &Xceed.Wpf.Toolkit.RichTextBoxFormatBar     TextFormatter *	  $Xceed.Wpf.Toolkit.PlainTextFormatter	  9� -   $��	Grup Ekle��#��[  . $��0 20 0 0q�#���  $��14(�$��Segoe UI Semibold)�$	��Top=�.���� $
 Vertical=�$��1��$��0 0 0 5q�{��� $ AddGroupIsEnabled�.+��� $��0 0 0 10q�#��[
 #���  $��35��  CustomComboBoxStyle#���  ���� $ CodeGroupsL� �� SelectedItem �� $ SelectedBasicCodeGroups���  �� CornerRadius$ 0��#��[ $��35��._��� $
 
Horizontal=�$��5 0 0 0q�.+�� .+�  $��25��$��25��$��Center=�$��Center=�y��� $ AddGroupIsEnabled��$ 	IsEnabled�# [  $ Hidden������ $ AddGroupTitle��$
 Text�# [ F� $ Uniform=�$��15��#��[ $��Center=����� # [ $
 Data��� -   $ AddGroupTitle��$	��240��$��35�� �� 	MaxLength$
 100 ��$��Center=�$��Stretch=�$��Center=�$% Kod Grubu için Bir İsim Girin��$��Segoe UI Semilight)�#��[ #��[  �� $ AddGroupTitle��$
 Text�# [  �� $ AddGroupTitle��$
 Text�# [ .�� �� $ Enter�� �� $ AddGroupComm� �� $ AddGroupTitle��$
 Text�.�� _� #���  $j��dBoş bırakılırsa veritabanına kaydediliği satır numarası ile gösterilecektir/çağrılabilir��.��  -   $ AddGroupRichTBox��$	��150��$��0 10 0 0q�$��5q�$��0q�$��13(�#��[ #��[ $��Stretch=�$? 9Varsa küçük bir açıklama veya bağlantı eklenebilir��$
��Auto=�$��Segoe UI Semilight)� �� $ AddGroupDesc�����  �� *FindAncestor+$ 
StackPanelL�$ ActualWidth�    	  9� -   $��Dil Ekle��#��[  . $��0 20 0 0q�#���  $��14(�$��Segoe UI Semibold)�$	��Top=�.���� $
 Vertical=�$��1��$��0 0 0 5q�{��� $ AddLangIsEnabled�.+��� $��0 0 0 10q�#��[ #���  $��35��#���  ���� $ 
CodeLangsL� �� $ SelectedBasicLangs��� $ 0��#��[ $��35��._��� $
 
Horizontal=�$��5 0 0 0q�.+�� .+�  $��25��$��25��$��Center=�$��Center=�y��� $ AddLangIsEnabled��$ 	IsEnabled�# [  $ Hidden������ $ AddLangTitle��$
 Text�# [ F� $ Uniform=�$��15��#��[ $��Center=����� # [ $
 Data��� -	   $ AddLangTitle��$	��240��$��35��$
 100 ��$��Center=�$��Stretch=�$��Center=�$ Bir Dil İsmi Girin��$��Segoe UI Semilight)�#��[ #��[  �� $ AddLangTitle��$
 Text�# [  �� $ AddLangTitle��$
 Text�# [ .�� �� $ Enter�� �� $ AddLangComm� �� $ AddLangTitle��$
 Text�.�� _� #���  .��  -
   $ AddLangRichTBox��$	��150��$��0 10 0 0q�$��5q�$��0q�$��13(�#��[ #��[ $��Stretch=�$? 9Varsa küçük bir açıklama veya bağlantı eklenebilir��$
��Auto=�$��Segoe UI Semilight)� �� $ AddLangDesc�����  �� *FindAncestor+$ 
StackPanelL�$ ActualWidth�    	  <
   6AurelienRibon.Ui.SyntaxHighlightBox.SyntaxHighlightBox
  -    
 Name$ HighlightedCodeBase��$��1��$��1��! 
  IsLineNumbersMarginVisible . $��15q����� $ AddCodeText�