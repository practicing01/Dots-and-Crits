function bitweb::loadplayerclass(%this)
{
//the following can be level-specific for different key input behaviour
exec("./../../../../DotsandCrits/scripts/playerscripts/loadplayerclass.cs");
exec("./../../../../DotsandCrits/scripts/playerscripts/joycursor/joycursor.cs");

exec("./../../../../DotsandCrits/scripts/playerscripts/resetstats.cs");
resetstats();

%this.spawnplayers();

}
