   M S B A M L   `   `   `  ���� D  @eve scout, Version=0.0.2.1, Culture=neutral, PublicKeyToken=null%clr-namespace:eve_scout	eve_scout  p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls     eve_scout.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.3.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  #localclr-namespace:eve_scout  X TXceed.Wpf.Toolkit, Version=1.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  cControlsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit  -     �Name$  
mainWindow�� � Title$ 	eve scout��$	��426��$
��1075��$	��375��.��� .+�o� -    o�Name$
 Menu��$��21��$	��Top=�.@�m� $��_File��.@�m� -    m�Name$ miExit��$��E_xit��m� $��_View��.@�m� -   $ 	miOptions��$��_Options�� m� IsCheckable .  m� 	IsChecked . m� -   $ miSystem��$��_System�� .  . m� -   $ miXML��$
��_XML�� .  . m� -   $ 	miHotlist��$��_Hotlist�� .  . m� $��_Tools��.@�m� -   $ 
miStartLog��$��Start _logserver��m� -	   $ 
miStartEve��$��
Start _eve��m� -
   $ miClearSystem��$��_Clear system���� $
��Auto=�$��10,30,10,30q�.��� -    �Name$ gdMain��$��	10,5,10,5q� � ColumnDefinitions (   "eve_scout.ColumnDefinitionExtended  -     Name$ 
colOptions��$	��250 �  -   $ 	colSystem��$	��275 �  -   $ colXML��$	��250 �  -   $ 
colHotlist��$	��250 �  $��* �.+��� $��0��$��Center=�$��0,5,0,0q�$��NoWrap=�$��Options��$	��Top=�$��16(��� $��0��$
��Left=�$��0,31,0,0q�$��NoWrap=�$��	Eve path:��$	��Top=�$��12(�$	��165��-  'System.Windows.Controls.AutoCompleteBox  -   	  Name$	 acEveFolder��$��0��$	��Top=�$��	0,52,35,0q�$��22��
 � ToolTip$
 Type 'c' to get presets���� -    ��Name$ 	cbAutoLog��$��0��$��Auto start logserver��$
��Left=�$	��215��$��22��$	��Top=�$��0,79,0,0q�$��Center=� d� 	IsChecked$
 TrueY��� -   $ 	cbAutoEve��$��0��$��Auto start eve��$
��Left=�$	��215��$��22��$	��Top=�$��	0,101,0,0q�$��Center=�$
 TrueY��� -   $ cbPlaySound��$��0��$��Play alarm sound��$
��Left=�$	��215��$��22��$	��Top=�$��	0,123,0,0q�$��Center=�$
 TrueY��� -   $ 	cbHotlist��$��0��$��Only react to hotlist��$
��Left=�$	��215��$��22��$	��Top=�$��	0,145,0,0q�$��Center=�$
 TrueY��� -   $ 
cbAutoSave��$��0��$#��Autosave local (My Documents)��$
��Left=�$	��215��$��22��$	��Top=�$��	0,167,0,0q�$��Center=�$
 TrueY�$+
 %(my documents-cybercritics-eve scout)��%  Xceed.Wpf.Toolkit.IntegerUpDown  -     Name$ udLocal��$��0��$��	0,189,0,0q�$
��Left=�$��58��$��22��$	��Top=��  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 1000000X�   Minimum$ 10X��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   MouseWheelActiveOnFocus .     Value$ 10X��� $��0��$��
63,189,0,0q�$��22��$	��Top=�$
��Left=�$	��152��$!��Check local every (seconds)���� $��0��$��5,0,5,20q�$
��Wrap=�$^��X*IMPORTANT close eve client before closing logserver. Start logserver before eve client.��$��35��$��Bottom=��� $��0��$
��10,0q�$��20��$��Bottom=� �� TextAlignment$ Right=��� -   $1��+https://sites.google.com/site/cybercritics/?�.�visit cybercritics�� -    ��Name$ btEveFolder��$��22��$��0��$��0,52,5,0q� J� RenderTransformOrigin$ 
2.72,0.455&�$	��...��$
 Select eve folder��$��Right=�$��25��$	��Top=��� -    ��Name$ gsOne��$��0��
����  �$��2��$��Stretch=��� $��1��$��Center=�$��0,5,0,0q�$��NoWrap=�$��Current System��$	��Top=�$��16(�&   System.Windows.Controls.DataGrid  -     Name$ 	dgMonitor��$��1��$��	5,32,5,60q�$	��230��   CanUserSortColumns .  �� $��1��$	��5,0q�$
��Wrap=�$b��\*Member list will only show players that have joined the system while you are in the system.��$��55��$��Bottom=��� $��1��
����  �$��2��$��Stretch=��� $��2��$��Center=�$��0,5,0,0q�$��NoWrap=�$��XML View��$	��Top=�$��16(��� -    ��Name$ tbXML��$��2��$��5,32,5,5q�$	��285���� $��2��
����  �$��2��$��Stretch=��� $��3��$��Center=�$��0,5,0,0q�$��NoWrap=�$��Hotlist��$	��Top=�$��16(��� -   $ 	tbHotlist��$��3��$��	5,32,5,55q� �� AcceptsReturn . $	��238���� $��3��$	��5,0q�$
��Wrap=�$l��fEnter exact player name or (corpID) or [allianceID] that you wish to be alarmed about. (One per line.)��$��55��$��Bottom=��� $��3��
����  �$��2��$��Stretch=��� $��22��$��Bottom=�.@��� -    ��Name$ sbInfo��$��-��$��22��$��Bottom=�$
��Left=�3  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon  -     Name$ myNotify��   
IconSource$! /Resources/eve scout xp.ico��   ToolTipText$  eve scout notifications...��