   M S B A M L   `   `   `  ����H  DFBAContentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:FBAContentApp.Views.AppWindowsFBAContentApp.Views.AppWindows  5   	   7    1FBAContentApp.Views.AppWindows.AmazonWarehouseWin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:FBAContentApp.Views.AppWindows     5   	     � Title$  Amazon Warehouse��5   	   $	��600��6"   $	��600��6/   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ 
titleLabel��5         
titleLabel#��[  6$   $��1��6H   $��4��6X   $��0��6l   $��	0,50,0,50q�6y   �� 5   
   $��Warehouse ID��6     settingsLabels#��[ 6'   $��1��6O   $��2��6_   $��1��6s   �� 5    
   -   5        $��	txtWhseID��5         compTextBox#��[ 6#   $��3��6H   $��1��6X   �� 5#   
   $��Company Name��6   #��[ 6'   $��1��6O   $��2��6_   $��2��6s   �� 5$   
   -   5        $��txtCompName��5$      #��[ 6%   $��3��6J   $��2��6Z   $��2��6n   �� 5'   
   $��Address Line��6   #��[ 6'   $��1��6O   $��2��6_   $��3��6s   �� 5(   
   -   5        $��txtAddressLine��5(      #��[ 6(   $��3��6M   $��2��6]   $��3��6q   �� 5+   
   $
��City��6   #��[ 6   $��1��6G   $��2��6W   $��4��6k   �� 5,   
   -   5        $��txtCity��5,      #��[ 6!   $��3��6F   $��2��6V   $��4��6j   �� 5/   
   $��State��6   #��[ 6    $��1��6H   $��5��6X   �� 50   
   -   5        $��
comboState��50      $��2��6%   $��5��65   $��	0,20,0,20q�6C   �� 53   
   $	��Zip��6   #��[ 6   $��3��6F   $��5��6V   $��Right=�6c   �� 54   
   -   5        $��txtZip��54      #��[ 6    $��4��6E   $��5��6U   �� 58   
   -   5         ��Name$ 
saveButton��58      $
��Save��6%     okaySaveBtns#��[ 64   $��1��6s   $��2��6�   $��6��6�   �� 59   
   -	   5        $ cancelButton��59      $��Cancel��6'   #��[ 68   $��3��6z   $��2��6�   $��6��6�   5<      5=      