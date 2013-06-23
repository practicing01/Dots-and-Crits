function stickclick(%state)
{

for (%x=0;%x<$joycallbackobjlist.getCount();%x++)
{

%obj=$joycallbackobjlist.getObject(%x);
//objects must have the stickclick function defined
%obj.stickclick(%state,$joyobject.cursorgui.Position);//state: 1=touch down, 0=touch up

}

}
