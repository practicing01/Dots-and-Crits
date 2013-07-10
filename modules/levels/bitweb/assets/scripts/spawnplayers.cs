function bitweb::spawnplayers(%this)
{

%player1=$players.getObject(0);
%player2=$players.getObject(1);

if (isObject(%player1))
{

%player1.sprite.Position=ScalePositionVectorToCam((getRandom(0,24)*50)+25+15 SPC (getRandom(0,15)*50)+25);

}

if (isObject(%player2))
{

%player2.sprite.Position=ScalePositionVectorToCam((getRandom(0,24)*50)+25+15 SPC (getRandom(0,15)*50)+25);

}

}
