   M S B A M L   `   `   `  ���� J  FMrMitch.Loaders, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null:.clr-namespace:Loaders;assembly=MrMitch.LoadersLoaders  J FPoli.Makro.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulljFclr-namespace:Poli.Makro.Core.Helpers.TextBox;assembly=Poli.Makro.CorePoli.Makro.Core.Helpers.TextBox E APoli.Makro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Poli.Makro.ConvertersPoli.Makro.Converters    Poli.Makro.Main.Login   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Bloaders.clr-namespace:Loaders;assembly=MrMitch.Loaders     ZtextBoxFclr-namespace:Poli.Makro.Core.Helpers.TextBox;assembly=Poli.Makro.Core     :
converters#clr-namespace:Poli.Makro.Converters     -     � Title$  
Poli Makro��$	��800��$	��450�� � WindowState$ Normal=� � WindowStartupLocation$ CenterScreen=� � Topmost . 
������  � WindowStyle$
 None=� � AllowsTransparency . '  !System.Windows.Shell.WindowChrome   WindowChrome      CaptionHeight$ 0Q�   ResizeBorderThickness$ 5q�	 � 	Resources	 :  4Poli.Makro.Converters.Bool2ToggleVisibilityConverter "  Bool2ToggleVisibilityConverter4  .Poli.Makro.Converters.Bool2VisibilityConverter  Bool2VisibilityConverter
 �� 
TargetType �� Property �� Value 	 White  BlueGrey700-  'System.Windows.Input.KeyboardNavigation �� 
TargetType ��Name �� CornerRadius �� Padding J� SnapsToDevicePixels ��Name J� IsHitTestVisible
 � Tag  BlueGrey500 $  WatermarkTextBlockforPasswordBox ��Name  SideMenuItemColorConverter �� 	Converter �� Triggers P� Property P� Value N� EnterActions �� TargetProperty �� 
TargetName<  6System.Windows.Media.Animation.EasingThicknessKeyFrame p� KeyTime p� Value N� ExitActions  �� 
TargetName  TextBox.Focus.Border��%-  &	        &	      'G� 
     7  7  7  7  7      �� "
 G�.���  �@G�PasswordChar$	 ●����  � ��# � ����  � ��8   ��  � ��8  ��  � ��$ 0q���  �@ TabNavigation$
 None=���  � ��$
 Left=���  �@�FocusVisualStyle Z� ��  �@J�	AllowDrop . ��  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � ��$ 5 0 0 0q���  � �� �� " G�.R�� .+��� $ border��$ 5��$ 5q�#��z��#��z�� . $��Stretch=�._�� .+��� $ 	Watermark��$��5 0 0 0q� .  #��z #��z��#��z��8�� #��z��#��z��#��z��#��z��#���  �� $ PART_ContentHost��|�.  $��Hidden=�$��Hidden=��� $��1��$��1 4 1 2q�$ .8��$y�Hidden=�$��Stretch=�$��Bottom=����� *PasswordChar+8   P�  �@J�	IsFocused .  �� .���� .��r� $ (FrameworkElement.Margin)�$ 	Watermark��.	�  $ 0:0:0.2�� 5 0 5 0  $ 0:0:0.3�� 6 0 6 0  $ 0:0:0.4�� 9 0 9 0 �� .���� .��r� $ (FrameworkElement.Margin)�$ 	Watermark��.	�  $ 0:0:0.2�� 9 0 9 0  $ 0:0:0.3�� 6 0 6 0  $ 0:0:0.4�� 5 0 5 0P�  � {� .  . ��� $  border�� �@J�Opacity$	 0.5Q�P�  �@J�IsKeyboardFocused . . ��� $  border��8   � ��.��� ! � ColumnDefinitions! �� $��* ��� $��* �" � RowDefinitions" �� $��* ��� $��* �.+��� $��2��$��2��# J� Opacity$	# .50Q�$ 10������ $ �� ImageSource$2$ ,/Poli.Makro;component/Resources/mountain.png��% j� Stretch$% UniformToFill=��� -   $��2��$��2��$	# .95Q�$ 10��  BlueGrey800#��[ �� $��2��$��30(�$��Poli Makro - Giriş��$��Center=�$	��Top=�$��50q� 	 BlueGrey300#��[	 � $��2��$��2��$��Center=�$��Center=�$	��150��$	��150��$��0 75 0 0q�" �� $��* ��� $��* �.+��� & �� Orientation$& 
Horizontal=�y��� *UsernameVisibility+' �� FallbackValue$' Hidden��{��� *UsernameIsEnabled+.+�� $��0 0 10 0q�.+�   Loaders.ChromeLoader  $��25��$��25��$��Center=�$��Center=�y��� *UsernameLoaderVisibility+$' Hidden������ ( �� ElementName$( Username��) �� Path$
) Text�* �� 	Converter#* [ F� + �� Stretch$+ Uniform=�$��25�� 
 BlueGrey400#��[
 ����   LightCircle, �� Source#, [ $
) Data�F� $+ Uniform=�$��15��#��[
 $��Center=�����   User#, [ $
) Data��� -   - ��Name$- Username��$	��300��$��35��$��Center=�$��Stretch=�$��Center=�$ Kullanıcı Adı��  BlueGrey900#��[   BlueGrey200#��[ 4  .Poli.Makro.Core.Helpers.TextBox.FocusExtension.   	IsFocused. �� *UsernameIsFocused+/ �� 
CaretBrush/ �� $( Username��$
) Text�#* [ 0 �� SelectionBrush0 �� $( Username��$
) Text�#* [ .��1 J� InputBindings1 �� 
2 �� Key$2 Enter��3 �� Command3 �� $) CheckUsernameCom�4 �� CommandParameter4 �� $( Username��$
) Text�.��� y��� *PasswordVisibility+{��� *PasswordIsEnabled+.+�� y��� $( Password��$) 
Visibility�.+�d� $
��Left=�$��0 0 0 60q�  CustomToggleButton#��[ ���� $) BacktoUsername�.��� .+�F� $+ Uniform=�$��20��#��[
 ���� #, [ $
) Data�F� $+ Uniform=�$��9��#��[
 $��Center=����� #, [ $
) Data�5 � ToolTip5 _�   CustomTooltip#���  $6��0Kullanıcı Adı kısmına geri dönebilirsiniz.��F� $+ Uniform=�$��15��#��[
 $
��Left=�$��	25 0 0 50q�6 J� RenderTransformOrigin$6 0.5,0.5&�����   SimpleArrow#, [ $
) Data�z�V� .~��� �� �� 7 �� Angle$7 11.496Q�T� �� $& 
Horizontal=�.+�� $��0 0 10 0q�.+�  $��25��$��25��$��Center=�$��Center=�y��� *PasswordLoaderVisibility+$' Hidden������ $( Password��$) SecurePassword�#* [ F� $+ Uniform=�$��25��#��[
 ���� #, [ $
) Data�F� $+ Uniform=�$��12��#��[
 $��Center=�����   Key#, [ $
) Data��� $ 5��#��[ $��35��._��� $& 
Horizontal=�$	��300��.+�� .+�G� -   8 G�Name$8 Password��$	��270��$��35��$��Center=�$��Stretch=�$��Center=�$ Şifre��#��[ #��[ y��� $( EyeToggleButton��$) 	IsChecked�#* [ . �� *PasswordBoxIsFocused+9 G� 
CaretBrush9 �� $( Password��$) SecurePassword�#* [ : G� SelectionBrush: �� $( Password��$) SecurePassword�#* [ 1 �� $2 Enter��3 �� $) LoginCom�4 �� $( Password���� -   $- PassTextBox��$	��270��$��35��$��Center=�$��Stretch=�$��Center=�$ >Şifre��#��[ #��[ y��� $( EyeToggleButton��$) 	IsChecked�#* [  . �� *PassTextBoxIsFocused+/ �� $( Username��$
) Text�#* [ 0 �� $( Username��$
) Text�#* [ .��1 �� $2 Enter��3 �� $) LoginComText�4 �� $( PassTextBox��$
) Text�.��5 _� #���  $k��eBu alan şifrenizi yetkisiz erişimlerde açık hale getirebilir, PasswordBox kullanmanız önerilir.��.��d� -   ; d�Name$; EyeToggleButton��  EyeToggleButton#��[ $��10��#��[	 $��Center=��� $��1��$��	30 -5 0 0q�$��Stretch=�$	��Top=�$
��Auto=�$
��Auto=�.���� $	��300��#��[ $��10q�$��WrapWithOverflow=����� *Status+< �� Mode$< OneWay=�= �� UpdateSourceTrigger$= PropertyChanged=�> �� IsAsync> . �� $��1��$��0��$
��Left=�$��Bottom=�$��10q�$��v1.2.3.4��#��[	 �� $& 
Horizontal=�$��1��$��1��$��10q�$��Right=�$��Bottom=�.+��� $��Misafir Girişi��$��10 0 0 0q�#��[	   ClickableTextButton#��[ �� $��/��$��10 0 0 0q�#��[ �� $��Şifremi Unuttum?��$��10 0 0 0q�#��[	 #��[ d� $��0��$��1��$��Right=�$	��Top=�
������ $��10q�#��[ .��� .+�F� $+ Uniform=�$��25��  BlueGrey100#��[ ���� #, [ $
) Data�F� $+ Uniform=�$��10��#��[ ����   	CrossMark#, [ $
) Data�5 _� #���  $ ��Uygulamayı sonlandırır.��