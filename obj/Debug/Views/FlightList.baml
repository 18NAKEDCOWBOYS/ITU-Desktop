   M S B A M L   `   `   `  ����F  BITU-Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ITU_Desktop.ViewsITU_Desktop.Views  5      ?$clr-namespace:ITU_Desktop.ViewModelsITU_Desktop.ViewModels  5      "    ITU_Desktop.Views.FlightList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:ITU_Desktop.Views     5      ;
viewmodels$clr-namespace:ITU_Desktop.ViewModels     5      .��5
      �   � RowDefinitions  5   
   �� 5      $��* �6   �� 5      $��70 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
flightList��5      $��15(�5         AlternatingRowBackground
 ��ح�   CanUserResizeRows .     SelectionMode$ Single=�5         
IsReadOnly .    CanUserAddRows .     AutoGenerateColumns .  $��0��5      $��0��5      ��5      �� *
FlightsObj+ �� SelectedItem 5      �� *SelectedFlight+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Stav��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 63   �� *eventTypeObj.displayString+  5      $	 Čas setkání��6%   
 6:   �� *
meetDate+  5      $	 Čas odletu��6%   
 69   �� *	startDate+  5       $	 Místo setkání��6%   
 6<   �� *	meetPoint+  5!      $	 Místo odletu��6%   
 6;   �� *
startPoint+  5"      $	 Pilot��6%   
 64   �� *pilotObj.name+  5#      $	 Doprovod��6%   
 67   �� *escortObj.name+  5$      $	 Počet pilotů��6%   
 6;   �� *registeredPilotIds.Count+  5%      $	 Počet doprovodů��6%   
 6>   �� *registeredEscortIds.Count+  5&      $	 Číslo na zákazníka��6%   
 6A   �� *customerPhone+  5'      $	 Počet zákazníků��6%   
 6>   �� *customerCount+5)      ]� 5+   
   -   5         ]�Name$
 lolu��5+      ���#27c4c4$��1��67   $��0��6D   $��-1,0,0,0q�6T   .+�5,      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5-      �� ��6   �� *OpenAddFlightWindowCommand+.��5.      �� $ 
Horizontal=�6!   $��Right=�6:   $
��10,0q�6V   .+�5/      �� $��../icons/plus.png��6    $��30��6<   $��5q�6K   6X   �� 50      $��Přidat let��6$   $��Center=�66   6S   51      52      �� 53      ��6   �� *RemoveFlightCommand+.��54      �� $ 
Horizontal=�6!   $��Right=�6:   $
��10,0q�6V   .+�55      �� $��../icons/minus (1).png��6    $��30��6A   $��5q�6P   6]   �� 56      $��Odebrat let��6$   $��Center=�67   6T   57      58      �� 59      ��6   �� *" OpenCustomizeFlightWindowCommand+.��5:      �� $ 
Horizontal=�6!   $��Right=�6:   $
��10,0q�6V   .+�5;      �� $��../icons/gear.png��6    $��30��6<   $��5q�6K   6X   �� 5<      $��Upravit let��6$   $��Center=�67   6T   5=      5>      �� 5?      ��6   �� *OpenAssignCrewWindowCommand+.��5@      �� $ 
Horizontal=�6!   $��Right=�6:   $
��10,0q�6V   .+�5A      �� $��../icons/task.png��6    $��30��6<   $��5q�6K   6X   �� 5B      $��Přiřadit posádku��6$   $��Center=�6<   6Y   5C      5D      5E      5F      5H      5I      