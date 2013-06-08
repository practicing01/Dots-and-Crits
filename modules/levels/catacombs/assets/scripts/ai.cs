//this is for player 2 ai
//can have custom ai here
function catacombs::ai(%this)//change catacombs to your module name
{
exec("./../../../../DotsandCrits/scripts/ai/ai.cs");

%schedulehandle_ai=new SimObject()
{
schedulehandle="0";
};

%schedulehandle_ai.schedulehandle=schedule(1000,0,"ai",%schedulehandle_ai,-1);

$cancellableschedules.add(%schedulehandle_ai);
}
