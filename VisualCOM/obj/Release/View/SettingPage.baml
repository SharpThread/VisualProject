   M S B A M L   `   `   `  ���� D  @VisualCOM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:VisualCOM.ValueConvertVisualCOM.ValueConvert  /clr-namespace:VisualCOM.ViewVisualCOM.View  /clr-namespace:VisualCOM.RuleVisualCOM.Rule  9!clr-namespace:VisualCOM.ViewModelVisualCOM.ViewModel       VisualCOM.View.SettingPage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.63.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aaR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     2c$clr-namespace:VisualCOM.ValueConvert     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:VisualCOM.View     _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  'ruleclr-namespace:VisualCOM.Rule  *vm!clr-namespace:VisualCOM.ViewModel    � DataContext  .   (VisualCOM.ViewModel.SettingPageViewModel   � 	Resources '   !VisualCOM.Rule.StringToDoubleRule   StringToDoubleRule2   ,VisualCOM.ValueConvert.ForgroundThemeConvert  ForgroundThemeConvert��%   &	        &	          .���� $
��Left=�.+�� .+��� $	��230��$	��320��$��	10,22,0,0q�
�������$��18(�$��串口配置��.����  �� Orientation$ Vertical=�.+�� $��0,5,0,5q�.+��� $��80��$��Center=�$��端口���� $	��100������ *	PortNames+ �� SelectedValue �� *
PortName+� $��0,0,0,5q�.+��� $��80��$��Center=�$��	波特率���� $	��100��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ BaudRate��   HintOpacity$	 .26Q� �� 
IsEditable . ���� *	BaudRates+ �� Text ��  �� Path$ BaudRate�	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� ValidationRules
 &    VisualCOM.Rule.CheckBaudRateRule  � $��0,0,0,5q�.+��� $��80��$��Center=�$��	数据位���� $	��100������ *
DataBits+ �� *	DataBit+� $��0,0,0,5q�.+��� $��80��$��Center=�$��	校验位���� $	��100������ *	Paritys+ �� *Parity+� .+��� $��80��$��Center=�$��	停止位���� $	��100������ *
StopBits+ �� *	StopBit+�� $��30��$��10q�$��保存参数配置�� � Cursor$
 Hand��
������� # MaterialDesignFlatLightBgButton#��[ ���� *SaveArgCommand+�� $	��240��$	��320��$��8,22,0,0q�
�������$��18(�$��绘图配置��.���� $ Vertical=�.+�� $��0,5,0,5q�.+��� $��70��$��Center=�$��通道���� $	��100������ *ChannelNames+ �� *ChannelName+� $��0,0,0,5q�.+��� $��70��$��Center=�$��类型���� $	��100������ *
ChartTypes+ �� *	ChartType+� $��0,0,0,5q� /   )VisualCOM.ValueConvert.CustomStyleConvert  CustomStyleConvert��%   &	         .+��� $��65��$��Center=�$��样式��	� $��5,0,0,0q�$��默认�� 	� 	GroupName$ 1�� d� 	IsChecked �� *
IsCustom+	� $��5,0,0,0q�$��	自定义��$ 1�� �� *
IsCustom+ �� 	Converter# [ �� $��30��$��10q�$��添加绘图��
�������#��[ ���� *AddChartArgsCommand+�� $��30��$��10q�$��保存参数配置��
�������#��[ ���� *SaveChartArgsCommand+�� $	��230��$	��320��$��8,22,0,0q� " MaterialDesignFilledTabControl#��[  0   *VisualCOM.ValueConvert.StringDoubleConvert  StringDoubleConvert��%   &	       &	          .@��� $��18(�$��	点样式��.���� 
�������.+�� $��5,10,0,5q�.+��� $��70��$��Center=�$��16(�$��大小���� $	��100��{��� *
IsCustom+# [ .������ $ 	PointSize�$	 PropertyChanged=�
   .��� $��5,10,0,5q�.+��� $��70��$��Center=�$��16(�$��形状���� $	��100��{��� *
IsCustom+# [ ���� *PointShapes+ �� *
PointShape+�� $��18(�
���   �$��	线样式��.���� 
�������.+�� $��5,10,0,5q�.+��� $��70��$��Center=�$��16(�$��粗细���� $	��100��{��� *
IsCustom+# [ .������ $ LineSize�$	 PropertyChanged=�
   .��� $��5,10,0,5q�.+��� $��70��$��Center=�$��16(�$��外观���� $	��100��{��� *
IsCustom+# [ ���� *
LineShapes+ �� *	LineShape+�� $	��230��$	��320��$��8,22,0,0q�
�������$��18(�$��公共样式��.����  ��%   &	         .+�� $��0,5,0,5q�.+��� $��75��$��Center=�$��颜色���� $	��100��{��� *
IsCustom+# [ ���� *ChartColors+ �� *
ChartColor+� $��0,5,0,5q�.+��� $��75��$��Center=�$��主题风格���� $	��100��{��� *
IsCustom+# [ ���� *ChartStyles+ �� *
ChartStyle+� $��Center=�.+�&   System.Windows.Controls.DataGrid  $	��590��$	��240��$��0,30,0,0q�   AutoGenerateColumns .  
�������   CanUserAddRows .  ���� *ChartSource+   Columns 0	  *System.Windows.Controls.DataGridTextColumn	  ,
  &System.Windows.Controls.DataGridColumn 
  Width5  /System.Windows.Controls.DataGridLengthConverter$ *  
  Header$ 通道�� 
  
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *ChannelName+	  $ * $ 类型�� .  �� *	ChartType+	  $ * $ 	点大小�� .  �� *	PointSize+	  $ * $ 	点形状�� .  �� *
PointShape+	  $ * $ 	线粗细�� .  �� *
LineSize+	  $ * $ 	线外观�� .  �� *	LineShape+	  $ * $ 颜色�� .  �� *Color+	  $ * $ 主题风格�� .  �� *Style+