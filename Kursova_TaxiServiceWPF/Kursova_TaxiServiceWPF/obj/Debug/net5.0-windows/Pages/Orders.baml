   M S B A M L   `   `   `  ����Q  MKursova_TaxiServiceWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Kursova_TaxiServiceWPF.UserControls#Kursova_TaxiServiceWPF.UserControls  5      )    #Kursova_TaxiServiceWPF.Pages.Orders   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @uc1clr-namespace:Kursova_TaxiServiceWPF.UserControls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5        N� Title$  	Analytics��5	       N� 
FontFamily$ Poppins)�6    � 	Resources 5         	BoolToVis��%   &	        �� 5   
   6'   5      .��5      �� -   5         ��Name$ 
mainBorder��5       �� CornerRadius$ 	0 20 20 0��5      
������ $��	20 0 20 0q�5      ._�5   
   � -   5         �Name$ mainGrid��5       � RowDefinitions 5      �� 5      $��75 �6    �� 5      $��* �6    �� 5      $��60 �6    .+�5      �� $��1��6   ._�5      �� -   5         ��Name$ EmpytNotification��5      $/��)Oh, there are not elements in datagrid...��5      $��Center=�5       $y�Visible=�5!        TextLightThemeColor#���  5"      $��18(�5#      $��Center=�5$      5%      &   System.Windows.Controls.DataGrid  5&      -   5          Name$ membersOfDataGrid��5,        DataGridStyle1#���  5&        DataGridCellStyle1	   	CellStyle#	 �  5'        DataGridColumnHeaderStyle1
   ColumnHeaderStyle#
 �  5(        listOfOrders_DataGrid   RowStyle# �  5)      $��1��5*      $��	20 0 20 0q�5-         Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ № Car��6)      
IsReadOnly$
 True��68      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6J   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6U   �� *Id+  51      $ Surname��6)   $
 True��6:   $	 140 6L    6X   �� *	Surname+  52      $ Price of km��6)   $
 True��6>   $ 80 6P    6[   �� *
PricePerKm+  53      $ Price of car��6)   $
 True��6?   $ 80 6Q    6\   �� *	CarCost+  54      $ Model��6)   $
 True��68   $	 100 6J    6W   �� *
CarModel+  55      $ Arrival time��6)   $
 True��6?   $	 160 6Q    6_   �� *ArrivalTime+  56      $ Distance��6)   $
 True��6;   $ 80 6M    6X   �� *
Distance+4  .System.Windows.Controls.DataGridTemplateColumn  58      $ 
Operations��6-   $
 True��59   -      CanUserResize$ False��5:   -   $	 100 5;   -      CellTemplate 5<      �� 5=      .R�5>   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5?   &   ��  ��Name$ DeleteButton��6-   -   5          gridRemoveButton#��[ 5@   -   .��5B   *   .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ DeleteOutline=�6@     gridButtonIcon#��[ 5C   @   5D   '   5E   #   5F      5H      5J      � 5M      $��0��6   .+�5N      �� -   5         ��Name$ actionComboBox��5N        ComboBoxStyle1#���  5O      $��	60 15 0 0q�5P      $
��Left=�5Q      $	��220��5R      .@�5S      �� $��
Qiuck Sort��6#   $��0 2 3 0q�68   �� 5T      $(��"Get taxi with minimal arrival time��6#   �� 5U      $&�� Get information about taxi by id��6#   �� 5V      $6��0Get most expensive car with minimal arrival time��6#   �� 5W      $7��1Get most expensive car with minimal price of trip��6#   �� 5X      $C��=Group taxis, where price of trip and arrivaltime are the same��6#   �� 5Y      $-��'Group taxis by models and sort in group��6#   5Z      �� 5\      -   5        $ ActionButton��5\       	 	addButton#��[	 5]      $��
285 0 0 15q�5^      $	��110��5`      .��5a      �� $ 
Horizontal=�6!   .+�5b      �� $��	Do action��6$   5c      5d      �� 5f      -   5        $ AddingButton��5f      #��[	 5g      $��
400 0 0 15q�5h      $	��110��5j      .��5k      �� $ 
Horizontal=�6!   .+�5l      �� $
��Add ��6$   5m      5n      �� 5p      -	   5        $ Back_Button��5p      #��[	 5q      $��	20 0 0 15q�5r      $��36��5s      .��5u      �� $ 
Horizontal=�6!   .+�5v      �� $
��Back��6$   5w      5x      � 5{      $	��210��6   $��30��5|      $��Bottom=�5}      $��Right=�5~      $��	0 0 35 15q�5      $��0��5�      .+�5�      �� $
��20 0q�6    $��Center=�5�       #���  5�        J� IsHitTestVisible$ False��5�        K� ZIndex$ 1��5�       $��Search here ...��61   y�5�       ��  �� ElementName$ 	txtSearch�� �� Path$ Text.IsEmpty� �� 	Converter# [  �� 5�      -
   5         ��Name$ 	txtSearch��5�       
 textBoxSearch#��[
 5�      $��Center=�5�       �� TextAlignment$
 Left=�5�      $	��210��5�        5�      $ Magnify=�6,   $��15��5�   ,   $��15��5�   ,   $��Center=�5�   ,   $��0 0 15 0q�5�   ,   #���  5�   ,   $��Right=�5�   ,   5�      5�      � 5�      $��2��6   .+�5�      �� ._�5�      �� -   5        $ NumberOfElements_ComboBox��5�      #���  5�      $��62��5�      $��28��5�      $��30 0.3 162 0q�5�      $��Right=�5�      $��13(�5�      .@�5�      �� $��12��6'   $��0 2 3 0q�5�   '   �� 5�      $��24��6'   �� 5�      $��36��6'   5�      5�      �� 5�      ._�5�      �� .+�5�      �� -   5        $ FileTextBox��5�   "     inputTextBoxForInputForm#��[ 5�   "   $	��170��5�   "   $
