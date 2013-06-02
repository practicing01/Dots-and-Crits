function cancelallschedules()
{
for (%x=0;%x<$cancellableschedules.getCount();%x++)
{
cancel($cancellableschedules.getObject(%x).schedulehandle);
}
$cancellableschedules.deleteObjects();

for (%x=0;%x<$skillschedules.getCount();%x++)
{
cancel($skillschedules.getObject(%x).schedulehandle);
$skillschedules.getObject(%x).delete();
}

//after cancelling skill schedules, ready skill bars
for (%x=0;%x<8;%x++)
{
%slot=$player1skillbar.getObject(%x);
cancel(%slot.cdschedule);
readyskillslot(%slot);
%slot=$player2skillbar.getObject(%x);
cancel(%slot.cdschedule);
readyskillslot(%slot);
}

}
