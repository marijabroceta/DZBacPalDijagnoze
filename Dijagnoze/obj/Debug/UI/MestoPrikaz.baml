   M S B A M L   `   `   `  ����D  @Dijagnoze, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Dijagnoze.UIDijagnoze.UI  5   	       Dijagnoze.UI.MestoPrikaz   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Dijagnoze.UI     5   	     � Title$  MestoPrikaz��5   	   $	��500��6   $	��300��6*    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6[   .��5	      � ��5
   
   �� 5       �� ImageSource$ /Image/pozadina1.jpg��6    � RowDefinitions 5   
   �� 5      �� 5      $��50 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgMesto��5       $��0��6      CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .     CanUserReorderColumns .  $��15,15,15,15q�6�   	 �� SelectedItem	 6/   �� 
 �� Path$
 IzabranoMesto�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Mesto��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *MestoStanovanja+6X   5      �� 5   
   -   5        $��1��5      $
��Left=�6   $��Center=�69   $��35��6T   $��35��6`   $��10,0,0,0q�6k   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��/Image/add.png��6   $
��None=�60   5      5      �� 5   
   -   5        $��1��5      $
��Left=�6   $��Center=�69   $��35��6T   $��35��6`   $��60,0,0,0q�6k   .��5      �� $ 
Horizontal=�6   .+�5      �� $��/Image/edit.png��6   $
��None=�61   5      5      �� 5    
   -   5        $��1��5       $��Right=�6   $��Center=�6:   $��35��6U   $��35��6a   $��0,0,10,0q�6l   .��5!      �� $ 
Horizontal=�6   .+�5"      �� $��/Image/close.png��6   $
��None=�62   5#      5$      5%      5&      