   M S B A M L   `   `   `  ���� E  APoli.Makro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Poli.Makro.ConvertersPoli.Makro.Converters  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0890    *Poli.Makro.Converters.SideMenuExpConverter   SideMenuExpConverter6   0Poli.Makro.Converters.SideMenuItemColorConverter  SideMenuItemColorConverter/   )Poli.Makro.Converters.ToggleBoolConverter  ToggleBoolConverter  Expander.ArrowDown  Expander.ArrowUp $  Expander.MouseOver.Circle.Stroke  �� Color " Expander.MouseOver.Circle.Fill # Expander.MouseOver.Arrow.Stroke " Expander.Pressed.Circle.Stroke  	 Expander.Pressed.Circle.Fill !
 Expander.Pressed.Arrow.Stroke # Expander.Disabled.Circle.Stroke ! Expander.Disabled.Circle.Fill " Expander.Disabled.Arrow.Stroke  Expander.Static.Circle.Fill ! Expander.Static.Circle.Stroke   Expander.Static.Arrow.Stroke  ExpanderRightHeaderStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Padding J� SnapsToDevicePixels � RowDefinitions � LayoutTransform	 �� Angle
 A�Name F�Name �� Triggers P� Property P� Value �� 
TargetName  ExpanderUpHeaderStyle � ColumnDefinitions  ExpanderLeftHeaderStyle  ExpanderDownHeaderStyle �� Stretch �� ElementName �� Path �� 	Converter ��Name J� Opacity J� RenderTransformOrigin �� Source N� EnterActions �� 
TargetName �� TargetProperty	 W� To g� Duration9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  N� ExitActions  ExpanderHeaderFocusVisual! �� StrokeDashArray  SidebarMenuExpander" �� CornerRadius# d�Name$ � FocusVisualStyle% d� 	IsChecked& �� Mode' �� RelativeSource( ��Name
) � Tag* `� 	Converter+ �Name   PoliMakroSidebarMenuExpander�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     2
converters#clr-namespace:Poli.Makro.Converters  1system&clr-namespace:System;assembly=mscorlib  %H'  &	        &	      &	 
     &	      &	     &	 X    &	 m    &	 �    &	 �    &		 �    &	
 �    &	 �    &	 �    &	      &	     &	 *    &	 ?    &	 T    7  7  7  7  7  7  7  7 	 7 
 7  7  7  &	 �    7  7  7  7  7  7  7  7 	 7 
 7  7  7  &	 /    7  7  7  7  7  7  7  7 	 7 
 7  7  7  &	 �    7  7  7  7  7  7  7 	 7  7  &	 �    &	 @    7  7  7   7  7  7  7  &	 �    7  7  7   7  7  7  7         F� �����yw�wb� �#y���� ���;,� iۣ�� �@x}{ �W �� ӫ8T �� �IP ��� �,L �q� ӏ�E ��� ~_@ IB� $�= !�� ��; <��  	= �Q� i�A ��� �i�r�� �J�xx�&6L�x�&B��� �o���� �����Q� �U�u�� \�[�� ����@� �ȴ�C� yw�wb� 	F� =����@x}��� �0�) ����I v6�@x}rњ�v6�P���	�� $  	#FF5593FF���� $  	#FFF3F9FF���� $  	#FF000000���� $  	#FF3C77DD���� $  	#FFD9ECFF���� $  	#FF000000���� $  	#FFBCBCBC���� $  	#FFE6E6E6���� $  	#FF707070���� $  	#FFFFFFFF���� $  	#FF333333���� $  	#FF333333���� " d�.���  � �� �� " d�.R��� # z��._�� 
