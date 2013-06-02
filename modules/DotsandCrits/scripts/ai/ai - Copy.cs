function ai(%schedulehandle)
{
%startcount=0;
%endcount=0;
if (!$player2activeskillbarnibble)//first nibble
{
%endcount=$player2skillbar.getCount()/2;
}
else
{
%startcount=$player2skillbar.getCount()/2;
%endcount=$player2skillbar.getCount();
}

//temporary way to go through both nibbles
$player2activeskillbarnibble=!$player2activeskillbarnibble;

for (%x=%startcount;%x<%endcount;%x++)
{
%slot=$player2skillbar.getObject(%x);

if (isObject(%slot.moduleid))
{
%slot.moduleid.ScopeSet.ai(%slot);
}

}

%schedulehandle.schedulehandle=schedule(1000,0,"ai",%schedulehandle);
}
