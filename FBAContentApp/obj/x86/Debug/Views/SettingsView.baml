   M S B A M L   `   `   `  ����H  DFBAContentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FBAContentApp.ViewsFBAContentApp.Views  5      &     FBAContentApp.Views.SettingsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:FBAContentApp.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��App Settings��6      
titleLabel#��[  6'   $��1��6K   $��4��6[   $��	0,50,0,50q�6p   �� 5    
   $��Ship From Address��6     settingsLabels#��[ 6,   $��1��6T   $��2��6d   $��1��6x   �� 5"   
   -   5        $��comboCompanyAddress��5"      $��2��6^   $��3��6n   $��1��6�   $��10,20,10,20q�6�   5#      �� 5%   
   $��1��6   $��2��6%   $��2��69   .+�5&      �� -   5        $ ��txtBlockFullCompanyAddress��5&      $��WrapWithOverflow=�6:   $��Center=�6Z    Full Ship From Company Address6�   5'      �� 5)   
   $��3��6   $��2��6%   $��2��69   .+�5*      �� -   5        $��newShipFrbtn��5*      $��Add New Ship From��6)     shipFromButtons#��[ 6E   6n   �� 5+      -   5        $��editShipFrBtn��5+      $��Edit Ship From��6*   #��[ 6C   6l   �� 5,      -   5        $��deleteShipFrBtn��5,      $��Delete Ship From��6,   #��[ 6G   6p   5-      �� 52   
   $��Label Printer��6   #��[ 6)   $��1��6Q   $��2��6a   $��3��6u   �� 53   
   -   5        $��comboPrinters��53      $��2��6(   $��3��68   $��3��6L   $��10,20,10,20q�6Z   �� 56   
   $��Save File Directory��6   #��[ 6.   $��1��6V   $��2��6f   $��4��6z    � ToolTip$G AThis is the directory where box content files text will be saved.��6�   �� 57   
   -   5        $��txtSaveLocation��57      $��2��6)   $��3��69   $��4��6M   $��10,20,10,20q�6[    �� TextWrapping$ WrapWithOverflow=�6p   �� 58   
   -   5        $��	browseBtn��58        okaySaveBtns#��[ 6"   $��Browse��6`   $��3��6q   $��2��6�   $��5��6�   $	��Top=�6�   �� 5;   
   -	   5        $
��Save��5;      #��[ 6    $��1��6`   $��2��6p   $��6��6�   �� 5<   
   -
   5        $��Cancel��5<      #��[ 6"   $��3��6d   $��2��6t   $��6��6�   5>      5?      