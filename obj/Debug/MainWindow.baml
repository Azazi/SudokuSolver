   M S B A M L   `   `   `  ����A  =Sudoku, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Sudoku.ViewSudoku.View  5   	       Sudoku.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4customControlsclr-namespace:Sudoku.View     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ Sudoku��5   	   $	��350��6   $	��430��6%   .��5      � .+�5   
      Sudoku.View.SBoardControl  -   5          Name$ boardControl��5   '   $
��Left=�5	   '   $��Center=�5
   '   $��11.75,0,0,0q�5   '   �� 5   
   -   5        $��loadGameButton��5      $��	Load Game��5      $
��Left=�5      $��
324,11,0,0q�5      $	��Top=�5      $��88��5       J� RenderTransformOrigin$ 0.531,1.599&�5      5      �� 5   
   -   5        $��solveGameButton��5      $��
Solve Game��5      $
��Left=�5      $��
324,36,0,0q�5      $	��Top=�5      $��88��5      5      �� 5   
   -   5        $��clearBoardButton��5      $��Clear Board��5      $
��Left=�5       $��324,290,0,0q�5!      $	��Top=�5"      $��88��5#      5$      �� 5&   
   -   5        $��statusLabel��5&      $�� ��5'      $
��Left=�5(      $��
324,61,0,0q�5)      $	��Top=�5*      $��88��5+      $��30��5,      $��Center=�5-      $��Center=�5.      50      51      