   M S B A M L   `   `   `  ����J  FPOS_Cafe_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:POS_Cafe_SystemPOS_Cafe_System  5          POS_Cafe_System.App   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      /localclr-namespace:POS_Cafe_System     5        �� 	Resources  5         btnStyleTransparent �� 
TargetType �� BasedOn �� Property �� Value  btnStyleCategory �� 
TargetType  tblStyle  
storyClick �� 
TargetName �� TargetProperty	 �� To	 g� Duration
 W� From	 W� To  
storyLeave  storyUp  
storyEnter  btnTemplate �� CornerRadius �� RadiusX �� RadiusY �� Color �� Triggers :� RoutedEvent��%#  &	        7��&	 �     7��7   &	 T    &	     &	 �    &	 �    &	     &	 �    7  7  7  7  7  �� 5
      " ��60   8   .�5      ��  � ��$ 45��6+   �� 5       � ��
 ���� 6/   �� 5       � ��$ 0q�64   5      �� 5      " ��6-   8   .�5      ��  � �� 5      �� 5      " ��6*   .R�5      �� 8�� .��5   "   �� #��z��6,   #���  6M   5      5      5      5      �� 5      " ��6%   .�5      ��  � ��$ Britannic Bold)�6/   �� 5        � ��$ 24(�6-   �� 5!       � ��
 �   �6/   �� 5"       � ��$ Center=�66   5#      �� 5&      $ hover��6,   .��5'      �� $" Fill.(SolidColorBrush.Color)�6!   $ 	LimeGreenX�5(   -   $	 00:00:00.01D�6<   W� 5)      $ Width�6"   $
 0X�5*   2   $	 500X�6;   $	 00:00:01D�6D   5+      �� 5-      $ hover��6,   .��5.      �� $" Fill.(SolidColorBrush.Color)�6!   $ GreenX�5/   -   $	 00:00:00.01D�68   50      �� 52      $ hover��6)   .��53      �� $" Fill.(SolidColorBrush.Color)�6!   $ GreenX�54   -   $	 00:00:00.01D�68   55      �� 57      $ hover��6,   .��58      W� $ Width�6"   $	 500X�59   2   $	 00:00:01D�6;   5:      �� 5=   
   " ��6.   .R�5>      �� $ 5��6   
��� � �$��1q�5@      
��� � �$	��2.5q�5B      }�. ._�5D      � $��75��6   .+�5E      �� $��hover��6    $��0��5F       #��z��5G       $ 25��5H       $ 25��5I       $��Center=�5J       $��Center=�5K       ��5L      �� 5M      $ Green��6.   5O      �� 5P      $��textContent��6    #��z��63   8��  $��Center=�5Q       $��Center=�6;   
�������6X   5R      5S       5T      :� 5U      $ 
MouseEnter��6   .[�5V      �� 8�� 5W      5X      :� 5Y      $ 
MouseLeave��6   .[�5Z      �� 8�� 5[      5\      :� 5]      $ Button.Click��6   .[�5^      �� 8�� 5_      5`      :� 5a      $ PreviewMouseUp��6   .[�5b      �� 8�� 5c      5d      5f      5g      5h      