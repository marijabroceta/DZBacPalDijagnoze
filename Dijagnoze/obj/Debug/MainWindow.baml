   M S B A M L   `   `   `  ����D  @Dijagnoze, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Dijagnoze	Dijagnoze  5   	       Dijagnoze.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Dijagnoze     5   	     � Title$  Glavni prozor��5   	   $	��400��6   $	��400��6,    � 
ResizeMode$ NoResize=�68    � WindowStartupLocation$ CenterScreen=�6N    � 	Resources 5	       �� 
TargetType   Btn �� Property �� Value �� 
TargetType �� CornerRadius	 �� Triggers
 P� Property P� Value��%�  &	        �� 5
   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 18(�6)   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 5��6!   $��1,1,1,1q�62   
���   �
�������._�5      �� $��Center=�6/   $��Center=�6L   5      	 5      P� 5      
 �@J�IsMouseOver . . �5   "   ��  � ��
 �����6?   �� 5   "    � ��
 �����6?   5      5      5      5      5      .��5       � ��5!   
   �� 5"       �� ImageSource$ /Image/pozadina1.jpg��6    � RowDefinitions 5$   
   �� 5%      �� 5&      .+�5(   
   �� -   5        $��Right=�5(      $	��Top=�6-   $��30��6E   $��80��6Q   $��Podesavanja��6\   $��	0,10,10,0q�6r   #��[  6�   $��12(�6�   �� 5)   
   -   5        $��btnPacijenti��5)      $��0��6   $��70��62   $	��180��6>   $��Spisak pacijenata��6J   $��Bottom=�6f   $��Center=�6�   $��0,0,0,15q�6�   #��[  6�   �� 5*   
   -   5        $��btnDijagnoze��5*      $��70��6%   $	��180��61   $��Spisak dijagnoza��6=   $	��Top=�6X   $��Center=�6p   $��0,15,0,0q�6�   $��1��6�   #��[  6�   5+      5,      