   M S B A M L   `   `   `  ���� E  AEisChanger, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EisChanger.ViewsEisChanger.Views      EisChanger.Views.MainView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:EisChanger.Views       � Title$  
EisChanger��$	��436��$	��800��
�������$��Mairyo)�'  !System.Windows.Shell.WindowChrome   WindowChrome      CaptionHeight# ZJ�%  System.Windows.SystemParameters"   WindowResizeBorderThickness   ResizeBorderThickness# Z .���  � ColumnDefinitions �� $	��230 ���  � RowDefinitions �� $
��Auto ��� .+��� $��0��$��1�� �� Orientation$ 
Horizontal=�$��0,5,5,0q�$��Right=�$	��Top=�$��18��$��20��.+��� $��r��   CaptionButtonStyleKey#���   $��Right=����� *CloseCommand+�� $��0��$��0��$��2��
���iii�._��  �� $
��Auto ��� .+��  �� $��30 ��� .+��� $��0������ *	IconImage+�� $��1��$��24(�
���iii�
�������
���iii�.��
EisChanger�� $��1��$��0������ *	NodeItems+���� .R�9� 
�������  ExpanderStyle1#���  ���� *Header+.���� ���� *PCs+���� .R�	�  	� 	GroupName$ pcGroup������ *Name+���� *DataContext.SelectPCCommand+	 �� RelativeSource	 �� *FindAncestor+
 �� AncestorType"
 ����� *.+����  �� 
TargetType" 	�.���  �� Property � �� �� Value Z� ��  � ��$ 40����  � ��
 �������  � �� ��  �� 
TargetType" 	�.R��  �� $��5 ��� .+��� $��0��#��z���� $��1�� �� Padding$ 10,0,0,0q�._��� $��Center=�$
��Left=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 ��ح�P�  �@d�	IsChecked$
 TrueY�. ���  � ��
 �ݠ��]� $��1��$��1��.+��� $��Bottom=�$ 
Horizontal=�$��Right=�.+��� $��	EIS起動��$
��10,4q�$��20,10q�  ButtonStyleKey#���  ���� *
EISCommand+�� $��Apply��$
��10,4q�$��20,10q�#���  ���� *ApplyCommand+�� $	��Top=�$��5q�.+��  �� �� $��20 ��� .+��� $��0��.+��� $��現在の環境���� �� ��� *CurrentNode.Header+ �� Mode$ OneWay=� �� StringFormat$ [{0}:�� �� ��� *CurrentPC.Name+$ OneWay=�$ {0}] ���� ���� *CurrentPC.ExePath+$$ 実行ファイルパス：{0}���� ���� *CurrentPC.ParamPath+$! パラメータパス：{0}���� ���� *CurrentPC.HalconVer+$ Halcon Ver：{0}���� $��1��$	��➟��$��20(�$��Center=��� $��2��.+��� $��変更環境���� �� ��� *SelectedNode.Header+$ OneWay=�$ [{0}:�� �� ��� *ChangeDestinationPC.Name+$ OneWay=��� ���� *ChangeDestinationPC.ExePath+�� ���� *ChangeDestinationPC.ParamPath+�� ���� *ChangeDestinationPC.HalconVer+�� 
�������._�� }�.  � Triggers :�  :� 
SourceName$ InputOpenButton�� :� RoutedEvent$ 
MouseEnter��.[��� .���� .��W�  �� 
TargetName$ inputBorder�� �� TargetProperty$ RenderTransform.Y�	 W� To$	 200X� g� Duration$ 0:0:0.25D�:� $ InputOpenButton��$ Button.Click��.[��� .���� .��W� $ inputBorder��$ RenderTransform.Y� W� From$	 200X�$ 0:0:0.25D�:� $ 	InputText��$ 
MouseLeave��.[��� .���� .��W� $ inputBorder��$ RenderTransform.Y�$	 200X�$ 0:0:0.25D�.+��� $��5q� �� 
IsReadOnly . " �� VerticalScrollBarVisibility$
 Auto=����� *Log+���� �� -    ��Name$ inputBorder��$��
0,-200,0,0q�z�T�   T� Y  �� ! �� ElementName$! inputBorder��._��� .+��� -   " ��Name$" 	InputText��$
 Auto=�# �� AcceptsReturn# . $
��10,5q�$��5,0,5,0q�
���   �$��1q�$	��199������ *
InputLog+�� .+��� -   $ ��Name$$ InputOpenButton��$��+��$��Right=�$��0,0,10,0q�  AddButtonStyleKey#���  ���� *CommitLogCommand+