   M S B A M L   `   `   `  ����D  @VisualCOM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:VisualCOM.ValueConvertVisualCOM.ValueConvert  5      /clr-namespace:VisualCOM.ViewVisualCOM.View  5      9!clr-namespace:VisualCOM.ViewModelVisualCOM.ViewModel  5          View.VisualCOM.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.63.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aaR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      2c$clr-namespace:VisualCOM.ValueConvert     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      (localclr-namespace:VisualCOM.View  5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      *vm!clr-namespace:VisualCOM.ViewModel  5      $
��1220��5      $	��740��5        � AllowsTransparency  . 
������  � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5       � 	Resources 5       �� MergedDictionaries-   'VisualCOM.ValueConvert.LeftThemeConvert   Key.   (VisualCOM.ValueConvert.RightThemeConvert2   ,VisualCOM.ValueConvert.ForgroundThemeConvert-   'VisualCOM.ValueConvert.IconThemeConvert0   *VisualCOM.ValueConvert.ToolTipThemeConvert�� 5   
    5      �� 5        5      LeftThemeConvert  6)     5      RightThemeConvert  6*     5      ForgroundThemeConvert  6.     5      IconThemeConvert  6)     5      ToolTipThemeConvert  6,   5      %    5"       � DataContext 5$      '   !VisualCOM.ViewModel.MainViewModel  5%   
   .��5'      �� -   5        
������ ._�5(   
   �  � ColumnDefinitions 5)      �� 5*      $��2* �6#   �� 5+      $��8* �6#   .+�5.      �� $��0��6   ��6%   �� *	IsTheme+  LeftThemeConvert �� 	Converter# [ ._�5/      �� $��Center=�6   	 �� Orientation$	 Vertical=�6:   .+�50      �� $��	0,35,0,35q�51      $��Center=�52       $  MaterialDesignHeadline4TextBlock#��[ 54      $��
Visual COM��55      ��53      �� *	IsTheme+  ForgroundThemeConvert# [ 55      �� 56      $	��210��57      $��75��58      $��0,5,0,0q�59      $
��Home��5;      
 � Cursor$

 Hand��5<      
������� # MaterialDesignRaisedLightButton#��[ 5>      ��5:      �� *OpenCommand+.��5?      �� $	 
Horizontal=�6%   .+�5@      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5A   !   $��30��5B   !   $��Center=�5C   !      Kind$ 	Microsoft=�5D   !   �� 5E      $��Center=�5F   !   $��16(�5G   !   $
��Home��5H   !   5I      5J      �� 5K      $��75��5L      $��0,10,0,0q�5M      $
��Uart��5O      $

 Hand��5P      
���������5N      �� *OpenCommand+.��5R      �� $	 
Horizontal=�6%   .+�5S        $��30��5T   !   $��30��5U   !   $��Center=�5V   !   $ 
SerialPort=�5W   !   �� 5X      $��Center=�5Y   !   $��16(�5Z   !   $
��Uart��5[   !   5\      5]      �� 5^      $��75��5_      $��0,10,0,0q�5`      $��Charts��5b      $

 Hand��5c      
���������5a      �� *OpenCommand+.��5e      �� $	 
Horizontal=�6%   .+�5f        $��30��5g   !   $��30��5h   !   $��Center=�5i   !   $ ChartAreasplineVariant=�5j   !   �� 5k      $��Center=�5l   !   $��16(�5m   !   $��Charts��5n   !   5o      5p      �� 5q      $��75��5r      $��0,10,0,0q�5s      $��Setting��5u      $

 Hand��5v      
���������5t      �� *OpenCommand+.��5x      �� $	 
Horizontal=�6%   .+�5y        $��30��5z   !   $��30��5{   !   $��Center=�5|   !   $	 Cog=�5}   !   �� 5~      $��Center=�5   !   $��16(�5�   !   $��Setting��5�   !   5�      5�      �� 5�      $��75��5�      $��0,10,0,0q�5�      $
��More��5�      
���������5�      �� *OpenCommand+.��5�      �� $	 
Horizontal=�6%   .+�5�        $��30��5�   !   $��30��5�   !   $��Center=�5�   !   $ Information=�5�   !   �� 5�      $��Center=�5�   !   $��16(�5�   !   $
��More��5�   !   5�      5�      5�      5�      �� 5�      $��1��6   ��6%   �� *	IsTheme+  RightThemeConvert# [ ._�5�      �  � RowDefinitions 5�      �� 5�      $
��1.5* �6(   �� 5�      $	��10* �6(   .+�5�      �� $��0��5�      $��Right=�5�      $	��Top=�5�      $	 
Horizontal=�5�      .+�5�      �� $��60��5�      $��60��5�       % !MaterialDesignFlatSecondaryButton#��[ 5�      ��5�      �� *ThemeToggleCommand+��5�      �� *	IsTheme+# [  � ToolTip 5�      �� *	IsTheme+  ToolTipThemeConvert# [ ��5�        5�   "   $��30��5�   %   $��30��5�   %    5�   %   �� *	IsTheme+  IconThemeConvert# [ 5�      �� 5�      $��60��5�      $��60��5�      #��[ 5�      $ 最小化窗口��5�      ��5�      �� *WindowMinCommand+��5�      �� *	IsTheme+# [ ��5�        5�   "   $��30��5�   %   $��30��5�   %   $ WindowMinimize=�5�   %   5�      �� 5�      $��60��5�      $��60��5�      #��[ 5�      $ 关闭窗口��5�      ��5�      �� *WindowCloseCommand+��5�      �� *	IsTheme+# [ ��5�        5�   "   $��30��5�   %   $��30��5�   %   $ Close=�5�   %   5�      5�      �� 5�      $��1��6%   ��62   �� *PageContent+5�      5�      5�      5�      5�      