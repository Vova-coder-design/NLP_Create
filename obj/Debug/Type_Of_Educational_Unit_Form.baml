   M S B A M L   `   `   `  ����E  ANLP_Create, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:NLP_Create
NLP_Create  5   	   .    (NLP_Create.Type_Of_Educational_Unit_Form   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:NLP_Create     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962a>design1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��14(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   ���	#FF9E9E9E  MaterialDesignFont#���  5   	    � Title$# Type_Of_Educational_Unit_Form��5   	   $	��450��6/   $	��800��6<   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $ ��dgType_Of_Educational_Unit��5      $
��Left=�65   $	��207��6P   $��
10,202,0,0q�6]   $	��Top=�6q   $	��772��6�      
IsReadOnly . ��5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   5      5      �� 5   
   -   5         ��Name$ tbNumber_Of_Type��5   �   $
��Left=�6   $��22��6-   $��
10,162,0,0q�69    �� TextWrapping$
 Wrap=�6M   $	��Top=�6�   $	��341��6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$= 7Название вида учебной единицы��6�   $��Sitka Subheading)�6,   0 ,MaterialDesignDataGridTextColumnEditingStyle#��[ 6J   J� RenderTransformOrigin$ 0.5,0.5&�6�  ��6a   �� *SelectedItem.Number_Of_Type+	 �� ElementName$ 	 dgType_Of_Educational_Unit��6�  �� 5   
   -   5        $ tbFindValue��5   �   $
��Left=�6   $��22��6-   $��	10,10,0,0q�69   $
 Wrap=�6L   $�� ��6`   $	��Top=�6h   $	��630��6�   $N HВведите значение для поиска/фильтрации��6�   $��Sitka Subheading)�6�   #��[ 6   $ 0.5,0.5&�6R  �� 5   
   -   5        
 ��Name$
 btSearch��5   r   $��
Поиск��6   $
��Left=�6!   $��	10,62,0,0q�6<   $	��Top=�6O   $��76��6g   6�   �� 5!   
   -   5        $
 btFilter��5!   s   $��Фильтр��6   $
��Left=�6"   $��	91,62,0,0q�6=   $	��Top=�6P   $��84��6h   6�   �� 5#   
   -   5        $
 btCancel��5#   t   $��Отмена��6   $
��Left=�6"   $��
180,62,0,0q�6=   $	��Top=�6Q   $��94��6i   6�   �� 5%   
   -   5        $
 btInsert��5%   x   $��Добавить��6   $
��Left=�6$   $��356,162,0,0q�6?   $	��Top=�6T   $	��100��6l   6�   �� 5'   
   -	   5        $
 btUpdate��5'   w   $��Изменить��6   $
��Left=�6$   $��461,162,0,0q�6?   $	��Top=�6T   $��99��6l   6�   �� 5)   
   -
   5        $
 btDelete��5)   v   $��Удалить��6   $
��Left=�6#   $��565,162,0,0q�6>   $	��Top=�6S   $��90��6k   6�   5+      5,      