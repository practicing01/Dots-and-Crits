if (isObject($joycallbackobjlist))
{
for (%x=0;%x<$joycallbackobjlist.getCount();%x++)
{
%obj=$joycallbackobjlist.getObject(%x);
%obj.delete();
}
$joycallbackobjlist.delete();
}

$joycallbackobjlist=new SimSet();

function joycallback(%state,%cursorpos)//state 0=up 1=down
{

for (%x=0;%x<$joycallbackobjlist.getCount();%x++)
{

%obj=$joycallbackobjlist.getObject(%x);
//objects must have the joycallback function defined
%obj.joycallback(%state,%cursorpos);

}

}
