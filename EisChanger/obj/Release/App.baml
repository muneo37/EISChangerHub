   M S B A M L   `   `   `  ���� E  AEisChanger, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null'clr-namespace:EisChanger
EisChanger      EisChanger.App   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     *localclr-namespace:EisChanger       �� 	Resources     CaptionButtonStyleKey �� 
TargetType �� Property �� Value'  !System.Windows.Shell.WindowChrome �� 
TargetType ��Name J� SnapsToDevicePixels J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   Opacity'  !System.Windows.VisualStateManager	   VisualStateGroups%  System.Windows.VisualStateGroup
   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value ��Name  ButtonStyleKey �� Triggers P� Property P� Value  AddButtonStyleKey � RowDefinitions �� Binding �� Value $  Expander.MouseOver.Circle.Stroke �� Color " Expander.MouseOver.Circle.Fill # Expander.MouseOver.Arrow.Stroke " Expander.Pressed.Circle.Stroke   Expander.Pressed.Circle.Fill ! Expander.Pressed.Arrow.Stroke #	 Expander.Disabled.Circle.Stroke !
 Expander.Disabled.Circle.Fill " Expander.Disabled.Arrow.Stroke  Expander.Static.Circle.Fill ! Expander.Static.Circle.Stroke   Expander.Static.Arrow.Stroke  ExpanderRightHeaderStyle �� Padding � LayoutTransform �� Angle A�Name F�Name �� Triggers  �� 
TargetName  ExpanderUpHeaderStyle! � ColumnDefinitions  ExpanderLeftHeaderStyle  ExpanderHeaderFocusVisual" �� StrokeDashArray  ExpanderDownHeaderStyle  ExpanderStyle1# �� CornerRadius$ d�Name% � FocusVisualStyle& d� 	IsChecked' �� Mode( �� RelativeSource��%.  &	        &	 2    &	     &	 �    &	 	    &	 )	    &	 9	    &	 P	    &	 g	    &		 |	    &	
 �	    &	 �	    &	 �	    &	 �	    &	 �	    &	 �	    7  7  7  7  7  7  7  7  7  7 	 7 
 7  &	 �    7  7  7  7  7  7  7  7  7  7 	 7 
 7  &	 �    7  7  7  7  7  7  7  7  7  7 	 7 
 7  &	 l    &	 �    7  7  7  7  7  7  7  7  7  7 	 7 
 7  &	     7  7  7  7  7  �� " ��.���  �@�OverridesDefaultStyle . ��  � ��
 �iii���  � ��$ Marlett)���  � �� .  ��  � ��$ Center=���  � ��$ Center=���  � ��$ 2q���  � ��$ 1q���   �@ IsHitTestVisibleInChrome . ��  � �� �� " ��.R��� $ border��
������  .    $ 0Q�	   CommonStates��.
   
Normal��. �� .��U� $ (UIElement.Opacity)�$ border��.\�  $ 0��$	 0.6Q�  	MouseOver��. �� .��U� $ (UIElement.Opacity)�$ border��.\�  $ 0��$ 1Q�  Pressed��. �� .��U� $ (UIElement.Opacity)�$ border��.\�  $ 0��$ 1Q�U� $7 1(UIElement.Effect).(DropShadowEffect.ShadowDepth)�$ border��.\�  $ 0��$ 0Q��� $1 +(UIElement.Effect).(DropShadowEffect.Color)�$ border��.g�  $ 0��$ White��U� $3 -(UIElement.Effect).(DropShadowEffect.Opacity)�$ border��.\�  $ 0��$	 0.6Q�  Disabled��._��� $ contentPresenter��|�.  #��z��#��z��#��z����  �@�FocusVisualStyle Z� �� " ��.���  �@�OverridesDefaultStyle . ��  � ��$ Center=���  � ��$ Center=���  � ��
 �������  � ��
 �   ���  � ��
 �   ���  � ��$ 1q���  � ��$ 1q���  � ��$ 25����  � ��$ 80����  � �� �� " ��.R��� #��z��#��z��#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � ��
 �����P�  � �� . . ���  � ��
 ������� " ��.���  �@�OverridesDefaultStyle . ��  � ��$ Center=���  � ��$ Center=���  � ��
 �������  � ��
 �   ���  � ��
 �   ���  � ��$ 1q���  � ��$ 1q���  � ��$ 25����  � ��$ 25����  � �� �� " ��.R��  �� �� .+��� $��0��#��z��A� $��0��$��2��#��z���� $��0��$��2��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � ��
 �����P�  � �� . . ���  � ��
 �������  �� *InputButtonName+ inputBtnOpenName.a���  � ��$ +����  � �� �� *OpenCommand+��  �� *InputButtonName+ inputBtnCloseName.a���  � ��$	 ∧����  � �� �� *CloseCommand+�� $ Transparent���� $ Transparent���� $
 #222���� $ Transparent���� $ Transparent���� $ 	#FF003366���� $ Transparent���� $ Transparent���� $ White���� $ Transparent���� $ Transparent���� $ white���� " d�.���  � ��$ 14(���  � �� �� " d�.R��� # z��._�� 
������  .   �� $��19 ��� $��* �.+��  V� ~�X� �� $	 -90Q�.+�A� $ circle��8��  $��Center=�$��19��8�� $��Center=�$��19��F� $ arrow��"����@B `� � �D @KL � z `� 	$��Center=� .  8�� $��2��$��Center=��� $��Center=�$��0,4,0,0q�$��1����.  . $	��Top=� P�  �@d�	IsChecked$
 trueY�. ��� $  arrow�� � ��" ��@B  �D � �D @B � z  �D 	P�  �@J�IsMouseOver . . ��� $  circle��8   � ���� $  circle��8   � ���� $  arrow��8   � ��P�  � �� . . ��� $  circle��8   � ���� $  circle�� � ��$	 1.5���� $  circle��8   � ���� $  arrow��8   � ��P�  � {� .  . ��� $  circle��8 	  � ���� $  circle��8 
  � ���� $  arrow��8   � ���� " d�.���  � �� �� " d�.R��� # z��._�� 
������  .  ! �� $��19 ��� $��* �.+��  V� ~�X� �� $	 180Q�.+�A� $ circle��8��  $��Center=�$��19��8�� $��Center=�$��19��F� $ arrow��"����@B `� � �D @KL � z `� 	$��Center=� .  8�� $��2��$��Center=��� $��1��$
��Left=�$��4,0,0,0q���.  . $��Center=� P�  �@d�	IsChecked$
 trueY�. ��� $  arrow�� � ��" ��@B  �D � �D @B � z  �D 	P�  �@J�IsMouseOver . . ��� $  circle��8   � ���� $  circle��8   � ���� $  arrow��8   � ��P�  � �� . . ��� $  circle��8   � ���� $  circle�� � ��$	 1.5���� $  circle��8   � ���� $  arrow��8   � ��P�  � {� .  . ��� $  circle��8 	  � ���� $  circle��8 
  � ���� $  arrow��8   � ���� " d�.���  � �� �� " d�.R��� # z��._�� 
������  .   �� $��19 ��� $��* �.+��  V� ~�X� �� $ 90Q�.+�A� $ circle��8��  $��Center=�$��19��8�� $��Center=�$��19��F� $ arrow��"����@B `� � �D @KL � z `� 	$��Center=� .  8�� $��2��$��Center=��� $��Center=�$��0,4,0,0q�$��1����.  . $	��Top=� P�  �@d�	IsChecked$
 trueY�. ��� $  arrow�� � ��" ��@B  �D � �D @B � z  �D 	P�  �@J�IsMouseOver . . ��� $  circle��8   � ���� $  circle��8   � ���� $  arrow��8   � ��P�  � �� . . ��� $  circle��8   � ���� $  circle�� � ��$	 1.5���� $  circle��8   � ���� $  arrow��8   � ��P�  � {� .  . ��� $  circle��8 	  � ���� $  circle��8 
  � ���� $  arrow��8   � ���� .���  � �� �� .R��� ._��� $��0q� . 
���   �$��1��$	" 1 2R��� " d�.���  � �� �� " d�.R��� # z��._�� 
������  .  ! �� $��19 ��� $��* �.+�A� $ circle��8��  $��Center=�$��19��8�� $��Center=�$��19��F� $ arrow��"����@B `� � �D @KL � z `� 	$��Center=� .  8�� $��2��$��Center=��� $��1��$
��Left=�$��4,0,0,0q���.  . $��Center=� P�  �@d�	IsChecked$
 trueY�. ��� $  arrow�� � ��" ��@B  �D � �D @B � z  �D 	P�  �@J�IsMouseOver . . ��� $  circle��8   � ���� $  circle��8   � ���� $  arrow��8   � ��P�  � �� . . ��� $  circle��8   � ���� $  circle�� � ��$	 1.5���� $  circle��8   � ���� $  arrow��8   � ��P�  � {� .  . ��� $  circle��8 	  � ���� $  circle��8 
  � ���� $  arrow��8   � ���� " 9�.���  � ��# � ����  � ��
 ���� ��  � ��$ Stretch=���  � ��$ Stretch=���  � ��
 ���� ��  � ��$ 1q���  � �� �� " 9�.R��� #��z��#��z��#��z��$# 3�� . ._�]� .+�d� $$ 
HeaderSite��#��z��#��z��#��z��$	��Top=�#��z��#��z��8%   #��z��#��z��$��14(�#��z��#��z��$��1q�$��0��$��0��#��z��8�� #��z��& �� *
IsExpanded+$' TwoWay=�( �� *TemplatedParent+�� $ 
ExpandSite��$��Bottom=�|�.  #��z��#��z��$y�	Collapsed=�#��z�� P�  �@9�
IsExpanded . . ��� $  
ExpandSite�� � y�$ Visible=�P�  �@9�ExpandDirection$ Right=�. ��� $  
ExpandSite�� � ��$ Right=��� $  
HeaderSite�� � ��$
 Left=��� $  
HeaderSite��8   � ��P�  �@9�ExpandDirection$ Up=�. ��� $  
ExpandSite�� � ��$	 Top=��� $  
HeaderSite�� � ��$ Bottom=��� $  
HeaderSite��8   � ��P�  �@9�ExpandDirection$
 Left=�. ��� $  
ExpandSite�� � ��$
 Left=��� $  
HeaderSite�� � ��$ Right=��� $  
HeaderSite��8   � ��P�  � {� .  . ��� # � �� � ��