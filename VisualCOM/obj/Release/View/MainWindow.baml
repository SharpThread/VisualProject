   M S B A M L   `   `   `  ���� D  @VisualCOM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:VisualCOM.ValueConvertVisualCOM.ValueConvert  /clr-namespace:VisualCOM.ViewVisualCOM.View  9!clr-namespace:VisualCOM.ViewModelVisualCOM.ViewModel      View.VisualCOM.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.63.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aaR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     2c$clr-namespace:VisualCOM.ValueConvert     @d2http://schemas.microsoft.com/expression/blend/2008     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  (localclr-namespace:VisualCOM.View  _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  *vm!clr-namespace:VisualCOM.ViewModel  $
��1220��$	��740��  � AllowsTransparency  . 
������  � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � 	Resources -   'VisualCOM.ValueConvert.LeftThemeConvert   LeftThemeConvert.   (VisualCOM.ValueConvert.RightThemeConvert  RightThemeConvert2   ,VisualCOM.ValueConvert.ForgroundThemeConvert  ForgroundThemeConvert-   'VisualCOM.ValueConvert.IconThemeConvert  IconThemeConvert0   *VisualCOM.ValueConvert.ToolTipThemeConvert  ToolTipThemeConvert�� %K   &	        &	      &	 
     &	      &	                ��  �� DataType+   %VisualCOM.ViewModel.HomePageViewModel"  .R�   VisualCOM.View.HomePage  �� +   %VisualCOM.ViewModel.MorePageViewModel"  .R�	   VisualCOM.View.MorePage	  �� .
   (VisualCOM.ViewModel.SettingPageViewModel" 
 .R�    VisualCOM.View.SettingPage  �� +   %VisualCOM.ViewModel.UartPageViewModel"  .R�   VisualCOM.View.UartPage  �� -   'VisualCOM.ViewModel.ChartsPageViewModel"  .R�   VisualCOM.View.ChartsPage   � DataContext '   !VisualCOM.ViewModel.MainViewModel  .���� -   
������ ._��  � ColumnDefinitions �� $��2* ��� $��8* �.+��� $��0������ *	IsTheme+ �� 	Converter# [  ._��� $��Center=�	 �� Orientation$	 Vertical=�.+��� $��	0,35,0,35q�$��Center=� $  MaterialDesignHeadline4TextBlock#��[ $��
Visual COM������ *	IsTheme+# [ �� $	��210��$��75��$��0,5,0,0q�$
��Home��
 � Cursor$

 Hand��
������� # MaterialDesignRaisedLightButton#��[ ���� *OpenCommand+.���� $	 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  $��30��$��30��$��Center=�   Kind$ 	Microsoft=��� $��Center=�$��16(�$
��Home���� $��75��$��0,10,0,0q�$
��Uart��$

 Hand��
����������� *OpenCommand+.���� $	 
Horizontal=�.+�  $��30��$��30��$��Center=�$ 
SerialPort=��� $��Center=�$��16(�$
��Uart���� $��75��$��0,10,0,0q�$��Charts��$

 Hand��
����������� *OpenCommand+.���� $	 
Horizontal=�.+�  $��30��$��30��$��Center=�$ ChartAreasplineVariant=��� $��Center=�$��16(�$��Charts���� $��75��$��0,10,0,0q�$��Setting��$

 Hand��
����������� *OpenCommand+.���� $	 
Horizontal=�.+�  $��30��$��30��$��Center=�$	 Cog=��� $��Center=�$��16(�$��Setting���� $��75��$��0,10,0,0q�$
��More��
����������� *OpenCommand+.���� $	 
Horizontal=�.+�  $��30��$��30��$��Center=�$ Information=��� $��Center=�$��16(�$
��More���� $��1������ *	IsTheme+# [ ._��  � RowDefinitions �� $
��1.5* ��� $	��10* �.+��� $��0��$��Right=�$	��Top=�$	 
Horizontal=�.+��� $��60��$��60�� % !MaterialDesignFlatSecondaryButton#��[ ���� *ThemeToggleCommand+���� *	IsTheme+# [  � ToolTip �� *	IsTheme+# [ ��  $��30��$��30�� �� *	IsTheme+# [ �� $��60��$��60��#��[ $ 最小化窗口������ *WindowMinCommand+���� *	IsTheme+# [ ��  $��30��$��30��$ WindowMinimize=��� $��60��$��60��#��[ $ 关闭窗口������ *WindowCloseCommand+���� *	IsTheme+# [ ��  $��30��$��30��$ Close=��� $��1������ *PageContent+