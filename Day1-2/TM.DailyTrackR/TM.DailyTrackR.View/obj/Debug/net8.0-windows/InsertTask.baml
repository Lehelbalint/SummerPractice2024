   M S B A M L   `   `   `  ����N  JTM.DailyTrackR.View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TM.DailyTrackR.ViewTM.DailyTrackR.View  5   	   $    TM.DailyTrackR.View.InsertTask   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:TM.DailyTrackR.View     5   	   $��Center=�5   	   $��Center=�5	   	     � Icon$!  Resources/tracking-icon.png��5
   	    � Title$ New Activity��5   	   $	��300��6   $	��640��6+    � 	Resources 5       �� 
TargetType �� Property �� Value��%?  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$ Arial)�6+   �� 5       � ��$ 18(�6)   �� 5       � ��
 �   �6+   �� 5       � ��$ Normal"�6+   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 25��6'   5      5      .��5      � .+�5   
   � 
�������$	��230��6&   $
��Auto��63   $	��Top=�6@   $��3q�6X    � ColumnDefinitions 5      �� 5      $��* �6#   6/   �� 5      $��3* �6#   60   �� 5      $��* �6#   6/   .+�5!      �� .+�5"      �� $��	10,30,0,0q�6   Project Type6=   �� 5#      $��	10,10,0,0q�6   	Task Type6:   �� 5$      $��	10,10,0,0q�6   Description6<   �� 5%      $��	10,10,0,0q�6   Status67   �� 5&      $��	10,10,0,0q�6   Date65   5'      �� 5(      $��1��6   .+�5)      �� -   5         ��Name$ ProjectTypeCB��5)      
�������$��0,30,0,0q�6E   5*      �� 5+      -   5        $ 
TaskTypeCB��5+      $��0,5,0,0q�6/   5,      �� 5-      -   5         ��Name$ DescriptionTextBox��5-   &   $��25��6   $��0,5,0,0q�6B   .��6S   5.      �� 5/      -   5        $ StatusCB��5/      $��0,5,0,0q�6-   50      (  "System.Windows.Controls.DatePicker  51      -   5        	  Name$	 
DatePicker��51      $	��150��61   $��25��6=   $��0,5,0,0q�6I   $
��Left=�6Z   52      53      54      �� 56   
   -   5        $	��100��56   *   $��25��66   
����  �$��13(�6U   $
��Bold"�6c   
�������$��Right=�6�   $��Bottom=�6�   .��6�   Save58      59      5:      