������  .   �� $��19 ��� $��* �.+��  V� ~�X� �� $		 -90Q�.+�A� $
 circle��8��  $��Center=�$��19��8�� $��Center=�$��19��F� $ arrow�������yw�wb� �#y���� ���;,� iۣ�� �@x}{ �W �� ӫ8T �� �IP ��� �,L �q� ӏ�E ��� ~_@ IB� $�= !�� ��; <��  	= �Q� i�A ��� �i�r�� �J�xx�&6L�x�&B��� �o���� �����Q� �U�u�� \�[�� ����@� �ȴ�C� yw�wb� 	$��Center=� .  8�� $��2��$��Center=��� $��Center=�$��0,4,0,0q�$��1����.  . $	��Top=� P�  �@d�	IsChecked$
 trueY�. ��� $ arrow�� � ��= ��@x}��� �0�) ����I v6�@x}rњ�v6�P���	P�  �@J�IsMouseOver . . ��� $ circle��8   � ���� $ circle��8   � ���� $ arrow��8   � ��P�  � �� . . ��� $ circle��8   � ���� $ circle�� � ��$	 1.5���� $ circle��8   � ���� $ arrow��8   � ��P�  � {� .  . ��� $ circle��8 	  � ���� $ circle��8 
  � ���� $ arrow��8   � ���� " d�.���  � �� �� " d�.R��� # z��._�� 
������  .   �� $��19 ��� $��* �.+��  V� ~�X� �� $		 180Q�.+�A� $
 circle��8��  $��Center=�$��19��8�� $��Center=�$��19��F� $ arrow�������yw�wb� �#y���� ���;,� iۣ�� �@x}{ �W �� ӫ8T �� �IP ��� �,L �q� ӏ�E ��� ~_@ IB� $�= !�� ��; <��  	= �Q� i�A ��� �i�r�� �J�xx�&6L�x�&B��� �o���� �����Q� �U�u�� \�[�� ����@� �ȴ�C� yw�wb� 	$��Center=� .  8�� $��2��$��Center=��� $��1��$
��Left=�$��4,0,0,0q���.  . $��Center=� P�  �@d�	IsChecked$
 trueY�. ��� $ arrow�� � ��= ��@x}��� �0�) ����I v6�@x}rњ�v6�P���	P�  �@J�IsMouseOver . . ��� $ circle��8   � ���� $ circle��8   � ���� $ arrow��8   � ��P�  � �� . . ��� $ circle��8   � ���� $ circle�� � ��$	 1.5���� $ circle��8   � ���� $ arrow��8   � ��P�  � {� .  . ��� $ circle��8 	  � ���� $ circle��8 
  � ���� $ arrow��8   � ���� " d�.���  � �� �� " d�.R��� # z��._�� 
������  .   �� $��19 ��� $��* �.+��  V� ~�X� �� $	 90Q�.+�A� $
 circle��8��  $��Center=�$��19��8�� $��Center=�$��19��F� $ arrow�������yw�wb� �#y���� ���;,� iۣ�� �@x}{ �W �� ӫ8T �� �IP ��� �,L �q� ӏ�E ��� ~_@ IB� $�= !�� ��; <��  	= �Q� i�A ��� �i�r�� �J�xx�&6L�x�&B��� �o���� �����Q� �U�u�� \�[�� ����@� �ȴ�C� yw�wb� 	$��Center=� .  8�� $��2��$��Center=��� $��Center=�$��0,4,0,0q�$��1����.  . $	��Top=� P�  �@d�	IsChecked$
 trueY�. ��� $ arrow�� � ��= ��@x}��� �0�) ����I v6�@x}rњ�v6�P���	P�  �@J�IsMouseOver . . ��� $ circle��8   � ���� $ circle��8   � ���� $ arrow��8   � ��P�  � �� . . ��� $ circle��8   � ���� $ circle�� � ��$	 1.5���� $ circle��8   � ���� $ arrow��8   � ��P�  � {� .  . ��� $ circle��8 	  � ���� $ circle��8 
  � ���� $ arrow��8   � ���� " d�.���  � �� �� " d�.R��� # z��._�� 
������  .   �� $��20 ��� $��* ��� $��10 �.+�� .+�A� $
 Ellipse��$��8��$��8��$
 Fill=�$��Center=�$��Center=����� $ Content��$ Content�8   �� $ Content��$��1��$
��Left=�$��4,0,0,0q���.  . $��Center=�A� $
 circle��$��2��8�� $��Center=�$��19��8�� $��Center=�$��19��$y�Hidden=�F� $ arrow��$��2��$��7��$ .7Q�$y�Hidden=�$ Uniform=�$ 0.5,0.5&�$��Center=�$��Center=�8�� $��2������ 8  $
 Data�z��� $	 0Q� P�  �@d�	IsChecked$
 TrueY� �� .���� .��W� $ arrow��$4 .(Path.RenderTransform).(RotateTransform.Angle)�$	 180X�$ 0:0:0.4D�U� $ (FrameworkElement.Height)�$ Ellipse��.\�  $ 0:0:0.4�� 13  $ 0:0:0.5�� 11  $ 0:0:0.6�� 13U� $ (FrameworkElement.Width)�$ Ellipse��.\�  $ 0:0:0.4�� 13  $ 0:0:0.5�� 11  $ 0:0:0.6�� 13  �� .���� .��W� $ arrow��$4 .(Path.RenderTransform).(RotateTransform.Angle)�$ 0X�$ 0:0:0.4D�U� $ (FrameworkElement.Height)�$ Ellipse��.\�  $ 0:0:0.4�� 8  $ 0:0:0.5�� 10  $ 0:0:0.6�� 8U� $ (FrameworkElement.Width)�$ Ellipse��.\�  $ 0:0:0.4�� 8  $ 0:0:0.5�� 10  $ 0:0:0.6�� 8P�  �@J�IsMouseOver . P�  � �� . . ��� $ circle��8   � ���� $ circle�� � ��$	 1.5���� $ circle��8   � ��P�  � {� .  . ��� $ circle��8   � ���� $ circle��8   � ���� .���  � �� �� .R��� ._��� $��0q� . 
���   �$��1��$	! 1 2R��� " 9�.���  � ��# � ����  � ��
 ���� ��  � ��$ Stretch=���  � ��$ Stretch=���  � ��
 ���� ��  � ��$ 1q���  � �� �� " 9�.R��� #��z��#��z��#��z��$" 3�� . ._�]� .+�d� $# 
HeaderSite��#��z��#��z��#��z��$	��Top=�#��z��#��z��8$   #��z��#��z��#��z��#��z��#��z��$��1q�$��0��$��0��#��z��8�� #��z��% �� *
IsExpanded+$& TwoWay=�' �� *TemplatedParent+�� $( ExpanderContentScrollView��$��Bottom=�) X�0.0Q���`� 8*  .1��� $ ActualHeight�$ ContentPGrid���� $	 Tag�' �� *Self+.+�� $+ ContentPGrid��$��6q� �� $��10 ��� $��* �.+��� $��1��$" 2��$��0 0 0 6q�$ .5Q�$��Stretch=�$��Center=����� $ 
HeaderSite��$ Content�8  �� $ 
ExpandSite��$��1��$��Bottom=�|�.  #��z��#��z��$y�Visible=�#��z�� P�  �@9�
IsExpanded .  �� .���� .��U� $ (UIElement.Opacity)�$ 
ExpandSite��.\�  $ 0:0:0.4�� .4  $ 0:0:0.7�� 1U� $ ExpanderContentScrollView��$	 Tag�.\�  $ 0:0:0.4�� 1  $ 0:0:0.5�� .9  $ 0:0:0.6�� 1  �� .���� .��U� $ ExpanderContentScrollView��$	 Tag�.\�  $ 0:0:0.4�� .5  $ 0:0:0.5�� .2  $ 0:0:0.6�� 0U� $ (UIElement.Opacity)�$ 
ExpandSite��.\�  $ 0:0:0.4�� .8  $ 0:0:0.7�� .4P�  �@9�ExpandDirection$ Right=�. ��� $ 
ExpandSite�� � ��$ Right=��� $ 
HeaderSite�� � ��$
 Left=��� $ 
HeaderSite��8   � ��P�  �@9�ExpandDirection$ Up=�. ��� $ 
ExpandSite�� � ��$	 Top=��� $ 
HeaderSite�� � ��$ Bottom=��� $ 
HeaderSite��8   � ��P�  �@9�ExpandDirection$
 Left=�. ��� $ 
ExpandSite�� � ��$
 Left=��� $ 
HeaderSite�� � ��$ Right=��� $ 
HeaderSite��8   � ��P�  � {� .  . ��� # � �� � ���� " 9�.���  � ��# � ����  � ��
 ���� ��  � ��$ Stretch=���  � ��$ Stretch=���  � ��
 ���� ��  � ��$ 1q���  � �� �� " 9�.R��� #��z��#��z��#��z��$" 3�� . ._�]� .+�d� $# 
HeaderSite��#��z��#��z��#��z��$	��Top=�#��z��#��z��8$   #��z��#��z��#��z��#��z��#��z��$��1q�$��0��$��0��#��z��8�� #��z��% �� *
IsExpanded+$& TwoWay=�' �� *TemplatedParent+�� $( ExpanderContentScrollView��$��Bottom=�) X�0.0Q���`� 8*  .1��� $ ActualHeight�$ ContentPGrid���� $	 Tag�' �� *Self+.+�� $+ ContentPGrid��$��6q� �� $��10 ��� $��* �.+��� $��1��$" 2��$��0 0 0 6q�$ .5Q�$��Stretch=�$��Center=����� $ 
HeaderSite��$ Content�8  �� $ 
ExpandSite��$��1��$��Bottom=�|�.  #��z��#��z��$y�Visible=�#��z�� P�  �@9�
IsExpanded .  �� .���� .��U� $ (UIElement.Opacity)�$ 
ExpandSite��.\�  $ 0:0:0.4�� .4  $ 0:0:0.7�� 1U� $ ExpanderContentScrollView��$	 Tag�.\�  $ 0:0:0.4�� 1  $ 0:0:0.5�� .9  $ 0:0:0.6�� 1  �� .���� .��U� $ ExpanderContentScrollView��$	 Tag�.\�  $ 0:0:0.4�� .5  $ 0:0:0.5�� .2  $ 0:0:0.6�� 0U� $ (UIElement.Opacity)�$ 
ExpandSite��.\�  $ 0:0:0.4�� .8  $ 0:0:0.7�� .4P�  �@9�ExpandDirection$ Right=�. ��� $ 
ExpandSite�� � ��$ Right=��� $ 
HeaderSite�� � ��$
 Left=��� $ 
HeaderSite��8   � ��P�  �@9�ExpandDirection$ Up=�. ��� $ 
ExpandSite�� � ��$	 Top=��� $ 
HeaderSite�� � ��$ Bottom=��� $ 
HeaderSite��8   � ��P�  �@9�ExpandDirection$
 Left=�. ��� $ 
ExpandSite�� � ��$
 Left=��� $ 
HeaderSite�� � ��$ Right=��� $ 
HeaderSite��8   � ��P�  � {� .  . ��� # � �� � ��