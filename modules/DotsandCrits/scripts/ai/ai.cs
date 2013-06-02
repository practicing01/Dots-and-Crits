function ai(%schedulehandle,%skillindex)
{
%curskillindex=0;

if (%skillindex<7)
{
%curskillindex=%skillindex+1;
}

if (%curskillindex<4)
{
$player2activeskillbarnibble=0;
}
else if (%curskillindex>=4)
{
$player2activeskillbarnibble=1;
}

%slot=$player2skillbar.getObject(%curskillindex);

if (isObject(%slot.moduleid))
{
%slot.moduleid.ScopeSet.ai(%slot);
}

%schedulehandle.schedulehandle=schedule(250,0,"ai",%schedulehandle,%curskillindex);
}
