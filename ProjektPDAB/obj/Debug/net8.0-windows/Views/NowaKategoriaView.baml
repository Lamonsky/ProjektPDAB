   M S B A M L   `   `   `  ����F  BProjektPDAB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjektPDAB.ViewsProjektPDAB.Views  5      )    #ProjektPDAB.Views.NowaKategoriaView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:ProjektPDAB.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   9� $��0��6   $��Dane ogólne��6     9� 
IsExpanded$
 True��65   .��5      �  � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $��* �6'   .+�5      �� $��Data dokumentu:��6   $��0��62   $��Center=�6B   (  "System.Windows.Controls.DatePicker  5      $��1��6   $��Center=�6{      SelectedDate 6-   ��  �� Path$ 
KiedyDodal� �� UpdateSourceTrigger$ PropertyChanged=�6{   5      5      9� 5   
   $��1��6   $��Informacje o kategorii��6    $
 True��6@   .��5      �  5      �� 5       $
��Auto �6'   �� 5!      $��* �6'   .+�5$      �� $��Nazwa:��6   $��0��6)   $��Center=�69   �� 5%      $��1��6   $��Center=�6t   ��6*   �� $ NazwaKategorii�$ PropertyChanged=�6t   5&      5'      5(      5*      