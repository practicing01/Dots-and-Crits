function callskilltransform(%playerindex)
{
if (!%playerindex)
{

%moduleidlist=new SimSet();

for (%x=0;%x<$player1skillbar.getCount();%x++)
{
%skill=$player1skillbar.getObject(%x);
if (%skill.moduleid)
{
%skill.moduleid.ScopeSet.transformobjects(%playerindex);

if (%moduleidlist.getCount()==0)
{
%moduleid=new SimObject()
{
moduleid=%skill.moduleid;
};
%moduleidlist.add(%moduleid);
continue;
}

for (%y=0;%y<%moduleidlist.getCount();%y++)
{
if (%skill.moduleid==%moduleidlist.getObject(%y).moduleid)
{
break;
}
else if (%y==%moduleidlist.getCount()-1)
{
%moduleid=new SimObject()
{
moduleid=%skill.moduleid;
};
%moduleidlist.add(%moduleid);
}
}
}
}

%moduleidlist.deleteObjects();
%moduleidlist.delete();

}
else
{

%moduleidlist=new SimSet();

for (%x=0;%x<$player2skillbar.getCount();%x++)
{
%skill=$player2skillbar.getObject(%x);
if (%skill.moduleid)
{
%skill.moduleid.ScopeSet.transformobjects(%playerindex);

if (%moduleidlist.getCount()==0)
{
%moduleid=new SimObject()
{
moduleid=%skill.moduleid;
};
%moduleidlist.add(%moduleid);
continue;
}

for (%y=0;%y<%moduleidlist.getCount();%y++)
{
if (%skill.moduleid==%moduleidlist.getObject(%y).moduleid)
{
break;
}
else if (%y==%moduleidlist.getCount()-1)
{
%moduleid=new SimObject()
{
moduleid=%skill.moduleid;
};
%moduleidlist.add(%moduleid);
}
}
}
}

%moduleidlist.deleteObjects();
%moduleidlist.delete();


}

}
