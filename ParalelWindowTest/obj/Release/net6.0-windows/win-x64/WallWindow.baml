   M S B A M L   `   `   `  ���� L  HParalelWindowTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ParalelWindowTestParalelWindowTest  "    ParalelWindowTest.WallWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:ParalelWindowTest     -     �Name$  
wallWindow�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � Title$ 
WallWindow��$	��480��$	��270�� � 	Resources    
fadeInAnim �� 
TargetName g� Duration �� TargetProperty g� AccelerationRatio	 W� From	
 W� To9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%�   &	        �� .��W� $ 
wallWindow��$ 00:00:00.5000D�$
 Left�$	 0.1Q�	 �� *	StartFrom+
 �� *Left+U� $ 
wallWindow��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�  $ 00:00:01��$ 1Q�.��� ����  �� ImageSource$ /nature.jpg��