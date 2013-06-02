function ScaleAssSizeVectorToCam(%ass)
{
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

if (%ass.OptimalResolution)
{
%size.X=(%size.X*$resolution.X)/%ass.OptimalResolution.X;
%size.Y=(%size.Y*$resolution.Y)/%ass.OptimalResolution.Y;
}
else{echo("Warning: OptimalResolution Asset Field Not Found.");}

%size.X=(%size.X*$camsize.X)/$resolution.X;
%size.Y=(%size.Y*$camsize.Y)/$resolution.Y;
return %size;
}

function ScalePositionVectorToCam(%vec2d)//assumes that x=0=left, y=0=top and +y=down, -y=up
{
%scaledvec2d=%vec2d;
%scaledvec2d.X-=$resolution.X/2;//offset cus cam is from -50 to 50
%scaledvec2d.Y-=$resolution.Y/2;//offset cus cam is from -31.25 to 31.25
%scaledvec2d.Y=-%scaledvec2d.Y;//flip cus -y is down and +y is up
%scaledvec2d.X=(%scaledvec2d.X*$camsize.X)/$resolution.X;
%scaledvec2d.Y=(%scaledvec2d.Y*$camsize.Y)/$resolution.Y;
return %scaledvec2d;
}

function ScaleVectorToCam(%vector)
{
%vector.X=(%vector.X*$camsize.X)/$resolution.X;
%vector.Y=(%vector.Y*$camsize.Y)/$resolution.Y;
return %vector;
}

function ScaleCamVectorToRes(%vector)
{
%vector.X=(%vector.X*$resolution.X)/$camsize.X;
%vector.Y=(%vector.Y*$resolution.Y)/$camsize.Y;
return %vector;
}
