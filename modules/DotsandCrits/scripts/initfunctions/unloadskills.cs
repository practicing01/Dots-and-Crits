function unloadskills()
{
%moduleidlist=new SimSet();

for (%x=0;%x<$player1skillbar.getCount();%x++)
{
%skill=$player1skillbar.getObject(%x);
if (%skill.moduleid)
{

if (%moduleidlist.getCount()==0)
{
%moduleid=new ScriptObject()
{
moduleid=%skill.moduleid;
};
%moduleidlist.add(%moduleid);
%skill.moduleid.ScopeSet.unloadskill();
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
%moduleid=new ScriptObject()
{
moduleid=%skill.moduleid;
};
%moduleidlist.add(%moduleid);
%skill.moduleid.ScopeSet.unloadskill();
}
}
}
}

for (%x=0;%x<$player2skillbar.getCount();%x++)
{
%skill=$player2skillbar.getObject(%x);
if (%skill.moduleid)
{

if (%moduleidlist.getCount()==0)
{
%moduleid=new ScriptObject()
{
moduleid=%skill.moduleid;
};
%moduleidlist.add(%moduleid);
%skill.moduleid.ScopeSet.unloadskill();
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
%moduleid=new ScriptObject()
{
moduleid=%skill.moduleid;
};
%moduleidlist.add(%moduleid);
%skill.moduleid.ScopeSet.unloadskill();
}
}
}
}

%moduleidlist.deleteObjects();
%moduleidlist.delete();
}
