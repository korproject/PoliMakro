   M S B A M L   `   `   `  ���� E  APoli.Makro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Poli.Makro.ConvertersPoli.Makro.Converters  Q MSystem.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089;,clr-namespace:System.Xml;assembly=System.Xml
System.Xml G(clr-namespace:Poli.Makro.Converters.JSONPoli.Makro.Converters.JSON  W SNewtonsoft.Json, Version=11.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeedT;clr-namespace:Newtonsoft.Json.Linq;assembly=Newtonsoft.JsonNewtonsoft.Json.Linq K*clr-namespace:Poli.Makro.TemplateSelectorsPoli.Makro.TemplateSelectors  7    1Poli.Makro.States.JSONXMLXAMLRSS.JXXR_View_Editor   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :
converters#clr-namespace:Poli.Makro.Converters     =xmll,clr-namespace:System.Xml;assembly=System.Xml     DvalueConverters(clr-namespace:Poli.Makro.Converters.JSON     Mjlinq;clr-namespace:Newtonsoft.Json.Linq;assembly=Newtonsoft.Json     HtemplateSelectors*clr-namespace:Poli.Makro.TemplateSelectors       � 	Resources  9  3Poli.Makro.Converters.ClipboardInputActionConverter !  ClipboardInputActionConverter6   0Poli.Makro.Converters.MultipleParameterConverter  MultipleParameterConverter  RecordsDataTemplate � ColumnDefinitions � RowDefinitions �� Orientation �� Stretch  BlueGrey600  HashTag �� Source �� Path  BlueGrey700  Date �� 	Converter 
 Binary �� StringFormat  BlueGrey500 	 TextAlignLeftThin 
 ClickableTextButton  StarToggleButton  HistoryComboBoxDataempalte	 �� Color  xmlValueBrush  xmAttributeBrush  xmlTagBrush  xmlMarkBrush  xmlValue  attributeTemplate
 �� 
TargetType �� Property �� Value  treeViewTemplate �� ItemsSource �� XPath ��Name �� Triggers �� Binding �� Value  System.Xml.XmlNodeType �� 
TargetName7   1Poli.Makro.Converters.JSON.MethodToValueConverter  MethodToValueConverterF  @Poli.Makro.Converters.JSON.ComplexPropertyMethodToValueConverter ) %ComplexPropertyMethodToValueConverter0   *Poli.Makro.Converters.JSON.JValueConverter  JValueConverter>   8Poli.Makro.Converters.JSON.JPropertyTypeToColorConverter ! JPropertyTypeToColorConverter;   5Poli.Makro.Converters.JSON.JValueTypeToColorConverter  JValueTypeToColorConverter6	   0Poli.Makro.Converters.JSON.JArrayLengthConverter  JArrayLengthConverter �� DataType!
  Newtonsoft.Json.Linq.JArray �� ConverterParameter �� Padding J� Opacity  ArrayPropertyTemplate$  Newtonsoft.Json.Linq.JProperty �� Mode  ObjectPropertyTemplate  PrimitivePropertyTemplate"  Newtonsoft.Json.Linq.JObject'  !Newtonsoft.Json.Linq.JConstructor  Newtonsoft.Json.Linq.JRaw@   :Poli.Makro.TemplateSelectors.JPropertyDataTemplateSelector ! JPropertyDataTemplateSelector   ArrayPropertyTemplate   ObjectPropertyTemplate    PrimitivePropertyTemplate!  Newtonsoft.Json.Linq.JValue��%W  &	        &	      &	 
     7  7  7  7  7  7  7  7   7  7  7  7  7  7  7 	 7  7 
 7  7 
 7  7 
 7  7  &	 �    &	 [    &	 n    &	 �    &	 �    &	 �    &	 �    7  7  7  7  'Q� X    &	 �    7  7  7  7  7  &	 �	    &	 �	    &	 
    &	 
    &	 
    &	 
    (�� 
    *,
 +)7  7  &	 �
    7  7  &	 �    7  &	 k    7  7  (�� #    *, +)7  (�� �    *, +)7  (�� �    *, +)7  &	     7  7  7  (�� '    *, +)7  7      �� .R�� $��Stretch=� �� $��* ��� $��* � �� $
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
 Date��� $��10 0 0 0q����� $ Count�$ ({0})���� $	 #64B5F6���� $	 #E57373���� $	 #1E88E5���� $	 #64B5F6���� $	 #E3F2FD���� .R��� $ 
Horizontal=�$��3,0,0,0q�$��Center=�.+��� 8��  ���� $
 Name��� $��="��8�� �� 8�� ���� $ Value��� $��"��8�� �� "
 Q�.���  �@Q�
IsExpanded . ��  �� $ child::node()��.R��� $ 
Horizontal=�$��3,0,0,0q�$��Center=�.+��� $ startTag��$��<��$��Center=�8��  �� $ xmlTag��$��0q�$��Center=�8�� ���� $
 Name��� 8�� $��Center=����� $ 
Attributes����� .R��� $ 
Horizontal=��� $ endTag��$��>��$��Center=�8��  ��  �� *
NodeType+  Text=�.a��� $ xmlTag�� �� *	InnerText+ � ���� 8  $ xmlTag�� � ���� $ startTag�� � y�$ 	Collapsed=��� $ endTag�� � y�$ 	Collapsed=��� $ False�� �� $ HasChildNodes�.a��� $ endTag�� � ��$ />��          	  �� " 
  �� 8   $ Children��.R��� $ 
Horizontal=�$��1q�.+��� $��array��
����������#a40000$ 
3, 0, 3, 1q�$	 0.4Q�$��0,0,5,0q��� ���#a40000���� 8  �� "   �� 8   $ Children��.R��� $ 
Horizontal=�$��1q�.+��� ���� $
 Name�$ OneWay=��� $	�� : ���� $��array��
����������#a40000$ 
3, 0, 3, 1q�$	 0.4Q�$��0,0,5,0q��� ���#a40000���� 8  �� "   �� 8   $ Children��.R��� $ 
Horizontal=�$��1q�.+��� ���� $
 Name�$ OneWay=��� $	�� : ���� $	��{ }�����#729fcf�� "  .R��� $ 
Horizontal=�$��1q�.+��� ���� $
 Name�$ OneWay=��� $	�� : ���� $��  ���� -   $	��300��$
��Wrap=����� $ Value�8   ���� 8  �� "   �� 8   $ Children��.R��� $ 
Horizontal=�$��1q�.+��� $�� ���� $	��{ }�����#729fcf�� "   �� 8   $ Children��.R��� $��Constructor���� "   �� 8   $ Children��.R��� $	��Raw��  8   8  8  �� "  .R��� -   $	��300��$
��Wrap=����� 8   ���� 8  .��� .+��� -    ��Name$ 
TabControl��  CustomTabControl#���  $��Stretch=�.@��� $��JSON Gör-Düzenle��  CustomTabItemStyle#��[ 
 � Tag ��    	Hierarchy# [  $
 Data�.���  �� $��* ��� $��10 ��� $��* � �� $��50 ��� $��* ��� $��* �.+��� $��1��$��2��$��1��$��5��$��0 5 0 5q�$��Stretch=�$ .1Q��� $��Hidden=�$��Hidden=�$��3��.���� $ 
Horizontal=�.+��� -    ! DefaultButtonStyle#��[!  � ToolTip$ Dosyadan Oku��.���� $ 
Horizontal=�.+�F� $��15��$ Uniform=� " 
BlueGrey50#��[" ����  # File# [# $
 Data��� -   #��[! $ Panodan Oku��.���� $ 
Horizontal=�.+�F� $��15��$ Uniform=�#��[" ����  $ 	Clipboard# [$ $
 Data��� -   #��[! $ 
Webden Oku��.���� $ 
Horizontal=�.+�F� $��15��$ Uniform=�#��[" ����  % Web# [% $
 Data��� $��1��$��10q� & BlueGrey400#��[& $��Stretch=��� -   #��[! $ Farklı Kaydet��.���� $ 
Horizontal=�.+�F� $��15��$ Uniform=�#��[" ����  
' SaveAs# [' $
 Data��� -   #��[! $ PAnoya Kopyala��.���� $ 
Horizontal=�.+�F� $��15��$ Uniform=�#��[" ����  ( Copy# [( $
 Data��� $��1��$��10q�#��[& $��Stretch=��� -	   #��[! $ İçerikleri Formatla��.���� $ 
Horizontal=�.+�F� $��15��$ Uniform=�#��[" ����  ) OkValue# [) $
 Data�d� -
    * ExpandCollapseToggleButton#��[* $ 10��$/ )Ağaç Görünümünü Daralt - Genişlet��{���  �� ElementName$ jsonTree��$ HasItems��� -   #��[! $ İçerikleri Formatla��.���� $ 
Horizontal=�.+�F� $��17��$ Uniform=�#��[" ����  + Cleaning# [+ $
 Data�R� -   $��jsonTree��$��1��$��2��$��5q�$" JSON Ağacında İçerik Yok�� , CustomTreeView#��� ,  - TreeViewItemStyle1#��[-   �� IsTextSearchEnabled  . #��[   ! �� Opacity��%J   (��       * SystemColors.HighlightBrushKey+)�� $	 #FFFFFF��$! .1Q��� -   " ��Name$" jsonRich��$��2��$��1��$��2��$��5q�$��1q�"# �� VerticalScrollBarVisibility$
# Auto=�$$ �� HorizontalScrollBarVisibility$
$ Auto=�#��[  . BlueGrey100#��[. 
������ �� $��XML Gör-Düzenle��#��[  �� # [  $
 Data�.���  �� $��* ��� $��10 ��� $��* � �� $��50 ��� $��* ��� $��* �.+��� $��1��$��2��$��1��$��5��$��0 5 0 5q�$��Stretch=�$ .1Q��� $��Hidden=�$��Hidden=�$��3��.���� $ 
Horizontal=�.+��� -   #��[! $ Dosyadan Oku��.���� $ 
Horizontal=�.+�F� $��15��$ Uniform=�#��[" ���� # [# $
 Data��� -   #��[! $ Panodan Oku��.���� $ 
Horizontal=�.+�F� $��15��$ Uniform=�#��[" ���� # [$ $
 Data��� -   #��[! $ 
Webden Oku��.���� $ 
Horizontal=�.+�F� $��15��$ Uniform=�#��[" ���� # [% $
 Data��� $��1��$��10q�#��[& $��Stretch=��� -   #��[! $ Farklı Kaydet��.���� $ 
Horizontal=�.+�F� $��15��$ Uniform=�#��[" ���� # [' $
 Data��� -   #��[! $ PAnoya Kopyala��.���� $ 
Horizontal=�.+�F� $��15��$ Uniform=�#��[" ���� # [( $
 Data��� $��1��$��10q�#��[& $��Stretch=��� -   #��[! $ İçerikleri Formatla��.���� $ 
Horizontal=�.+�F� $��15��$ Uniform=�#��[" ���� # [) $
 Data�d� -   #��[* $ 10��$/ )Ağaç Görünümünü Daralt - Genişlet��{��� $ xmlTree��$ HasItems��� -   #��[! $ İçerikleri Formatla��.���� $ 
Horizontal=�.+�F� $��17��$ Uniform=�#��[" ���� # [+ $
 Data�R� -   $��xmlTree��$��1��$��2��$��5q�$! XML Ağacında İçerik Yok��#��[ #��� , #��[-   ��%J   (��       * SystemColors.HighlightBrushKey+)�� $	 #FFFFFF��$! .1Q��� -   $" xmlRich��$��2��$��1��$��2��$��5q�$��1q�$
# Auto=�$
$ Auto=�#��[ #��[. 
������ �� $��XAML Gör-Düzenle��#��[ .��� �� $��RSS Gör-Düzenle��#��[ .��� �� $��Seçenekler��#��[ .��� .+�� % � Orientation$% 
Horizontal=�.+��� $ ��Klavye - Fare Aksiyonları��#��[ $��Center=�$	��250�� / CustomGroupBox#��� / .���� .+��� $��CTRL + X (Metin)�� 0 CustomCheckBox#��� 0 $��Center=�$��4q�$2 ,Bu aksiyon sadece metin için tanımlıdır.��& d� 	IsChecked& �� $
 KeyX�$ TwoWay=����� $ SetKey���`� ' `� 	Converter#' [ .1��� $
 Keyx��� $ 	IsChecked�( �� RelativeSource( �� *Self+�� $��CTRL + C (Metin)��#��� 0 $��Center=�$��4q�$
 Buda��& �� $
 KeyC�$ TwoWay=����� $ SetKey���`� #' [ .1��� $
 Keyc��� $ 	IsChecked�( �� *Self+�� $��CTRL + V (Metin)��#��� 0 $��Center=�$��4q�$ Ve buda.��& �� $
 KeyV�$ TwoWay=����� $ SetKey���`� #' [ .1��� $
 Keyv��� $ 	IsChecked�( �� *Self+�� $��1��$
��Left=� 1 BlueGrey300#��[1 $ .5Q�$	��130���� $(��"CTRL + LShift (Metin Birleştirme)��#��� 0 $��Center=�$��4q�$ Ve buda.��& �� $ 	KeyLShift�$ TwoWay=����� $ SetKey���`� #' [ .1��� $ 	Keylshift��� $ 	IsChecked�( �� *Self+�� $��1��$
��Left=�#��[1 $ .5Q�$	��130���� $��Fare R - L Tık (Metin)��#��� 0 $��Center=�$��4q�$( "Fare ile Metinsel içeriği izler.��& �� $ MouseRLText�$ TwoWay=����� $ 	SetButton���`� #' [ .1��� $ 
Mouseltext��� $ 	IsChecked�( �� *Self+�� $��Fare R - L Tık (Görsel)��#��� 0 $��Center=�$��4q�$' !Fare ile Görsel içeriği izler.��& �� $ MouseRLImage�$ TwoWay=����� $ 	SetButton���`� #' [ .1��� $ Mouselimage��� $ 	IsChecked�( �� *Self+