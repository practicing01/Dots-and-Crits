function skillslots(%playerindex,%slotindex)
{

if (!%playerindex)//player 1
{

%slot=$player1skillbar.getObject(%slotindex);
if (isObject(%slot.moduleid))
{
%slot.moduleid.ScopeSet.useskill(%playerindex,%slot);
}

}
else
{

%slot=$player2skillbar.getObject(%slotindex);
if (isObject(%slot.moduleid))
{
%slot.moduleid.ScopeSet.useskill(%playerindex,%slot);
}

}

}
