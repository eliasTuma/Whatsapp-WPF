   M S B A M L   `   `   `  ����G  CcSharpClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:cSharpClientcSharpClient  5   	       cSharpClient.ContactsView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:cSharpClient     5   	   -   5          � Title$  Contacts��5   	   $��404.673��6   $��510.28��6+    � 
ResizeMode$ NoResize=�6Q    � WindowStartupLocation$ CenterScreen=�6g   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��39* �6   �� 5      $
��212* �6   .+�5   
   o� $��Center=�6   $��20��6,   $��
25,10,88,0q�68   $	��Top=�6L   $	��350��6d   $��0q�6p   
�������$��1��6�   .@�5      m� -   5        $��12(�5      $��Sign-Out��6%   $��25,0,0,0q�67   $��97��6a   6n   m� 5      -   5        $��12(�5      $��Add Contact��6%   $��15,0,0,0q�6:   6h   m� 5      -   5        $��12(�5      $��Remove Contact��6%   $��15,0,0,0q�6=   6k   5      �� 5   
   $
��Left=�6    �� TextAlignment$ Center=�6/   $��
10,348,0,0q�6F   $
��Wrap=�6Z   $0��*All Rights Reserved © For Mira And Daniel��6n   $	��Top=�6�   $	��482��6�   $��2��6�   �� 5   
   -   5         ��Name$ contactsListView��5      $
��Left=�6-   $	��308��6H   $��	10,35,0,0q�6U   $	��Top=�6h   $	��482��6�   $��2��6�   ��6�   �� ��5      �� 5      .R�5      �� $��1,1,1,1q�6   
�������$��1,0,0,5q�6O   $	��465��6`   ._�5      ��  �� Orientation$ Vertical=�6%   .+�5      �� $��15(�6(   $��Times New Roman)�66   $��Medium"�6S   $ Center=�6g   ��6~   �� *Name+�� 5      $��15(�6(   ��66   �� *	Message+�� 5      $
 left=�6(   ��6=   �� *Date+5      5      5      ��5!      �� 5#       �� 
TargetType" ��6   .�5$      -   5        5%      5(      5*      5+      