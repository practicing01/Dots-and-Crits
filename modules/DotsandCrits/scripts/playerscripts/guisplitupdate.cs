//objects that want to use this function must have the handle to their attached gui named: handle_attached_gui
$guisplitobjlist=new SimSet();

function guisplitupdate(%splitstate)//0=merge, 1=split
{

for (%x=0;%x<$guisplitobjlist.getCount();%x++)
{

%obj=$guisplitobjlist.getObject(%x);

if (isObject(%obj))
{

%obj.reattachgui(%splitstate);

}
else
{
$guisplitobjlist.remove(%x);//prune
}

}

}
