   M S B A M L   `   `   `  ����D  @Dijagnoze, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Dijagnoze.UIDijagnoze.UI  5   	   "    Dijagnoze.UI.DijagnozaPrikaz   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Dijagnoze.UI     5   	     � Title$  DijagnozaPrikaz��5   	   $	��600��6!   $	��900��6.    � WindowStartupLocation$ CenterScreen=�6:   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��100 �6   �� 5      �� 5      $��50 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $	��100 �6#   �� 5      .+�5      �� $��0��6   $��Pretraga��6$   $��Stretch=�67   $��Stretch=�6U   $��15(�6q   $��30��6   $��70��6�   �� 5      -   5        $��
tbPretraga��5   &   $��1��6   $��30��68   $	��700��6D   $
��Left=�6|   $��Stretch=�6�   5      � 5   
   $��1��6    5      �� 5      $��50 �6#   �� 5      �� 5      $��50 �6#   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��dgDijagnoze��5   '   $��1��6   $��Stretch=�6:   $��Stretch=�6X      AutoGenerateColumns .     CanUserAddRows .     CanUserReorderColumns .     CanUserDeleteRows .     CanUserSortColumns .  	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id dijagnoze��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6?   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *IdDijagnoze+  5!      $
 Sifra��6)   $ * 68    6B   �� *Sifra+  5"      $
 NazivD��6)   $ * 69    6C   �� *NazivD+  5#      $
 Naziv Latinski��6)   $ * 6A    6K   �� *NazivLatinski+  5$      $
 Vazi od��6)   $ * 6:    6D   �� *VaziOd+  5%      $
 	Metastaze��6)   $ * 6<    6F   �� *	Metastaze+  5&      $
 Histoloska dijagnoza��6)   $ * 6G    6Q   �� *HistoloskaDijagnoza+5(      5)      � 5*   
   $��2��6   .+�5+      �� -   5        $��
btnIzaberi��5+   )   $��	Izaberite��6   $��30��6;   $��70��6G   $��Stretch=�6R   $��Right=�6n   $��665,10,150,9.6q�6�   �� 5,      -   5        $��Zatvori��5,      $��30��6'   $��70��63   $��Stretch=�6>   $��Right=�6Z   $��763,10,52,9.6q�6w   6�   5-      5.      5/      