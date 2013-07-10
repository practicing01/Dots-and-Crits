function stickclick(%state)
{
/*
if (DotsandCritswindow.Visible)
{
DotsandCritswindow.SimulateonMouseDown($joyobject.cursorgui.Position.X,$joyobject.cursorgui.Position.Y);
}
else if (scenewindow_player2.Visible)
{
scenewindow_player2.SimulateonMouseDown($joyobject.cursorgui.Position.X,$joyobject.cursorgui.Position.Y);
}
*/
for (%x=0;%x<$joycallbackobjlist.getCount();%x++)
{

%obj=$joycallbackobjlist.getObject(%x);
//objects must have the stickclick function defined
%obj.stickclick(%state,$joyobject.cursorgui.Position);//state: 1=touch down, 0=touch up

}

}
