exec("./skill_Grab.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");
exec("./ontouchdown.cs");

function Grab::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Grab and place or throw objects.");
Grab.setskillbaricon(%slot);
}

function Grab::onlevelload(%this)
{
echo("Grab loaded");

Grab.customplayerfields=new SimSet();

for (%x=0;%x<$numofplayers;%x++)//one ScriptObject per player, containing all custom fields for this skill
{
%fields=new ScriptObject()
{
schedulehandle=0;
grabbedobject=0;
mousecaptureobj=0;
};

Grab.customplayerfields.add(%fields);

%fields.mousecaptureobj=new SceneObject()
{
size="1 1";
Position="0 0";
Visible="false";
Active="true";
class="class_grabmousecaptureobj";
BodyType="static";
};
DotsandCritsscene.add(%fields.mousecaptureobj);

if (!%x)//player 0 casted
{
%fields.mousecaptureobj.setUseInputEvents(true);

DotsandCritswindow.addInputListener(%fields.mousecaptureobj);
scenewindow_player1.addInputListener(%fields.mousecaptureobj);
scenewindow_player2.addInputListener(%fields.mousecaptureobj);
}
else
{
$joycallbackobjlist.add(%fields.mousecaptureobj);
}

}

}

function Grab::create(%this)
{
echo("created Grab");
}

function Grab::destroy(%this)
{
echo("deleted Grab");
}

function Grab::unloadskill(%this)
{
echo("unloaded Grab");

for (%x=0;%x<$numofplayers;%x++)
{
%customfieldobj=Grab.customplayerfields.getObject(%x);
%customfieldobj.mousecaptureobj.safeDelete();
cancel(%customfieldobj.schedulehandle);
}

Grab.customplayerfields.deleteObjects();
Grab.customplayerfields.delete();

}

function Grab::transformobjects(%this,%playerindex)
{
return;
}

function movemountedobject(%playerindex)
{
%player=$players.getObject(%playerindex);

%customfieldobj=Grab.customplayerfields.getObject(%playerindex);

if (!isObject(%customfieldobj.grabbedobject)){return;}

%playerspritesize=%player.sprite.getSpriteSize();
%spritesize=%customfieldobj.grabbedobject.getSize();

%customfieldobj.grabbedobject.Position=%player.sprite.Position;

if (%player.curdir==0)//up
{
%customfieldobj.grabbedobject.Position.Y+=(%spritesize.Y/2)+(%playerspritesize.Y/2)+1;
}
else if (%player.curdir==1)//down
{
%customfieldobj.grabbedobject.Position.Y-=(%spritesize.Y/2)+(%playerspritesize.Y/2)+1;
}
else if (%player.curdir==2)//left
{
%customfieldobj.grabbedobject.Position.X-=(%spritesize.X/2)+(%playerspritesize.X/2)+1;
}
else if (%player.curdir==3)//right
{
%customfieldobj.grabbedobject.Position.X+=(%spritesize.X/2)+(%playerspritesize.X/2)+1;
}

%customfieldobj.schedulehandle=schedule(32,0,"movemountedobject",%playerindex);
}
