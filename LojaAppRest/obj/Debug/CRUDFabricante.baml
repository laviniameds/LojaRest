   M S B A M L   `   `   `  ����F  BLojaAppRest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:LojaAppRestLojaAppRest  5   	        LojaAppRest.CRUDFabricante   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:LojaAppRest     5   	     � Title$  CRUDFabricante��5   	   $	��350��6    $��345.8��6-   .��5	      � .+�5
   
   �� -   5         ��Name$ txtId��5
      $
��Left=�6!   $��23��6<   $��	10,10,0,0q�6H    �� TextWrapping$
 Wrap=�6[   $��Id��6o   $	��Top=�6y   $	��120��6�   �� 5   
   -   5        $ txtDesc��5      $
��Left=�6#   $��23��6>   $��
135,10,0,0q�6J   $
 Wrap=�6^   $��Descrição��6r   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ 	btnSelect��5      $��Select��6$   $
��Left=�65   $��	10,38,0,0q�6P   $	��Top=�6c   $��75��6{   6�   �� 5   
   -   5        $ 	btnInsert��5      $��Insert��6$   $
��Left=�65   $��	90,38,0,0q�6P   $	��Top=�6c   $��75��6{   6�   �� 5   
   -   5        $ 	btnUpdate��5      $��Update��6$   $
��Left=�65   $��
170,38,0,0q�6P   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $ 	btnDelete��5      $��Delete��6$   $
��Left=�65   $��
250,38,0,0q�6P   $	��Top=�6d   $��75��6|   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%   $��	10,76,0,0q�6@   $	��Top=�6S   $	��221��6k   $	��315��6x      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6<   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+6<     5      $ 	Descricao��6C    6%   �� *	Descricao+6C   5      5      5      