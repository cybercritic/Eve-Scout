   M S B A M L   `   `   `  ����D  @eve scout, Version=0.0.2.0, Culture=neutral, PublicKeyToken=null%clr-namespace:eve_scout	eve_scout  5   	   p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls 5   	       eve_scout.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.3.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  5   	   #localclr-namespace:eve_scout  5   	   X TXceed.Wpf.Toolkit, Version=1.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   cControlsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit  5   	   -   5          �Name$  
mainWindow��5   o    � Title$ 	eve scout��5   	   $	��426��6   $
��1075��6(   $	��375��6w   .��5	      � .+�5
   
   o� -   5         o�Name$
 Menu��5
      $��21��6   $	��Top=�6)   .@�5      m� $��_File��6   .@�5      m� -   5         m�Name$ miExit��5      $��E_xit��6+   6:   5      m� 5      $��_View��6   .@�5      m� -   5        $ 	miOptions��5      $��_Options��6.    m� IsCheckable .  m� 	IsChecked . 6�   m� 5      -   5        $ miSystem��5      $��_System��6-    .  . 6}   m� 5      -   5        $ miXML��5      $
��_XML��6*    .  . 6t   m� 5      -   5        $ 	miHotlist��5      $��_Hotlist��6.    .  . 6�   5      m� 5      $��_Tools��6   .@�5      m� -   5        $ 
miStartLog��5      $��Start _logserver��6/   6I   m� 5      -	   5        $ 
miStartEve��5      $��
Start _eve��6/   6C   m� 5      -
   5        $ miClearSystem��5      $��_Clear system��62   6I   5      5      �� 5   
   $
��Auto=�6   $��10,30,10,30q�6<   .��5      � -   5         �Name$ gdMain��5      $��	10,5,10,5q�6#    � ColumnDefinitions 5      (   "eve_scout.ColumnDefinitionExtended  5      -   5          Name$ 
colOptions��5   5   $	��250 �6I     5      -   5        $ 	colSystem��5   5   $	��275 �6H     5       -   5        $ colXML��5    5   $	��250 �6E     5!      -   5        $ 
colHotlist��5!   5   $	��250 �6I     5"      $��* �65   .+�5%      �� $��0��6   $��Center=�6,   $��0,5,0,0q�6I   $��NoWrap=�6Z   $��Options��6p   $	��Top=�6   $��16(�6�   �� 5&      $��0��6   $
��Left=�6,   $��0,31,0,0q�6G   $��NoWrap=�6Y   $��	Eve path:��6o   $	��Top=�6�   $��12(�6�   $	��165��6�   -  'System.Windows.Controls.AutoCompleteBox  5'      -   5        	  Name$	 acEveFolder��5'   +   $��0��6@   $	��Top=�6P   $��	0,52,35,0q�6h   $��22��6{   
 � ToolTip$
 Type 'c' to get presets��6�   �� 5(      -   5         ��Name$ 	cbAutoLog��5(      $��0��6.   $��Auto start logserver��6>   $
��Left=�6]   $	��215��6x   $��22��6�   $	��Top=�6�   $��0,79,0,0q�6�   $��Center=�6�    d� 	IsChecked$
 TrueY�6�   �� 5)      -   5        $ 	cbAutoEve��5)      $��0��6.   $��Auto start eve��6>   $
��Left=�6W   $	��215��6r   $��22��6~   $	��Top=�6�   $��	0,101,0,0q�6�   $��Center=�6�   $
 TrueY�6�   �� 5*      -   5        $ cbPlaySound��5*      $��0��60   $��Play alarm sound��6@   $
��Left=�6[   $	��215��6v   $��22��6�   $	��Top=�6�   $��	0,123,0,0q�6�   $��Center=�6�   $
 TrueY�6�   �� 5+      -   5        $ 	cbHotlist��5+      $��0��6.   $��Only react to hotlist��6>   $
��Left=�6^   $	��215��6y   $��22��6�   $	��Top=�6�   $��	0,145,0,0q�6�   $��Center=�6�   $
 TrueY�6�   �� 5,      -   5        $ 
cbAutoSave��5,      $��0��6/   $#��Autosave local (My Documents)��6?   $
��Left=�6g   $	��215��6�   $��22��6�   $	��Top=�6�   $��	0,167,0,0q�6�   $��Center=�6�   $
 TrueY�6�   $+
 %(my documents-cybercritics-eve scout)��6�   %  Xceed.Wpf.Toolkit.IntegerUpDown  5-      -   5          Name$ udLocal��5-   %   $��0��66   $��	0,189,0,0q�6F   $
��Left=�6Y   $��58��6t   $��22��6   $	��Top=�6�   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 1000000X�6�      Minimum$ 10X�6�   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   MouseWheelActiveOnFocus .     Value$ 10X�6�   6  �� 5.      $��0��6   $��
63,189,0,0q�6,   $��22��6@   $	��Top=�6L   $
��Left=�6d   $	��152��6   $!��Check local every (seconds)��6�   �� 5/      $��0��6   $��5,0,5,20q�6,   $
��Wrap=�6>   $^��X*IMPORTANT close eve client before closing logserver. Start logserver before eve client.��6R   $��35��6�   $��Bottom=�6�   �� 50      $��0��6   $
��10,0q�6,   $��20��6:   $��Bottom=�6F    �� TextAlignment$ Right=�6a   �� 51      -   5        $1��+https://sites.google.com/site/cybercritics/?�51       .�6�   visit cybercritics53      54      �� 55      -   5         ��Name$ btEveFolder��55      $��22��6.   $��0��6:   $��0,52,5,0q�6J    J� RenderTransformOrigin$ 
2.72,0.455&�6\   $	��...��6   $
 Select eve folder��6�   $��Right=�6�   $��25��6�   $	��Top=�6�   �� 56      -   5         ��Name$ gsOne��56      $��0��6.   
����  �$��2��6P   $��Stretch=�6Z   �� 58      $��1��6   $��Center=�6,   $��0,5,0,0q�6I   $��NoWrap=�6Z   $��Current System��6p   $	��Top=�6�   $��16(�6�   &   System.Windows.Controls.DataGrid  59      -   5          Name$ 	dgMonitor��59      $��1��6.   $��	5,32,5,60q�6>   $	��230��6�      CanUserSortColumns .  6�   �� 5:      $��1��6   $	��5,0q�6,   $
��Wrap=�69   $b��\*Member list will only show players that have joined the system while you are in the system.��6M   $��55��6�   $��Bottom=�6�   �� 5;      $��1��6   
����  �$��2��6A   $��Stretch=�6K   �� 5=      $��2��6   $��Center=�6,   $��0,5,0,0q�6I   $��NoWrap=�6Z   $��XML View��6p   $	��Top=�6�   $��16(�6�   �� 5>      -   5         ��Name$ tbXML��5>      $��2��6)   $��5,32,5,5q�69   $	��285��6K   �� 5?      $��2��6   
����  �$��2��6A   $��Stretch=�6K   �� 5A      $��3��6   $��Center=�6,   $��0,5,0,0q�6I   $��NoWrap=�6Z   $��Hotlist��6p   $	��Top=�6   $��16(�6�   �� 5B      -   5        $ 	tbHotlist��5B      $��3��6-   $��	5,32,5,55q�6=    �� AcceptsReturn . $	��238��6�   �� 5C      $��3��6   $	��5,0q�6,   $
��Wrap=�69   $l��fEnter exact player name or (corpID) or [allianceID] that you wish to be alarmed about. (One per line.)��6M   $��55��6�   $��Bottom=�6�   �� 5D      $��3��6   
����  �$��2��6A   $��Stretch=�6K   5E      5F      �� 5H   
   $��22��6   $��Bottom=�6    .@�5I      �� -   5         ��Name$ sbInfo��5I      $��-��6,   $��22��68   $��Bottom=�6D   $
��Left=�6_   5J      3  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon  5L   
   -   5          Name$ myNotify��5L         
IconSource$! /Resources/eve scout xp.ico��6+      ToolTipText$  eve scout notifications...��6U   5M      5N      5O      