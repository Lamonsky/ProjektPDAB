   M S B A M L   `   `   `  ����F  BProjektPDAB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjektPDABProjektPDAB  5   	   "    ProjektPDAB.Views.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProjektPDAB     5   	   -   5          � Title$,  &Sklep i Serwis Komputerowy Lamonski.pl��5   	   $	��900��68   $
��1600��6E    � 	Resources 5	       �� Source�� 5
   
   $" Resources/ViewResources.xaml?�6   %    .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   o� .@�5      m� $��_System��6   6*   m� 5      $��_Admin��6   .@�5      m� $��Dodaj Kategorie��6    m� Command 64   �� *DodajKategorieCommand+m� 5      $��Dodaj Sposób Płatności��6    6;   �� *DodajSposobPlatnosciCommand+m� 5      $��Generator Faktur��6    65   �� *GeneratorFakturCommand+5      m� 5      $��_Raporty��6   .@�5      m� $��Raport Faktur��6    62   �� *RaportyFakturCommand+5      5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5       $
��auto �6#   �� 5!      $��* �6#   .+�5#      �� $��0��5$      $��Operacje��5%      
����� �   CommandsTemplate#��[  5(        MainHCCStyle#��[ 5)      ��5'      �� *
Commands+5)      �� 5*      $��1��5+      $��Przestrzeń robocza��5,      
����� �  WorkspacesTemplate#��[ 5/      #��[ 50      ��5.      �� *
Workspaces+50      51      �� 55   
   $��2��6   .@�56      �� .��57      �� WSB-NLU Damian Lamonski65   58      �� 59      $��Right=�6   .��5:      �� -   5         ��Name$ 
myDateTime��5:   6   5;      5<      5?      5@      