��Left=�5�   "   $��	20 15 0 0q�5�   "   �� 5�      -   5        $ WriteButton��5�   !   #��[	 5�   !   $��Write in file��5�   !   $	��100��5�   !   $��30��5�   !   $��200 -35 0 0q�5�   !   �� 5�      -   5        $ 
ReadButton��5�   !   #��[	 5�   !   $��Read from file��5�   !   $	��100��5�   !   $��30��5�   !   $��310 -45 0 0q�5�   !   5�      5�      �� 5�      $��Right=�6   $��1q�5�      $ 5��5�       �� Padding$	 5 4q�5�      ���#C1D4FB$��0 0 30 0q�5�      $��30��5�       J� Effect 5�      3  -System.Windows.Media.Effects.DropShadowEffect  5�          Color$  #93B0EF��6+   !   	Direction$	! 270Q�5�   +   "   ShadowDepth$	" 0.5Q�5�   +   #   
BlurRadius$# 6Q�5�   +   ._�5�      �� $ 
Horizontal=�6!   .+�5�      �� -   5        $ 	LeftArrow��5�   !     ArrowButton#��[ 5�   !   .��5�        $ ChevronLeft=�64     pagingButtonIcon#��[ 5�   4   $��0 0 0 0q�5�   4   $��8��5�   4   $��8��5�   4   5�      �� 5�      $	��0.5��6$   
�������$��3 5 2 5q�5�   $   �� 5�      -   5        $ FirstButton��5�   !     pagingButton#��[ 5�   !   ��5�   !   �� *	FirstPage+�� 5�      -   5        $ SecondButton��5�   !   #��[ 5�   !   ��5�   !   �� *
SecondPage+�� 5�      -   5        $ ThirdButton��5�   !   #��[ 5�   !   ��5�   !   �� *	ThirdPage+�� 5�      $	��0.5��6$   
�������$��3 5 2 5q�5�   $   �� 5�      -   5        $ 
RightArrow��5�   !   #��[ 5�   !   .��5�        $ ChevronRight=�64   #��[ 5�   4   $��8��5�   4   $��8��5�   4   5�      5�      5�      5�      � 5�      -   5        $��
inputPopup��5�      $ J� IsManipulationEnabled$
$ True��5�      $��False��5      % � 	StaysOpen$
% True��5     $��Mouse=�5     .��5     �� ���#A1BFFB$	��300��5     $	��540��5     $��2q�5	     ���#9CBBFB 5       5     $  #8193FB��6+   $	! 270Q�5  +   $	" 0.8Q�5  +   $# 6Q�5  +   ._�5     �� 
������ .+�5     �� -   5        $ Back_ButtonInput��5  !   #��[	 6;   $��	10 10 0 0q�5  !   $��60��5  !   $��23��5  !   .��5     �� $ 
Horizontal=�6)   .+�5  "   �� $
��Back��6,   5     5     �� 5     ._�5     �� $��
Input form��6(   $��
60 -28 0 0q�5  (   $��Center=�5   (   ���#A3CBF5$
��Bold"�5"  (   $��29(�5#  (    5$       5%  "   $  #6E8FEA��63   $	! 270Q�5&  3   $	" 0.4Q�5'  3   $# 2Q�5(  3   5*     2	   ,Kursova_TaxiServiceWPF.UserControls.uTextBox	  5,     -   5        & 	 Name$& SurnamePopUp��5,  &   ' 	  Caption$' Surname��5-  &   ( 	  Hint$$( Enter the surname of driver...��5.  &   	  50     -   5        $& PricePerKmPopUp��50  &   $' Price per kilometre��51  &   $#( Enter the price in dollars...��52  &   	  54     -   5        $& CarPricePopUp��54  &   $' Car's price��55  &   $( Enter the price of car...��56  &   	  58     -   5        $& CarModelPopUp��58  &   $' Car's model��59  &   $( Enter the model of car...��5:  &   	  5<     -   5        $& ArrivallTimePopUp��5<  &   $' Arrival time��5=  &   $"( Format - yyyy-MM-dd HH:mm:ss��5>  &   	  5@     -   5        $& DistancePopUp��5@  &   $' Distance��5A  &   $'( !Enter the approximate distance...��5B  &   �� 5D     -   5        $��Sumbit��5D  !   #��[	 5E  !   $��40��5F  !   $��0 10 0 0q�5G  !   $��Center=�5I  !   5J     5K     5L     � 5O     -   5        $��IdSearchPopUp��5O     $
$ True��5P     $��False��5Q     $
% True��6#   $��Mouse=�5R     .��5S     �� ���#A1BFFB$	��300��5T     $	��180��5U     $��2q�5V     ���#9CBBFB 5X       5Y     $  #8193FB��6+   $	! 270Q�5Z  +   $	" 0.8Q�5[  +   $# 6Q�5\  +   ._�5_     �� 
������ .+�5`     �� -   5        $ BackIdSearchButton��5`  !   #��[	 5a  !   $��	10 10 0 0q�5b  !   $��60��5c  !   $��23��5d  !   .��5f     �� $ 
Horizontal=�6)   .+�5g  "   �� $
��Back��6,   5h     5i     �� 5k     ._�5l     �� $��
Input form��6(   $��
60 -28 0 0q�5m  (   $��Center=�5n  (   ���#A3CBF5$
��Bold"�5p  (   $��29(�5q  (    5s       5t  "   $  #6E8FEA��63   $	! 270Q�5u  3   $	" 0.4Q�5v  3   $# 2Q�5w  3   5y     	  5{     -   5        $& IdSearch��5{  &   $' 	Id of car��5|  &   $( Enter the id of car...��5}  &   �� 5     -    5        $ SumbitIdPopUp��5  !   $��Sumbit��5�  !   #��[	 5�  !   $��40��5�  !   $��0 10 0 0q�5�  !   $��Center=�5�  !   5�     5�     5�     5�     5�     5�     