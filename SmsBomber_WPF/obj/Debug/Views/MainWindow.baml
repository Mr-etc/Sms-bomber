   M S B A M L   `   `   `  ????H  DSmsBomber_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SmsBomber_WPFSmsBomber_WPF  5   	       SmsBomber_WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SmsBomber_WPF     5   	   
??????   ? Title$  Phone Bomber??5	   	   $	??550??6   $
??1000??6+    ? WindowStyle$
 None=?5
   	   $y?Visible=?6    J? OpacityMask
 ?   ? J? SnapsToDevicePixels . .??5      ? ???	#FF252526 ? RowDefinitions 5   
   ?? 5      $??30 ?6   ?? 5      $??* ?6    ? ColumnDefinitions 5   
   ?? 5      $??1* ?6   ?? 5      $??4* ?6   .+?5   
   ?? -   5           Default_border#??[  5      $??0??69   $??0??6F   $??2??6V    ?? CornerRadius$ 	0 0 10 10??6j   $??0 0 0 1q?6?   6?   ?? 5   
   $??0??6   $??1??6"    ?? Orientation$ 
Horizontal=?62   $??Right=?6K   .+?5      ?? -   5          btn_form#??[ 5      $
??Hide??6Q   ?? 5      -   5        #??[ 5      $??Close??6Q   5      ?? 5   
   $??0??6   $ 
Horizontal=?6"   $
??Left=?6;   .+?5      ?? $??5 2 0 0q?6   ???#fafafa$??Phone Bomber??6:   5      ?? 5!   
   #??[  6   $??1??69   $??0??6F   $??5q?6V   ._?5"      ?? $??1??6   $??0??6&   $ Vertical=?66   .+?5#      ?? -   5        #??[ 5#      $
??Main??6:   $??0 7 0 0q?6I   $??10 5 5 5q?6Z   6m   ?? 5$      -   5        #??[ 5$      $??Settings??6:   $??0 7 0 0q?6M   $??10 5 5 5q?6^   6q   ?? 5%      -   5        #??[ 5%      $??About??6:   $??0 7 0 0q?6J   $??10 5 5 5q?6[   6n   5&      5'      ?? 5)   
   #??[  6   $??1??69   $??1??6F   $??5q?6V   ._?5*       ? -   5          ?Name$ Pages??5*      	  ? NavigationUIVisibility$	 Hidden=?6#   $??3q?6C   5+      5-      5.      