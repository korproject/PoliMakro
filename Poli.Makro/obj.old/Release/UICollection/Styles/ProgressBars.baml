   M S B A M L   `   `   `  ���� E  APoli.Makro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Poli.Makro.UICollection.StylesPoli.Makro.UICollection.Styles  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ProgressBar.Progress  �� Color  ProgressBar.Background  ProgressBar.Border  CustomProgressBar �� 
TargetType �� Property �� Value �� 
TargetType �Name'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard	 g� RepeatBehavior
 �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8  2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value ��Name J� RenderTransformOrigin �� Triggers P� Property P� Value �� 
TargetName �� Angle�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     6local,clr-namespace:Poli.Makro.UICollection.Styles  %J  &	        &	      &	 *     &	 ?     7   7  7  �� $  	#FF06B025���� $  	#FFE6E6E6���� $  	#FFBCBCBC���� " �.���  � ��8   ��  � ��8  ��  � ��8  ��  � ��$ 1q���  � �� �� " �.R�� $ TemplateRoot��   CommonStates��.   Determinate��  Indeterminate��. �� $	 Forever��.��U� $V
 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ 	Animation��.\�  $ 0��$
 0.25Q�  $ 0:0:1��$
 0.25Q�  $ 0:0:2��$
 0.25Q�*� $'
 !(UIElement.RenderTransformOrigin)�$ 	Animation��.'�  $ 0��$ -0.5,0.5&�  $ 0:0:1��$ 0.5,0.5&�  $ 0:0:2��$ 1.5,0.5&�.+��� #��z��#��z��#��z���� $ 
PART_Track��� $ PART_Indicator��}�. $
��Left=�.+��� $ 	Indicator��#��z���� $ 	Animation��#��z��$ 0.5,0.5&�z�V� .~��� �� �� T�  P�  �@�Orientation$ Vertical=�. ��� $ TemplateRoot�� �@�LayoutTransform �� $	 -90Q�P�  �@�IsIndeterminate . . ��� $ 	Indicator�� � y�$ 	Collapsed=