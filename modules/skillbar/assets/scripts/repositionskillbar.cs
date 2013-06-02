function repositionskillbar()
{
%extent=skillbar_p1slot0.Extent;
%halftotalextent=(%extent.X*8)/2;

if ($playerssplit)//cameras split
{
if ($splitplane)//horizontal
{

for (%x=0;%x<$player1skillbar.getCount();%x++)
{
%slot=$player1skillbar.getObject(%x);
%slot.guihandle.Position.X=(($resolution.X/2)-(%halftotalextent+1))+(%extent.X*%x);
%slot.guihandle.Position.Y=($resolution.Y/2)-(%extent.Y+1);
}

for (%x=0;%x<$player2skillbar.getCount();%x++)
{
%slot=$player2skillbar.getObject(%x);
%slot.guihandle.Position.X=(($resolution.X/2)-(%halftotalextent+1))+(%extent.X*%x);
%slot.guihandle.Position.Y=$resolution.Y-(%extent.Y+1);
}

}
}
else//cameras together
{

for (%x=0;%x<$player1skillbar.getCount();%x++)
{
%slot=$player1skillbar.getObject(%x);
%slot.guihandle.Position.X=(($resolution.X/4)-(%halftotalextent+1))+(%extent.X*%x);
%slot.guihandle.Position.Y=$resolution.Y-(%extent.Y+1);
}

for (%x=0;%x<$player2skillbar.getCount();%x++)
{
%slot=$player2skillbar.getObject(%x);
%slot.guihandle.Position.X=((($resolution.X/4)*3)-(%halftotalextent+1))+(%extent.X*%x);
%slot.guihandle.Position.Y=$resolution.Y-(%extent.Y+1);
}

}
}
