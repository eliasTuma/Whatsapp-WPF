   M S B A M L   `   `   `  ����G  CcSharpClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:cSharpClientcSharpClient  5   	       cSharpClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:cSharpClient     5   	   -   5          � Title$  Sign In��5   	   $	��350��6   $	��525��6&    � 
ResizeMode$ NoResize=�62    � WindowStartupLocation$ CenterScreen=�6H   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��433* �6   �� 5      $	��86* �6   .+�5   
   �� $
��Left=�6    �� TextAlignment$ Center=�6/   $��	10,10,0,0q�6F   $
��Wrap=�6Y   $7��1Welcome To cSharpClient 
 Please Sign-In/Sing-Up ��6m   $	��Top=�6�   $	��497��6�   $��55��6�   $��2��6�   �� 5   
   $
��Left=�6   $ Center=�6/   $��
10,293,0,0q�6F   $
��Wrap=�6Z   $0��*All Rights Reserved © For Mira And Daniel��6n   $	��Top=�6�   $	��497��6�   $��2��6�   �� 5   
   -   5         ��Name$ signInButton��5      $��Sign-In��6'   $
��Left=�69   $��181,166,0,0q�6T   $	��Top=�6i   $��75��6�   6�   �� 5   
   $��	Username:��6   $
��Left=�6$   $��
145,88,0,0q�6?   $	��Top=�6S   �� 5   
   -   5         ��Name$ usernameText��5      $
��Left=�6(   $��23��6C   $��
216,91,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��120��6�   �� 5   
   $��	Password:��6   $
��Left=�6$   $��145,116,0,0q�6?   $	��Top=�6T   �� 5   
   -   5        $ passwordText��5      $
��Left=�6(   $��23��6C   $��216,119,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��120��6�   �� 5   
   -   5        $ signUpButton��5      $��Sign-Up��6'   $
��Left=�69   $��261,166,0,0q�6T   $	��Top=�6i   $��75��6�   6�   5      5      