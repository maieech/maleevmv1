   M S B A M L   `   `   `  ����	  kr222    kr222.BookEditWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$-  'Редактирование книги��5   	   $	��400��6&   $	��400��63   .��5      � $��10q�6    � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Артикул:��6   $��0��6$   �� 5   
   -   5         ��Name$ 
txtArticle��5      $��1��6&   $��0,0,0,10q�63   �� 5   
   $��Название:��6   $��2��6%   �� 5   
   -   5        $ txtTitle��5      $��3��6$   $��0,0,0,10q�61   �� 5   
   $��	Жанр:��6   $��4��6!   �� 5   
   -   5        $ txtGenre��5      $��5��6$   $��0,0,0,10q�61   �� 5   
   $��Дата выпуска:��6   $��6��6)   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpReleaseDate��5      $��7��6,   $��0,0,0,10q�69   �� 5!   
   $��8��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5"      �� -   5         ��Name$ btnSave��5"      $��Сохранить��6&   $��80��6:   $��5q�6E   6P   �� 5#      -   5        $ 	btnCancel��5#      $��Отмена��6(   $��80��69   $��5q�6D   6O   5$      5%      5&      