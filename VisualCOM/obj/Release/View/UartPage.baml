   M S B A M L   `   `   `  ���� D  @VisualCOM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:VisualCOM.ValueConvertVisualCOM.ValueConvert  /clr-namespace:VisualCOM.ViewVisualCOM.View  9!clr-namespace:VisualCOM.ViewModelVisualCOM.ViewModel      VisualCOM.View.UartPage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.63.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aaR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     2c$clr-namespace:VisualCOM.ValueConvert     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:VisualCOM.View     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0vm!clr-namespace:VisualCOM.ViewModel       � DataContext  +   %VisualCOM.ViewModel.UartPageViewModel   � 	Resources ,   &VisualCOM.ValueConvert.EncodingConvert   EncodingConvert,   &VisualCOM.ValueConvert.ColorConverters  ColorConverters-   'VisualCOM.ValueConvert.ComSwitchConvert  ComSwitchConvert(   "VisualCOM.ValueConvert.DataConvert  DataConvert  
text_style �� 
TargetType �� Property �� Value  group_Box_style��%�   &	        &	      &	 
     &	      &	      &	 7             �� " ��.���  � ��$ 16(��� " �����  � ��
 �����.��� $��5q�
������  � ColumnDefinitions �� $��7* ��� $��3* �.+��� $��1��$��5q�.+��� $	��155�� � Cursor$
 Hand��$��18(�$��接收区设置��#��[ .���� .+�� $
��auto��$��0,2,0,0q�.+�	� $��0,0,0,0q�$��ASCII�� 	� 	GroupName$ Receive�� d� 	IsChecked �� *ReceiveEncoding+	� $��45,0,0,0q�$	��Hex��$ Receive�� �� *ReceiveEncoding+	 �� 	Converter#	 [  � $��0,10,0,0q�.+��� $��停止接收������ *StopReceiveCommand+ �� *StopReceive+�� $��20,0,0,0q�$��日志模式�� �� *
AppendTime+� $��0,15,0,0q�.+��� $��保存到文件��
��������� $��10,0,0,0q�$��清空接收区��$
 Hand��
����������� *ClearReceiveCommand+�� $	��140��$��0,20,0,0q�$��18(�$��发送区设置��#��[ .���� .+�� $��0,2,0,0q�.+�	� $��ASCII��$
 Send�� �� *SendEncoding+	� $��45,0,0,0q�$	��Hex��$
 Send�� �� *SendEncoding+#	 [  � $��0,5,0,0q�.+��� $��自动换行�� �� *	AddLine+�� $��18,0,0,0q�$��定时发送�� �� *
AutoSend+� $��0,7,0,0q�.+��� $��周期:���� $��70������ *Time+�� $��ms���� $��80��$��0,30,0,0q�$��	控制区��#��[ .���� $��Center=�.+�� .+��� $��90��$��40��$��5,0,0,0q�$
 Hand��
����������� *OpenComCommand+���� *IsOpen+#	 [ �� $��30,0,0,0q�$��Center=�$��状   态：���� $��30��$��30��
 �� CornerRadius$
 30������ *IsOpen+#	 [ �� $	��120��$��0,22,0,0q�$��	发送区��#��[ .���� $��Center=�.+�� $��Center=�.+��� $	��100��$��40��$��发送数据��
����������� *SendCommand+�� $	��100��$��40��$��15,0,0,0q�$��清除发送区��
����������� *ClearSendCommand+�� $��35��$��0,19,0,0q�
���   �$��1q�$
 4��._�� $��Center=�.+��� $��Center=�$��S:���� $��40��$��Center=����� *	SendCount+#	 [ �� $��35��$��5,0,5,0q�
�������$��1,0,0,0q��� $��Center=�$��R:���� $��40��$��Center=����� *ReceiveCount+#	 [ �� $��35��$��5,0,5,0q�
�������$��1,0,0,0q�� $��0��$��0,0,0,0q�
������  � RowDefinitions �� $��7* ��� $��3* �.+��� $��0��$��0,8,0,0q�$��数据接收显示区��#��[ .���� $
��Left=�$��16(����#3b76ee$ �� HorizontalScrollBarVisibility$
 Auto=� �� 
IsReadOnly .  �� TextWrapping$
 Wrap=���Z� ���� *ReceiveContent+�� $��1��$��数据发送区��#��[ .���� $	��174��$	��Top=� �� AcceptsReturn . $��16(� ) %MaterialDesignComboBoxEditableTextBox#��[ $
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=����� *SendContent+