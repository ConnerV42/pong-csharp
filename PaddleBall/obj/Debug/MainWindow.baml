   M S B A M L   `   `   `  ����E  APaddleBall, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:PaddleBall
PaddleBall  5   	       PaddleBall.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:PaddleBall     5   	   -   5          �Name$  window��5       � Title$ 
Solar Pong��6	   $	��650��6,   $	��700��69    � 
ResizeMode$ NoResize=�6E   
���   �.��5	      � .+�5
   
   �� -   5        $��myGameCanvas��5
       J� Opacity$ 1Q�6%   $��11,10,11,50.5q�61   $	��672��6H   $	��550��6T   .+�5      A� -   5        $��gameBall��5      
���   �$��30��64   $��30��6?    �� Left$	 600��6K   
 �� Top$	 300��6]   $ 1Q�6n   �� 5      -   5         ��Name$ gameRectangle��5      
���   �$	��110��6<   $ 10��6I   $	 237��6Z   $��20��6k   �� 5      -   5         ��Name$ currentScore��5      $	 236��6.   $
��Wrap=�6@   $��Current Score: 0��6T   $��30(�6l   $��	UltraBold"�6z   $��44��6�   $	��356��6�   5      �� 5   
   -   5         ��Name$ btnPause��5      $��Pause��6#   
��� ���$��20(�6G   $��	ExtraBold"�6U   $
��Left=�6l   $��148,574,0,0q�6�   $	��Top=�6�   $	��100��6�   $��30��6�   6�   �� 5   
   -   5        $ btnPlay��5      $��Play!��6"   
��� E��$��20(�6I   $��	ExtraBold"�6W   $
��Left=�6n   $��
11,574,0,0q�6�   $	��Top=�6�   $	��100��6�   $��30��6�   6�   �� 5   
   -   5        $ btnStop��5      $
��Stop��6"   
������$��20(�6N   $��	ExtraBold"�6\   $
��Left=�6s   $��285,574,0,0q�6�   $	��Top=�6�   $	��100��6�   $��30��6�   6�   �� 5   
   -	   5        $ 	highScore��5      $
��Left=�6'   $��435,575,0,0q�6B   $
��Wrap=�6W   $��HIGH SCORE: 0��6k   $��20(�6�   $��	ExtraBold"�6�   
�������$	��Top=�6�   $	��248��6�   5      5      