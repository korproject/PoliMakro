   M S B A M L   `   `   `  ���� E  APoli.Makro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Poli.Makro.ConvertersPoli.Makro.Converters  R NSystem.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089>.clr-namespace:System.Data;assembly=System.DataSystem.Data 2    ,Poli.Makro.States.Clipboard.ClipboardRecords   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :
converters#clr-namespace:Poli.Makro.Converters     ?data.clr-namespace:System.Data;assembly=System.Data       � 	Resources  9  3Poli.Makro.Converters.ClipboardInputActionConverter !  ClipboardInputActionConverter6   0Poli.Makro.Converters.MultipleParameterConverter  MultipleParameterConverter  RecordsDataTemplate � ColumnDefinitions � RowDefinitions �� Orientation �� Stretch  BlueGrey600  HashTag �� Source �� Path  BlueGrey700  Date �� 	Converter 
 Binary �� StringFormat  BlueGrey500 	 TextAlignLeftThin 
 ClickableTextButton  StarToggleButton  HistoryComboBoxDataempalte��%�  &	        &	      &	 
     7  7  7  7  7  7  7  7   7  7  7  7  7  7  7 	 7  7 
 7  7 
 7  7 
 7  7  &	 �        �� .R�� $��Stretch=� �� $��* ��� $��* � �� $
��Auto ��� $��* �.+�� $��2��$��10q� �� $
��Auto ��� $��* � �� $
��Auto ��� $
��Auto �.+��� $ Vertical=�$��2��.+��� $ 
Horizontal=�$��0q�$��Center=�.+��� $ 
Horizontal=�.+�F� $ Uniform=�$��15��8��  ���� 8  $
 Data��� $��12(�$��Center=�$��5 0 0 0q�8�� ���� $ OrderNumber��� $ 
Horizontal=�$��20 0 0 0q�.+�F� $ Uniform=�$��15��8�� ���� 8  $
 Data��� $��12(�$��Center=�$��5 0 0 0q�8�� ���� $ DateTime��� $ 
Horizontal=�$��20 0 0 0q�.+�F� $ Uniform=�$��15��8�� ���� $ Action�8  �� $��12(�$��Center=�$��5 0 0 0q�8�� ���� $ Action��� $ 
Horizontal=�$��20 0 0 0q�.+�F� $ Uniform=�$��15��8��	 ���� 8 
 $
 Data��� $��12(�$��Center=�$��5 0 0 0q�8�� ���� $
 Size�$ {0} Kb���� 8�� $��1��$��Bottom=�$��0 5 0 0q��� $ 
Horizontal=�$��1��$��Center=�$��	0 10 0 10q�.+��� $ 
Horizontal=�.+��� $��Uniform=�$��30������ $ ContentImage�F� $ Uniform=�$��15��8�� $��Center=����� 8  $
 Data��� $ Vertical=�$��10 0 0 0q�.+��� $	��600��$��CharacterEllipsis=�$��SemiBold"�8�� ���� $ ContentTextPreview��� $ 
Horizontal=�$��1��$��1��$��Right=�$��0 0 20 0q�.+��� $	��Sil��8�� 8�� �� $��Kopyala��8�� 8�� �� $��Kaydet��8�� 8�� d� 8�� $��50 0 0 0q��� .R��� $ 
Horizontal=�$��5q�.+��� ���� $
 Date��� $��10 0 0 0q����� $ Count�$ ({0})��.��� $��Stretch=�.+��� -   	 ��Name$	 
TabControl��  CustomTabControl#���  $��Stretch=�.@��� $��Şuanki Yakalamalar��  CustomTabItemStyle#��[ .���  �� $��* ��� $��* � �� $��20 ��� $��* ��� $��* �.+��� $ 
Horizontal=�$��10 0 0 0q�.+��� #��[ $
��Auto������ $ ContentCount�$ Öğe Sayısı:{0}��
 �� Mode$
 OneWay=��� -    ��Name$ Records��$��2��$��1��$��2��  CustomListView#��[  ! ClipboardRecordsListVıewItem#��[ $��Stretch=�$��Stretch=�#��[ 
 � Tag �� $	 Tag�$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��Yakalama Geçmişi��#��[ .���  �� $��* ��� $��* � �� $��20 ��� $��* ��� $��* �.+��� $ 
Horizontal=�$��10 0 0 0q�.+��� -    ��Name$ HistoryComboBox��  CustomComboBox#���  #��[ �� -   $ HistoryofRecords��$��2��$��1��$��2��#��[ #��[ $��Stretch=�$��Stretch=�#��[  �� $	 Tag�$
 TwoWay=�$ PropertyChanged=��� $��Seçenekler��#��[ .��� .+��  � Orientation$ 
Horizontal=�.+��� $ ��Klavye - Fare Aksiyonları��#��[ $��Center=�$	��250��  CustomGroupBox#���  .���� .+��� $��CTRL + X (Metin)�� 	 White#��[   CustomCheckBox#���  $��Center=�$��4q�$2 ,Bu aksiyon sadece metin için tanımlıdır.�� d� 	IsChecked �� $
 KeyX�$
 TwoWay=����� $ SetKey���`�  `� 	Converter# [ .1��� $
 Keyx��� $ 	IsChecked� �� RelativeSource �� *Self+�� $��CTRL + C (Metin)��#��[ #���  $��Center=�$��4q�$
 Buda�� �� $
 KeyC�$
 TwoWay=����� $ SetKey���`� # [ .1��� $
 Keyc��� $ 	IsChecked� �� *Self+�� $��CTRL + V (Metin)��#��[ #���  $��Center=�$��4q�$ Ve buda.�� �� $
 KeyV�$
 TwoWay=����� $ SetKey���`� # [ .1��� $
 Keyv��� $ 	IsChecked� �� *Self+�� $��1��$
��Left=�  BlueGrey300#��[  J� Opacity$ .5Q�$	��130���� $(��"CTRL + LShift (Metin Birleştirme)��#��[ #���  $��Center=�$��4q�$ Ve buda.�� �� $ 	KeyLShift�$
 TwoWay=����� $ SetKey���`� # [ .1��� $ 	Keylshift��� $ 	IsChecked� �� *Self+�� $��1��$
��Left=�#��[ $ .5Q�$	��130���� $��Fare R - L Tık (Metin)��#��[ #���  $��Center=�$��4q�$( "Fare ile Metinsel içeriği izler.�� �� $ MouseRLText�$
 TwoWay=����� $ 	SetButton���`� # [ .1��� $ 
Mouseltext��� $ 	IsChecked� �� *Self+�� $��Fare R - L Tık (Görsel)��#��[ #���  $��Center=�$��4q�$' !Fare ile Görsel içeriği izler.�� �� $ MouseRLImage�$
 TwoWay=����� $ 	SetButton���`� # [ .1��� $ Mouselimage��� $ 	IsChecked� �� *Self+