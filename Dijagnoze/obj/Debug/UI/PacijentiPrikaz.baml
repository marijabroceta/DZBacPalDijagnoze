   M S B A M L   `   `   `  ����D  @Dijagnoze, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Dijagnoze.UIDijagnoze.UI  5   	   "    Dijagnoze.UI.PacijentiPrikaz   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Dijagnoze.UI     5   	     � Title$  PacijentiPrikaz��5   	   $	��700��6!   $	��950��6.    � WindowStartupLocation$ CenterScreen=�6:    � 
ResizeMode$ NoResize=�6_    � 	Resources 5	       �� 
TargetType   Lbl �� Property �� Value  Btn �� 
TargetType �� CornerRadius	 �� Triggers
 P� Property P� Value��%�  &	        &	 �     �� 5
   
   " ��6   .�5      ��  � ��$ 12(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��
 �����6+   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 12(�6)   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 5��6!   $��1,1,1,1q�62   
���   �
�������._�5      �� $��Center=�6/   $��Center=�6L   5      	 5      P� 5      
 �@J�IsMouseOver . . �5   "   ��  � ��
 �����6?   �� 5   "    � ��
 �����6?   5      5      5!      5"      5#      .��5%      � ��5&   
   �� 5'       �� ImageSource$ /Image/pozadina1.jpg��6    � RowDefinitions 5)   
   �� 5*      $��50 �6   �� 5+      �� 5,      $��50 �6   .+�5.   
   � $��0��6    � ColumnDefinitions 5/      �� 50      $	��100 �6#   �� 51      .+�53      �� $��0��6   $��PRETRAGA��6$   $��14(�67   $��Center=�6E   $��Center=�6`   #��[  6}   �� 54      -   5        $��
tbPretraga��54   &   $��1��6   $��30��68   $	��730��6D   6P   55      � 56   
   $��1��6    57      �� 58      $��30 �6#   �� 59      �� 5:      $��30 �6#   .+�5<      &   System.Windows.Controls.DataGrid  -   5        $��dgPacijenti��5<   '   $��1��6      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserSortColumns .   �� SelectedItem 6:   ��  �� Path$ IzabraniPacijent�   Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5>      ,  &System.Windows.Controls.DataGridColumn   Header$	 Ime��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 66   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *Ime+  5?      $ Prezime��6)   $ * 6:    6D   �� *	Prezime+  5@      $
 JMBG��6)   $ * 67    6A   �� *Jmbg+  5A      $ Adresa��6)   $ * 69    6C   �� *Adresa+  5B      $ Mesto��6)   $ * 68    6B   �� *Mesto.MestoStanovanja+  5C      $	 Pol��6)   $ 50 66    6A   �� *Pol+  5D      $ Datum smrti��6)   $ * 6>    6H   �� *
DatumSmrti+  5E      $ 	Dijagnoza��6)   $ 70 6<    6G   �� *Dijagnoza.Sifra+5G      5H      � 5I   
   $��2��6   .+�5J      �� -   5        $��btnDodaj��5J   ,   $��35��6   $��90��6!   $
��Left=�6S   $��Center=�6n   $��35,0,0,0q�6�   #��[ 6�   .��5K      ��  �� Orientation$ 
Horizontal=�6   .+�5L      �� $��/Image/add.png��6   $
��None=�64    J� RenderTransformOrigin$ -0.925,0.538&�6C   �� 5M      $��5,0,0,0q�6    $��37��61   $��20��6<   �� 6I   $�Dodaj��6M   6]   5N      5O      �� 5P      -   5        $��	btnIzmeni��5P   .   $��35��6   $��90��6"   $
��Left=�6W   $��Center=�6r   $��	130,0,0,0q�6�   #��[ 6�   .��5Q      �� $ 
Horizontal=�6   .+�5R      �� $��/Image/edit.png��6   $
��None=�65   $ -0.925,0.538&�6D   �� 5S      $��5,0,0,0q�6    $��37��61   $��20��6<   �� 6I   $�Izmeni��6M   6^   5T      5U      �� 5V      -   5        $��	btnObrisi��5V   .   $��35��6   $��90��6"   $
��Left=�6W   $��Center=�6r   $��	225,0,0,0q�6�   #��[ 6�   .��5W      �� $ 
Horizontal=�6   .+�5X      �� $��/Image/delete.png��6   $
��None=�67   $ -0.925,0.538&�6F   �� 5Y      $��5,0,0,0q�6    $��37��61   $��20��6<   �� 6I   $�Obrisi��6M   6^   5Z      5[      �� 5\      -   5        $��
btnZatvori��5\   -   $��35��6   $��90��6"   $��Right=�6X   $��Center=�6t   $��0,0,35,0q�6�   #��[ 6�   .��5]      �� $ 
Horizontal=�6   .+�5^      �� $��/Image/close.png��6   $
��None=�66   $ -0.925,0.538&�6E   �� 5_      $��5,0,0,0q�6    $��43��61   $��20��6<   $ -0.162,0.47&�6H   �� 6m   $�Zatvori��6q   6�   5`      5a      5b      5c      5d      