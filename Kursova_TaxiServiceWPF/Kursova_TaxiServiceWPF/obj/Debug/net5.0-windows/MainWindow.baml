   M S B A M L   `   `   `  ����W  SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35eDclr-namespace:System.Windows.Media.Effects;assembly=PresentationCoreSystem.Windows.Media.Effects  5   	   Q MKursova_TaxiServiceWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Kursova_TaxiServiceWPFKursova_TaxiServiceWPF 5   	   '   !Kursova_TaxiServiceWPF.MainWindow   5   	   PEffectsDclr-namespace:System.Windows.Media.Effects;assembly=PresentationCore  5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      5   	   @d2http://schemas.microsoft.com/expression/blend/2008      5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   2local$clr-namespace:Kursova_TaxiServiceWPF   5   	     � Title$  
MainWindow��5
   	   $	��720��6   $
��1080��6)    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�6.   
������  � AllowsTransparency$
 True��5   "    � 
ResizeMode$ NoResize=�5   	    � WindowState$ Normal=�6   $��Poppins)�64    J� 	AllowDrop$
 True��6I   .��5      �� -   5         ��Name$ 
mainBorder��5         BackgroundColorForMainPart#���   5       �� CornerRadius$ 20��5      ._�5   
   � 	 � ColumnDefinitions	 5      �� 5      $	��200 �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��0��5      $
��Left=�5      $	��Top=�5      $��	20 5 10 0q�5      $��30��5      
 �� Orientation$
 
Horizontal=�5       $��RightToLeft=�5!       J� Effect 5"      3   -System.Windows.Media.Effects.DropShadowEffect  5#         Color$ #183462��6/      	Direction$	 270Q�5$   /      ShadowDepth$	 0.4Q�5%   /      
BlurRadius$ 1Q�5&   /   .+�5(      �� -   5         ��Name$ btnMinimize��5(      $��0 0 10 0q�5)        IconButtonsStyle#���  5*        minimize#���  5+      5,      �� 5-      -   5        $ btnClose��5-      #��[ 5.       	 close#���  5/      
 � Tag$ IsCloseButton��51      52      �� 55      $ 	0 70 0 20��6     LightBlueForLeftMenu#���  56      $��0 80 0 0q�57       59        5:      $ #9CB6F3��6/   $	 270Q�5;   /   $ 1Q�5<   /   $ 15Q�5=   /   ._�5A      � -   5         �Name$ LeftMenuGrid��5A       � RowDefinitions 5C      �� 5D      $	��130 �6(   �� 5E      $��* �6(   .+�5I      �� $��0��6   ._�5J      �� $��1��6%   $
 
Horizontal=�5K   %   .+�5L      �� $��TaxiService��6$   ���#98B0F1$
��Bold"�5N   $   $��29(�5O   $   $��Center=�5P   $   $
��Left=�5Q   $   $
��Left=�5R   $   $��	13 0 0 20q�5S   $   5T       5W        5X      $ #6E8FEA��6/   $	 270Q�5Y   /   $	 0.4Q�5Z   /   $ 2Q�5[   /   5]      �� 5`      $��1��6   ._�5a      �� $ ��@Created by Lukianov Nazar��6    $��SemiBold"�5b       $��11(�5c         TextLightThemeColor#���  5d       $��21 1 0 0q�5e       $��Bottom=�5f       5g      5h      5i      �� 5l      $��1��6   ._�5m      �  5n      �� 5o      $��80 �6(   �� 5p      $��* �6(   .+�5t      �� $��1��6   $ 0 0 5 0��5u      
������ ._�5w       � -   5          �Name$ frameContent��5w         � NavigationUIVisibility$ Hidden=�5x       5y      5z      5{      5�      5�      5�      