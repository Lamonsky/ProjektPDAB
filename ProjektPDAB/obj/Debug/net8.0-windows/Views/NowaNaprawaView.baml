   M S B A M L   `   `   `  ����F  BProjektPDAB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjektPDAB.ViewsProjektPDAB.Views  5      '    !ProjektPDAB.Views.NowaNaprawaView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:ProjektPDAB.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   9� $��0��6   $��Dane ogólne��6     9� 
IsExpanded$
 True��65   .��5      �  � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $��* �6'   .+�5      �� $��Data dokumentu:��6   $��0��62   $��Center=�6B   (  "System.Windows.Controls.DatePicker  5      $��1��6   $��Center=�6{      SelectedDate 6-   ��  �� Path$ 
KiedyDodal� �� UpdateSourceTrigger$ PropertyChanged=�6{   5      5      9� 5    
   $��1��6   $��Informacje o naprawie��6    $
 True��6?   .��5!      �   5"      �� 5#      $
��Auto �6$   �� 5$      $
��Auto �6$   �� 5%      $
��Auto �6$   �� 5&      $
��Auto �6$    5)      �� 5*      $
��Auto �6'   �� 5+      $��* �6'   .+�5.      �� $��Data Naprawy:��6   $��0��60   $��0��6@   $��Center=�6M     5/      $��1��6   $��0��6-   $��Center=�6�    6:   �� $ DataNaprawy�$ PropertyChanged=�6�   �� 51      $��Status Naprawy:��6   $��0��62   $��1��6B   $��Center=�6O   �� 52      $��1��6   $��1��6+   $��Center=�6�   ��68   �� $ StatusNaprawyComboBox� �� Text 6k   �� $ StatusNaprawy�$ PropertyChanged=�6�   �� 54      $��Serwis:��6   $��0��6*   $��2��6:   $��Center=�6G   �� 55      $��1��6   $��2��6)   $
��Left=�6b   $��Center=�6}   ��66   �� $ ShowSerwisyCommand�.��56      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ AccountWrench=�6.   $��30��6C   $��30��6O   $��Center=�6Z   $��Center=�6u   57      �� 58      $��2��6   $��3��6,   $��Center=�6[   $��Center=�6x   ��69   �� $ SerwisNazwa�6x   �� 5:      $��Produkt:��6   $��0��6+   $��3��6;   $��Center=�6H   �� 5;      $��1��6   $��3��6)   $
��Left=�6c   $��Center=�6~   ��66   �� $ ShowProduktyCommand�.��5<        $ DesktopClassic=�6.   $��30��6D   $��30��6P   $��Center=�6[   $��Center=�6v   5=      �� 5>      $��1��6   $��4��6,   $��Center=�6\   $��Center=�6y   ��69   �� $ ProduktNazwa�6y   5?      5@      5A      5D      