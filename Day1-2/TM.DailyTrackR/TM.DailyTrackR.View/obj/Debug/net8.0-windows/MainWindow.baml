   M S B A M L   `   `   `  ����N  JTM.DailyTrackR.View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TM.DailyTrackR.ViewTM.DailyTrackR.View  5   	   $    TM.DailyTrackR.View.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:TM.DailyTrackR.View     5   	     � Icon$!  Resources/tracking-icon.png��5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ TM Daily TrackR��5
   	   $	��450��6!   $	��800��6.    J� InputBindings 5      �� 5   
   
 �� Key$ Delete��6C    �� 	Modifiers$
 Ctrlf�6P    �� Command 6   �� *DeleteFromKeyBoardCommand+6P   �� 5   
   $ n��6:   $ Controlf�6B    6   �� *NewWindowCommand+6B   �� 5    
   $ N��6:   $ Controlf�6B    6   �� *NewWindowCommand+6B   .��5#      ]� .+�5$   
   &   System.Windows.Controls.Calendar  -   5          Name$ MainCalendar��5$   F   $	��Top=�6\   $	��197��6�      SelectedDate 6   �� *SelectedDate+	 �� Mode$	 TwoWay=�
   DisplayDate
 6t   �� *SelectedDate+$	 TwoWay=� � LayoutTransform 5%      �� 5&       �� ScaleX$	 1.3Q�6!    �� ScaleY$	 2.5Q�6.   5(      � 5)   
   
�������.+�5*      �� .@�5+      �� $��Daily��6   .��5,      �� .+�5-      ]� .+�5.      �� $��15(�6$    �� TextAlignment$
 Left=�6V   ��62   �� *ActivitiesDateText+6m   �� 5/      -   5        $��OpenWindowButton��5/   !   $��29��6_   $��Right=�6k   $��29��6�   $��0,0,80,0q�6�   ��6:   �� *NewWindowCommand+.��50      �� $��Resources\addTask.png��6$   $��30��6C   $��30��6N   $��Right=�6[   51      52      � 53      .+�54      &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridDaily��54   #      	RowHeight$ 30Q�6:   $��1q�6I   
���   �$��0,0,80,0q�6q      CanUserAddRows$ False��6�      AutoGenerateColumns$ False��6�   $
��Auto=�6�      SelectionMode$ Single=�6	  ��6�   �� *
Activities+ �� SelectedItem 6   �� *SelectedActivity+   ColumnHeaderStyle 55      �� 56   "    �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6(   .�57   &   ��  �� Property � �� �� Value �#9BC2E66C   �� 58   &    � ��
 �   �6D   �� 59   &    � ��$ 1q�6H   �� 5:   &    � ��$ 30��6?   �� 5;   *    � ��$
 Auto��6B   5<   '    � ContextMenu 5>      �� 5?   "   
����·�$��1q�6D   .@�5@   &   m� $��Create CTRL + N��6/    m� Command 6H   �� *NewWindowCommand+m� 5A   &   $��Delete CTRL + DEL��6/    6J   �� *DeleteCommand+5B   #      Columns 5D      0  *System.Windows.Controls.DataGridTextColumn  5E   "   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 65      
IsReadOnly$
 True��6@      Header$	 No.��6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6_   �� *No+  5F   "   $ 2* 65   $ Project Type��6@    6V   �� *ProjectTypeDescription+  5G   "   $ 2* 65   $ 	Task Type��6@    6S   �� *ActivityType_Id+  5H   "   $ 4* 65   $ Description��6@    6U   �� *ActivityDescription+  5I   "   $ 2* 65   $ Status��6@    6P   �� *	Status_Id+5K      5L      5M      5N      �� 5O      $��OverView��6   $��20��6(   $	��Top=�64   .��5P      �� .+�5Q      ]� .+�5R      �� $��15(�6$   $
 Left=�6V   ��62   �� *ActivitiesDateText+6m   5S      � 5T      .+�5U        -   5        $ DataGridOverView��5U   '       
IsReadOnly$
  True��6C   $ 30Q�6U   $��1q�6d   
���   �$��0,0,80,0q�6�   $ False��6�   $ False��6�   ��6�   �� *ActivitiesForAll+ 5V      �� 5W   "   "  6(   .�5X   &   ��  � �� �#9BC2E66C   �� 5Y   &    � ��
 �   �6D   �� 5Z   &    � ��$ 1q�6H   �� 5[   &    � ��$ 30��6?   �� 5\   *    � ��$
 Auto��6B   5]   '    5_        5`   "   $ * 65   $	 No.��6?    6L   �� *No+  5a   "   $ * 65   $ Project Type��6?    6U   �� *ProjectTypeDescription+  5b   "   $ 2* 65   $ Description��6@    6U   �� *ActivityDescription+  5c   "   $ * 65   $ Status��6?    6O   �� *	Status_Id+  5d   "   $ * 65   $
 User��6?    6M   �� *
UserName+5f      5g      ]� 5h      .+�5i      �� $��10q�6$   Export activity in6D   �� 5j      $��10q�6%   .+�5k      �� 
���   �$��1q�69   ! �� CornerRadius$! 5��6M   " �� Padding$" 5q�6^   ._�5l   "   �� -   5        $��	textBlock��5l   ,   $ Center=�6=   $
��Left=�6T   $��Bottom=�6o   5m        5n      -   5        $��calendar��5n   '   #   SelectionMode$# MultipleRange=�67   $y�	Collapsed=�6U   6l   5o      �� 5p      -   5        $��toggleButton��5p   4   $��	0,10,0,10q�6!   $
��📅��6H   $��20��6p   $	��Top=�6|   �� 5q      $��10q�6$   period of time.6C   �� 5r      -   5        $��30��5r   !   $��30��6,   $	��Top=�68   $
��Left=�6e   $��0,10,0,0q�6�   .��5s      �� $��Resources\SaveToFile.png��6%   $��30��6G   $��30��6R   5t      �� 5u      -	   5        $��30��5u   "   $��30��6-   $	��Top=�69   $
��Left=�6f   $��	10,10,0,0q�6�   .��5v   "   �� $��Resources\diagramm.png��6*   $��30��6J   $��30��6U   5w      5y      5z      5|      5}      5~      5      5�      