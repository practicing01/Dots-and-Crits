function class_Wave::onAnimationEnd(%this)
{

if (!isObject(%this))
{
return;
}

%this.Wavedecay();

}
