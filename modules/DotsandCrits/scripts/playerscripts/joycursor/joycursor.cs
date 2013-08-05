if (isObject($joyobject))
{
if (isObject($joyobject.cursorgui))
{
$joyobject.cursorgui.delete();
}
if (isObject($joyobject.cursorparentgui))
{
$joyobject.cursorparentgui.delete();
}
if (isObject($joyobject.xmoveschedule))
{
cancel($joyobject.xmoveschedule.schedulehandle);
$joyobject.xmoveschedule.delete();
}
if (isObject($joyobject.ymoveschedule))
{
cancel($joyobject.ymoveschedule.schedulehandle);
$joyobject.ymoveschedule.delete();
}
$joyobject.delete();
}

$joyobject=new ScriptObject()
{
cursorgui=0;
cursorparentgui=0;
axisstate="0 0";
xmoveschedule=0;
ymoveschedule=0;
};

%scheduleobj=new ScriptObject()
{
schedulehandle="0";
};
$joyobject.xmoveschedule=%scheduleobj;
$cancellableschedules.add($joyobject.xmoveschedule);

%scheduleobj=new ScriptObject()
{
schedulehandle="0";
};
$joyobject.ymoveschedule=%scheduleobj;
$cancellableschedules.add($joyobject.ymoveschedule);

%ass=AssetDatabase.acquireAsset("DotsandCrits:image_joycursor");

%size="0 0";
if (%ass.getCellWidth()==0)
{
%size=%ass.getImageSize();
}
else
{
%size.X=%ass.getCellWidth();
%size.Y=%ass.getCellHeight();
}

$joyobject.cursorgui=new GuiSpriteCtrl()
{
Profile=gui_profile_modalless;
Position=$resolution.X/2 SPC $resolution.Y/2;
Extent=%size;
Image="DotsandCrits:image_joycursor";
HorizSizing="relative";
VertSizing="relative";
};

$joyobject.cursorparentgui=new GuiControl()
{
Profile=gui_profile_modalless;
Position="0 0";
Extent=$resolution;
HorizSizing="relative";
VertSizing="relative";
};

$joyobject.cursorparentgui.addGuiControl($joyobject.cursorgui);

Canvas.pushDialog($joyobject.cursorparentgui);

AssetDatabase.releaseAsset(%ass.getAssetId());

//$joycursor.playAnimation("DotsandCrits:anim_joycursor");

exec("./movejoycursor.cs");
exec("./bindjoystick.cs");
exec("./joycallback.cs");
exec("./stickclick.cs");
