   M S B A M L   `   `   `  ���� L  HParalelWindowTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ParalelWindowTestParalelWindowTest  (    "ParalelWindowTest.WallWindowChrome   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:ParalelWindowTest     0thriplehttp://thriple.codeplex.com/     -     �Name$  window�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � Title$ WallWindowChrome�� � AllowsTransparency$
 True��$	��960��$	��540�� J� RenderTransformOrigin$ 0.5,0.5&����	#FFECECEC � 	Resources    
fadeInAnim �� 
TargetName �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame	 O� KeyTime
 O� Value  setWindowAnim��%�  &	        &	 o     �� .��U� $ window��$ (UIElement.Opacity)�.\�  $	 00:00:00��$
 0Q�  $	 00:00:01��$
 1Q��� .��U� $ window��$V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�.\�  $	 00:00:00��$

 0.50Q�  $	 
00:00:00.5��$
 1Q�U� $ window��$V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�.\�  $	 00:00:00��$

 0.50Q�  $	 
00:00:00.5��$
 1Q�z�V� .~��� �� �� T� .��� ���� -   bgImage�� �� ImageSource$ /nature.jpg��.+�]� -    ]�Name$ 
ChromeDock���� -    ��Name$ zIndexTextBlock��$��ORDER��$��Center=�$��Center=�$
��Bold"�$��72(����	#FF11E00A