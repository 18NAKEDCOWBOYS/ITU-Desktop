   M S B A M L   `   `   `  ���� F  BITU-Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ITU_Desktop.ViewsITU_Desktop.Views  ?$clr-namespace:ITU_Desktop.ViewModelsITU_Desktop.ViewModels  "    ITU_Desktop.Views.FlightList   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:ITU_Desktop.Views     ;
viewmodels$clr-namespace:ITU_Desktop.ViewModels     .���   � RowDefinitions  �� $��* ��� $��70 �.+�&   System.Windows.Controls.DataGrid  -   $��
flightList��$��15(�   AlternatingRowBackground
 ��ح�   CanUserResizeRows .     SelectionMode$ Single=�   
IsReadOnly .    CanUserAddRows .     AutoGenerateColumns .  $��0��$��0������ *
FlightsObj+ �� SelectedItem �� *SelectedFlight+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Stav��1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *eventTypeObj.displayString+  $	 Čas setkání��
 �� *
meetDate+  $	 Čas odletu��
 �� *	startDate+  $	 Místo setkání��
 �� *	meetPoint+  $	 Místo odletu��
 �� *
startPoint+  $	 Pilot��
 �� *pilotObj.name+  $	 Doprovod��
 �� *escortObj.name+  $	 Počet pilotů��
 �� *registeredPilotIds.Count+  $	 Počet doprovodů��
 �� *registeredEscortIds.Count+  $	 Číslo na zákazníka��
 �� *customerPhone+  $	 Počet zákazníků��
 �� *customerCount+]� -    ]�Name$
 lolu�����#27c4c4$��1��$��0��$��-1,0,0,0q�.+���  �� Orientation$ 
Horizontal=�$��Right=�.+��� ���� *OpenAddFlightWindowCommand+.���� $ 
Horizontal=�$��Right=�$
��10,0q�.+��� $��../icons/plus.png��$��30��$��5q��� $��Přidat let��$��Center=��� ���� *RemoveFlightCommand+.���� $ 
Horizontal=�$��Right=�$
��10,0q�.+��� $��../icons/minus (1).png��$��30��$��5q��� $��Odebrat let��$��Center=��� ���� *" OpenCustomizeFlightWindowCommand+.���� $ 
Horizontal=�$��Right=�$
��10,0q�.+��� $��../icons/gear.png��$��30��$��5q��� $��Upravit let��$��Center=��� ���� *OpenAssignCrewWindowCommand+.���� $ 
Horizontal=�$��Right=�$
��10,0q�.+��� $��../icons/task.png��$��30��$��5q��� $��Přiřadit posádku��$��Center=