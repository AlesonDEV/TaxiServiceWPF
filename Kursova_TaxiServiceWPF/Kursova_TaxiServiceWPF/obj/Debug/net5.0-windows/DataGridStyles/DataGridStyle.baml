   M S B A M L   `   `   `  ����W  SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType �� 
ResourceId �� TypeInTargetAssembly&    System.Windows.Controls.DataGrid �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels �Name	 J� Opacity
 � Points �� Stretch �� Triggers P� Property P� Value �� 
TargetName   DataGridStyle1  TextLightThemeColor5  /System.Windows.Controls.DataGridLengthConverter �� Padding ��Name � ColumnDefinitions � RowDefinitions    SelectAllCommand!    HeadersVisibilityConverter �� 	Converter7  1System.Windows.Controls.DataGridHeadersVisibility
   All �� ConverterParameter �� RelativeSource �� AncestorTypeG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter  Name   Column ��Name �� CanContentScroll ��Name  �� ScrollableHeight! � Maximum" �� Orientation# �� ViewportHeight$ �� ViewportSize*% �� #ComputedVerticalScrollBarVisibility& � Value' �� Mode( �� ScrollableWidth) �� ViewportWidth,* �� %ComputedHorizontalScrollBarVisibility+ �� Triggers, ]� 
Conditions- �� Property. �� Value/ �� Binding0 �� Value�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %�  (��       5      $" DataGridSelectAllButtonStyle��"   )&	  �    �� 6   "  ��6{   .�5   
   ��  � �� 5      �� 5      " ��6"   .R�5      � .+�5	      �� $ Border��6$   #��� ��64   $
 True��6u   � 5
      $ Arrow��6"   
���   �$��Right=�6>   $��8,8,3,3q�6Z   $
	 0.15Q�6k   
 �   ��� ��� ��� ��� $ Uniform=�6�   $��Bottom=�6�   5       5      P� 5       �@J�IsMouseOver$
 True��69   . �5      �� $ Border��67   # � ��6K    � ��5      P� 5       � ��$
 True��67   . �5      �� $ Border��65   # � ��6I    � ��5      P� 5       � {�$ False��67   . �5      �� $ Arrow��6;    � y�$ 	Collapsed=�6N   5      5      5      5      �� 5      "    6#   .�5   
   ��  � ��
 ���� 6'   �� 5   
    � ��# �  6'   �� 5   
    � ��$ 0q�6,   �� 5    
     �@  RowDetailsVisibilityMode$ VisibleWhenSelected=�65   �� 5!   
    � ��$
 True��6:   �� 5"   
    �@��PanningMode$
 Both=�65   �� 5#   
    �@��IsFlicksEnabled$ False��63   �� 5$   
    �@  HeadersVisibility$ Column=�6.   �� 5%   
    � ��$ 0 10 0 0q�6#   �� 5&   
    �@  SelectionMode$ Single=�6*   �� 5'   
    �@  SelectionUnit$ FullRow=�6*   �� 5(   
    �@  CanUserAddRows$ false��6+   �� 5)   
    �@  CanUserDeleteRows$ false��6.   �� 5*   
    �@  CanUserResizeRows$ false��6.   �� 5+   
    �@  CanUserReorderColumns$ false��62   �� 5,   
    � ��$ 13(�6%   �� 5-   
    �@  ColumnWidth$ * 6(   �� 5.   
    �@  GridLinesVisibility$
 None=�60   �� 5/   
    �@  AutoGenerateColumns$ False��60   �� 50   
    � ��$ Hidden=�6E   �� 51   
    � ��$ Hidden=�6G   �� 53   
    � �� 54      �� 55      "   6"   .R�56      �� #��z��6   #��z��6G   #��z��6{   # z��6�   $
 True��6�   ._�57      �� $ DG_ScrollViewer��6'   $|�false��6@   ��58      �� 59   "   " ��62   .R�5:   &   �  5;   *   �� 5<   .   $
��Auto �6?   �� 5=   .   $��* �6?   �� 5>   .   $
��Auto �6?    5@   *   �� 5A   .   $
��Auto �6<   �� 5B   .   $��* �6<   �� 5C   .   $
��Auto �6<   .+�5E   *   �� #��Z 61   $|�false��6`   ��6r   C� *�� $" DataGridSelectAllButtonStyle��"   +y�6�   �� *HeadersVisibility+# Z # Z  �� "   ��6�  �� *CellsPanelHorizontalOffset+ �� "     5F   *   $! PART_ColumnHeadersPresenter��6I   $��1��6n   y�6~   �� *HeadersVisibility+# Z # Z  �� "   �� 5G   *   $! PART_ScrollContentPresenter��6A   $��2��6f   # z��6z   $��1��6�   �� 5H   *   $ PART_VerticalScrollBar��64   $��2��6T   #! z  6d   $" Vertical=�6�   $��1��6�   #$ z# 6�   #y�z% 6D  & 6�   �� *VerticalOffset+$' OneWay=� �� *TemplatedParent+6D  � 5I   *   $��1��6/   $��2��6?    5J   .   �� 5K   2   ��6C   �� **(NonFrozenColumnsViewportHorizontalOffset+ �� "   �� 5L   2   $��* �6C   .+�5N   .   �� $ PART_HorizontalScrollBar��68   $��1��6Z   #! z( 6j   $" 
Horizontal=�6�   #$ z) 6�   #y�z* 6?  & 6�   �� *HorizontalOffset+$' OneWay=� �� *TemplatedParent+6?  5O   +   5P   '   5Q   #   .��5S      �� # z 6-   5T      5U      5V      5X      + 5Y   
   ]� 5Z      , 5[      �� 5\      - �@��
IsGrouping$
. true��66   �� 5]      "- �@%�IsVirtualizingWhenGrouping$. false��6X   ./�5_      ��  � ��$ false��6B   5`      �� 5a      / 6   �� *ShowDetails+0 True6:   .a�5b      ��   �@  RowDetailsVisibilityMode$ Visible=�6=   5c      5f      5h      