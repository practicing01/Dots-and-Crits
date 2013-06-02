function deathballvalley::loadplayerclass()
{
//the following can be level-specific for different key input behaviour
exec("./../../../../DotsandCrits/scripts/playerscripts/loadplayerclass.cs");
exec("./../../../../DotsandCrits/scripts/playerscripts/splitcamera.cs");
//exec("./../../../../DotsandCrits/scripts/playerscripts/joycursor.cs");

exec("./../../../../DotsandCrits/scripts/playerscripts/resetstats.cs");
resetstats();

//clear previous map's spawn portals, load this one's
$levelp1spawnportals.deleteObjects();
$levelp2spawnportals.deleteObjects();

for (%x=0;%x<DotsandCritsscene.getCount();%x++)
{
%obj=DotsandCritsscene.getObject(%x);

/*for (%y=0;%y<%obj.getDynamicFieldCount();%y++)
{
if (%obj.getDynamicField(%y)$="Type")
{
if (%obj.Type$="portal_spawn_p1")
{
$levelp1spawnportals.add(%obj);
}
else if (%obj.Type$="portal_spawn_p2")
{
$levelp2spawnportals.add(%obj);
}
}
}*/

if (%obj.Class$="class_portal_spawn_p1")
{
$levelp1spawnportals.add(%obj);
}
else if (%obj.Class$="class_portal_spawn_p2")
{
$levelp2spawnportals.add(%obj);
}

}

%player1=$players.getObject(0);
%player2=$players.getObject(1);

if ($levelp1spawnportals.getCount())
{
%player1.sprite.Position=$levelp1spawnportals.getObject(getRandom(0,$levelp1spawnportals.getCount()-1)).Position;
}
else{%player1.sprite.setPosition(0,0);}

if ($levelp1spawnportals.getCount())
{
%player2.sprite.Position=$levelp2spawnportals.getObject(getRandom(0,$levelp2spawnportals.getCount()-1)).Position;
}
else{%player2.sprite.setPosition(0,0);}

exec("./wincondition.cs");

}
